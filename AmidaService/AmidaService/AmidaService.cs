using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AmidaService;
using AmidaClientService20.Messages;
using AmidaService.Messages;
using System.Diagnostics;

namespace AmidaServerService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的類別名稱 "Service1"。
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)] 
    public class AmidaService : IAmidaService
    {
        public System.Collections.Generic.Dictionary<string, RegisterData> dictClientCallBacks = new Dictionary<string, RegisterData>();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public AmidaService()
        {
            new System.Threading.Thread(CheckConnectionTask).Start();
        }

        void CheckConnectionTask()
        {
            while (true)
            {
                try
                {
                    foreach (KeyValuePair<string, RegisterData> pair in dictClientCallBacks.ToArray())
                    {
                        try
                        {
                            if(pair.Value.Callback != null)
                            pair.Value.Callback.SayHello("hello");
                            //else
                            //{
                            //    if (!Service.NotifyServer.IsRegistered(pair.Value.info.PcName))
                            //        throw new Exception("device not found!");
                            //}
                                
                                //.NotifyAll(
                                //new RemoteInterface.NotifyEventObject( RemoteInterface.EventEnumType.TEST,pair.Value.PcName,"TEST"));
                               
                            
                        }
                        catch
                        {
                            dictClientCallBacks.Remove(pair.Key);
                         //   NotifyAllConnetedChange();
                            Console.WriteLine(pair.Key + " dead , Remove!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                System.Threading.Thread.Sleep(1000 * 60);
            }
        }
        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}


         void InsertIntoStatusChangeLog(ReportStatusChangedData data)
        {


        }


        public void InsertIntoVerifyNote(VerifyNoteData data)
        {
          AmidaEntities db = new AmidaEntities();
            tblVerifyNote note = new tblVerifyNote()
            {
                 Fail=data.Fail,
                  MAP=data.MAP,
                   Operators=data.Operators,
                    Pass=data.Pass,
                     PCID=data.PCID,
                      RCP=data.RCP,
                       StartTimes=data.StartTimes,
                        StopTimes=data.StopTimes,
                         TestVerify=data.TestVerify,
                         TestVerifyDate=data.TestVerifyDate,
                          TouchDo=data.TouchDo,
                           TPS=data.TPS,
                            WaferID=data.WaferID,
                             HasWarning=data.HasWarning,
                         //     WarningType=(int)data.WarningType,
                               ProbeShape=data.ProbeShape,
                               over_drive=data.OverDrive
                              

               
            };
            db.AddTotblVerifyNote(note);
            db.SaveChanges();

           // throw new NotImplementedException();
        }

        public void RegisterFromRemoting(string PcName, string DeviceType) // register from Tester
        {
                RegisterData regdata = new RegisterData() { Callback = null, info = new RegisterDeviceInfo() { PcName = PcName.ToUpper(), DeviceType = DeviceType.ToUpper(), ConnectedTime = System.DateTime.Now, Status = "Idle",StatusBeginTime=DateTime.Now } };
                 AmidaEntities db = new AmidaEntities();
                 tblEQ q = (from n in db.tblEQ where n.eqi_id == PcName select n).FirstOrDefault<tblEQ>();
                 Console.WriteLine(PcName + "," + DeviceType);
                 if (q == null)
                 {


                     tblEQHistory eqhist = new tblEQHistory();
                     eqhist.eq_id = PcName;
                     eqhist.start_time = DateTime.Now;
                     eqhist.status = "Idle";
                     eqhist.total_num_wafer = 0;
                     db.tblEQHistory.AddObject(eqhist);
                     db.SaveChanges();
                     db.AcceptAllChanges();

                     db.tblEQ.AddObject(new tblEQ()
                     {
                         eqi_id = PcName,
                         eq_release_time = DateTime.Now,
                         start_time = DateTime.Now,
                         status = "Idle",
                         tested_num_chip = 0,
                         tested_num_wafer = 0,

                         IsWarnig = "N",
                         total_num_chip = 0,
                         total_num_wafer = 0,
                         current_identify = eqhist.identify

                     }
                    );
                 }

                 db.SaveChanges();
                 db.AcceptAllChanges();
            
            if (!dictClientCallBacks.ContainsKey(regdata.Key))
            {
                if (q != null)
                {

                    regdata.info.eq_area = q.eq_area;
                    regdata.info.CurrentWaferId = q.current_test_wafer_id;
                    regdata.info.lot_id = q.lot_id;
                    regdata.info.eq_comment = q.eq_comment;
                    regdata.info.ProbeCardId = q.probe_card_id;
                    regdata.info.Status = q.status;
                    regdata.info.StatusBeginTime = (DateTime)q.start_time;
                    regdata.info.total_num_chip = q.total_num_chip;
                    regdata.info.eq_prober = q.eq_prober;
                    regdata.info.total_num_wafer = q.total_num_wafer;
                    regdata.info.tested_num_chip = q.tested_num_chip;
                    regdata.info.tested_num_wafer = q.tested_num_wafer;

                  //  regdata.info.ststart_time = (DateTime)q.start_time;
                    
                        
                    //    = new RegisterDeviceInfo()
                    //{
                    //    eq_area = q.eq_area,
                    //    CurrentWaferId = q.current_test_wafer_id,
                    //    lot_id = q.lot_id,
                    //    eq_comment = q.eq_comment,
                    //    ProbeCardId = q.probe_card_id,
                    //    Status = q.status,
                    //    StatusBeginTime = (DateTime)q.start_time,
                    //    total_num_chip = q.total_num_chip,
                    //    eq_prober = q.eq_prober,
                    //    total_num_wafer = q.total_num_wafer,
                    //    tested_num_chip = q.tested_num_chip,
                    //    tested_num_wafer = q.tested_num_wafer,
                    //     PcName=q.eqi_id

                    //};

                    if(q.IsWarnig=="Y")
                    {
                        tblAlarm alarm=(from n in db.tblAlarm where n.identify== q.current_warning_identify   select n).FirstOrDefault();
                         if(alarm!=null)
                         {
                        regdata.info.WarningMessage= alarm.warning_message;
                        regdata.info.WarningType=(int)alarm.warning_type;
                        regdata.info.WarningBeginTime=(DateTime)alarm.start_time;
                        
                         }


                    }
                }
               
                Console.WriteLine("client:" + regdata.Key + ",Registered!,total connection:" + dictClientCallBacks.Count);
                dictClientCallBacks.Add(regdata.Key, regdata);

                 
            }
            //else
            //    dictClientCallBacks[regdata.Key] = regdata;

       

         
          
            
           
            if (DeviceType != "CONSOLE")
                 NotifyAllConnetedChange();
        }
        public void Register(string PcName,string DeviceType)
        {
            try
            {
                RegisterData regdata = new RegisterData() { Callback = OperationContext.Current.GetCallbackChannel<ICallBack>(), info = new RegisterDeviceInfo() { PcName = PcName, DeviceType = DeviceType, ConnectedTime = System.DateTime.Now } };

                if (!dictClientCallBacks.ContainsKey(regdata.Key))

                    dictClientCallBacks.Add(regdata.Key, regdata);
                else
                    dictClientCallBacks[regdata.Key] = regdata;

                if (DeviceType != "CONSOLE")
                    NotifyAllConnetedChange();
                Console.WriteLine("client:" + regdata.Key + ",Registered!,total connection:" + dictClientCallBacks.Count);
                // throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>(ex.Message + "," + ex.StackTrace);
            }
        }


        void NotifyAllConnetedChange()
        {
            foreach (RegisterData data in dictClientCallBacks.Values.ToArray())
            {
                if (data.info.DeviceType == "CONSOLE")
                {
                    try
                    {
                        data.Callback.NotifyConnectionChanged();
                    }
                    catch { ;}
                }
            }

        }

        void NotifyAllYieldChanged(string pcname, double yield, string lotid)
        {
            foreach (RegisterData data in dictClientCallBacks.Values.ToArray())
            {
                if (data.info.DeviceType == "CONSOLE")
                {
                    try
                    {
                        data.Callback.NotifyClientYieldChange(pcname, yield, lotid);
                    }
                    catch { ;}
                }
            }
        }
        void NotifyAllExportedCommand(string pcname,string cmdtype)
        {
            foreach (RegisterData data in dictClientCallBacks.Values.ToArray())
            {
                if (data.info.DeviceType == "CONSOLE")
                {
                    try
                    {
                        data.Callback.NotifyClientExported(pcname, cmdtype);
                    }
                    catch { ;}
                }
            }
        }
        void NotifyAllStatusChange(string PcName, RegisterDeviceInfo info)
        {
            var q = dictClientCallBacks.Where(n => n.Value.info.DeviceType == "CONSOLE");
            foreach (KeyValuePair<string, RegisterData> pair in q.ToArray())
            {
                try
                {
                    GetEq_Comment(info);
                    pair.Value.Callback.NotifyStatusChanged(PcName, info);
                }
                catch
                { ;}
            }
        }

        public  void GetEq_Comment(RegisterDeviceInfo info)
        {
            AmidaEntities db = new AmidaEntities();
            tblEQ data = db.tblEQ.Where<tblEQ>(n => n.eqi_id == info.PcName).FirstOrDefault<tblEQ>();
            if (data != null)
            {
                info.eq_comment = data.eq_comment;
                info.eq_area = data.eq_area;
                info.eq_prober = data.eq_prober;
                info.eq_type = data.eq_type;
            }
            
        }
        public void SayServerHello()
        {
            //throw new NotImplementedException();
        }


        public RegisterDeviceInfo[] GetAllConnectionInfo()
        {
            try
            {
                var res = from n in dictClientCallBacks.Values.ToArray<RegisterData>()
                          where n.info.DeviceType == "TESTER"
                          orderby n.info.DeviceType, n.info.PcName
                          select n.info;
                foreach (RegisterDeviceInfo info in res)
                    GetEq_Comment(info);
                return res.ToArray<RegisterDeviceInfo>();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>(ex.Message + "," + ex.StackTrace);
            }
        }


        public void ExportCommand(string PcName,string cmdType, string xml)
        {
           // throw new NotImplementedException();

            try
            {
                if (!dictClientCallBacks.ContainsKey(PcName+"-TESTER"))
                    RegisterFromRemoting(PcName, "TESTER");

                System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml));
                if (cmdType.Contains("VerifyNoteData"))
                {
                    System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(VerifyNoteData));
                    VerifyNoteData data = sr.Deserialize(ms) as VerifyNoteData;
                    InsertIntoVerifyNote(data);
                    if (data.TestVerify.ToUpper().Trim() == "TEST" || data.TestVerify.ToUpper().Trim().Contains("VERIFY"))
                    {
                        string lotid = data.WaferID.Split(new char[] { '_' })[0];
                        double yield = (double)data.Pass / (data.Pass+data.Fail)*100.0;
                        if (!dictClientCallBacks.ContainsKey(data.RCP.ToUpper() + "-TESTER"))
                            return;
                        RegisterData inf = dictClientCallBacks[data.RCP.ToUpper() + "-TESTER"];

                        if (inf.info.lot_id == null || inf.info.lot_id == "")
                            return;

                        if (inf.info.lot_id!=lotid)
                            return;
                        if (inf.info.Status != "Product" && inf.info.Status != "Verify")
                            return;
                        try
                        {
                            NotifyAllYieldChanged(data.RCP, yield, lotid);
                        }
                        catch (Exception ex1)
                        {
                            Console.WriteLine(ex1.Message);
                        }
                       if( dictClientCallBacks.ContainsKey(data.RCP.ToUpper()+"-TESTER")    )
                       {
                          // RegisterData inf = dictClientCallBacks[data.RCP.ToUpper() + "-TESTER"];
                           inf.info.yield = yield;
                           
                         //  dictClientCallBacks[data.RCP.ToUpper() + "-TESTER"].info.yield = yield;
                        
                       }
                    }
                  
                   

                //    NotifyAllStatusChange(PcName, cmdType);
                    //var q = dictClientCallBacks.Where(n => n.Value.DeviceType == "CONSOLE");
                    //foreach (KeyValuePair<string, RegisterData> pair in q.ToArray())
                    //{
                    //    try
                    //    {
                    //        pair.Value.Callback.NotifyClientExported(PcName, cmdType);
                    //    }
                    //    catch
                    //    { ;}
                    //}
                }
                else if (cmdType.Contains("ReportProgress"))
                {
                    System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(ReportProgressData));
                    ReportProgressData data = sr.Deserialize(ms) as ReportProgressData;
                    AmidaEntities db = new AmidaEntities();
                    tblEQ eq = (from n in db.tblEQ where n.eqi_id == data.eq_id select n).FirstOrDefault<tblEQ>();
                    if (eq == null)
                        return;
                    eq.tested_num_chip = data.tested_num_chip;
                    eq.tested_num_wafer = data.tested_num_wafer;
                    eq.total_num_chip = data.total_num_chip;
                    //   eq.total_num_wafer = data.total_num_wafer;
                    if (eq.status == "Product")
                    {
                        if (data.tested_num_chip != 0)
                            eq.expected_remain_time = (int)data.timestamp.Subtract(System.Convert.ToDateTime(eq.start_time)).TotalMinutes * (data.total_num_chip - data.tested_num_chip) / data.tested_num_chip;
                        else
                            eq.expected_remain_time = -1;
                    }
                    else if (eq.status == "Verify")
                    {
                        string maskID = data.current_test_wafer_id.Split(new char[] { '-' })[0];
                       // int totalVerifyMin = 0;
                        tblVerifyTimeRef timeref = db.tblVerifyTimeRef.Where(n => n.MaskID == maskID).FirstOrDefault();
                        if (timeref == null)
                            eq.expected_remain_time = -1;
                        else
                        {
                            eq.expected_remain_time = timeref.Minutes * (data.total_num_wafer-data.tested_num_wafer);

                        }

                    }
                    else
                        eq.expected_remain_time = -1;
                    db.SaveChanges();
                    db.AcceptAllChanges();

                    if (dictClientCallBacks.ContainsKey(data.eq_id.ToUpper()+"-TESTER"))
                    {
                        RegisterDeviceInfo info = (dictClientCallBacks[data.eq_id.ToUpper() + "-TESTER"] as RegisterData).info;
                        info.tested_num_chip = data.tested_num_chip;
                        info.tested_num_wafer = data.tested_num_wafer;
                        info.total_num_chip = data.total_num_chip;
                        info.total_num_wafer = data.total_num_wafer;
                        info.TimeRemain = (double)eq.expected_remain_time; //min
                        info.Status = data.status;
                        info.CurrentWaferId = data.current_test_wafer_id;
                      if (info.Status.Trim().ToUpper() == "PRODUCT" && info.total_num_chip != 0)
                        {
                            info.Progress = (double)info.tested_num_chip*100 / info.total_num_chip ;
                        }
                      else if (info.Status.Trim().ToUpper() == "VERIFY"  && info.total_num_wafer!=0 )
                      {
                          info.Progress = (double)info.tested_num_wafer*100 / info.total_num_wafer;
                      }
                      else

                          info.Progress = 0;

                      if (info.Progress > 100)
                          info.Progress = 100;
                      Console.WriteLine(info.PcName + ":Remain time " + info.TimeRemain);
                        NotifyAllStatusChange(PcName,info);
                        
                    }

                   

                }
                else if (cmdType.Contains("ReportStatusChanged"))
                {
                    System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(ReportStatusChangedData));
                    ReportStatusChangedData data = sr.Deserialize(ms) as ReportStatusChangedData;
                    AmidaEntities db = new AmidaEntities();
                    tblEQ eq = (from n in db.tblEQ where n.eqi_id == data.eq_id select n).FirstOrDefault<tblEQ>();
                    if (eq == null)
                        return;
                    

                    tblEQHistory eqhist = null;
                    if (eq.current_identify != null)
                        eqhist = (from n in db.tblEQHistory where n.identify == eq.current_identify select n).FirstOrDefault<tblEQHistory>();

                    if (eqhist != null)
                    {
                        if (data.eq_status != "Idle" && eqhist.status == "Idle" || data.eq_status == "Idle" && (eqhist.status != data.eq_status  || eqhist.sub_status!=data.sub_status )    ) //狀態不同才寫
                        {
                            eqhist.stop_time = data.start_time;
                            eqhist.IsFinish = true;
                            eqhist.wafer_id_out = data.wafer_id;
                            eqhist.over_drive_out = data.over_drive;
                            if (data.eq_status == "Idle")
                                eqhist.tested_num_wafer = data.total_num_wafer;
                        }
                        else
                        {
                            eqhist.stop_time = data.start_time;
                        }
                    }

                    tblEQHistory newHist = new tblEQHistory()
                    {
                        eq_id = data.eq_id,
                        lot_id = data.lot_id,
                        probe_card_id = data.probe_card_id,
                        recipe = data.recipe,
                        start_time = data.start_time,
                        total_num_wafer = data.total_num_wafer,
                        status = data.eq_status,
                       

                        IsFinish = false,
                        @operator = data.eq_operator,
                         sub_status=data.sub_status,
                        over_drive_in=data.over_drive,
                        wafer_id_in=data.wafer_id
                    };
                    db.tblEQHistory.AddObject(newHist);
                    db.SaveChanges();
                    eq.lot_id = data.lot_id;
                    eq.current_identify = newHist.identify;
                    eq.probe_card_id = data.probe_card_id;
                    eq.status = data.eq_status;
                    eq.recipe = data.recipe;
                    eq.start_time = data.start_time;
                    eq.total_num_wafer = data.total_num_wafer;
                    eq.@operator = data.eq_operator;
                    eq.sub_status=data.sub_status;
                    eq.over_drive=data.over_drive;
                    eq.wafer_id = data.wafer_id;
                  //  data.Wafer_ID=data.Wafer_ID;
                    db.SaveChanges();
                    db.AcceptAllChanges();
                    if (dictClientCallBacks.ContainsKey(data.eq_id.ToUpper() +"-TESTER"))
                    {
                        RegisterDeviceInfo info = (dictClientCallBacks[data.eq_id.ToUpper() + "-TESTER"] as RegisterData).info;
                        info.tested_num_chip =0;
                        info.tested_num_wafer =0;
                        info.total_num_chip = 0;
                        info.total_num_wafer = data.total_num_wafer;
                        //if (info.Status == "Verify")
                        //{
                        //    string maskID = eq.lot_id.Split(new char[] { '-' })[0];
                        //    //int totalVerifyMin = 0;
                        //    tblVerifyTimeRef timeref = db.tblVerifyTimeRef.Where(n => n.MaskID == maskID).FirstOrDefault();
                        //    if (timeref == null)
                        //        eq.expected_remain_time = -1;
                        //    else
                        //    {
                        //        eq.expected_remain_time = timeref.Minutes;
                        //    }
                        //}
                        //else
                            info.TimeRemain = -1; //min
                        info.Status = data.eq_status;
                        info.SubStatus = data.sub_status;
                       // if(info.Status
                       // info.lot_id = data.lot_id;
                        info.CurrentWaferId ="";
                        info.lot_id=data.lot_id;
                        info.StatusBeginTime = data.start_time;
                      //  info.TimeRemain = -1;
                        if(info.Status !="Product" &&  info.Status!="Verify")
                            info.yield=0;
                        //if (info.Status == "Product" && info.total_num_chip != 0)
                        //{
                        //    info.Progress = info.tested_num_chip / info.total_num_chip * 100;
                        //}
                        //else
                            info.Progress = 0;
                            info.ProbeCardId = data.probe_card_id;
                          //if(data.eq_status=="Idle")   //if idle force warning messgae state finish  2013/1/17
                          //    info.WarningMessage="";

                            NotifyAllStatusChange(PcName, info);
                    }

                   

                   

                }
                else if (cmdType.Contains("WarningMessage"))
                {
                    System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(ReportWarningData));
                    ReportWarningData data = sr.Deserialize(ms) as ReportWarningData;
                    AmidaEntities db = new AmidaEntities();

                    if (!data.isfinished)
                    {
                        tblAlarm alarm = new tblAlarm()
                        {
                            eq_id = data.eq_id,
                            start_time = data.timestamp,
                            warning_message = data.warning_message,
                            warning_type = data.warning_type,
                             eq_operator=data.eq_operator,
                              probe_card_id=data.probe_card_id,
                               WaferID=data.WaferID
                        };
                        db.tblAlarm.AddObject(alarm);
                        db.SaveChanges();
                        db.AcceptAllChanges();
                        tblEQ eq = (from n in db.tblEQ where n.eqi_id == data.eq_id select n).FirstOrDefault();
                        if (eq != null)
                        {
                            eq.IsWarnig = "Y";
                            eq.current_warning_identify = alarm.identify;
                        }
                        db.SaveChanges();
                        db.AcceptAllChanges();


                    }
                    else
                    {

                        tblEQ eq = (from n in db.tblEQ where n.eqi_id == data.eq_id select n).FirstOrDefault();
                        if (eq != null)
                        {
                            tblAlarm alarm = db.tblAlarm.Where<tblAlarm>(n => n.identify == eq.current_warning_identify).FirstOrDefault();
                            if (alarm != null)
                            {
                                eq.IsWarnig = "N";

                                alarm.end_time = data.timestamp;
                                db.SaveChanges();
                                db.AcceptAllChanges();
                            }


                        }
                    }

                    if (dictClientCallBacks.ContainsKey(data.eq_id.ToUpper() + "-TESTER"))
                    {
                        RegisterDeviceInfo info = (dictClientCallBacks[data.eq_id.ToUpper() + "-TESTER"] as RegisterData).info;

                        if (data.isfinished)
                            info.WarningMessage = "";
                        else
                        {
                            info.WarningMessage = data.warning_message;
                            info.WarningBeginTime =data.timestamp;
                        }

                        info.WarningType = data.warning_type;
                       
                        NotifyAllStatusChange(PcName, info);
                    }

                }

                NotifyAllExportedCommand(PcName, cmdType);
                //
            }
            catch (Exception ex)
            {
                Console.WriteLine(PcName+":"+ ex.Message + "," + ex.StackTrace+",---"+ex.InnerException.Message);
                EventLog mylog = new EventLog() { Source = "AmidaService" };
                try
                {
                    mylog.WriteEntry(ex.Message + "," + ex.StackTrace);
                }
                catch { ;}
                throw ex;
               // throw new FaultException<string>(ex.Message + "," + ex.StackTrace);
            }

        }

        public void ReportExportPending(string pcname,bool IsPending)
        {
            try
            {
                if (dictClientCallBacks.ContainsKey(pcname.ToUpper() + "-TESTER"))
                {
                    RegisterDeviceInfo info = (dictClientCallBacks[pcname.ToUpper() + "-TESTER"] as RegisterData).info;
                    if (info.IsExportPending != IsPending)
                    {
                        info.IsExportPending = IsPending;
                        NotifyAllStatusChange(pcname, info);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        public void Down(string PcName,string UserID,string SubStatus)
        {
            try
            {
                ImportCmdData cmdData = new ImportCmdData() { Cmd = "Down", param1 = SubStatus, param2 = "", param3 = "", eq_operator = UserID, start_time = DateTime.Now };
                System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(ImportCmdData));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                sr.Serialize(ms, cmdData);
                string xmlcmd = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                RemoteInterface.Inport.InportCommand inportCmd = new RemoteInterface.Inport.InportCommand(xmlcmd, "Down");
                Console.WriteLine("Down Pass to " + PcName);
                Service.NotifyServer.NotifyAll(new RemoteInterface.NotifyEventObject(RemoteInterface.EventEnumType.InportCommand, PcName, inportCmd));
            }
            catch(Exception ex) {

                Console.WriteLine(ex.Message + "," + ex.StackTrace);
                
                ;}
        }
        public void Release(string PcName,string UserId)
        {
            try
            {
                ImportCmdData cmdData = new ImportCmdData() { Cmd = "Release", param1 = "SB0", param2 = "", param3 = "", eq_operator = UserId, start_time = DateTime.Now };
                System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(ImportCmdData));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                sr.Serialize(ms, cmdData);
                string xmlcmd = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                RemoteInterface.Inport.InportCommand inportCmd = new RemoteInterface.Inport.InportCommand(xmlcmd, "Release");
                Console.WriteLine("Release Pass to " + PcName);
                Service.NotifyServer.NotifyAll(new RemoteInterface.NotifyEventObject(RemoteInterface.EventEnumType.InportCommand, PcName, inportCmd));
                    
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "," + ex.StackTrace);

                ;
            }
            }



        public void NotifyRCP(string PCName,  string title, string text)
        {
            Service.NotifyServer.NotifyAll(new RemoteInterface.NotifyEventObject( RemoteInterface.EventEnumType.Message,PCName,
                new RemoteInterface.NotifyMessage(){ title= title, text=text,IsFinish=false,TimeStamp=DateTime.Now , Key= Guid.NewGuid().ToString()})
                );
        }

      

    }
}
