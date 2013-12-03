﻿using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
//using AmidaServerService;
using AmidaClientService20;//.AmidaService;
//using System.ServiceModel;
using System.IO;
using RemoteInterface;

using System.Collections;
using AmidaClientService20.Messages;

namespace AmidaClientService20
{
    public class AmidaClientExportThread
    {
        bool bexit = false;

        EventNotifyClient NotifyClient;
        RemoteInterface.IAmidaService IAmidaService;
       // AmidaClientServiceDll.AmidaService.AmidaServiceClient client;
    //   AmidaService.AmidaServiceClient client;//=new AmidaService.AmidaServiceClient(;//=new AmidaService.AmidaServiceClient(;
        public AmidaClientExportThread()
        {
            //try
            //{
                
                IAmidaService = RemoteInterface.RemoteBuilder.GetRemoteObj(typeof(IAmidaService),
                    RemoteInterface.RemoteBuilder.getRemoteUri(AmidaClientService20.Service.DestIP, 9090, "AmidaService")) as IAmidaService;
#if WANA
                IAmidaService.Register(Environment.MachineName, "WANA");
#else
                IAmidaService.Register(Environment.MachineName, "TESTER");
#endif
                NotifyClient = new EventNotifyClient();
                NotifyClient.OnConnect += new OnConnectEventHandler(NotifyClient_OnConnect);
                NotifyClient.OnCommError += new EventHandler(NotifyClient_OnCommError);
                NotifyClient.Connect(AmidaClientService20.Service.DestIP, 9091);

                //  client=new myHost(new,
                new System.Threading.Thread(Task).Start();
            //}
            //catch (Exception ex)
            //{
            //    Util.WriteEventLog(ex.Message + "," + ex.StackTrace);
            //}
           
        }

        void NotifyClient_OnCommError(object sender, EventArgs e)
        {
            //if (this.NotifyClient != null)
            //{
            //NotifyClient.OnConnect -= new OnConnectEventHandler(NotifyClient_OnConnect);
            //NotifyClient.OnCommError -= new EventHandler(NotifyClient_OnCommError);
            NotifyClient.OnEvent -= new NotifyEventHandler(NotifyClient_OnEvent);
            //    try
            //    {
            //        NotifyClient.close();
            //    }
            //    catch { ;}
            //}

            //NotifyClient = new EventNotifyClient();
            //NotifyClient.OnConnect += new OnConnectEventHandler(NotifyClient_OnConnect);
            //NotifyClient.OnCommError += new EventHandler(NotifyClient_OnCommError);
        }

        void NotifyClient_OnEvent(object sender, NotifyEventObject objEvent)
        {
            if (objEvent.type == EventEnumType.InportCommand)
            {

                RemoteInterface.Inport.InportCommand cmd = objEvent.EventObj as RemoteInterface.Inport.InportCommand;
                this.ReceivedCommand(cmd.xmlcmd, InportCmdType.InportFile, cmd.leadingFilename);

            }
            else if (objEvent.type == EventEnumType.TEST)
            {
                Console.WriteLine("test from server!");
            }
            


          //  throw new NotImplementedException();
        }

        void NotifyClient_OnConnect(object sender)
        {
           // throw new NotImplementedException();
            //if (NotifyClient.OnEvent == null)
            //{
                NotifyClient.OnEvent += new NotifyEventHandler(NotifyClient_OnEvent);
            //}
                NotifyClient.RegistEvent(new NotifyEventObject(EventEnumType.InportCommand, Environment.MachineName, null));
            IAmidaService.Register(Environment.MachineName, "TESTER");
 
        
        }

