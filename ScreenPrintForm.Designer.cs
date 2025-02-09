namespace Screen_Print
{
    partial class ScreenPrintForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanelPrintArea = new FlowLayoutPanel();
            buttonSelectPrintArea = new Button();
            textBoxPrintArea = new TextBox();
            flowLayoutPanelNextZone = new FlowLayoutPanel();
            buttonSelectClickArea = new Button();
            textBoxClickArea = new TextBox();
            flowLayoutPanelClick = new FlowLayoutPanel();
            numericTotalClicks = new NumericUpDown();
            labelClickDelay = new Label();
            numericClickDelay = new NumericUpDown();
            labelSecs = new Label();
            flowLayoutPanelSaveDirectory = new FlowLayoutPanel();
            buttonChooseSaveDir = new Button();
            textBoxSaveFolder = new TextBox();
            tableLayoutPanelToolbar = new TableLayoutPanel();
            buttonSubmit = new Button();
            progressBar = new ProgressBar();
            labelStatus = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanelPrintArea.SuspendLayout();
            flowLayoutPanelNextZone.SuspendLayout();
            flowLayoutPanelClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericTotalClicks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericClickDelay).BeginInit();
            flowLayoutPanelSaveDirectory.SuspendLayout();
            tableLayoutPanelToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(flowLayoutPanelPrintArea);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelNextZone);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelClick);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelSaveDirectory);
            flowLayoutPanel1.Controls.Add(tableLayoutPanelToolbar);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(823, 179);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanelPrintArea
            // 
            flowLayoutPanelPrintArea.AutoSize = true;
            flowLayoutPanelPrintArea.Controls.Add(buttonSelectPrintArea);
            flowLayoutPanelPrintArea.Controls.Add(textBoxPrintArea);
            flowLayoutPanelPrintArea.Location = new Point(3, 3);
            flowLayoutPanelPrintArea.Name = "flowLayoutPanelPrintArea";
            flowLayoutPanelPrintArea.Size = new Size(816, 29);
            flowLayoutPanelPrintArea.TabIndex = 0;
            // 
            // buttonSelectPrintArea
            // 
            buttonSelectPrintArea.Location = new Point(3, 3);
            buttonSelectPrintArea.Name = "buttonSelectPrintArea";
            buttonSelectPrintArea.Size = new Size(153, 23);
            buttonSelectPrintArea.TabIndex = 0;
            buttonSelectPrintArea.Text = "Select print area ...";
            buttonSelectPrintArea.UseVisualStyleBackColor = true;
            buttonSelectPrintArea.Click += buttonSelectPrintArea_Click;
            // 
            // textBoxPrintArea
            // 
            textBoxPrintArea.Dock = DockStyle.Fill;
            textBoxPrintArea.Enabled = false;
            textBoxPrintArea.Location = new Point(162, 3);
            textBoxPrintArea.Name = "textBoxPrintArea";
            textBoxPrintArea.Size = new Size(651, 23);
            textBoxPrintArea.TabIndex = 1;
            // 
            // flowLayoutPanelNextZone
            // 
            flowLayoutPanelNextZone.AutoSize = true;
            flowLayoutPanelNextZone.Controls.Add(buttonSelectClickArea);
            flowLayoutPanelNextZone.Controls.Add(textBoxClickArea);
            flowLayoutPanelNextZone.Location = new Point(3, 38);
            flowLayoutPanelNextZone.Name = "flowLayoutPanelNextZone";
            flowLayoutPanelNextZone.Size = new Size(816, 29);
            flowLayoutPanelNextZone.TabIndex = 1;
            // 
            // buttonSelectClickArea
            // 
            buttonSelectClickArea.Location = new Point(3, 3);
            buttonSelectClickArea.Name = "buttonSelectClickArea";
            buttonSelectClickArea.Size = new Size(153, 23);
            buttonSelectClickArea.TabIndex = 0;
            buttonSelectClickArea.Text = "Select click area ...";
            buttonSelectClickArea.UseVisualStyleBackColor = true;
            buttonSelectClickArea.Click += buttonSelectClickArea_Click;
            // 
            // textBoxClickArea
            // 
            textBoxClickArea.Enabled = false;
            textBoxClickArea.Location = new Point(162, 3);
            textBoxClickArea.Name = "textBoxClickArea";
            textBoxClickArea.Size = new Size(651, 23);
            textBoxClickArea.TabIndex = 1;
            // 
            // flowLayoutPanelClick
            // 
            flowLayoutPanelClick.AutoSize = true;
            flowLayoutPanelClick.Controls.Add(numericTotalClicks);
            flowLayoutPanelClick.Controls.Add(labelClickDelay);
            flowLayoutPanelClick.Controls.Add(numericClickDelay);
            flowLayoutPanelClick.Controls.Add(labelSecs);
            flowLayoutPanelClick.Dock = DockStyle.Fill;
            flowLayoutPanelClick.Location = new Point(3, 73);
            flowLayoutPanelClick.Name = "flowLayoutPanelClick";
            flowLayoutPanelClick.Size = new Size(816, 29);
            flowLayoutPanelClick.TabIndex = 1;
            // 
            // numericTotalClicks
            // 
            numericTotalClicks.Location = new Point(3, 3);
            numericTotalClicks.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericTotalClicks.Name = "numericTotalClicks";
            numericTotalClicks.Size = new Size(83, 23);
            numericTotalClicks.TabIndex = 5;
            numericTotalClicks.TextAlign = HorizontalAlignment.Right;
            numericTotalClicks.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelClickDelay
            // 
            labelClickDelay.Location = new Point(92, 0);
            labelClickDelay.Name = "labelClickDelay";
            labelClickDelay.Size = new Size(83, 23);
            labelClickDelay.TabIndex = 0;
            labelClickDelay.Text = "clicks every";
            labelClickDelay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericClickDelay
            // 
            numericClickDelay.Location = new Point(181, 3);
            numericClickDelay.Name = "numericClickDelay";
            numericClickDelay.Size = new Size(41, 23);
            numericClickDelay.TabIndex = 3;
            numericClickDelay.TextAlign = HorizontalAlignment.Right;
            numericClickDelay.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelSecs
            // 
            labelSecs.Location = new Point(228, 0);
            labelSecs.Name = "labelSecs";
            labelSecs.Size = new Size(135, 26);
            labelSecs.TabIndex = 2;
            labelSecs.Text = "seconds";
            labelSecs.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelSaveDirectory
            // 
            flowLayoutPanelSaveDirectory.AutoSize = true;
            flowLayoutPanelSaveDirectory.Controls.Add(buttonChooseSaveDir);
            flowLayoutPanelSaveDirectory.Controls.Add(textBoxSaveFolder);
            flowLayoutPanelSaveDirectory.Dock = DockStyle.Fill;
            flowLayoutPanelSaveDirectory.Location = new Point(3, 108);
            flowLayoutPanelSaveDirectory.Name = "flowLayoutPanelSaveDirectory";
            flowLayoutPanelSaveDirectory.Size = new Size(816, 31);
            flowLayoutPanelSaveDirectory.TabIndex = 4;
            // 
            // buttonChooseSaveDir
            // 
            buttonChooseSaveDir.AutoSize = true;
            buttonChooseSaveDir.Location = new Point(3, 3);
            buttonChooseSaveDir.Name = "buttonChooseSaveDir";
            buttonChooseSaveDir.Size = new Size(153, 25);
            buttonChooseSaveDir.TabIndex = 4;
            buttonChooseSaveDir.Text = "Choose save directory ...";
            buttonChooseSaveDir.UseVisualStyleBackColor = true;
            buttonChooseSaveDir.Click += buttonChooseSaveDir_Click;
            // 
            // textBoxSaveFolder
            // 
            textBoxSaveFolder.Dock = DockStyle.Fill;
            textBoxSaveFolder.Enabled = false;
            textBoxSaveFolder.Location = new Point(162, 3);
            textBoxSaveFolder.Name = "textBoxSaveFolder";
            textBoxSaveFolder.Size = new Size(651, 23);
            textBoxSaveFolder.TabIndex = 3;
            // 
            // tableLayoutPanelToolbar
            // 
            tableLayoutPanelToolbar.ColumnCount = 3;
            tableLayoutPanelToolbar.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelToolbar.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelToolbar.Controls.Add(buttonSubmit, 2, 0);
            tableLayoutPanelToolbar.Controls.Add(progressBar, 1, 0);
            tableLayoutPanelToolbar.Controls.Add(labelStatus, 0, 0);
            tableLayoutPanelToolbar.Dock = DockStyle.Fill;
            tableLayoutPanelToolbar.Location = new Point(3, 145);
            tableLayoutPanelToolbar.Name = "tableLayoutPanelToolbar";
            tableLayoutPanelToolbar.RowCount = 1;
            tableLayoutPanelToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelToolbar.Size = new Size(816, 29);
            tableLayoutPanelToolbar.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Enabled = false;
            buttonSubmit.Location = new Point(738, 3);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(75, 23);
            buttonSubmit.TabIndex = 0;
            buttonSubmit.Text = "Start";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(162, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(570, 23);
            progressBar.TabIndex = 2;
            progressBar.Visible = false;
            // 
            // labelStatus
            // 
            labelStatus.Location = new Point(3, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(153, 23);
            labelStatus.TabIndex = 6;
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            labelStatus.Visible = false;
            // 
            // ScreenPrintForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 179);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ScreenPrintForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScreenPrint";
            TopMost = true;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanelPrintArea.ResumeLayout(false);
            flowLayoutPanelPrintArea.PerformLayout();
            flowLayoutPanelNextZone.ResumeLayout(false);
            flowLayoutPanelNextZone.PerformLayout();
            flowLayoutPanelClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericTotalClicks).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericClickDelay).EndInit();
            flowLayoutPanelSaveDirectory.ResumeLayout(false);
            flowLayoutPanelSaveDirectory.PerformLayout();
            tableLayoutPanelToolbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanelPrintArea;
        private FlowLayoutPanel flowLayoutPanelNextZone;
        private TableLayoutPanel tableLayoutPanelToolbar;
        private Button buttonSubmit;
        private Button buttonSelectPrintArea;
        private TextBox textBoxPrintArea;
        private Button buttonSelectClickArea;
        private TextBox textBoxClickArea;
        private Label labelClickDelay;
        private Label labelSecs;
        private NumericUpDown numericClickDelay;
        private FlowLayoutPanel flowLayoutPanelClick;
        private NumericUpDown numericTotalClicks;
        private FlowLayoutPanel flowLayoutPanelSaveDirectory;
        private TextBox textBoxSaveFolder;
        private Button buttonChooseSaveDir;
        private FolderBrowserDialog folderBrowserDialog;
        private ProgressBar progressBar;
        private Label labelStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}
