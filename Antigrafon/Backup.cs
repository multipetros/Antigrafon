using System;
using System.Collections.Generic;
using System.IO ;
using System.Linq ;

namespace Antigrafon{
	
	//used at Backup class for cumulatively or mirroring backup process
	public enum BackupOptions{
		KeepFilesNotInOrigin,
		DeleteFilesNotInOrigin
	}
	
	//used at BackupLog class to determinate each item's refered operation
	public enum BackupOperation{
		Copy,
		Delete
	}
	
	//do cumulatively or mirroring file backup between two locations 
	public class Backup	{
		private List<BackupLog> logs ; //report the results of the process
		private string originRoot ;    //origin root path (copy from)
		private string destRoot ;      //destination root path (copy to / delete from)
		private bool cancel = false ;  //flag to cancel the process
		
		//default builder
		public Backup(){ }
		
		//build object initializing the origin and destination paths
		public Backup(string originRoot, string destRoot){
			OriginRoot = originRoot ;
			DestRoot = destRoot ;
		}
		
		//setup the origin root path
		public string OriginRoot{
			get{ return this.originRoot ; }
			set{
				if(!Directory.Exists(value)){
					throw new Exception("Origin Directory does not exist!") ;
				}
				this.originRoot = value ;
			}
		}
		
		//setup the destination root path
		public string DestRoot{
			get{ return this.destRoot ; }
			set{
				if(!Directory.Exists(value)){
					Directory.CreateDirectory(value) ;
				}
				this.destRoot = value ; 
			}
		}
		
		//turn cancel flag on
		public void CancelBackup(){
			this.cancel = true ;
		}
		
		//start the backup process
		public List<BackupLog> StartBackup(BackupOptions deleteOption){
			logs = new List<BackupLog>() ; //create object to keep the results
			
			//start copying all new/changed files from origin to destination
			CopyNewFiles(originRoot, destRoot, null) ;
			
			//if won't cumulatively backup, clean files from destination, that not present in origin
			if(deleteOption == BackupOptions.DeleteFilesNotInOrigin){
				CleanDeletedFiles(destRoot, originRoot, null) ;
			}
			
			return logs ;
		}
		
		//search origin recursively and copy them to destination if are new or modified
		private void CopyNewFiles(string path, string destRoot, List<string> files){         	
         	if(this.cancel){
         		return ;
         	}
			if(files == null){
				files = new List<string>() ;
			}
		    try{
		        Directory.GetFiles(path)
		            .ToList()
		        	.ForEach(s => {
		        	         	string sDest = s.Replace(originRoot,destRoot) ;
		        	         	
		        	         	if(this.cancel){
		        	         		return ;
		        	         	}
		        	         	
		        	         	if(!File.Exists(sDest) || DateTime.Compare(File.GetLastWriteTime(s), File.GetLastWriteTime(sDest)) > 0) {
		        	         	    	try{
		        	         	    		File.Copy(s, sDest, true) ;
		        	         	    		logs.Add(new BackupLog(sDest, BackupOperation.Copy, null)) ;
		        	         	        }catch(Exception err){
		        	         				logs.Add(new BackupLog(sDest, BackupOperation.Copy, err.Message)) ;
		        	         			}
									}
		        	         	}
		        	         );

		        Directory.GetDirectories(path)
		            .ToList()
		        	.ForEach(s => {
		        	         	string sDest = s.Replace(originRoot,destRoot) ;
		        	         	
		        	         	if(!Directory.Exists(sDest)){
		        	         	   		try{
			        	         			Directory.CreateDirectory(sDest) ;
			        	         			logs.Add(new BackupLog(sDest, BackupOperation.Copy, null)) ;
		        	         	   		}catch(Exception err){
		        	         				logs.Add(new BackupLog(sDest, BackupOperation.Copy, err.Message)) ;
		        	         			}				        	        
		        	         	}
		        	         	CopyNewFiles(s, destRoot, files);
		        	         }
		        	         );
		    }
		    catch (Exception){
		        // if can't access this dir, just skip it
		    }
		}

		//search destination recursively for files not exit at origin, and delete them
		private void CleanDeletedFiles(string path, string originRoot, List<string> files){		        	         	
         	if(this.cancel){
         		return ;
         	}
			if(files == null){
				files = new List<string>() ;
			}
		    try{
		        Directory.GetFiles(path)
		            .ToList()
		        	.ForEach(s => {
		        	         	string sOrigin = s.Replace(destRoot,originRoot) ;
		        	         	if(this.cancel){
		        	         		return ;
		        	         	}
		        	         	
		        	         	if(!File.Exists(sOrigin)){
		        	         	    	try{
		        	         	    		File.Delete(s) ;
		        	         	    		logs.Add(new BackupLog(s, BackupOperation.Delete, null)) ;
		        	         	        }catch(Exception err){
		        	         				logs.Add(new BackupLog(s, BackupOperation.Delete, err.Message)) ;
		        	         			}
									}
		        	         	}
		        	         );

		        Directory.GetDirectories(path)
		            .ToList()
		        	.ForEach(s => {
		        	         	string sOrigin = s.Replace(destRoot,originRoot) ;
		        	         	
		        	         	if(!Directory.Exists(sOrigin)){
		        	         	   		try{
			        	         			Directory.Delete(s, true) ;
			        	         			logs.Add(new BackupLog(s, BackupOperation.Delete, null)) ;
		        	         	   		}catch(Exception err){
		        	         				logs.Add(new BackupLog(s, BackupOperation.Delete, err.Message)) ;
		        	         			}				        	        
		        	         	}
		        	         	else{
		        	         		CleanDeletedFiles(s, originRoot, files);
		        	         	}
		        	         }
		        	         );
		    }
		    catch (Exception){
		        // if can't access this dir, just skip it
		    }
		}
	}
	
	//store infromation about a signle backup operation
	public class BackupLog{
		private string filename ;           //path of the current file
		private BackupOperation operation ; //operation type
		private string error ;              //error message, if exist
		
		//default builder
		public BackupLog(){ }
		
		//build object specifying file name, operation type & error message
		public BackupLog(string filename, BackupOperation operation, string error){
			Filename = filename ;
			Operation = operation ;
			Error = error ;
		}
		
		//get & set file name
		public string Filename{
			get{ return filename ; }
			set{ filename = value ; }
		}
		
		//get & set operation type
		public BackupOperation Operation{
			get{ return operation ; }
			set{ operation = value ; }
		}
		
		//get & set error message
		public string Error{
			get{ return error ; }
			set{ error = value ; }
		}
	}
}
