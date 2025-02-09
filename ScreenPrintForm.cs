using System.Drawing.Imaging;
using PdfSharp.Pdf;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace Screen_Print
{
    public partial class ScreenPrintForm : Form {
        System.Drawing.Point? clickLocation { get; set; }
        System.Drawing.Rectangle? printArea { get; set; }
        String saveFolderPath { get; set; }

        public ScreenPrintForm() {
            InitializeComponent();
            clickLocation = null;
            printArea = null;
            saveFolderPath = "";
        }

        private void buttonSelectPrintArea_Click(object sender, EventArgs e) {
            this.Hide();
            SelectArea selectArea = new SelectArea();
            selectArea.Show();
            selectArea.FormClosed += SelectPrintArea_FormClosed;
        }

        private void SelectPrintArea_FormClosed(object? sender, FormClosedEventArgs e) {
            SelectArea? selectArea = sender as SelectArea;
            if (selectArea != null) {
                printArea = new System.Drawing.Rectangle(selectArea.Location, selectArea.Size);
                System.Drawing.Point bottomRight = new System.Drawing.Point(selectArea.Location.X + selectArea.Width, selectArea.Location.Y + selectArea.Height);
                this.textBoxPrintArea.Text = "Rectangle: { " + printArea?.Left + "} -> {" + printArea?.Top + "} {" + printArea?.Right + "} {" + printArea?.Bottom + "}";
            }
            this.Show();
            this.RefreshSubmitState();
        }

        private void buttonSelectClickArea_Click(object sender, EventArgs e) {
            this.Hide();
            SelectArea selectArea = new SelectArea();
            selectArea.Show();
            selectArea.FormClosed += SelectClickArea_FormClosed;
        }
        private void SelectClickArea_FormClosed(object? sender, FormClosedEventArgs e) {
            SelectArea? selectArea = sender as SelectArea;
            if (selectArea != null) {
                clickLocation = new System.Drawing.Point(selectArea.Location.X + selectArea.Width / 2, selectArea.Location.Y + selectArea.Height / 2);
                this.textBoxClickArea.Text = "Rectangle: { " + clickLocation?.X + "} -> {" + clickLocation?.Y + "}";
            }
            this.Show();
            this.RefreshSubmitState();
        }

        private void buttonChooseSaveDir_Click(object sender, EventArgs e) {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) {
                this.textBoxSaveFolder.Text = folderBrowserDialog.SelectedPath;
                this.saveFolderPath = folderBrowserDialog.SelectedPath;
                this.RefreshSubmitState();
            }
        }


        private void RefreshSubmitState() {
            this.buttonSubmit.Enabled = this.printArea != null && this.clickLocation != null && saveFolderPath != "";
        }

        #region Screenshot
        private void ScreenShot(int number) {
            if (this.printArea != null) {
                using (Bitmap bitmap = new Bitmap(this.printArea.Value.Width, this.printArea.Value.Height, PixelFormat.Format32bppArgb))
                using (Graphics graphics = Graphics.FromImage(bitmap)) {
                    graphics.CopyFromScreen(this.printArea.Value.Left, this.printArea.Value.Top, 0, 0, this.printArea.Value.Size, CopyPixelOperation.SourceCopy);

                    using (MemoryStream ms = new MemoryStream()) {
                        bitmap.Save(ms, ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin);

                        using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(ms)) {
                            var options = new PngEncoder() {
                                CompressionLevel = PngCompressionLevel.Level7
                            };
                            image.Save(Path.Combine(saveFolderPath, "png", $"{number}.png"), options);
                        }
                    }
                }
            }
        }
        private static ImageCodecInfo GetEncoder(System.Drawing.Imaging.ImageFormat format) {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs) {
                if (codec.FormatID == format.Guid) {
                    return codec;
                }
            }
            return null;
        }
        #endregion


        #region MouseClick
        private void SimulateClick() {
            if (this.clickLocation != null) {
                MouseService.SetCursorPosition(this.clickLocation.Value.X, this.clickLocation.Value.Y);
                MouseService.MouseEvent(MouseService.MouseEventFlags.LeftDown | MouseService.MouseEventFlags.LeftUp);
            }
        }
        #endregion


        private void buttonSubmit_Click(object sender, EventArgs e) {
            if (!this.backgroundWorker.IsBusy) {
                progressBar.Visible = true;
                labelStatus.Visible = true;
                buttonSubmit.Text = "Cancel";

                backgroundWorker.DoWork += Capture_DoWork;
                backgroundWorker.ProgressChanged += Capture_ChangedEventHandler;
                backgroundWorker.RunWorkerCompleted += Capture_RunWorkerCompleted;
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.RunWorkerAsync();

            } else {
                backgroundWorker.CancelAsync();
                progressBar.Visible = false;
                labelStatus.Visible = false;
                buttonSubmit.Text = "Start";
            }
        }

        private void Capture_RunWorkerCompleted(object? sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            progressBar.Visible = false;
            labelStatus.Visible = false;
            buttonSubmit.Text = "Start";
        }

        private void Capture_ChangedEventHandler(object? sender, System.ComponentModel.ProgressChangedEventArgs e) {
            this.progressBar.Value = e.ProgressPercentage;
            this.labelStatus.Text = e.UserState as String;
        }

        private void Capture_DoWork(object? sender, System.ComponentModel.DoWorkEventArgs e) {
            if (!System.IO.Directory.Exists(Path.Combine(saveFolderPath, "png"))) {
                System.IO.Directory.CreateDirectory(Path.Combine(saveFolderPath, "png"));
            } else {
                foreach (string file in Directory.GetFiles(Path.Combine(saveFolderPath, "png")).Where(item => item.EndsWith(".png"))) {
                    File.Delete(file);
                }
            }
            this.progressBar.Maximum = 100;
            for (int idxScreenshot = 0; idxScreenshot < this.numericTotalClicks.Value; idxScreenshot++) {
                this.ScreenShot(idxScreenshot);
                backgroundWorker.ReportProgress((int)((idxScreenshot / this.numericTotalClicks.Value) * 100), $"Screenshot: {idxScreenshot} / {this.numericTotalClicks.Value}");
                if (this.backgroundWorker.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
                if (idxScreenshot < (this.numericTotalClicks.Value - 1)) {
                    this.SimulateClick();
                    Thread.Sleep((int)this.numericClickDelay.Value * 1000);
                }
            }

            using (var document = new PdfDocument()) {
                int idxPDF = 0;
                foreach (string file in Directory.GetFiles(Path.Combine(saveFolderPath, "png")).Where(item => item.EndsWith(".png"))) {
                    PDFService.AddImageToPdfDocument(document, file);
                    idxPDF++;
                    backgroundWorker.ReportProgress((int)((idxPDF / this.numericTotalClicks.Value) * 100), $"Merge into PDF: {idxPDF} / {this.numericTotalClicks.Value}");
                    if (this.backgroundWorker.CancellationPending) {
                        e.Cancel = true;
                        return;
                    }
                }
                document.Save(Path.Combine(saveFolderPath, "captured.pdf"));
            }            
        }
    }
}
