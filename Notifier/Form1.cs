using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using RemoteInterface;
using System.Configuration;

namespace Notifier
{

    public delegate  void InvokeDelegate(NotifyMessage mesg);
    public partial class Form1 : Form
    {

        System.Collections.Queue qNormal = new System.Collections.Queue();
        System.Collections.Queue qOther = new System.Collections.Queue();
        RemoteInterface.EventNotifyClient nClient;
        bool isVisible;
        bool HasNewMessage = false;
        NotifyMessage CurrentMessage;
        string MachineName;
        public Form1()
        {
            InitializeComponent();
            try
            {
                SettingsProperty temp = Properties.Settings.Default.Properties["MachineName"];
                MachineName = temp.DefaultValue.ToString();
            }
            catch
            {
                MachineName = System.Environment.MachineName;
            }
 
         //   this.dataGridView1.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Descending;
        
        }

        void nClient_OnConnect(object sender)
        {  
             nClient.RegistEvent(new RemoteInterface.NotifyEventObject(RemoteInterface.EventEnumType.Message,MachineName,null));
             NotifyMessage mesg=new NotifyMessage(){ TimeStamp=DateTime.Now, title="SYS", text="ORegist "+MachineName };
             this.BeginInvoke(new InvokeDelegate(InvokeTask), mesg);
        }

        void nClient_OnEvent(object sender, RemoteInterface.NotifyEventObject objEvent)
        {
            if(objEvent.EventObj is NotifyMessage)
            {
               NotifyMessage mesg= objEvent.EventObj as NotifyMessage;
               this.BeginInvoke(new InvokeDelegate(InvokeTask), mesg);
              
            }
            if (objEvent.type == EventEnumType.TEST)
            {
              System.Diagnostics.Debug.Print( DateTime.Now.ToShortDateString()+",test");
            }
            
           
          //  throw new NotImplementedException();
        }

        void InvokeTask(NotifyMessage mesg)
        {
            //if (dataSet11.tblMessageLog.Count == 20)
            //    dataSet11.tblMessageLog[0].Delete();
            //dataSet11.tblMessageLog.AddtblMessageLogRow(DateTime.Now, mesg.title, mesg.text);
            //dataSet11.AcceptChanges();
         //   this.dataGridView1.DataSource = dataSet11;
          //  this.dataGridView1.DataMember = "tblMessageLog";
         //   this.dataGridView1.Refresh();
            if(mesg.text.Trim().Length==0)
                return;

            char ctype=mesg.text[0];
             mesg.text=mesg.text.Substring(1);
             if (ctype == 'N')  //normal
             {
                 qNormal.Enqueue(mesg);
                 if (qNormal.Count > 5)
                     qNormal.Dequeue();
             }
             else
             {
                 qOther.Enqueue(mesg);
                 if (qOther.Count > 3)
                     qOther.Dequeue();
             }

            CurrentMessage = mesg;
         //   if(!isVisible)
                HasNewMessage = true;

    
            ShowTip(mesg.title, mesg.text);

            ShowNormals();
            ShowOthers();
          
        }

        void ShowOthers()
        {
           string strShow = "";
           int inx = 0;
            NotifyMessage[] others = new NotifyMessage[qOther.Count];

            qOther.CopyTo(others, 0);
            foreach (NotifyMessage m in others)
            {
                inx++;
                strShow +=m.TimeStamp.ToString("yyyyMMdd") + m.title + ":";
                strShow += m.text + "\r\n";

            }
            txtOther.Text = strShow;
        }
        void ShowNormals()
        {
            NotifyMessage[] normals = new NotifyMessage[qNormal.Count];
            qNormal.CopyTo(normals, 0);
            string strShow = "<html><body bgcolor=\"pink\">";
            int inx = 0;
            foreach (NotifyMessage m in normals)
            {
                inx++;
                if (m.IsFinish)
                {
                    strShow += "<strike><i><font color=\"red\">" + "Next " + inx + " From " + m.title + ":<br>";
                    strShow += m.text.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;") + "</font></i></strike>";
                }
                else
                {
                    strShow += "<b>Next " + inx + " From " + m.title + ":<br>";
                    strShow += m.text.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")+"</b>";
                }

            }

            strShow+="</body></html>";
        wb1.DocumentText = strShow;
        }
        //void nClient_OnConnect(object sender)
        //{
        //    nClient.OnEvent += new RemoteInterface.NotifyEventHandler(nClient_OnEvent);
        //    nClient.OnCommError += new EventHandler(nClient_OnCommError);
        //    //throw new NotImplementedException();
        //}

        //void nClient_OnCommError(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //void nClient_OnEvent(object sender, RemoteInterface.NotifyEventObject objEvent)
        //{
        //    throw new NotImplementedException();
        //}

        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory+"normal.ico");
            ShowNormals();
            
           // ShowTip("test", "a test");
        }

        void ShowTip(string title, string text)
        {
            

            notifyIcon1.BalloonTipTitle = title;
            this.notifyIcon1.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory+"warning.ico");
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.ShowBalloonTip(1000 * 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = this.Visible.ToString();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if(!isVisible)
                this.Hide();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (isVisible)
                HideForm();
            else
                ShowForm();
           
        }
        void ShowForm()
        {
            isVisible = true;
         //   HasNewMessage = false;
         //   this.notifyIcon1.Icon = new Icon("normal.ico");
            Screen screen = System.Windows.Forms.Screen.FromControl(this);
            this.Location = new Point(screen.WorkingArea.Width - this.Width, screen.WorkingArea.Height - this.Height-50);
            this.Show();
        }

        void  HideForm()
        {
            isVisible = false;
         //   HasNewMessage = false;
         //   this.notifyIcon1.Icon = new Icon("normal.ico");
          //  this.WindowState = FormWindowState.Maximized;
          //  Screen screen = System.Windows.Forms.Screen.FromControl(this);
           // this.Location = new Point(screen.WorkingArea.Width - this.Width, screen.WorkingArea.Height - this.Height - 50);
            this.Hide();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true; ;
            //isVisible = false;

            //this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(HasNewMessage)
                ShowTip(this.CurrentMessage.title, CurrentMessage.text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HideForm();
        }

        private void txtOther_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNormal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.HasNewMessage = false;
            this.notifyIcon1.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory+"normal.ico");

        }

        //private void txtNormal_DoubleClick(object sender, EventArgs e)
        //{
        //     NotifyMessage[] normals = new NotifyMessage[qNormal.Count];
        //    qNormal.CopyTo(normals,0);
        //    FrmNotifyFinishDialog diallog=new FrmNotifyFinishDialog(normals);
        //     diallog.StartPosition= FormStartPosition.CenterScreen;
        //     if (diallog.ShowDialog() == DialogResult.Cancel)
        //        return;
        //    ShowNormals();
        //}

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifyMessage[] normals = new NotifyMessage[qNormal.Count];
            qNormal.CopyTo(normals, 0);
            FrmNotifyFinishDialog diallog = new FrmNotifyFinishDialog(normals);
            diallog.StartPosition = FormStartPosition.CenterScreen;
            if (diallog.ShowDialog() == DialogResult.Cancel)
                return;
            ShowNormals();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            (sender as Timer).Stop();
         //   (sender as Timer).Enabled = false;
            nClient = new RemoteInterface.EventNotifyClient(
        Properties.Settings.Default.ServiceIP, 9091, true
       );
            nClient.OnEvent += new RemoteInterface.NotifyEventHandler(nClient_OnEvent);
            nClient.OnConnect += new RemoteInterface.OnConnectEventHandler(nClient_OnConnect);
            ShowNormals();
        }
    }
}
