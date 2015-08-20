using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AmidaServerService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的類別名稱 "RestService"。
      [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class RestService : IRestService
    {
         public RestService()
          {
          }
        public string DoWork()
        {
            try
            {
                return "ok";
            }
            catch (Exception ex)
            {
                return "fail:" + ex.StackTrace;
            }
        }


        public ConfigInfo GetConfig2(string OPID, string PCID, string SM, string TestMode, string LotID, string Wafer, string FP, string RCP)
        {
            try
            {
                string[] splits = LotID.Split(new char[] { '-' });
                string MaskID = splits[0];
                LotID = splits[1];
                string Mask = MaskID.Substring(0, 5);  //PCID.Substring(0, 5);

                //  string Mask_M = MaskID;   //
                string temp15, temp17, temp18;
                if (PCID[15] >= '0' && PCID[15] <= '9')  //is digit
                    temp15 = "";
                else
                    temp15 = "V";
                if (PCID[17] == '0')
                    temp17 = "";
                else if (PCID[17] == '3')
                    temp17 = "X";
                else if (PCID[17] == '4')
                    temp17 = "Y";
                else if (PCID[17] == '5')
                    temp17 = "Z";
                else
                    temp17 = "";

                if (PCID[18] == '1')
                    temp18 = "";
                else if (PCID[18] >= 'A' && PCID[18] <= 'W')
                    temp18 = PCID[18].ToString();
                else
                    temp18 = "";

                string Mask_M, ini = "", FileName = "";

                Mask_M = Mask + temp15 + temp17 + temp18;

                if (SM == "S")
                {


                    ini = Mask_M + ".ini";

                    FileName = Mask_M + "-" + LotID;
                }
                else if (SM == "M")
                {
                    // ini = MaskID + "-" + LotID + ".ini";
                    ini = Mask_M + "-" + LotID + ".ini";
                    FileName = Mask_M + "-" + LotID;
                    string[] seqs = Wafer.Split(new char[] { ',' });
                    string res = (from n in seqs where n.Trim() == LotID.Substring(LotID.Length - 2, 2) select n).FirstOrDefault();
                    if (res == null)
                        return new ConfigInfo() { ErrorMessage = "multi map compare  fail!" };
                }
                else
                    new ConfigInfo() { ErrorMessage = "Unknown SM mode!" };

                string Shape = PCID[9].ToString();
                if (OPID == "99999")
                    return new ConfigInfo() { Ini = ini, Mask = Mask, RCP = RCP, Shape = Shape, GoTest = "Error Message test!", FileName = FileName };

                return new ConfigInfo() { Ini = ini, Mask = Mask, RCP = RCP, Shape = Shape, GoTest = "Go", FileName = FileName };
            }

            catch (Exception ex)
            {
                return new ConfigInfo() { ErrorMessage = ex.Message + "," + ex.StackTrace };
            }

                //Mask = Mask + "V" + MaskID.Substring(5, MaskID.Length - 5);
        }

        public ConfigInfo GetConfig(string OPID, string PCID, string SM, string TestMode, string LotID, string Wafer, string FP, string RCP)
        {
            try
            {
               //string mLotID;
                //s.IndexOf('-',s.IndexOf('-')+1)
             //   int pos = LotID.IndexOf('-');
                //if (pos >= 0)
                //    mLotID = LotID.Substring(0, pos);
               // LotID = LotID.Substring(pos+1);
            //    string MaskID = LotID.Substring(0, LotID.IndexOf('-'));
          //  mLotID=LotID.Substring(pos,Lotid
                string[] splits=LotID.Split(new char[]{'-'});
                string MaskID = splits[0];
                 LotID = splits[1];
                 string Mask = MaskID.Substring(0, 5);  //PCID.Substring(0, 5);

                 string Mask_M = MaskID;   //          

                if (PCID[15] == 'V' || PCID[14] == 'V')
                    Mask = Mask + "V" + MaskID.Substring(5, MaskID.Length - 5);
                else
                    Mask = MaskID;
                if (PCID[17] == '3')
                {
                    Mask = Mask + "C";
                    Mask_M = Mask_M + "C"; 
                }
                else if (PCID[17] == '4')
                {
                    Mask = Mask + "D";
                    Mask_M = Mask_M + "D"; 
                }
                else if (PCID[17] == '5')
                {
                    Mask = Mask + "E";
                    Mask_M = Mask_M + "E"; 
                }
                else if(PCID[17] == '6')
                {
                     Mask = Mask + "F";
                    Mask_M = Mask_M + "F"; 
                }
                


                string Shape = PCID[9].ToString();

                string ini = "",FileName="";
                if (SM == "S")
                {
                    //ini = MaskID + ".ini";
                    ini = Mask + ".ini";
                  //  FileName = MaskID + "-" + LotID; 
                    FileName = Mask_M + "-" + LotID; 
                }
                else if (SM == "M")
                {
                   // ini = MaskID + "-" + LotID + ".ini";
                    ini = Mask_M + "-" + LotID + ".ini";
                    FileName = Mask_M + "-" + LotID;            
                    string[] seqs = Wafer.Split(new char[] { ',' });
                    string res = (from n in seqs where n.Trim() == LotID.Substring(LotID.Length - 2, 2) select n).FirstOrDefault();
                    if (res == null)
                        return new ConfigInfo() { ErrorMessage = "multi map compare  fail!" };
                }
                else
                    new ConfigInfo() { ErrorMessage = "Unknown SM mode!" };


                //sr = new System.Xml.Serialization.XmlSerializer(typeof(ErrorInfo));
                //sr.Serialize(ms, new ErrorInfo() { Message = "error", StackTrace = "test" });
                //return System.Text.UTF8Encoding.UTF8.GetString(ms.ToArray());
                if(OPID=="99999")
                    return new ConfigInfo() { Ini = ini, Mask = Mask, RCP = RCP, Shape = Shape, GoTest = "Error Message test!" ,FileName=FileName};

                return new ConfigInfo() { Ini = ini, Mask = Mask, RCP = RCP, Shape = Shape,GoTest="Go",FileName=FileName };
            }
            catch (Exception ex)
            {
                return new ConfigInfo() { ErrorMessage = ex.Message + "," + ex.StackTrace };
            }
        }

        public string AutoPMS(string INOUT, string OPID, string PARTID, string EQPID, string OPENO, string SM, string WAFER)
        {
            string partid="";
           // if(SM=='S")

              if(EQPID.StartsWith("RCP"))

              {
                  try
                  {
                  EQPID = "RCP-" + int.Parse(EQPID.Split(new char[] { '-' })[1]);
                  }
                  catch(Exception ex)
                  {
                      Console.WriteLine(ex.Message+","+ex.StackTrace);
                      return "Fail:RCP name illegal!";
                     
                  }

             
              }
            
                   string feedfilename = Guid.NewGuid().ToString() + ".txt";
            try
            {
                if(INOUT!="IN" && INOUT !="OUT")
                    return "Fail: unexpected INOUT !";

                if (SM == "S")
                {
                    string[] temps = PARTID.Split(new char[] { '-' });
                    string part0 = temps[0].Substring(0, 5);
                    string part1 = "";
                    if (char.IsLetter(temps[1][0]))  // is letter
                        part1 = temps[1].Substring(0, 4);
                    else
                        part1 = "-" + temps[1].Substring(0, 3);

                    partid = part0 + part1 + "-" + WAFER;
                }
                else if (SM == "M")
                {
                    string[] temps = PARTID.Split(new char[] { '-' });
                    string part0 = temps[0].Substring(0, 5);
                    string part1 = char.IsLetter(temps[1].Split(new char[] { 'W' })[0][0]) ? temps[1].Split(new char[] { 'W' })[0].Substring(0, 4) : "-"+temps[1].Split(new char[] { 'W' })[0].Substring(0, 3);

                    partid = part0 + part1 + "-"+temps[1].Split(new char[] { 'W' })[1];

                }
                else
                    throw new Exception("unknow SM:" + SM);
                
            //    string[] temps = PARTID.Split(new char[] { '-' });
               // string partid = temps[0].Substring(0, 5) + temps[1] + "." + temps[2];

                Console.WriteLine("AutoPMS:{0},{1},{2},{3},{4}", INOUT, OPID, partid, EQPID, OPENO);
                //###############################
               //  return partid;
                //####################
                System.Diagnostics.Process process;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "AutoPms\\" + feedfilename));
                sw.Write(OPID + " " + partid + " " + EQPID + " " + OPENO);
                sw.Close();
                process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"AutoPms\AutoPMS.exe", INOUT + " " + AppDomain.CurrentDomain.BaseDirectory + "AutoPms\\" + feedfilename);

                if (!process.WaitForExit(20000))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch { ;}
                    return "Fail:Timeout";
                }

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"AutoPms\" + feedfilename + ".out"))
                    return "Fail:output file not found!";
                System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"AutoPms\" + feedfilename + ".out");
                string res = sr.ReadLine();
                sr.Close();
                if (!res.StartsWith("[0000000I:"))
                    return "Fail:" + res;

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail:" + ex.Message;
            }
            finally
            {
                try
                {
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoPms\" + feedfilename);
                }
                catch { ;}


                try
                {

                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoPms\" + feedfilename + ".out");
                }
                catch { ;}
            }
         //   throw new NotImplementedException();
        }
        public string AutoMES(string INOUT, string OPID, string PARTID, string EQPID, string OPENO)
        {
            if (EQPID.StartsWith("RCP"))
            {
                try
                {
                    EQPID = "RCP-" + int.Parse(EQPID.Split(new char[] { '-' })[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "," + ex.StackTrace);
                    return "Fail:RCP name illegal!";

                }

               
            }

            string feedfilename = Guid.NewGuid().ToString() + ".txt";
            try
            {
                if (INOUT != "IN" && INOUT != "OUT")
                    return "Fail: unexpected INOUT !";
                string[] temps = PARTID.Split(new char[] { '-' });
                string partid = temps[0].Substring(0, 5) + temps[1] + "." + temps[2];

                Console.WriteLine("AutoMes:{0},{1},{2},{3},{4}", INOUT, OPID, partid, EQPID, OPENO);
                System.Diagnostics.Process process;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "AutoMes\\" + feedfilename));
                sw.Write(OPID + " " + partid + " " + EQPID + " " + OPENO);
                sw.Close();
                process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\AutoMES.exe", INOUT + " " + AppDomain.CurrentDomain.BaseDirectory + "AutoMes\\" + feedfilename);
                int timeout = 120 * 1000;
                if (INOUT == "OUT")
                    timeout = 1000 * 120;

                if (!process.WaitForExit(timeout))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch { ;}
                    return "Fail:Timeout";
                }

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out"))
                    return "Fail:output file not found!";
                System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out");
                string res = sr.ReadLine();
                sr.Close();
                if (!res.StartsWith("[0000000I:"))
                    return "Fail:" + res;

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail:" + ex.Message+","+ex.StackTrace;
            }
            finally
            {
                try
                {
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename);
                }
                catch { ;}


                try
                {

                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out");
                }
                catch { ;}
            }


           // throw new NotImplementedException();
        }

        public string AutoMESPCM(string INOUT, string OPID, string PARTID, string EQPID/*, string OPENO*/)
        {
            //if (EQPID.StartsWith("RCP"))
            //{
            //    try
            //    {
            //        EQPID = "RCP-" + int.Parse(EQPID.Split(new char[] { '-' })[1]);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message + "," + ex.StackTrace);
            //        return "Fail:RCP name illegal!";

            //    }


            //}

            string feedfilename = Guid.NewGuid().ToString() + ".txt";
            try
            {
                if (INOUT != "IN" && INOUT != "OUT")
                    return "Fail: unexpected INOUT !";
           //     string[] temps = PARTID.Split(new char[] { '-' });
             //   string partid = temps[0].Substring(0, 5) + temps[1] + "." + temps[2];
                string partid = PARTID;
                Console.WriteLine("AutoMesPMS:{0},{1},{2},{3} ", INOUT, OPID, partid, EQPID /*, OPENO*/);
                System.Diagnostics.Process process;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "AutoMESPCM\\" + feedfilename));
                sw.Write(OPID + " " + partid + " " + EQPID /*+ " " + OPENO*/);
                sw.Close();
                process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"AutoMESPCM\AutoMESPCM.exe", INOUT + " " + AppDomain.CurrentDomain.BaseDirectory + "AutoMESPCM\\" + feedfilename);
                int timeout = 120 * 1000;
                if (INOUT == "OUT")
                    timeout = 1000 * 120;

                if (!process.WaitForExit(timeout))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch { ;}
                    return "Fail:Timeout";
                }

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"AutoMESPCM\" + feedfilename + ".out"))
                    return "Fail:output file not found!";
                System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"AutoMESPCM\" + feedfilename + ".out");
                string res = sr.ReadLine();
                sr.Close();
                if (!res.StartsWith("[0000000I:"))
                    return "Fail:" + res;

                else
                {
                    if (INOUT == "IN")
                    {
                        int startpos, endpos;
                        startpos = res.IndexOf('@');
                        endpos = res.IndexOf(']');
                        if (startpos == -1 || endpos == -1)
                            return "Fail: @ or ] not found!";
                        string ReceipeID = res.Substring(startpos + 1, endpos - startpos - 1);  // res.Split(new char[] { '@' })[1].Trim(new char[] { ']' });
                        //處理 Receipe ID here
                        return "Success:" + ReceipeID;
                    }
                    else
                        return "Success";
                }
            }
            catch (Exception ex)
            {
                return "Fail:" + ex.Message;
            }
            finally
            {
                try
                {
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMESPCM\" + feedfilename);
                }
                catch { ;}


                try
                {

                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMESPCM\" + feedfilename + ".out");
                }
                catch { ;}
            }


            // throw new NotImplementedException();
        }
    }

      [DataContract]
      public class ConfigInfo
      {
          public ConfigInfo()
          {
              ErrorMessage = "";
          }
           [DataMember]
         public  string ErrorMessage { get; set; }
          [DataMember]
          public  string Mask { get; set; }
          [DataMember]
          public string Shape { get; set; }
          [DataMember]
          public string RCP { get; set; }
          [DataMember]
          public string Ini { get; set; }
          [DataMember]
          public string GoTest { get; set; }
          [DataMember]
          public string FileName { get; set; }
      }

   
}
