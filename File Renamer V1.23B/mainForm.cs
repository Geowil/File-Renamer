using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using File_Renamer_V1._23B.Properties;
using System.Security.AccessControl;
using System.Security.Principal;

namespace File_Renamer_V1._23B{
    public partial class fRenamer : Form{
        public fRenamer(){
            InitializeComponent();
            bAllFilesSelected = false;
            startingLetter = -1;
            startingInt = -1;
            selectedFiles = new List<string>();

            bReturnedError = false;
        }

        //Handle close request from File menu
        private void closeProg(object sender, EventArgs e){
            Application.Exit();
        }

        //Show program settings dialog
        private void openSettings(object sender, EventArgs e){
            progSettings pSettings = new progSettings(); //Create new reference for each call; no presistent data present
            pSettings.Show();
        }

        //Handle close button so that we can confirm the close based on setting
        protected override void OnFormClosing(FormClosingEventArgs e){
            //Get latest state of notify on close setting
            bool bNotifyOnClose = (bool)Settings.Default["usrWarnClose"];
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown){ //If Win is shutting down, don't display dialog
                return;
            } else if (bNotifyOnClose){
                //Confirm if user wants to close with or without saving
                switch (MessageBox.Show(this, "You are about to close the application.  Continue?", "Application Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true; //Interrupt original close request
                        break;

                    default:
                        //do nothing
                        break;
                }
            }
        }

        private void selectDir(object sender, EventArgs e){
            using (var selDir = new FolderBrowserDialog()){
                DialogResult result = selDir.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(selDir.SelectedPath)){
                    dirPath = selDir.SelectedPath;

                    files = Directory.GetFiles(selDir.SelectedPath);
                    populatFileList();
                }
            }
        }

        //Once done renaming, we must update the file list in case further renaming is wanted
        private void updateFileList(){
            files = Directory.GetFiles(dirPath);
            populatFileList();
        }

        //Handler for when user selects suffix via letter option
        private void rBtnLSuffChanged(object sender, EventArgs e){
            if (rBtnLSuff.Checked){
                cBoxLSuffix.Enabled = true;
            } else{
                //Reset controls and vars
                cBoxLSuffix.Enabled = false;
                startingLetter = -1;
                cBoxLSuffix.SelectedIndex = -1;
            }
        }

        //Handler for when user selects suffix via number option
        private void rBtnNumSuffChanged(object sender, EventArgs e){
            if (rBtnNumSuff.Checked){
                tBoxNumSuffix.Enabled = true;
            } else {
                //Reset controls and vars
                tBoxNumSuffix.Enabled = false;
                startingInt = -1;
                tBoxNumSuffix.Text = "";
            }
        }

        //Handler for when user selects no suffix option
        private void rBtnNoSuffChanged(object sender, EventArgs e){
            if (rBtnNoSuff.Checked){
                //Reset all option controlls and vars
                cBoxLSuffix.Enabled = false;
                tBoxNumSuffix.Enabled = false;

                startingLetter = -1;
                startingInt = -1;
                tBoxNumSuffix.Text = "";
                cBoxLSuffix.SelectedIndex = -1;
            }
        }

