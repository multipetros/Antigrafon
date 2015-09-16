/* 
 * Antigrafon project: Logs form logic
 * (c) 2015, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */

using System ;
using System.Drawing ;
using System.Windows.Forms ;
using System.Collections.Generic ;
using System.IO ;
using Multipetros.Config ;

namespace Antigrafon{
	public partial class LogsForm : Form{
		private RegistryIni properties = new RegistryIni(Application.CompanyName, Application.ProductName) ;		
		private readonly string REG_LOGS_LEFT = "LogsLeft" ;
		private readonly string REG_LOGS_TOP = "LogsTop" ;
		private readonly string REG_LOGS_WIDTH = "LogsWidth" ;
		private readonly string REG_LOGS_HEIGHT = "LogsHeight" ;
		private readonly string REG_LOGS_MAXIMIZED = "LogsMaximized" ;
		private readonly string REG_LOGS_FONT = "LogsFont" ;
		private readonly string REG_LOGS_FORE_COLOR = "LogsForeColor" ;
		private readonly string REG_LANGUAGE = "Language" ;

		private SimpleIni languageStrings ;
		private readonly string LANG_SAVE = "Save" ;
		private readonly string LANG_FONT = "Font" ;
		private readonly string LANG_COPIES_DONE = "CopiesDone" ;
		private readonly string LANG_COPIES_FAILED = "CopiesFailed" ;
		private readonly string LANG_DELETIONS_DONE = "DeletionsDone" ;
		private readonly string LANG_DELETIONS_FAILED = "DeletionsFailed" ;
		private readonly string LANG_LOGS_TITLE = "LogsTitle" ;

		public LogsForm(List<BackupLog> backupLogs){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			InitUI() ;
			InitLogs(backupLogs) ;
		}
		
		private void InitUI(){
			try {
				int left ;
				if(int.TryParse(properties[REG_LOGS_LEFT], out left))
					this.Left = left ;
				
				int top ;
				if(int.TryParse(properties[REG_LOGS_TOP], out top))
					this.Top = top ;
				
				int height ;				
				if(int.TryParse(properties[REG_LOGS_HEIGHT], out height))
					this.Height = height ;
				
				int width ;
				if(int.TryParse(properties[REG_LOGS_WIDTH], out width))
					this.Width = width ;
				
				bool maximized ;
				bool.TryParse(properties[REG_LOGS_MAXIMIZED], out maximized) ;
				this.WindowState = (maximized) ? FormWindowState.Maximized : FormWindowState.Normal ;
				
				string lang = properties[REG_LANGUAGE] ; 
				if(lang.Length == 2 && lang != "en") //for languages used the ISO 639-1, two-letter codes format
					LoadLang(lang) ;
				
				//use FontConverter to 'deserialize' the current Font object from string
				string storedFont = properties[REG_LOGS_FONT] ;
				if(storedFont != ""){
					FontConverter fontCon = new FontConverter() ;
					Font font = (Font) fontCon.ConvertFromString(storedFont) ;
					textBoxCopiesFailed.Font = font ;
					textBoxCopiesDone.Font = font ;
					textBoxDeletionsDone.Font = font ;
					textBoxDeletionsFailed.Font = font ;
				}
				
				//use ColorConverter to 'deserialize' the current Color object from string
				string storedColor = properties[REG_LOGS_FORE_COLOR] ;
				if(storedColor != ""){
					ColorConverter colorCon = new ColorConverter() ;
					Color color = (Color) colorCon.ConvertFromString(storedColor) ;
					textBoxCopiesDone.ForeColor = color ;
					textBoxCopiesFailed.ForeColor = color ;					
					textBoxDeletionsDone.ForeColor = color ;
					textBoxDeletionsFailed.ForeColor = color ;
					
					//change backcolor to white instead of readonly gray, to make fore color visible
					textBoxCopiesDone.BackColor = Color.White ;
					textBoxCopiesFailed.BackColor = Color.White ;
					textBoxDeletionsDone.BackColor = Color.White ;
					textBoxDeletionsFailed.BackColor = Color.White ;
				}
			} catch (Exception) { }
		}
		
		private void ChangeFont(){
			fontDialog.Font = textBoxCopiesDone.Font ;
			fontDialog.Color = textBoxCopiesDone.ForeColor ;
			
			DialogResult res = fontDialog.ShowDialog(this) ;
			if(res == DialogResult.OK){
				textBoxCopiesFailed.Font = fontDialog.Font ;
				textBoxCopiesDone.Font = fontDialog.Font ;
				textBoxDeletionsDone.Font = fontDialog.Font ;
				textBoxDeletionsFailed.Font = fontDialog.Font ;
				
				//use FontConverter to 'serialize' the current Font object into string
				FontConverter fontCon = new FontConverter() ;
				properties[REG_LOGS_FONT] = fontCon.ConvertToString(fontDialog.Font) ;
				
				textBoxCopiesDone.ForeColor = fontDialog.Color ;
				textBoxCopiesFailed.ForeColor = fontDialog.Color ;					
				textBoxDeletionsDone.ForeColor = fontDialog.Color ;
				textBoxDeletionsFailed.ForeColor = fontDialog.Color ;
				
				//use ColorConverter to 'serialize' the current Color object into string
				ColorConverter colorCon = new ColorConverter() ;
				properties[REG_LOGS_FORE_COLOR] = colorCon.ConvertToString(fontDialog.Color) ;
			}
		}
		
