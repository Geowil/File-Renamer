using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using File_Renamer_V1._23B.Properties;

namespace File_Renamer_V1._23B
{
    public partial class progSettings : Form
    {
        public progSettings(){
            InitializeComponent();

            //Load last saved settings
            bAlwaysOverwriteFiles = (bool)Settings.Default["autoOverwrite"];
            bNotifyOnClose = (bool)Settings.Default["usrWarnClose"];

            cBoxWOnClose.Checked = bNotifyOnClose;
            cBoxOEFiles.Checked = bAlwaysOverwriteFiles;
        }

        //Save changes and close dialog
        private void closePanel(object sender, EventArgs e){
            Settings.Default["usrWarnClose"] = bNotifyOnClose;
            Settings.Default["autoOverwrite"] = bAlwaysOverwriteFiles;
            Settings.Default.Save(); //Save any settings changes
            this.Dispose();
        }

        //Handle close button so that we can confirm the close without saving if changes were made
        protected override void OnFormClosing(FormClosingEventArgs e){
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown){ //If Win is shutting down, don't display dialog
                return;
            }  else if (bAlwaysOverwriteFiles != (bool)Settings.Default["autoOverwrite"] || bNotifyOnClose != (bool)Settings.Default["usrWarnClose"]){
                //Confirm if user wants to close with or without saving
                switch (MessageBox.Show(this, "Close settings panel without saving?", "Changes Present", MessageBoxButtons.YesNo)){
                    case DialogResult.No:
                        e.Cancel = true; //Interrupt original close event
                        MessageBox.Show(this, "Saving settings then closing the panel.", "Saving...", MessageBoxButtons.OK); //Tell the user we will save settings and then close
                        this.closePanel(this, e);
                        break;

                    default:
                        //Do nothing
                        break;
                }
            }
        }

        //If WONClose state changes, capture the change in settings defaults
        private void cBoxWOnCloseChanged(object sender, EventArgs e){
            bNotifyOnClose = cBoxWOnClose.Checked;
        }

        //If OEFiles state changes, capture the change in settings defaults
        private void cBoxOEFilesChanged(object sender, EventArgs e){
            bAlwaysOverwriteFiles = cBoxOEFiles.Checked;
        }

        //Members
        //Variables
        private bool bAlwaysOverwriteFiles; //Intermediary between settings and form controls
        private bool bNotifyOnClose; //Intermediary between settings and form controls
    }
}