        //Handler to make sure user is entering valid input for Number Suffix
        private void tBoxNumSuffixChanged(object sender, EventArgs e){
            if ((tBoxNumSuffix.Text != "" || tBoxNumSuffix.Text != null) && rBtnNumSuff.Checked){
                try{
                    startingInt = Int32.Parse(tBoxNumSuffix.Text);

                    if (startingInt < 0){
                        MessageBox.Show(this, "You have entered an invalid number, please enter a number greater than -1.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } catch (FormatException){
                    MessageBox.Show(this, "The value you entered is not a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (OverflowException){ //Using text length limit, should not be needed but just in case something weird happens
                    MessageBox.Show(this, "There was an issue with the number you entered, please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
        }

        //Handler to set up var for user selected letter suffix
        private void cBoxLSuffixChanged(object sender, EventArgs e){
            startingLetter = cBoxLSuffix.SelectedIndex;
        }

        //Handler to ensure valid user input for root file name
        private void tBoxRFNameChanged(object sender, EventArgs e){
            if (tBoxRFName.Text != "" || tBoxRFName.Text != null){
                Regex badParts = new Regex("(^(PRN|AUX|NUL|CON|COM[1-9]|LPT[1-9]|(\\.+)$)(\\..*)?$)|(([‌\\\x00-\\\x1f\\?*:​‌​|/<>‌​])+)|(^([\\.]+‌​))|(^[\\])|(^[\"])", RegexOptions.IgnoreCase);

                if (badParts.IsMatch(tBoxRFName.Text)){
                    MessageBox.Show(this, "The value you entered for the file name is not valid.  Please re-enter the file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Process renaming files with the supplied user options/inputs
        private void renameFiles(object sender, EventArgs e){
            //First we need to get the checked file names
            getSelectedFiles();

            //Now check various conditions based on rename options, length of selectedFiles list, and other input data
            if (selectedFiles.Count == 0){
                MessageBox.Show(this, "You have not selected any files to rename.  Please select at least one file.", "Warning", MessageBoxButtons.OK);
                return;
            } else if (rBtnNoSuff.Checked && selectedFiles.Count > 1){
                MessageBox.Show(this, "You can only change one file when using the 'No Suffix' option.  Please unselect all but one file.", "Warning", MessageBoxButtons.OK);
                return;
            } else if (rBtnLSuff.Checked && startingLetter == -1){
                MessageBox.Show(this, "You have not chosen which letter to start on for the suffix.  Please select which letter you want to start renaming on or choose a different 'Renaming Option'.", "Warning", MessageBoxButtons.OK);
                return;
            } else if (rBtnLSuff.Checked && (52 - startingLetter) < selectedFiles.Count){
                int numOfLetters = 52 - startingLetter;
                MessageBox.Show(this, "You have selected to rename " + selectedFiles.Count.ToString() + " files but due to your starting letter selection there are only " + numOfLetters.ToString() + " letters available.  Please select fewer files to rename, a different starting letter, or a different 'Renaming Option'.", "Warning", MessageBoxButtons.OK);
                return;
            } else if (rBtnNumSuff.Checked && startingInt == -1){
                MessageBox.Show(this, "You have not entered a number to start on for the suffix.  Please enter the number you want to start renaming on or choose a different 'Renaming Option'.", "Warning", MessageBoxButtons.OK);
                return;
            } else if (tBoxRFName.TextLength == 0){
                MessageBox.Show(this, "You have not entered a new root file name.  Please the root file name to rename your file(s) to.", "Warning", MessageBoxButtons.OK);
                return;
            }

            //If execution passes all of the checks, continue based on renaming option selected
            /*if (rBtnLSuff.Checked)
            {

            } else if (rBtnNumSuff.Checked)
            {

            } else if (rBtnNoSuff.Checked)
            {

            }*/

            if ((bool)Settings.Default["autoOverwrite"]){
                switch (MessageBox.Show(this, "Overwrite Files setting is set to on.  Please be aware that any existing files with the same name as a new file name will be overwritten.  Do you wish to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)){
                    case DialogResult.No:
                        return;

                    default:
                        break;
                }
            }

            if (rBtnLSuff.Checked)
            {
                numCount = startingLetter;

                foreach (string oldFName in selectedFiles)
                {
                    //If there was an error on last iteration, break loop
                    if (bReturnedError)
                    {
                        break;
                    }
                    else {
                        string[] fileBits;
                        string fileName;
                        string fileExt;
                        string oldFPath;
                        string newFPath;
                        string newFName;

                        fileBits = oldFName.Split('.');

                        //First we need to handle the file name where multiple .'s exist
                        fileName = tBoxRFName.Text;
                        fileExt = fileBits.Last(); //Save the file extension; use Last in case of multiple .'s in the file name

                        //Next, append the suffix to the file name, extension, and increment the counter
                        newFName = fileName + cBoxLSuffix.Items[numCount].ToString();
                        newFName += "." + fileExt;

                        numCount += 1;

                        //Next append the old and new file names to the path and rename the file
                        oldFPath = dirPath + "\\" + oldFName;
                        newFPath = dirPath + "\\" + newFName;

                        //Some defensive programming.  Check to see if both source and destination files exist or not
                        if (File.Exists(oldFPath))
                        {
                            if (File.Exists(newFPath))
                            {
                                bReturnedError = renameByCopy(oldFPath, newFPath, fileExt, newFName);
                            }
                            else {
                                bReturnedError = renameByMove(oldFPath, newFPath, fileExt, newFName);
                            }
                        }
                        else {
                            MessageBox.Show(this, "The source file " + oldFName + " could not be located at " + dirPath + ".  Please ensure that it still exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            else if (rBtnNumSuff.Checked)
            {
                numCount = startingInt;

                foreach (string oldFName in selectedFiles)
                {
                    //If there was an error on last iteration, break loop
                    if (bReturnedError)
                    {
                        break;
                    }
                    else {
                        string[] fileBits;
                        string fileName;
                        string fileExt;
                        string oldFPath;
                        string newFPath;
                        string newFName;

                        fileBits = oldFName.Split('.');

                        //First we need to handle the file name where multiple .'s exist
                        fileName = tBoxRFName.Text;
                        fileExt = fileBits.Last(); //Save the file extension; use Last in case of multiple .'s in the file name

                        //Next, append the suffix to the file name, extension, and increment the counter
                        newFName = fileName + numCount.ToString();
                        newFName += "." + fileExt;

                        numCount += 1;

                        //Next append the old and new file names to the path and rename the file
                        oldFPath = dirPath + "\\" + oldFName;
                        newFPath = dirPath + "\\" + newFName;

                        //Some defensive programming.  Check to see if both source and destination files exist or not
                        if (File.Exists(oldFPath))
                        {
                            if (File.Exists(newFPath))
                            {
                                bReturnedError = renameByCopy(oldFPath, newFPath, fileExt, newFName);
                            }
                            else {
                                bReturnedError = renameByMove(oldFPath, newFPath, fileExt, newFName);
                            }
                        }
                        else {
                            MessageBox.Show(this, "The source file " + oldFName + " could not be located at " + dirPath + ".  Please ensure that it still exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            else if (rBtnNoSuff.Checked)
            {
                foreach (string oldFName in selectedFiles)
                {
                    //If there was an error on last iteration, break loop
                    if (bReturnedError)
                    {
                        break;
                    }
                    else {
                        string[] fileBits;
                        string fileName;
                        string fileExt;
                        string oldFPath;
                        string newFPath;
                        string newFName;

                        fileBits = oldFName.Split('.');

                        //First we need to handle the file name where multiple .'s exist
                        fileName = tBoxRFName.Text;
                        fileExt = fileBits.Last(); //Save the file extension; use Last in case of multiple .'s in the file name

                        //Next, append the suffix to the file name, extension, and increment the counter
                        newFName = fileName;
                        newFName += "." + fileExt;

                        numCount += 1;

                        //Next append the old and new file names to the path and rename the file
                        oldFPath = dirPath + "\\" + oldFName;
                        newFPath = dirPath + "\\" + newFName;

                        //Some defensive programming.  Check to see if both source and destination files exist or not
                        if (File.Exists(oldFPath))
                        {
                            if (File.Exists(newFPath))
                            {
                                bReturnedError = renameByCopy(oldFPath, newFPath, fileExt, newFName);
                            }
                            else {
                                bReturnedError = renameByMove(oldFPath, newFPath, fileExt, newFName);
                            }
                        }
                        else {
                            MessageBox.Show(this, "The source file " + oldFName + " could not be located at " + dirPath + ".  Please ensure that it still exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            if (!bReturnedError){
                
                MessageBox.Show(this, "The files have been successfully renamed.  The File List will now update...", "Success!", MessageBoxButtons.OK);
                updateFileList();
            } else{
                bReturnedError = false;
            }
        }

        //Allow button to enable or disable all checkboxes in DGV
        private void toggleFileSelect(object sender, EventArgs e){
            if (!bAllFilesSelected){
                toggleCBoxes(true);
                bAllFilesSelected = true;
            } else{
                toggleCBoxes(false);
                bAllFilesSelected = false;
            }
        }

        //Helper function to change all rows
        private void toggleCBoxes(bool bSelectFiles){
            foreach (DataGridViewRow row in dGVFileList.Rows){
                row.Cells[0].Value = bSelectFiles;
            }
        }

        //Helper function to get all selected files from DGV
        private void getSelectedFiles(){
            if (selectedFiles.Count > 0){
                selectedFiles.Clear(); //Clear this list each time so that any changes are captured
            }

            foreach (DataGridViewRow row in dGVFileList.Rows){
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value){ //Check for nulls in col 0
                    if (row.Cells[1].Value != null){ //Check for nulls in col 1
                        string[] fileBits;
                        string tempStore;
                        
                        tempStore = (string)row.Cells[1].Value; //Store file name temporarily
                        fileBits = tempStore.Split('\\'); //Split on hacks

                        //Get just the file name, not path
                        selectedFiles.Add(fileBits.Last());                        
                    }
                }
            }
        }

        private bool renameByCopy(string oldFPath, string newFPath, string fileExt, string fileName){
            //If the new file already exists, check the auto-overwrite bool and if true overwrite else display error
            if ((bool)Settings.Default["autoOverwrite"]){
                try{
                    File.Copy(oldFPath, newFPath, true);
                    fixPermissions(newFPath);
                } catch (Exception ex){
                    MessageBox.Show(this, "The file " + fileName + " could not be created at " + dirPath + " for the following reason: " + ex.Message + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            } else{
                MessageBox.Show(this, "The file " + fileName + " already exists at " + dirPath + ".  Please choose different renaming options or turn the 'Overwrite File' setting on and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private bool renameByMove(string oldFPath, string newFPath, string fileExt, string fileName){
            try{
                File.Move(oldFPath, newFPath);
                fixPermissions(newFPath);
            } catch (Exception ex){
                MessageBox.Show(this, "The file " + fileName + " could not be created at " + dirPath + " for the following reason: " + ex.Message + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private void populatFileList(){
            //check if there is already data in the list and if so, purge it
            if (dGVFileList.Rows.Count > 0){
                dGVFileList.Rows.Clear();
            }

            foreach (string file in files){
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGVFileList);

                row.Cells[1].Value = file;
                dGVFileList.Rows.Add(row);
            }
        }

        //Need this to deal with stupid permissions system in W7+; other wise new files won't be readable
        private void fixPermissions(string fullPath){
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }

        ////Members
        //Variables
        string[] files; //Store files found in selected directory
        int startingInt; //Store starting int for number suffix
        int startingLetter; //Store starting letter index for letter suffix
        bool bAllFilesSelected; //Used to toggle all files selected or not
        string dirPath; //Stores selected directory path before loading file list
        List<string> selectedFiles; //Stores only file list items which are selected
        int numCount; //Used to track int value for number/letter suffix while renaming
        bool bReturnedError; //This stores if any errors were returned during a renaming iteration
    }
}