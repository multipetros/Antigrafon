/* 
 * Antigrafon project: Logs form designer
 * (c) 2015, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */
 
namespace Antigrafon{
	partial class LogsForm{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsForm));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageCopiesDone = new System.Windows.Forms.TabPage();
			this.textBoxCopiesDone = new System.Windows.Forms.TextBox();
			this.tabPageDeletionsDone = new System.Windows.Forms.TabPage();
			this.textBoxDeletionsDone = new System.Windows.Forms.TextBox();
			this.tabPageCopiesFailed = new System.Windows.Forms.TabPage();
			this.textBoxCopiesFailed = new System.Windows.Forms.TextBox();
			this.tabPageDeletionsFailed = new System.Windows.Forms.TabPage();
			this.textBoxDeletionsFailed = new System.Windows.Forms.TextBox();
			this.menuStripTop = new System.Windows.Forms.MenuStrip();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tabControl.SuspendLayout();
			this.tabPageCopiesDone.SuspendLayout();
			this.tabPageDeletionsDone.SuspendLayout();
			this.tabPageCopiesFailed.SuspendLayout();
			this.tabPageDeletionsFailed.SuspendLayout();
			this.menuStripTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageCopiesDone);
			this.tabControl.Controls.Add(this.tabPageDeletionsDone);
			this.tabControl.Controls.Add(this.tabPageCopiesFailed);
			this.tabControl.Controls.Add(this.tabPageDeletionsFailed);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 24);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(489, 305);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageCopiesDone
			// 
			this.tabPageCopiesDone.Controls.Add(this.textBoxCopiesDone);
			this.tabPageCopiesDone.Location = new System.Drawing.Point(4, 22);
			this.tabPageCopiesDone.Name = "tabPageCopiesDone";
			this.tabPageCopiesDone.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCopiesDone.Size = new System.Drawing.Size(481, 279);
			this.tabPageCopiesDone.TabIndex = 0;
			this.tabPageCopiesDone.Text = "Copies Done";
			this.tabPageCopiesDone.UseVisualStyleBackColor = true;
			// 
			// textBoxCopiesDone
			// 
			this.textBoxCopiesDone.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxCopiesDone.Location = new System.Drawing.Point(3, 3);
			this.textBoxCopiesDone.Multiline = true;
			this.textBoxCopiesDone.Name = "textBoxCopiesDone";
			this.textBoxCopiesDone.ReadOnly = true;
			this.textBoxCopiesDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxCopiesDone.Size = new System.Drawing.Size(475, 273);
			this.textBoxCopiesDone.TabIndex = 0;
			// 
			// tabPageDeletionsDone
			// 
			this.tabPageDeletionsDone.Controls.Add(this.textBoxDeletionsDone);
			this.tabPageDeletionsDone.Location = new System.Drawing.Point(4, 22);
			this.tabPageDeletionsDone.Name = "tabPageDeletionsDone";
			this.tabPageDeletionsDone.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDeletionsDone.Size = new System.Drawing.Size(481, 279);
			this.tabPageDeletionsDone.TabIndex = 2;
			this.tabPageDeletionsDone.Text = "Deletions Done";
			this.tabPageDeletionsDone.UseVisualStyleBackColor = true;
			// 
			// textBoxDeletionsDone
			// 
			this.textBoxDeletionsDone.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDeletionsDone.Location = new System.Drawing.Point(3, 3);
			this.textBoxDeletionsDone.Multiline = true;
			this.textBoxDeletionsDone.Name = "textBoxDeletionsDone";
			this.textBoxDeletionsDone.ReadOnly = true;
			this.textBoxDeletionsDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDeletionsDone.Size = new System.Drawing.Size(475, 273);
			this.textBoxDeletionsDone.TabIndex = 1;
			// 
			// tabPageCopiesFailed
			// 
			this.tabPageCopiesFailed.Controls.Add(this.textBoxCopiesFailed);
			this.tabPageCopiesFailed.Location = new System.Drawing.Point(4, 22);
			this.tabPageCopiesFailed.Name = "tabPageCopiesFailed";
			this.tabPageCopiesFailed.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCopiesFailed.Size = new System.Drawing.Size(481, 279);
			this.tabPageCopiesFailed.TabIndex = 1;
			this.tabPageCopiesFailed.Text = "Copies Failed";
			this.tabPageCopiesFailed.UseVisualStyleBackColor = true;
			// 
			// textBoxCopiesFailed
			// 
			this.textBoxCopiesFailed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxCopiesFailed.Location = new System.Drawing.Point(3, 3);
			this.textBoxCopiesFailed.Multiline = true;
			this.textBoxCopiesFailed.Name = "textBoxCopiesFailed";
			this.textBoxCopiesFailed.ReadOnly = true;
			this.textBoxCopiesFailed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxCopiesFailed.Size = new System.Drawing.Size(475, 273);
			this.textBoxCopiesFailed.TabIndex = 1;
			// 
			// tabPageDeletionsFailed
			// 
			this.tabPageDeletionsFailed.Controls.Add(this.textBoxDeletionsFailed);
			this.tabPageDeletionsFailed.Location = new System.Drawing.Point(4, 22);
			this.tabPageDeletionsFailed.Name = "tabPageDeletionsFailed";
			this.tabPageDeletionsFailed.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDeletionsFailed.Size = new System.Drawing.Size(481, 279);
			this.tabPageDeletionsFailed.TabIndex = 3;
			this.tabPageDeletionsFailed.Text = "Deletions Failed";
			this.tabPageDeletionsFailed.UseVisualStyleBackColor = true;
			// 
			// textBoxDeletionsFailed
			// 
			this.textBoxDeletionsFailed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDeletionsFailed.Location = new System.Drawing.Point(3, 3);
			this.textBoxDeletionsFailed.Multiline = true;
			this.textBoxDeletionsFailed.Name = "textBoxDeletionsFailed";
			this.textBoxDeletionsFailed.ReadOnly = true;
			this.textBoxDeletionsFailed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDeletionsFailed.Size = new System.Drawing.Size(475, 273);
			this.textBoxDeletionsFailed.TabIndex = 1;
			// 
			// menuStripTop
			// 
			this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.saveToolStripMenuItem,
									this.fontToolStripMenuItem});
			this.menuStripTop.Location = new System.Drawing.Point(0, 0);
			this.menuStripTop.Name = "menuStripTop";
			this.menuStripTop.Size = new System.Drawing.Size(489, 24);
			this.menuStripTop.TabIndex = 0;
			this.menuStripTop.Text = "menuStripTop";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fontToolStripMenuItem.Image")));
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.fontToolStripMenuItem.Text = "&Font";
			this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItemClick);
			// 
			// fontDialog
			// 
			this.fontDialog.AllowScriptChange = false;
			this.fontDialog.FontMustExist = true;
			this.fontDialog.ShowColor = true;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "txt";
			this.saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			// 
			// LogsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 329);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStripTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripTop;
			this.Name = "LogsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Antigrafon - Results Report";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogsFormFormClosing);
			this.tabControl.ResumeLayout(false);
			this.tabPageCopiesDone.ResumeLayout(false);
			this.tabPageCopiesDone.PerformLayout();
			this.tabPageDeletionsDone.ResumeLayout(false);
			this.tabPageDeletionsDone.PerformLayout();
			this.tabPageCopiesFailed.ResumeLayout(false);
			this.tabPageCopiesFailed.PerformLayout();
			this.tabPageDeletionsFailed.ResumeLayout(false);
			this.tabPageDeletionsFailed.PerformLayout();
			this.menuStripTop.ResumeLayout(false);
			this.menuStripTop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.TextBox textBoxDeletionsFailed;
		private System.Windows.Forms.TextBox textBoxDeletionsDone;
		private System.Windows.Forms.TextBox textBoxCopiesFailed;
		private System.Windows.Forms.TextBox textBoxCopiesDone;
		private System.Windows.Forms.MenuStrip menuStripTop;
		private System.Windows.Forms.TabPage tabPageDeletionsFailed;
		private System.Windows.Forms.TabPage tabPageDeletionsDone;
		private System.Windows.Forms.TabPage tabPageCopiesFailed;
		private System.Windows.Forms.TabPage tabPageCopiesDone;
		private System.Windows.Forms.TabControl tabControl;
	}
}
