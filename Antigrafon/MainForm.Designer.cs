/* 
 * Antigrafon project: Main form designer
 * (c) 2015, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */
 
namespace Antigrafon{
	partial class MainForm{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.menuStripTop = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showLastReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.greekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelOrigin = new System.Windows.Forms.Label();
			this.textBoxOrigin = new System.Windows.Forms.TextBox();
			this.buttonSlectOrigin = new System.Windows.Forms.Button();
			this.buttonSelectDestination = new System.Windows.Forms.Button();
			this.textBoxDestination = new System.Windows.Forms.TextBox();
			this.labeDestination = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.checkBoxKeepFiles = new System.Windows.Forms.CheckBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.progressBarWait = new System.Windows.Forms.ProgressBar();
			this.labelWait = new System.Windows.Forms.Label();
			this.menuStripTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// menuStripTop
			// 
			this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.languageToolStripMenuItem,
									this.aboutToolStripMenuItem});
			this.menuStripTop.Location = new System.Drawing.Point(0, 0);
			this.menuStripTop.Name = "menuStripTop";
			this.menuStripTop.Size = new System.Drawing.Size(521, 24);
			this.menuStripTop.TabIndex = 0;
			this.menuStripTop.Text = "menuStrip";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.showLastReportToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// showLastReportToolStripMenuItem
			// 
			this.showLastReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLastReportToolStripMenuItem.Image")));
			this.showLastReportToolStripMenuItem.Name = "showLastReportToolStripMenuItem";
			this.showLastReportToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.showLastReportToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.showLastReportToolStripMenuItem.Text = "Show &Last Report";
			this.showLastReportToolStripMenuItem.Click += new System.EventHandler(this.ShowLastReportToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.englishToolStripMenuItem,
									this.greekToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.languageToolStripMenuItem.Text = "&Language";
			// 
			// englishToolStripMenuItem
			// 
			this.englishToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("englishToolStripMenuItem.Image")));
			this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			this.englishToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.englishToolStripMenuItem.Text = "E&nglish";
			this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItemClick);
			// 
			// greekToolStripMenuItem
			// 
			this.greekToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("greekToolStripMenuItem.Image")));
			this.greekToolStripMenuItem.Name = "greekToolStripMenuItem";
			this.greekToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.greekToolStripMenuItem.Text = "Ε&λληνικά";
			this.greekToolStripMenuItem.Click += new System.EventHandler(this.GreekToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "A&bout";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// labelOrigin
			// 
			this.labelOrigin.Location = new System.Drawing.Point(12, 41);
			this.labelOrigin.Name = "labelOrigin";
			this.labelOrigin.Size = new System.Drawing.Size(75, 23);
			this.labelOrigin.TabIndex = 8;
			this.labelOrigin.Text = "Origin";
			// 
			// textBoxOrigin
			// 
			this.textBoxOrigin.AllowDrop = true;
			this.textBoxOrigin.Location = new System.Drawing.Point(93, 38);
			this.textBoxOrigin.Name = "textBoxOrigin";
			this.textBoxOrigin.Size = new System.Drawing.Size(319, 20);
			this.textBoxOrigin.TabIndex = 1;
			this.textBoxOrigin.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxOriginDragDrop);
			this.textBoxOrigin.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxOriginDragEnter);
			// 
			// buttonSlectOrigin
			// 
			this.buttonSlectOrigin.Image = ((System.Drawing.Image)(resources.GetObject("buttonSlectOrigin.Image")));
			this.buttonSlectOrigin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSlectOrigin.Location = new System.Drawing.Point(418, 38);
			this.buttonSlectOrigin.Name = "buttonSlectOrigin";
			this.buttonSlectOrigin.Size = new System.Drawing.Size(91, 23);
			this.buttonSlectOrigin.TabIndex = 2;
			this.buttonSlectOrigin.Text = "Select";
			this.buttonSlectOrigin.UseVisualStyleBackColor = true;
			this.buttonSlectOrigin.Click += new System.EventHandler(this.ButtonSlectOriginClick);
			// 
			// buttonSelectDestination
			// 
			this.buttonSelectDestination.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectDestination.Image")));
			this.buttonSelectDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSelectDestination.Location = new System.Drawing.Point(418, 73);
			this.buttonSelectDestination.Name = "buttonSelectDestination";
			this.buttonSelectDestination.Size = new System.Drawing.Size(91, 23);
			this.buttonSelectDestination.TabIndex = 4;
			this.buttonSelectDestination.Text = "Select";
			this.buttonSelectDestination.UseVisualStyleBackColor = true;
			this.buttonSelectDestination.Click += new System.EventHandler(this.ButtonSelectDestinationClick);
			// 
			// textBoxDestination
			// 
			this.textBoxDestination.AllowDrop = true;
			this.textBoxDestination.Location = new System.Drawing.Point(93, 73);
			this.textBoxDestination.Name = "textBoxDestination";
			this.textBoxDestination.Size = new System.Drawing.Size(319, 20);
			this.textBoxDestination.TabIndex = 3;
			this.textBoxDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxDestinationDragDrop);
			this.textBoxDestination.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxDestinationDragEnter);
			// 
			// labeDestination
			// 
			this.labeDestination.Location = new System.Drawing.Point(12, 78);
			this.labeDestination.Name = "labeDestination";
			this.labeDestination.Size = new System.Drawing.Size(75, 23);
			this.labeDestination.TabIndex = 9;
			this.labeDestination.Text = "Destination";
			// 
			// buttonStart
			// 
			this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
			this.buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonStart.Location = new System.Drawing.Point(373, 129);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(136, 32);
			this.buttonStart.TabIndex = 6;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
			// 
			// checkBoxKeepFiles
			// 
			this.checkBoxKeepFiles.Checked = true;
			this.checkBoxKeepFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxKeepFiles.Location = new System.Drawing.Point(93, 99);
			this.checkBoxKeepFiles.Name = "checkBoxKeepFiles";
			this.checkBoxKeepFiles.Size = new System.Drawing.Size(338, 24);
			this.checkBoxKeepFiles.TabIndex = 5;
			this.checkBoxKeepFiles.Text = "Keep files not in origin";
			this.checkBoxKeepFiles.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.Location = new System.Drawing.Point(373, 129);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(136, 32);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Visible = false;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// progressBarWait
			// 
			this.progressBarWait.Location = new System.Drawing.Point(12, 73);
			this.progressBarWait.Name = "progressBarWait";
			this.progressBarWait.Size = new System.Drawing.Size(497, 35);
			this.progressBarWait.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBarWait.TabIndex = 11;
			this.progressBarWait.Visible = false;
			// 
			// labelWait
			// 
			this.labelWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.labelWait.Location = new System.Drawing.Point(12, 29);
			this.labelWait.Name = "labelWait";
			this.labelWait.Size = new System.Drawing.Size(497, 35);
			this.labelWait.TabIndex = 10;
			this.labelWait.Text = "Working... Please wait...";
			this.labelWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelWait.Visible = false;
			// 
			// MainForm
			// 
			this.AcceptButton = this.buttonStart;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(521, 177);
			this.Controls.Add(this.labelWait);
			this.Controls.Add(this.progressBarWait);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.checkBoxKeepFiles);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.buttonSelectDestination);
			this.Controls.Add(this.textBoxDestination);
			this.Controls.Add(this.labeDestination);
			this.Controls.Add(this.buttonSlectOrigin);
			this.Controls.Add(this.textBoxOrigin);
			this.Controls.Add(this.labelOrigin);
			this.Controls.Add(this.menuStripTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripTop;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Antigrafon";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.menuStripTop.ResumeLayout(false);
			this.menuStripTop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem showLastReportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem greekToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ProgressBar progressBarWait;
		private System.Windows.Forms.Label labelWait;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.CheckBox checkBoxKeepFiles;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label labelOrigin;
		private System.Windows.Forms.TextBox textBoxOrigin;
		private System.Windows.Forms.Button buttonSlectOrigin;
		private System.Windows.Forms.Button buttonSelectDestination;
		private System.Windows.Forms.TextBox textBoxDestination;
		private System.Windows.Forms.Label labeDestination;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.MenuStrip menuStripTop;
	}
}
