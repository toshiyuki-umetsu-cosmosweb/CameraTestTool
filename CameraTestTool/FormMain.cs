using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using static System.Net.Mime.MediaTypeNames;

namespace CameraTestTool
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            { // フォームタイトル
                StringBuilder title = new StringBuilder();
                title.Append(System.Windows.Forms.Application.ProductName);
                title.Append(" Ver.").Append(System.Windows.Forms.Application.ProductVersion);
                this.Text = title.ToString();
            }
            Properties.Settings.Default.PropertyChanged
                += OnApplicationDataChanged;
        }

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (pictureBox.Image != null)
            {
                var image = pictureBox.Image;
                pictureBox.Image = null;
                image.Dispose();
            }
            if (CaptureDevice != null)
            {
                CaptureDevice.Dispose();
                CaptureDevice = null;
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// キャプチャーデバイス
        /// </summary>
        private VideoCapture CaptureDevice { get; set; } = null;

        /// <summary>
        /// ApplicationDataのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnApplicationDataChanged(object sender, PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                default:
                    // do nothing.
                    break;
            }
        }

        /// <summary>
        /// 終了メニューが選択された時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMenuItemExitClick(object sender, EventArgs evt)
        {
            Close();
        }

        /// <summary>
        /// 設定メニューが選択された時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMenuItemSettingClick(object sender, EventArgs evt)
        {
            FormSelectCamera formSetting = new FormSelectCamera();
            formSetting.Show(this);
        }

        /// <summary>
        /// フォームが最初に表示された時の処理を行う。
        /// WIN32の名残。WM_CREATEに相当する。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormLoad(object sender, EventArgs evt)
        {
        }


        /// <summary>
        /// フォームを閉じる操作を受けたときに処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormClosing(object sender, FormClosingEventArgs evt)
        {
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception e) 
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// フォームが閉じられた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormClosed(object sender, FormClosedEventArgs evt)
        {
            try
            {
                Cv2.DestroyAllWindows();
                CaptureDevice?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// 撮影設定を保存する。
        /// </summary>
        private void StoreCaptureSettings()
        {
            if (checkBoxExposureControl.Checked)
            {
                CaptureDevice.AutoExposure = (double)(numericUpDownAutoExposure.Value);
            }
            if (checkBoxExposure.Checked)
            {
                CaptureDevice.Exposure = (double)(numericUpDownExposure.Value);
            }
        }

        /// <summary>
        /// カメラから画像をキャプチャし、
        /// キャプチャした画像を処理して表示する処理を行う。
        /// </summary>
        private System.Drawing.Image CaptureProcedure()
        {
            bool isCapturing = true;
            Mat rawFrame = new Mat();
            int captureCount = 0;
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            while (isCapturing && (sw.ElapsedMilliseconds <= 120000))
            {

                if (CaptureDevice.Read(rawFrame))
                {
                    captureCount++;
                    if (captureCount >= 2) // 2枚目以降を取り出す。（1枚目は古いデータが入ってるぽい）
                    {
                        isCapturing = false;
                    }
                }
                else
                {
                    System.Threading.Thread.Yield();
                }
            }
            if (!isCapturing) // 撮影完了？
            {
                using (var ms = rawFrame.ToMemoryStream())
                {
                    return System.Drawing.Image.FromStream(ms);
                }
            }
            else
            {
                return null;
            }
        }




        /// <summary>
        /// フォームが表示されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            try
            {
                ChangeDeviceProc();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                Close();
            }
        }

        /// <summary>
        /// デバイス変更処理
        /// </summary>
        private void ChangeDeviceProc()
        {
            using (var form = new FormSelectCamera())
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    Close();
                }
                else
                {
                    try
                    {
                        CaptureDevice?.Release();
                        CaptureDevice?.Dispose();
                        CaptureDevice = null;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                    CaptureDevice = new VideoCapture(form.SelectedIndex);
                    Text = form.SelectedName;
                }
            }
        }

        /// <summary>
        /// キャプチャーボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private async void OnButtonCaptureClick(object sender, EventArgs e)
        {
            buttonCapture.Enabled = false;
            try
            {
                StoreCaptureSettings();
                var image = await Task.Run(() => CaptureProcedure());
                var prevImage = pictureBox.Image;
                pictureBox.Image = image;
                prevImage?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            buttonSave.Enabled = (pictureBox.Image != null);
            buttonCapture.Enabled = true;
        }

        /// <summary>
        /// カメラ設定がクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCameraSettingClick(object sender, EventArgs e)
        {
            CaptureDevice.Settings = 1; // 設定画面表示
        }

        /// <summary>
        /// 保存ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonSaveClick(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var image = pictureBox.Image;
                System.Drawing.Imaging.ImageFormat imageFormat;
                switch (saveFileDialog.FilterIndex)
                {
                    case 0: // ファイルフィルター0 はJPEG
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case 1: // ファイルフィルター1 はPNG
                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    default:
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                }
                image.Save(saveFileDialog.FileName, imageFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// カメラ変更ボタンがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonChangeDevieClick(object sender, EventArgs e)
        {
            try
            {
                ChangeDeviceProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
