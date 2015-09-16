/* 
 * Antigrafon project: Main form logic
 * (c) 2015, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */

using System ;
using System.Collections.Generic ;
using System.Drawing ;
using System.Windows.Forms ;
using System.IO ;
using Multipetros.Config ;

namespace Antigrafon{
	public partial class MainForm : Form{
		private Backup backup ;
		private List<BackupLog> backupLogs ;
		private Form logsForm ;
		
		private RegistryIni properties = new RegistryIni(Application.CompanyName, Application.ProductName) ;		
		private readonly string REG_MAIN_LEFT = "MainLeft" ;
		private readonly string REG_MAIN_TOP = "MainTop" ;
		private readonly string REG_DESTINATION = "Destination" ;
		private readonly string REG_ORIGIN = "Origin" ;
		private readonly string REG_KEEP_FILES = "KeepFiles" ;
		private readonly string REG_LANGUAGE = "Language" ;
		
		private SimpleIni languageStrings ;
		private readonly string LANG_START = "Start" ;
		private readonly string LANG_CANCEL = "Cancel" ;
		private readonly string LANG_SELECT = "Select" ;
		private readonly string LANG_ORIGIN = "Origin" ;
		private readonly string LANG_DESTINATION = "Destination" ;
		private readonly string LANG_KEEP_FILES = "KeepFiles" ;
		private readonly string LANG_FILE = "File" ;
		private readonly string LANG_EXIT = "Exit" ;
		private readonly string LANG_LANGUAGE = "Language" ;
		private readonly string LANG_ABOUT = "About" ;
		private readonly string LANG_WAIT = "Wait" ;
		private readonly string LANG_LAST_REPORT = "LastReport" ;
		private readonly string LANG_LAST_REPORT_MSG = "LastReportMessage" ;
		
		private string MSG_LAST_REPORT_NOT_EXIST = "There is no report generated at the current session (no backup process has run yet)." ;
		
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			InitUI() ;
		}
		
		private void InitUI(){
			try {
				int left ;
				if(int.TryParse(properties[REG_MAIN_LEFT], out left))
					this.Left = left ;
				
				int top ;
				if(int.TryParse(properties[REG_MAIN_TOP], out top))
					this.Top = top ;
				
				textBoxDestination.Text = properties[REG_DESTINATION] ;
				textBoxOrigin.Text = properties[REG_ORIGIN] ;
				checkBoxKeepFiles.Checked = (properties[REG_KEEP_FILES] == "False") ? false : true ;
				
				string lang = properties[REG_LANGUAGE] ; 
				if(lang.Length == 2 && lang != "en") //for languages used the ISO 639-1, two-letter codes format
					LoadLang(lang) ;
			} catch (Exception) { }
		}
		
		private void LoadLang(string lang){
			string langFile = Path.GetDirectoryName(Application.ExecutablePath) +  "\\" + lang + ".lng" ;
			if(File.Exists(langFile)){
				languageStrings = new SimpleIni(langFile, false, true) ;
				string currentString ;
				
				currentString = languageStrings[LANG_CANCEL] ;
				if(currentString != "")
					buttonCancel.Text = currentString ;
				
				currentString = languageStrings[LANG_SELECT] ;
				if(currentString != "")
					buttonSelectDestination.Text = currentString ;
				
				currentString = languageStrings[LANG_SELECT] ;
				if(currentString != "")
					buttonSlectOrigin.Text = currentString ;
				
				currentString = languageStrings[LANG_START] ;
				if(currentString != "")
					buttonStart.Text = currentString ;
				
				currentString = languageStrings[LANG_ORIGIN] ;
				if(currentString != "")
					labelOrigin.Text = currentString ;
				
				currentString = languageStrings[LANG_DESTINATION] ;
				if(currentString != "")
					labeDestination.Text = currentString ;
				
				currentString = languageStrings[LANG_WAIT] ;
				if(currentString != "")
					labelWait.Text = currentString ;
				
				currentString = languageStrings[LANG_KEEP_FILES] ;
				if(currentString != "")
					checkBoxKeepFiles.Text = currentString ;
				
				currentString = languageStrings[LANG_FILE] ;
				if(currentString != "")
					fileToolStripMenuItem.Text = currentString ;
				
				currentString = languageStrings[LANG_EXIT] ;
				if(currentString != "")
					exitToolStripMenuItem.Text = currentString ;
				
				currentString = languageStrings[LANG_LANGUAGE] ;
				if(currentString != "")
					languageToolStripMenuItem.Text = currentString ;
				
				currentString = languageStrings[LANG_ABOUT] ;
				if(currentString != "")
					aboutToolStripMenuItem.Text = currentString ;
				
				currentString = languageStrings[LANG_LAST_REPORT] ;
				if(currentString != "")
					showLastReportToolStripMenuItem.Text = currentString ;
				
				currentString = languageStrings[LANG_LAST_REPORT_MSG] ;
				if(currentString != "")
					MSG_LAST_REPORT_NOT_EXIST = currentString ;
				
				this.Refresh() ;				
				properties[REG_LANGUAGE] = lang ;
			}		
		}
		
