namespace Screen_Print {
    partial class SelectArea {
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
            panelDrag = new Panel();
            buttonSelect = new Button();
            panelDrag.SuspendLayout();
            SuspendLayout();
            // 
            // panelDrag
            // 
            panelDrag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDrag.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelDrag.Controls.Add(buttonSelect);
            panelDrag.Cursor = Cursors.SizeAll;
            panelDrag.Location = new Point(3, 3);
            panelDrag.Name = "panelDrag";
            panelDrag.Padding = new Padding(10);
            panelDrag.Size = new Size(499, 500);
            panelDrag.TabIndex = 0;
            panelDrag.MouseDown += panelDrag_MouseDown;
            // 
            // buttonSelect
            // 
            buttonSelect.Image = Properties.Resources.checkbox;
            buttonSelect.Location = new Point(0, 0);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(37, 36);
            buttonSelect.TabIndex = 1;
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // SelectArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 506);
            Controls.Add(panelDrag);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectArea";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectArea";
            panelDrag.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDrag;
        private Button buttonSelect;
    }
}