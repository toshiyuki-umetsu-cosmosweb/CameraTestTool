namespace CameraTestTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCapture = new System.Windows.Forms.Button();
            this.groupBoxOpenCvParameter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownAutoExposure = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownExposure = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCameraSetting = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.checkBoxExposureControl = new System.Windows.Forms.CheckBox();
            this.checkBoxExposure = new System.Windows.Forms.CheckBox();
            this.buttonChangeDevice = new System.Windows.Forms.Button();
            this.groupBoxOpenCvParameter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoExposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExposure)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCapture
            // 
            this.buttonCapture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonCapture.Location = new System.Drawing.Point(61, 374);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(96, 69);
            this.buttonCapture.TabIndex = 0;
            this.buttonCapture.Text = "撮影する";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.OnButtonCaptureClick);
            // 
            // groupBoxOpenCvParameter
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxOpenCvParameter, 3);
            this.groupBoxOpenCvParameter.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxOpenCvParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOpenCvParameter.Location = new System.Drawing.Point(3, 32);
            this.groupBoxOpenCvParameter.Name = "groupBoxOpenCvParameter";
            this.groupBoxOpenCvParameter.Size = new System.Drawing.Size(213, 307);
            this.groupBoxOpenCvParameter.TabIndex = 3;
            this.groupBoxOpenCvParameter.TabStop = false;
            this.groupBoxOpenCvParameter.Text = "OpenCVパラメータ";
            this.groupBoxOpenCvParameter.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownAutoExposure, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownExposure, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxExposureControl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxExposure, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 289);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numericUpDownAutoExposure
            // 
            this.numericUpDownAutoExposure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAutoExposure.Location = new System.Drawing.Point(127, 3);
            this.numericUpDownAutoExposure.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAutoExposure.Name = "numericUpDownAutoExposure";
            this.numericUpDownAutoExposure.Size = new System.Drawing.Size(77, 19);
            this.numericUpDownAutoExposure.TabIndex = 1;
            this.numericUpDownAutoExposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownExposure
            // 
            this.numericUpDownExposure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownExposure.Location = new System.Drawing.Point(127, 28);
            this.numericUpDownExposure.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownExposure.Name = "numericUpDownExposure";
            this.numericUpDownExposure.Size = new System.Drawing.Size(77, 19);
            this.numericUpDownExposure.TabIndex = 2;
            this.numericUpDownExposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCapture, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxOpenCvParameter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCameraSetting, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonChangeDevice, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(595, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 446);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonCameraSetting
            // 
            this.buttonCameraSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCameraSetting.Location = new System.Drawing.Point(61, 345);
            this.buttonCameraSetting.Name = "buttonCameraSetting";
            this.buttonCameraSetting.Size = new System.Drawing.Size(96, 23);
            this.buttonCameraSetting.TabIndex = 4;
            this.buttonCameraSetting.Text = "カメラ設定";
            this.buttonCameraSetting.UseVisualStyleBackColor = true;
            this.buttonCameraSetting.Click += new System.EventHandler(this.OnButtonCameraSettingClick);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(595, 446);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(163, 420);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(53, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnButtonSaveClick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG形式(*.jpg)|*.jpg|PNG形式(*.png)|*.png|全てのファイル(*.*)|*.*";
            // 
            // checkBoxExposureControl
            // 
            this.checkBoxExposureControl.AutoSize = true;
            this.checkBoxExposureControl.Location = new System.Drawing.Point(3, 3);
            this.checkBoxExposureControl.Name = "checkBoxExposureControl";
            this.checkBoxExposureControl.Size = new System.Drawing.Size(118, 16);
            this.checkBoxExposureControl.TabIndex = 4;
            this.checkBoxExposureControl.Text = "AUTO_EXPOSURE";
            this.checkBoxExposureControl.UseVisualStyleBackColor = true;
            // 
            // checkBoxExposure
            // 
            this.checkBoxExposure.AutoSize = true;
            this.checkBoxExposure.Location = new System.Drawing.Point(3, 28);
            this.checkBoxExposure.Name = "checkBoxExposure";
            this.checkBoxExposure.Size = new System.Drawing.Size(83, 16);
            this.checkBoxExposure.TabIndex = 5;
            this.checkBoxExposure.Text = "EXPOSURE";
            this.checkBoxExposure.UseVisualStyleBackColor = true;
            // 
            // buttonChangeDevice
            // 
            this.buttonChangeDevice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonChangeDevice, 3);
            this.buttonChangeDevice.Location = new System.Drawing.Point(141, 3);
            this.buttonChangeDevice.Name = "buttonChangeDevice";
            this.buttonChangeDevice.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeDevice.TabIndex = 6;
            this.buttonChangeDevice.Text = "カメラを変更する";
            this.buttonChangeDevice.UseVisualStyleBackColor = true;
            this.buttonChangeDevice.Click += new System.EventHandler(this.OnButtonChangeDevieClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 446);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "メイン画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.groupBoxOpenCvParameter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoExposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExposure)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.GroupBox groupBoxOpenCvParameter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericUpDownAutoExposure;
        private System.Windows.Forms.NumericUpDown numericUpDownExposure;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonCameraSetting;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBoxExposureControl;
        private System.Windows.Forms.CheckBox checkBoxExposure;
        private System.Windows.Forms.Button buttonChangeDevice;
    }
}

