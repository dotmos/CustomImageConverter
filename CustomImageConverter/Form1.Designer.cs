namespace CustomImageConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fitImageCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.batchConvertButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.ditheringCheckBox = new System.Windows.Forms.CheckBox();
            this.scriptListBox = new System.Windows.Forms.ListBox();
            this.mainPictureBox = new PictureBoxWithInterpolationMode();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*";
            this.openImageFileDialog.FilterIndex = 4;
            this.openImageFileDialog.Title = "Select Image";
            // 
            // saveImageFileDialog
            // 
            this.saveImageFileDialog.Filter = "All files (*.*)|*.*";
            // 
            // fitImageCheckBox
            // 
            this.fitImageCheckBox.AutoSize = true;
            this.fitImageCheckBox.Location = new System.Drawing.Point(3, 265);
            this.fitImageCheckBox.Name = "fitImageCheckBox";
            this.fitImageCheckBox.Size = new System.Drawing.Size(69, 17);
            this.fitImageCheckBox.TabIndex = 1;
            this.fitImageCheckBox.Text = "Fit Image";
            this.fitImageCheckBox.UseVisualStyleBackColor = true;
            this.fitImageCheckBox.CheckedChanged += new System.EventHandler(this.fitImageCheckBox_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.batchConvertButton);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Controls.Add(this.convertButton);
            this.flowLayoutPanel1.Controls.Add(this.openButton);
            this.flowLayoutPanel1.Controls.Add(this.ditheringCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(109, 265);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(528, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // batchConvertButton
            // 
            this.batchConvertButton.AutoSize = true;
            this.batchConvertButton.Location = new System.Drawing.Point(440, 3);
            this.batchConvertButton.Name = "batchConvertButton";
            this.batchConvertButton.Size = new System.Drawing.Size(85, 23);
            this.batchConvertButton.TabIndex = 4;
            this.batchConvertButton.Text = "Batch Convert";
            this.batchConvertButton.UseVisualStyleBackColor = true;
            this.batchConvertButton.Click += new System.EventHandler(this.batchConvertButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Location = new System.Drawing.Point(359, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.AutoSize = true;
            this.convertButton.Location = new System.Drawing.Point(278, 3);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // openButton
            // 
            this.openButton.AutoSize = true;
            this.openButton.Location = new System.Drawing.Point(197, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // ditheringCheckBox
            // 
            this.ditheringCheckBox.AutoSize = true;
            this.ditheringCheckBox.Location = new System.Drawing.Point(58, 3);
            this.ditheringCheckBox.Name = "ditheringCheckBox";
            this.ditheringCheckBox.Size = new System.Drawing.Size(133, 17);
            this.ditheringCheckBox.TabIndex = 5;
            this.ditheringCheckBox.Text = "Monochrome Dithering";
            this.ditheringCheckBox.UseVisualStyleBackColor = true;
            this.ditheringCheckBox.CheckedChanged += new System.EventHandler(this.ditheringCheckBox_CheckedChanged);
            // 
            // scriptListBox
            // 
            this.scriptListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptListBox.FormattingEnabled = true;
            this.scriptListBox.IntegralHeight = false;
            this.scriptListBox.Location = new System.Drawing.Point(3, 3);
            this.scriptListBox.MinimumSize = new System.Drawing.Size(100, 4);
            this.scriptListBox.Name = "scriptListBox";
            this.scriptListBox.Size = new System.Drawing.Size(100, 256);
            this.scriptListBox.TabIndex = 3;
            this.scriptListBox.SelectedIndexChanged += new System.EventHandler(this.scriptListBox_SelectedIndexChanged);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(109, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(528, 256);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.scriptListBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mainPictureBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.fitImageCheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.progressBar, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(640, 317);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // progressBar
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.progressBar, 2);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 300);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(634, 14);
            this.progressBar.TabIndex = 4;
            // 
            // Form1
            // 
            this.AcceptButton = this.openButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 317);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Form1";
            this.Text = "CustomImageConverter - www.dotmos.org";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.SaveFileDialog saveImageFileDialog;
        private System.Windows.Forms.CheckBox fitImageCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button batchConvertButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ListBox scriptListBox;
        private PictureBoxWithInterpolationMode mainPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox ditheringCheckBox;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

