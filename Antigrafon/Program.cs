﻿/* 
 * Antigrafon project: Program entry point
 * (c) 2015, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */
 
using System;
using System.Windows.Forms;

namespace Antigrafon{
	internal sealed class Program{
		[STAThread]
		private static void Main(string[] args){
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