		void ButtonSlectOriginClick(object sender, EventArgs e){
			DialogResult result = folderBrowserDialog.ShowDialog(this) ;
			if(result == DialogResult.OK)
				textBoxOrigin.Text = folderBrowserDialog.SelectedPath ;
		}
		
		void ButtonSelectDestinationClick(object sender, EventArgs e){
			DialogResult result = folderBrowserDialog.ShowDialog(this) ;
			if(result == DialogResult.OK)
				textBoxDestination.Text = folderBrowserDialog.SelectedPath ;			
		}
		
		void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e){			
			backupLogs = backup.StartBackup(checkBoxKeepFiles.Checked ? BackupOptions.KeepFilesNotInOrigin : BackupOptions.DeleteFilesNotInOrigin) ;
		}
		
		void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e){
			ChangeControls(ControlsGroup.Normal) ;
			logsForm = new LogsForm(backupLogs) ;
			logsForm.ShowDialog(this) ;
		}
		
		void ButtonStartClick(object sender, EventArgs e){
			backup = new Backup() ;
			try{
				backup.OriginRoot = textBoxOrigin.Text ;
				backup.DestRoot = textBoxDestination.Text ;
			}catch(Exception err){
				MessageBox.Show(err.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				return ;
			}
			ChangeControls(ControlsGroup.Waiting) ;
			backgroundWorker.RunWorkerAsync() ;
		}
		
		// used at ChangeControls(ControlsGroup) method, to determinate
		// who controls group to be visible and hide the other one
		private enum ControlsGroup{
			Normal, 
			Waiting
		}
		
		// if ControlsGroup.Waiting passed, hide all other controls and show the waiting controls
		// if ControlsGroup.Normal passed do the opposite
		private void ChangeControls(ControlsGroup cGroup){
			bool waitingState = (cGroup == ControlsGroup.Waiting) ? true : false ;
			
			menuStripTop.Visible = !waitingState ;
			textBoxDestination.Visible = !waitingState ;
			textBoxOrigin.Visible = !waitingState ;
			labeDestination.Visible = !waitingState ;
			labelOrigin.Visible = !waitingState ;
			buttonSelectDestination.Visible = !waitingState ;
			buttonSlectOrigin.Visible = !waitingState ;
			buttonStart.Visible = !waitingState ;
			checkBoxKeepFiles.Visible = !waitingState ;
			
			labelWait.Visible = waitingState ;
			progressBarWait.Visible = waitingState ;
			buttonCancel.Visible = waitingState ;
		}
		
		void ButtonCancelClick(object sender, System.EventArgs e){
			backup.CancelBackup() ;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e){
			try {
			properties[REG_MAIN_LEFT] = this.Left.ToString() ;
			properties[REG_MAIN_TOP] = this.Top.ToString() ;
			properties[REG_DESTINATION] = textBoxDestination.Text ;
			properties[REG_ORIGIN] = textBoxOrigin.Text ;
			properties[REG_KEEP_FILES] = checkBoxKeepFiles.Checked.ToString() ;
			} catch (Exception) { }
		}
		
		void EnglishToolStripMenuItemClick(object sender, EventArgs e){
			LoadLang("en") ;
		}
		
		void GreekToolStripMenuItemClick(object sender, EventArgs e){
			LoadLang("el") ;
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e){
			Application.Exit() ;
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e){
			MessageBox.Show("Antigrafon - Ver 1.0\nA simple but efficient backup utility\n\n(c) 2015, Petros Kyladitis  <http://www.multipetros.gr>\n\nThis program is free software distributed under the GNU GPL 3, for license details see at 'license.txt' file, distributed with this program, or see at <http://www.gnu.org/licenses/>.", "About Antigrafon", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
		}
		
		void ShowLastReportToolStripMenuItemClick(object sender, EventArgs e){
			if(backupLogs == null){
				MessageBox.Show(MSG_LAST_REPORT_NOT_EXIST, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) ;
			}else{				
				logsForm = new LogsForm(backupLogs) ;
				logsForm.ShowDialog(this) ;
			}
		}
		
		void TextBoxOriginDragEnter(object sender, DragEventArgs e){
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				e.Effect = DragDropEffects.Copy ;
			}
		}
		
		void TextBoxOriginDragDrop(object sender, DragEventArgs e){
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(Directory.Exists(files[0]))
				   textBoxOrigin.Text = files[0] ;
			}
		}
		
		void TextBoxDestinationDragEnter(object sender, DragEventArgs e){
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				e.Effect = DragDropEffects.Copy ;
			}
		}
		
		void TextBoxDestinationDragDrop(object sender, DragEventArgs e){
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(Directory.Exists(files[0]))
				   textBoxDestination.Text = files[0] ;
			}
		}
	}
}
