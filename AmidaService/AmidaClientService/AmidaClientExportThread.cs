using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using AmidaServerService;
//using AmidaClientServiceDll.AmidaService;
using System.ServiceModel;
using System.IO;
using AmidaClientService.AmidaService;

namespace AmidaClientService
{
    public class AmidaClientExportThread:AmidaClientService.AmidaService.IAmidaServiceCallback
    {
        bool bexit = false;
        AmidaClientService.AmidaService.AmidaServiceClient client;
    //   AmidaService.AmidaServiceClient client;//=new AmidaService.AmidaServiceClient(;//=new AmidaService.AmidaServiceClient(;
        public AmidaClientExportThread()
        {
         
          //  client=new myHost(new,
            new System.Threading.Thread(Task).Start();
        }

        public void Exit()
        {
            bexit = true;
        }
        void Task()
        {

            client = new myHost(new InstanceContext(this),"CustomBinding_IAmidaService");
          
            while (!bexit)
            {

                try
                {
                    string[] files = System.IO.Directory.GetFiles("c:\\export");
                    if (files.Length == 0)
                        continue;
                  
                    foreach (string file in files)
                    {
                        try
                        {
                            Type DestType = null;
                            System.IO.FileStream fs = null;
                            System.IO.FileInfo fileinfo = new System.IO.FileInfo(file);
                            //if (fileinfo.Length <= 0)
                            //    continue;
                            bool HasErr = true;
                            if (fileinfo.Length == 0)
                                continue;
                         
                            if (fileinfo.Extension.ToUpper()==".MDB")
                            {
                                // continue;
                              
                                System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=" + file);

                                try
                                {
                                    cn.Open();
                                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("select * from VerifyNote",cn);
                                    System.Data.OleDb.OleDbDataReader rd = cmd.ExecuteReader();
                                    while (rd.Read())
                                    {
                                        VerifyNoteData data = new VerifyNoteData();
                                        data.Fail = System.Convert.ToInt32(rd["Fail"]);
                                        data.MAP = rd["Map"].ToString();
                                        data.Operators = rd["Operators"].ToString();
                                        data.Pass = System.Convert.ToInt32(rd["Pass"]);
                                        data.PCID = rd["PCID"].ToString();
                                        data.RCP = rd["RCP"].ToString();
                                        data.StartTimes = System.Convert.ToDateTime(rd["StartTime"]);
                                        data.StopTimes = System.Convert.ToDateTime(rd["StopTime"]);
                                        data.TestVerify =rd["TestVerify"].ToString();
                                        data.TestVerifyDate = System.Convert.ToDateTime(rd["TestVerifyDate"]);
                                        data.TouchDo = System.Convert.ToInt64(rd["TouchDo"]);
                                        data.TPS = rd["TPS"].ToString();
                                        data.WaferID = rd["WaferID"].ToString();
                                        //AmidaService.AmidaServiceClient client = new AmidaService.AmidaServiceClient();
                                        System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(VerifyNoteData));
                                        MemoryStream ms=new MemoryStream();

                                        sr.Serialize(ms, data);
                                        
                                       // client.InsertIntoVerifyNote(data);
                                        client.ExportCommand(Environment.MachineName,"VerifyNoteData",System.Text.Encoding.UTF8.GetString(ms.ToArray()));
                                       // client.Close();
                                        HasErr = false;
                                    }

                                }
                                catch (Exception ex1)
                                {
                                    System.Diagnostics.EventLog verifylog = new System.Diagnostics.EventLog() { Source = "AmidaClientService" };
                                    verifylog.WriteEntry(ex1.Message + "," + ex1.StackTrace);
                                    Console.WriteLine(ex1.Message);
                                }
                                finally
                                {
                                    cn.Close();
                                }
                             

                            }
                            else
                             if (fileinfo.Name.ToUpper().StartsWith("VerifyNoteData".ToUpper()))
                             {

                                
                                    DestType = typeof(VerifyNoteData);

                                     string xmlcmd = System.IO.File.ReadAllText(file);
                                    //System.Xml.Serialization.XmlSerializer sz = new System.Xml.Serialization.XmlSerializer(DestType);
                                    //VerifyNoteData data = sz.Deserialize(fs) as VerifyNoteData;
                                    //Console.WriteLine(data.ToString());
                                   
                                  //  fs.Close();

                                 
                                  //  client.InsertIntoVerifyNote(data);
                                     client.ExportCommand(Environment.MachineName,"VerifyNoteData", xmlcmd);
                                   // client.Close();
                                    HasErr = false;
                                }
                            if (!HasErr)
                                  System.IO.File.Delete(file);
                        }
                        catch (Exception ex1)
                        {
                            if (client == null || client.State == CommunicationState.Faulted || client.State == CommunicationState.Closed)
                            {
                                client = new myHost(new InstanceContext(this), "CustomBinding_IAmidaService");
                            }
                            Util.WriteEventLog(ex1.Message);
                            Console.WriteLine(ex1.Message);
                        }
                    }

                  
                }
                catch (Exception ex)
                {


                    Util.WriteEventLog(ex.Message);
                    Console.WriteLine(ex.Message);
                    //System.Threading.Thread.Sleep(5000);
                }
                finally
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }
        }


        public void ReceivedCommand(string xmlCmd, InportCmdType cmdType,string LeadingFileName)
        {
            try
            {
                switch (cmdType)
                {

                    case InportCmdType.InportFile:
                        if (!System.IO.Directory.Exists("c:\\import"))
                            System.IO.Directory.CreateDirectory("c:\\import");
                        StreamWriter wr = System.IO.File.CreateText("c:\\import\\" + LeadingFileName + "-" + Guid.NewGuid().ToString()+".xml");
                        wr.Write(xmlCmd);
                        wr.Flush();
                        wr.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.WriteEventLog(ex.Message + "," + ex.StackTrace);
            }

           // throw new NotImplementedException();
        }

        public void SayHello(string hello)
        {
            Console.WriteLine("Host Say hello!");
          //  throw new NotImplementedException();
        }


        public void NotifyConnectionChanged()
        {
            throw new NotImplementedException();
        }


        public void NotifyClientExported(string PCName, string CmdType)
        {
           // throw new NotImplementedException();
        }


        public void NotifyStatusChanged(string pcname, RegisterDeviceInfo info)
        {
            throw new NotImplementedException();
        }
    }


    public class myHost : AmidaClientService.AmidaService.AmidaServiceClient
    {
        System.Threading.Timer tmr;
        public myHost(InstanceContext callbackInstance, string config)
            : base(callbackInstance,config)
        {
            tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Timeout), null, 1000 * 30, 1000 * 60);
            try
            {
                this.Register(Environment.MachineName,Service.DeviceType);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        
        void Timeout(object sender)
        {
            try
            {
                if (this.State == CommunicationState.Opened)
                    this.SayServerHello();
                else
                {
                    tmr.Change(System.Threading.Timeout.Infinite, 0);
                    //tmr.Dispose();
                }

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                    ;}
        }
        ~myHost()
        {
            try
            {
                tmr.Change(System.Threading.Timeout.Infinite, 0);
                tmr.Dispose();
            }
            catch { ;}
        }
    }
}
