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

namespace CameraTestTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            { // フォームタイトル
                StringBuilder title = new StringBuilder();
                title.Append(Application.ProductName);
                title.Append(" Ver.").Append(Application.ProductVersion);
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

#if false

            try {
                ApplySettingsToUI();

                int captureDeviceCount = 0;
                await Task.Run(() => {
                    for (int i = 0; i < 20; i++) {
                        VideoCapture vc = new VideoCapture();
                        vc.Open(i);
                        if (vc.IsOpened()) {
                            vc.Dispose();
                            captureDeviceCount++;
                        } else {
                            break;
                        }
                    }
                });
                Properties.ApplicationData.Default.CaptureDeviceCount = captureDeviceCount;

                if (captureDeviceCount == 0) {
                    throw new Exception("キャプチャデバイスがありません。");
                }
                if (Properties.Settings.Default.CaptureDeviceNo >= captureDeviceCount) {
                    Properties.Settings.Default.CaptureDeviceNo = captureDeviceCount - 1;
                }

                UpdateCaptureDeviceCount();
            }
            catch (AggregateException e) {
                StringBuilder msg = new StringBuilder();
                foreach (Exception ie in e.InnerExceptions) {
                    msg.Append(ie.Message).Append('\n');
                }
                MessageBox.Show(this, msg.ToString());
            }
            catch (Exception e) {
                MessageBox.Show(this, e.Message);
            }
#endif
        }

        private void ApplySettingsToUI()
        {
#if false
            // 収縮強度設定値をUIに反映させる。
            int contractionStrength = Properties.Settings.Default.ContractionStrength;
            labelContractionStrength.Text = contractionStrength.ToString();
            if (contractionStrength > trackBarContractionStrength.Maximum) {
                contractionStrength = trackBarContractionStrength.Maximum;
                Properties.Settings.Default.ContractionStrength = contractionStrength;
            } else if (contractionStrength < trackBarContractionStrength.Minimum) {
                contractionStrength = trackBarContractionStrength.Minimum;
                Properties.Settings.Default.ContractionStrength = contractionStrength;
            }
            trackBarContractionStrength.Value = contractionStrength;

            // 表示画像設定をUIに反映させる。
            int displayImageType = Properties.Settings.Default.DisplayImageType;
            if (displayImageType < 0) {
                displayImageType = 0;
                Properties.Settings.Default.DisplayImageType = displayImageType;
            } else if (displayImageType >= comboBoxDisplayImageType.Items.Count) {
                displayImageType = comboBoxDisplayImageType.Items.Count - 1;
                Properties.Settings.Default.DisplayImageType = displayImageType;
            }
            comboBoxDisplayImageType.SelectedIndex = displayImageType;

            // 2値化閾値設定をUIに反映させる。
            int binaryThresholdBlockSize = Properties.Settings.Default.BinaryThresholdBlockSize;
            if ((binaryThresholdBlockSize & 0x1) == 0) {
                binaryThresholdBlockSize--;
            }
            if (binaryThresholdBlockSize < 1) {
                binaryThresholdBlockSize = 1;
            } else if (binaryThresholdBlockSize > 99) {
                binaryThresholdBlockSize = 99;
            }
            trackBarBinaryThresholdBlockSize.Value = (binaryThresholdBlockSize - 1) / 2;
            labelBinaryThresholdBlockSize.Text = binaryThresholdBlockSize.ToString();

            // 対象エリア
            int targetArea = Properties.Settings.Default.TargetArea;
            if (targetArea < trackBarTargetArea.Minimum) {
                targetArea = trackBarTargetArea.Minimum;
            } else if (targetArea > trackBarTargetArea.Maximum) {
                targetArea = trackBarTargetArea.Maximum;
            }
            trackBarTargetArea.Value = targetArea;
            label1TargetArea.Text = targetArea.ToString();
#endif
        }

        /// <summary>
        /// キャプチャデバイス数の表示更新を行う。
        /// </summary>
        private void UpdateCaptureDeviceCount()
        {
#if false
            int captureDeviceCount = Properties.ApplicationData.Default.CaptureDeviceCount;
            int captureDeviceNo = Properties.Settings.Default.CaptureDeviceNo;
            labelCaptureDevice.Text = captureDeviceNo.ToString();
            if (captureDeviceNo >= 0) {
                // キャプチャデバイスあり
                menuItemMeasureStart.Enabled = true;
                menuItemMeasureStop.Enabled = true;
                buttonStartStop.Enabled = true;
            } else {
                // キャプチャデバイスなし。
                menuItemMeasureStart.Enabled = false;
                menuItemMeasureStop.Enabled = false;
                buttonStartStop.Enabled = false;
            }
#endif
        }

        /// <summary>
        /// フォームを閉じる操作を受けたときに処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormClosing(object sender, FormClosingEventArgs evt)
        {
#if false
            StopCapture();
#endif

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
            CaptureDevice.AutoExposure = (double)(numericUpDownAutoExposure.Value);
            CaptureDevice.Exposure = (double)(numericUpDownExposure.Value);
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
                using (var form = new FormSelectCamera())
                {
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        Close();
                    }
                    else
                    {
                        CaptureDevice = new VideoCapture(form.SelectedIndex);
                        Text = form.SelectedName;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
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
            buttonCapture.Enabled = true;
        }

        /// <summary>
        /// カメラ設定がクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCameraSettingClick(object sender, EventArgs e)
        {
            CaptureDevice.Settings = 1; // 設定画面表示
        }
    }
}
