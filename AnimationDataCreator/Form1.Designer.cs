namespace AnimationDataCreator {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanelComplexAnimation = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFrames = new System.Windows.Forms.Label();
            this.labelFrameCount = new System.Windows.Forms.Label();
            this.labelFrameData = new System.Windows.Forms.Label();
            this.listBoxFrames = new System.Windows.Forms.ListBox();
            this.buttonAddFrame = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteFrame = new System.Windows.Forms.Button();
            this.textBoxFrametime = new System.Windows.Forms.TextBox();
            this.textBoxImageID = new System.Windows.Forms.TextBox();
            this.labelFrametime = new System.Windows.Forms.Label();
            this.labelImageID = new System.Windows.Forms.Label();
            this.labelSelectedFrame = new System.Windows.Forms.Label();
            this.labelSelectedFrameNumber = new System.Windows.Forms.Label();
            this.pictureBoxFrame = new System.Windows.Forms.PictureBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.labelImageFilename = new System.Windows.Forms.Label();
            this.labelAnimationType = new System.Windows.Forms.Label();
            this.comboBoxAnimationType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnimationFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openAnimationFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanelSimpleAnimation = new System.Windows.Forms.TableLayoutPanel();
            this.simple_labelFrametime = new System.Windows.Forms.Label();
            this.simple_textBoxFrametime = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelComplexAnimation.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelSimpleAnimation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelComplexAnimation
            // 
            this.tableLayoutPanelComplexAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelComplexAnimation.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelComplexAnimation.ColumnCount = 2;
            this.tableLayoutPanelComplexAnimation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.88189F));
            this.tableLayoutPanelComplexAnimation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.11811F));
            this.tableLayoutPanelComplexAnimation.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanelComplexAnimation.Controls.Add(this.labelFrameData, 1, 0);
            this.tableLayoutPanelComplexAnimation.Controls.Add(this.listBoxFrames, 0, 1);
            this.tableLayoutPanelComplexAnimation.Controls.Add(this.buttonAddFrame, 0, 2);
            this.tableLayoutPanelComplexAnimation.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanelComplexAnimation.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanelComplexAnimation.Name = "tableLayoutPanelComplexAnimation";
            this.tableLayoutPanelComplexAnimation.RowCount = 3;
            this.tableLayoutPanelComplexAnimation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelComplexAnimation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelComplexAnimation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelComplexAnimation.Size = new System.Drawing.Size(359, 432);
            this.tableLayoutPanelComplexAnimation.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.labelFrames, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelFrameCount, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(146, 22);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // labelFrames
            // 
            this.labelFrames.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFrames.AutoSize = true;
            this.labelFrames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrames.Location = new System.Drawing.Point(3, 4);
            this.labelFrames.Name = "labelFrames";
            this.labelFrames.Size = new System.Drawing.Size(44, 13);
            this.labelFrames.TabIndex = 2;
            this.labelFrames.Text = "Frames:";
            // 
            // labelFrameCount
            // 
            this.labelFrameCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelFrameCount.AutoSize = true;
            this.labelFrameCount.Location = new System.Drawing.Point(130, 4);
            this.labelFrameCount.Name = "labelFrameCount";
            this.labelFrameCount.Size = new System.Drawing.Size(13, 13);
            this.labelFrameCount.TabIndex = 3;
            this.labelFrameCount.Text = "0";
            // 
            // labelFrameData
            // 
            this.labelFrameData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFrameData.AutoSize = true;
            this.labelFrameData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrameData.Location = new System.Drawing.Point(165, 9);
            this.labelFrameData.Name = "labelFrameData";
            this.labelFrameData.Size = new System.Drawing.Size(65, 13);
            this.labelFrameData.TabIndex = 5;
            this.labelFrameData.Text = "Frame Data:";
            // 
            // listBoxFrames
            // 
            this.listBoxFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFrames.FormattingEnabled = true;
            this.listBoxFrames.Location = new System.Drawing.Point(5, 35);
            this.listBoxFrames.Name = "listBoxFrames";
            this.listBoxFrames.Size = new System.Drawing.Size(152, 355);
            this.listBoxFrames.TabIndex = 3;
            this.listBoxFrames.SelectedIndexChanged += new System.EventHandler(this.listBoxFrames_SelectedIndexChanged);
            // 
            // buttonAddFrame
            // 
            this.buttonAddFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFrame.Location = new System.Drawing.Point(5, 401);
            this.buttonAddFrame.Name = "buttonAddFrame";
            this.buttonAddFrame.Size = new System.Drawing.Size(152, 26);
            this.buttonAddFrame.TabIndex = 4;
            this.buttonAddFrame.Text = "Add Frame";
            this.buttonAddFrame.UseVisualStyleBackColor = true;
            this.buttonAddFrame.Click += new System.EventHandler(this.buttonAddFrame_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.pictureBoxFrame, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.buttonLoadImage, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.labelImageFilename, 0, 2);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(165, 35);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(189, 358);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.buttonDeleteFrame, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.textBoxFrametime, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxImageID, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelFrametime, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelImageID, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelSelectedFrame, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelSelectedFrameNumber, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(183, 155);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // buttonDeleteFrame
            // 
            this.buttonDeleteFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFrame.Location = new System.Drawing.Point(95, 126);
            this.buttonDeleteFrame.Name = "buttonDeleteFrame";
            this.buttonDeleteFrame.Size = new System.Drawing.Size(83, 22);
            this.buttonDeleteFrame.TabIndex = 4;
            this.buttonDeleteFrame.Text = "Delete";
            this.buttonDeleteFrame.UseVisualStyleBackColor = true;
            this.buttonDeleteFrame.Click += new System.EventHandler(this.buttonDeleteFrame_Click);
            // 
            // textBoxFrametime
            // 
            this.textBoxFrametime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFrametime.Location = new System.Drawing.Point(95, 66);
            this.textBoxFrametime.Name = "textBoxFrametime";
            this.textBoxFrametime.Size = new System.Drawing.Size(83, 20);
            this.textBoxFrametime.TabIndex = 3;
            this.textBoxFrametime.Text = "n/a";
            this.textBoxFrametime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxFrametime.TextChanged += new System.EventHandler(this.textBoxFrametime_TextChanged);
            // 
            // textBoxImageID
            // 
            this.textBoxImageID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImageID.Location = new System.Drawing.Point(95, 36);
            this.textBoxImageID.Name = "textBoxImageID";
            this.textBoxImageID.Size = new System.Drawing.Size(83, 20);
            this.textBoxImageID.TabIndex = 1;
            this.textBoxImageID.Text = "n/a";
            this.textBoxImageID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxImageID.TextChanged += new System.EventHandler(this.textBoxImageID_TextChanged);
            // 
            // labelFrametime
            // 
            this.labelFrametime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelFrametime.AutoSize = true;
            this.labelFrametime.Location = new System.Drawing.Point(7, 69);
            this.labelFrametime.Name = "labelFrametime";
            this.labelFrametime.Size = new System.Drawing.Size(80, 13);
            this.labelFrametime.TabIndex = 2;
            this.labelFrametime.Text = "Frametime (ms):";
            // 
            // labelImageID
            // 
            this.labelImageID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelImageID.AutoSize = true;
            this.labelImageID.Location = new System.Drawing.Point(34, 39);
            this.labelImageID.Name = "labelImageID";
            this.labelImageID.Size = new System.Drawing.Size(53, 13);
            this.labelImageID.TabIndex = 0;
            this.labelImageID.Text = "Image ID:";
            // 
            // labelSelectedFrame
            // 
            this.labelSelectedFrame.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSelectedFrame.AutoSize = true;
            this.labelSelectedFrame.Location = new System.Drawing.Point(48, 9);
            this.labelSelectedFrame.Name = "labelSelectedFrame";
            this.labelSelectedFrame.Size = new System.Drawing.Size(39, 13);
            this.labelSelectedFrame.TabIndex = 5;
            this.labelSelectedFrame.Text = "Frame:";
            // 
            // labelSelectedFrameNumber
            // 
            this.labelSelectedFrameNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSelectedFrameNumber.AutoSize = true;
            this.labelSelectedFrameNumber.Location = new System.Drawing.Point(154, 9);
            this.labelSelectedFrameNumber.Name = "labelSelectedFrameNumber";
            this.labelSelectedFrameNumber.Size = new System.Drawing.Size(24, 13);
            this.labelSelectedFrameNumber.TabIndex = 6;
            this.labelSelectedFrameNumber.Text = "n/a";
            // 
            // pictureBoxFrame
            // 
            this.pictureBoxFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFrame.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBoxFrame.Location = new System.Drawing.Point(3, 164);
            this.pictureBoxFrame.Name = "pictureBoxFrame";
            this.pictureBoxFrame.Size = new System.Drawing.Size(183, 128);
            this.pictureBoxFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFrame.TabIndex = 3;
            this.pictureBoxFrame.TabStop = false;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadImage.Location = new System.Drawing.Point(3, 320);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(183, 26);
            this.buttonLoadImage.TabIndex = 4;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // labelImageFilename
            // 
            this.labelImageFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImageFilename.AutoSize = true;
            this.labelImageFilename.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelImageFilename.Location = new System.Drawing.Point(3, 295);
            this.labelImageFilename.Name = "labelImageFilename";
            this.labelImageFilename.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelImageFilename.Size = new System.Drawing.Size(183, 22);
            this.labelImageFilename.TabIndex = 5;
            this.labelImageFilename.Text = "imageName";
            this.labelImageFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAnimationType
            // 
            this.labelAnimationType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAnimationType.AutoSize = true;
            this.labelAnimationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnimationType.Location = new System.Drawing.Point(5, 11);
            this.labelAnimationType.Name = "labelAnimationType";
            this.labelAnimationType.Size = new System.Drawing.Size(83, 13);
            this.labelAnimationType.TabIndex = 0;
            this.labelAnimationType.Text = "Animation Type:";
            // 
            // comboBoxAnimationType
            // 
            this.comboBoxAnimationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAnimationType.FormattingEnabled = true;
            this.comboBoxAnimationType.Location = new System.Drawing.Point(164, 7);
            this.comboBoxAnimationType.Name = "comboBoxAnimationType";
            this.comboBoxAnimationType.Size = new System.Drawing.Size(190, 21);
            this.comboBoxAnimationType.TabIndex = 1;
            this.comboBoxAnimationType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnimationType_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelComplexAnimation, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelSimpleAnimation, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(365, 530);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.56141F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.43859F));
            this.tableLayoutPanel3.Controls.Add(this.comboBoxAnimationType, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelAnimationType, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(359, 32);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*";
            this.openImageFileDialog.FilterIndex = 4;
            this.openImageFileDialog.Title = "Select Image";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(390, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // saveAnimationFileDialog
            // 
            this.saveAnimationFileDialog.Filter = "Animation (*.anim)|*.anim";
            // 
            // openAnimationFileDialog
            // 
            this.openAnimationFileDialog.Filter = "Animation (*.anim)|*.anim";
            // 
            // tableLayoutPanelSimpleAnimation
            // 
            this.tableLayoutPanelSimpleAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelSimpleAnimation.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelSimpleAnimation.ColumnCount = 2;
            this.tableLayoutPanelSimpleAnimation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.56824F));
            this.tableLayoutPanelSimpleAnimation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.43176F));
            this.tableLayoutPanelSimpleAnimation.Controls.Add(this.simple_labelFrametime, 0, 0);
            this.tableLayoutPanelSimpleAnimation.Controls.Add(this.simple_textBoxFrametime, 1, 0);
            this.tableLayoutPanelSimpleAnimation.Location = new System.Drawing.Point(3, 57);
            this.tableLayoutPanelSimpleAnimation.Name = "tableLayoutPanelSimpleAnimation";
            this.tableLayoutPanelSimpleAnimation.RowCount = 1;
            this.tableLayoutPanelSimpleAnimation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSimpleAnimation.Size = new System.Drawing.Size(359, 32);
            this.tableLayoutPanelSimpleAnimation.TabIndex = 1;
            // 
            // simple_labelFrametime
            // 
            this.simple_labelFrametime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simple_labelFrametime.AutoSize = true;
            this.simple_labelFrametime.Location = new System.Drawing.Point(5, 9);
            this.simple_labelFrametime.Name = "simple_labelFrametime";
            this.simple_labelFrametime.Size = new System.Drawing.Size(58, 13);
            this.simple_labelFrametime.TabIndex = 0;
            this.simple_labelFrametime.Text = "Frametime:";
            // 
            // simple_textBoxFrametime
            // 
            this.simple_textBoxFrametime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.simple_textBoxFrametime.Location = new System.Drawing.Point(164, 6);
            this.simple_textBoxFrametime.Name = "simple_textBoxFrametime";
            this.simple_textBoxFrametime.Size = new System.Drawing.Size(190, 20);
            this.simple_textBoxFrametime.TabIndex = 1;
            this.simple_textBoxFrametime.Text = "128";
            this.simple_textBoxFrametime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.simple_textBoxFrametime.TextChanged += new System.EventHandler(this.simple_textBoxFrametime_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 569);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Animation Data Creator - www.dotmos.org";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelComplexAnimation.ResumeLayout(false);
            this.tableLayoutPanelComplexAnimation.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelSimpleAnimation.ResumeLayout(false);
            this.tableLayoutPanelSimpleAnimation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelComplexAnimation;
        private System.Windows.Forms.Label labelAnimationType;
        private System.Windows.Forms.ComboBox comboBoxAnimationType;
        private System.Windows.Forms.Label labelFrames;
        private System.Windows.Forms.Label labelFrameData;
        private System.Windows.Forms.ListBox listBoxFrames;
        private System.Windows.Forms.Button buttonAddFrame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox textBoxFrametime;
        private System.Windows.Forms.Label labelImageID;
        private System.Windows.Forms.TextBox textBoxImageID;
        private System.Windows.Forms.Label labelFrametime;
        private System.Windows.Forms.Button buttonDeleteFrame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelFrameCount;
        private System.Windows.Forms.Label labelSelectedFrame;
        private System.Windows.Forms.Label labelSelectedFrameNumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox pictureBoxFrame;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.Label labelImageFilename;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveAnimationFileDialog;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openAnimationFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSimpleAnimation;
        private System.Windows.Forms.Label simple_labelFrametime;
        private System.Windows.Forms.TextBox simple_textBoxFrametime;
    }
}

