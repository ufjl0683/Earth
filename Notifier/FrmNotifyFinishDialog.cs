using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RemoteInterface;

namespace Notifier
{
    public partial class FrmNotifyFinishDialog : Form
    {
        NotifyMessage[] mesgs;
        NotifyMessage[] origmesgs;
        public FrmNotifyFinishDialog(RemoteInterface.NotifyMessage[] mesgs)
        {
            InitializeComponent();
            this.origmesgs = mesgs;

             this.mesgs = new NotifyMessage[mesgs.Length];
             for (int i = 0; i < origmesgs.Length; i++)
             {
                 this.mesgs[i] = origmesgs[i].Clone();
             }



             foreach (Control ctl in this.Controls)
             {
                 if (ctl is CheckBox)
                 {
                     if (Convert.ToInt32(ctl.Tag) < mesgs.Length)
                         (ctl as CheckBox).Checked = mesgs[Convert.ToInt32(ctl.Tag)].IsFinish;
                     else
                         ctl.Visible = false;
                 }
             }

         
        }

        private void chkNext_CheckedChanged(object sender, EventArgs e)
        {

            mesgs[Convert.ToInt32((sender as CheckBox).Tag)].IsFinish = (sender as CheckBox).Checked;
        }

        private void FrmNotifyFinishDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            for (int i = 0; i < mesgs.Length; i++)
            {
                origmesgs[i].IsFinish = mesgs[i].IsFinish;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
