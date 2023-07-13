using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using OpenCvSharp;
using System.Text.RegularExpressions;

namespace CameraTestTool
{
    /// <summary>
    /// カメラ選択画面
    /// </summary>
    /// <remarks>
    /// カメラ列挙については、多分Managementクラスから引っ張ってくるのが良いと思われる。
    /// デバイスIDが一致しているかとか、番号がどうだとかは要確認。
    /// </remarks>
    public partial class FormSelectCamera : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FormSelectCamera()
        {
            InitializeComponent();
        }

        /// <summary>
        /// キャプチャデバイス列挙を更新する
        /// </summary>
        private void UpdateCaptureDevices()
        {
            var prevSelect = string.IsNullOrEmpty(comboBoxCaptureDeviceNo.Text)
                ? string.Empty : comboBoxCaptureDeviceNo.Text;
            comboBoxCaptureDeviceNo.Items.Clear();

            try
            {
                using (var pnpEntityManager = new ManagementClass("Win32_PnPEntity"))
                {
                    var pnpEntities = pnpEntityManager.GetInstances();

                    foreach (var pnpEntity in pnpEntities)
                    {
                        var pnpClassName = pnpEntity.GetPropertyValue("PNPClass") as string;
                        if (string.IsNullOrEmpty(pnpClassName))
                        {
                            continue;
                        }
                        if (!pnpClassName.Equals("Camera"))
                        {
                            continue;
                        }

                        // Nameプロパティは、デバイスマネージャで表示名として取得されるものに相当する。
                        var name = pnpEntity.GetPropertyValue("Name") as string;
                        if (string.IsNullOrEmpty(name))
                        {
                            continue;
                        }
                        comboBoxCaptureDeviceNo.Items.Add(name);
                    }
                }
            }
            catch (Exception)
            {
                var portNames = System.IO.Ports.SerialPort.GetPortNames();
                foreach (var portName in portNames)
                {
                    comboBoxCaptureDeviceNo.Items.Add($"{portName}");
                }
            }

            if (!string.IsNullOrEmpty(prevSelect)) // 前回選択値がある？
            {
                foreach (var item in comboBoxCaptureDeviceNo.Items)
                {
                    if (item.Equals(prevSelect))
                    {
                        comboBoxCaptureDeviceNo.SelectedItem = prevSelect;
                    }
                }
            }
            if ((comboBoxCaptureDeviceNo.SelectedIndex == -1) // COMポート選択されていない？
                && (comboBoxCaptureDeviceNo.Items.Count > 0)) // 選択可能なシリアルポートがある？
            {
                comboBoxCaptureDeviceNo.SelectedIndex = 0;
            }

            buttonOK.Enabled = comboBoxCaptureDeviceNo.Items.Count > 0;
        }

        private void OnButtonOKClick(object sender, EventArgs evt)
        {
            // 設定値を反映させる。
            SelectedName = comboBoxCaptureDeviceNo.SelectedItem as string;
            SelectedIndex = comboBoxCaptureDeviceNo.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnButtonCancelClick(object sender, EventArgs e)
        {
            // フォームを閉じる。
            Close();
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            try
            {
                UpdateCaptureDevices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnButtonUpdateClick(object sender, EventArgs e)
        {
            try
            {
                UpdateCaptureDevices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public int SelectedIndex { get; set; } = -1;

        public string SelectedName { get; set; } = string.Empty;
    }
}