		private void LoadLang(string lang){
			string langFile = Path.GetDirectoryName(Application.ExecutablePath) +  "\\" + lang + ".lng" ;
			if(File.Exists(langFile)){
				languageStrings = new SimpleIni(langFile, false, true) ;
				string currentString ;
				
				currentString = languageStrings[LANG_COPIES_DONE] ;
				if(currentString != "")
					tabPageCopiesDone.Text = currentString ;
				
				currentString = languageStrings[LANG_COPIES_FAILED] ;
				if(currentString != "")
					tabPageCopiesFailed.Text = currentString ;
				
				currentString = languageStrings[LANG_DELETIONS_DONE] ;
				if(currentString != "")
					tabPageDeletionsDone.Text = currentString ;
				
				currentString = languageStrings[LANG_DELETIONS_FAILED] ;
				if(currentString != "")
					tabPageDeletionsFailed.Text = currentString ;
				
				currentString = languageStrings[LANG_FONT] ;
				if(currentString != "")
					fontToolStripMenuItem.Text = currentString ;
				
				currentString = languageStrings[LANG_LOGS_TITLE] ;
				if(currentString != "")
					this.Text = "Antigrafon - " + currentString ;
				
				currentString = languageStrings[LANG_SAVE] ;
				if(currentString != "")
					saveToolStripMenuItem.Text = currentString ;
				
				this.Refresh() ;
			}		
		}
		
		private void InitLogs(List<BackupLog> backupLogs){
			List<string> copiesDone = new List<string>() ;
			List<string> copiesFailed = new List<string>() ;
			List<string> deletionsDone = new List<string>() ;
			List<string> deletionsFailed = new List<string>() ;
			
			foreach(BackupLog log in backupLogs){
				if(log.Operation == BackupOperation.Copy){
					if(log.Error == null){
						copiesDone.Add(log.Filename) ;
					}else{
						copiesFailed.Add(log.Filename + " : " + log.Error) ;
					}
				}else{
					if(log.Error == null){
						deletionsDone.Add(log.Filename) ;
					}else{
						deletionsFailed.Add(log.Filename + " : " + log.Error) ;
					}					
				}
			}
			
			tabPageCopiesDone.Text += " (" + copiesDone.Count.ToString() + ")" ;
			tabPageCopiesFailed.Text += " (" + copiesFailed.Count.ToString() + ")" ;
			tabPageDeletionsDone.Text += " (" + deletionsDone.Count.ToString() + ")" ;
			tabPageDeletionsFailed.Text += " (" + deletionsFailed.Count.ToString() + ")" ;
			
			textBoxCopiesDone.Text = string.Join("\r\n", copiesDone.ToArray()) ;
			textBoxCopiesFailed.Text = string.Join("\r\n", copiesFailed.ToArray()) ;
			textBoxDeletionsDone.Text = string.Join("\r\n", deletionsDone.ToArray()) ;
			textBoxDeletionsFailed.Text = string.Join("\r\n", deletionsFailed.ToArray()) ;
		}
		
		private void SaveLogs(){
			DialogResult res = saveFileDialog.ShowDialog() ;
			if(res == DialogResult.OK){
				try {
					string logsSum = "Antigrafon Log - " + DateTime.Now.ToString() + "\r\n\r\n" +
						tabPageCopiesDone.Text + "\r\n==========\r\n" + textBoxCopiesDone.Text + "\r\n\r\n" +
						tabPageCopiesFailed.Text + "\r\n==========\r\n" + textBoxCopiesFailed.Text + "\r\n\r\n" +
						tabPageDeletionsDone.Text + "\r\n==========\r\n" + textBoxDeletionsDone.Text + "\r\n\r\n" +
						tabPageDeletionsFailed.Text + "\r\n==========\r\n" + textBoxDeletionsFailed.Text ;
					
					File.WriteAllText(saveFileDialog.FileName, logsSum) ;
				} catch (Exception err) {
					MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				}
			}
		}
		
		void LogsFormFormClosing(object sender, FormClosingEventArgs e){
			try {
				properties[REG_LOGS_LEFT] = this.Left.ToString() ;
				properties[REG_LOGS_TOP] = this.Top.ToString() ;
				if(this.WindowState == FormWindowState.Maximized){
					properties[REG_LOGS_MAXIMIZED] = true.ToString() ;
				}else{
					properties[REG_LOGS_HEIGHT] = this.Height.ToString() ;
					properties[REG_LOGS_WIDTH] = this.Width.ToString() ;
					properties[REG_LOGS_MAXIMIZED] = false.ToString() ;
				}
			} catch (Exception) { }

		}
		
		void FontToolStripMenuItemClick(object sender, EventArgs e){
			ChangeFont() ;
		}
		
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e){
			SaveLogs() ;
		}
	}
}