        public void Exit()
        {
            bexit = true;
        }
        void Task()
        {
            bool isPending = false;
            bool isPendfingChanged = false;
          //  client = new myHost(new InstanceContext(this),"CustomBinding_IAmidaService");
          
            while (!bexit)
            {
               
                try
                {
                    string[] files = System.IO.Directory.GetFiles("c:\\export");

                    if (files.Length == 0)
                    {
                        isPendfingChanged = isPending == false;
                        isPending = false;
                        if (isPendfingChanged)
                            IAmidaService.ReportExportPending(Environment.MachineName, isPending);
                        continue;
                    }
                    System.Collections.Generic.List<string> list = new List<string>();
                    foreach (string filename in files)
                        list.Add(filename);

                    list.Sort(new FileComparer());

                    files = list.ToArray();
                 
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
                                        

                                      //check here
                                       IAmidaService.ExportCommand(Environment.MachineName,"VerifyNoteData"/*fileinfo.Name*/,System.Text.Encoding.UTF8.GetString(ms.ToArray()));
                                       
                                        HasErr = false;
                                    }

                                }
                                catch (Exception ex1)
                                {
                                    try
                                    {
                                        System.Diagnostics.EventLog verifylog = new System.Diagnostics.EventLog() { Source = "AmidaClientService" };
                                        verifylog.WriteEntry(ex1.Message + "," + ex1.StackTrace);
                                    }
                                    catch { ;}
                                    Console.WriteLine(ex1.Message);
                                }
                                finally
                                {
                                    cn.Close();
                                }
                             

                            }
                            else
                             if (fileinfo.Extension.ToUpper()==".XML")
                             {
                                
                                // check here
                                //    DestType = typeof(AmidaService.VerifyNoteData);

                                     string xmlcmd = System.IO.File.ReadAllText(file);
                                   

                                 
                                 // check here
                                 //    client.ExportCommand("VerifyNoteData", xmlcmd);
                                     IAmidaService.ExportCommand(Environment.MachineName,file, xmlcmd);
                                    HasErr = false;
                                    isPendfingChanged = isPending != false;
                                    isPending = false;
                                }

                            if (!HasErr)
                                  System.IO.File.Delete(file);
                        }
                        catch (Exception ex1)
                        {
                            //if (client == null || client.State == CommunicationState.Faulted || client.State == CommunicationState.Closed)
                            //{
                            //    client = new myHost(new InstanceContext(this), "CustomBinding_IAmidaService");
                            //}
                            try
                            {
                                try
                                {
                                    Util.WriteEventLog(ex1.Message);
                                }
                                catch { ;}
                                //try
                                //{
                                //    IAmidaService.ReportExportPending(Environment.MachineName, true);
                                //}
                                //catch { ;}
                                isPendfingChanged = isPending != true;
                                isPending = true;
                                break;
                            }
                            catch { ;}
                            Console.WriteLine(ex1.Message);
                        }
                    }  //for
                    try
                    {
                        if(isPendfingChanged)
                             IAmidaService.ReportExportPending(Environment.MachineName, isPending);
                    }
                    catch { ;}

                }
                catch (Exception ex)
                {
                    try
                    {

                        Util.WriteEventLog(ex.Message);
                    }
                    catch { ;}
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
                try
                {
                    Util.WriteEventLog(ex.Message + "," + ex.StackTrace);
                }
                catch { ;}
            }

           // throw new NotImplementedException();
        }

        public void SayHello(string hello)
        {
            Console.WriteLine("Host Say hello!");
          //  throw new NotImplementedException();
        }
    }

    public class FileComparer : IComparer<string>
    {
       
     
        public int Compare(string x, string y)
        {
            try
            {

                if ((System.IO.File.GetLastWriteTime(x) - System.IO.File.GetLastWriteTime(y)).TotalMilliseconds > 0)
                    return 1;
                else if ((System.IO.File.GetLastWriteTime(x) - System.IO.File.GetLastWriteTime(y)).TotalMilliseconds < 0)
                    return -1;
                else
                    return 0;
               // return (long)(System.IO.File.GetLastWriteTime(x) - System.IO.File.GetLastWriteTime(y)).TotalMilliseconds;
            }
            catch
            {
                return int.MaxValue;
            }
        }
    }

    //public class myHost : AmidaClientServiceDll.AmidaService.AmidaServiceClient
    //{
    //    System.Threading.Timer tmr;
    //    public myHost(InstanceContext callbackInstance, string config)
    //        : base(callbackInstance,config)
    //    {
    //        tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Timeout), null, 1000 * 30, 1000 * 60);
    //        try
    //        {
    //            this.Register(Environment.MachineName,"TESTER");
    //        }
    //        catch(Exception ex) {
    //            Console.WriteLine(ex.Message);
    //        }

    //    }

        
    //    void Timeout(object sender)
    //    {
    //        try
    //        {
    //            if (this.State == CommunicationState.Opened)
    //                this.SayServerHello();
    //            else
    //            {
    //                tmr.Change(System.Threading.Timeout.Infinite, 0);
    //                //tmr.Dispose();
    //            }

    //        }
    //        catch(Exception ex) {
    //            Console.WriteLine(ex.Message);
    //                ;}
    //    }
    //    ~myHost()
    //    {
    //        try
    //        {
    //            tmr.Change(System.Threading.Timeout.Infinite, 0);
    //            tmr.Dispose();
    //        }
    //        catch { ;}
    //    }
    //}
}