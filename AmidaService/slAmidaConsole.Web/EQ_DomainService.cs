
namespace slAmidaConsole.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Linq.Dynamic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
   // using slDBManager.Web;


    // 使用 AmidaEntities 內容實作應用程式邏輯。
    // TODO: 將應用程式邏輯加入至這些方法或其他方法。
    // TODO: 連接驗證 (Windows/ASP.NET Forms) 並取消下面的註解，以停用匿名存取
    // 視需要也考慮加入要限制存取的角色。
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class EQ_DomainService : LinqToEntitiesDomainService<AmidaEntities>
    {

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'sysdiagrams' 查詢。
        public IQueryable<sysdiagrams> GetSysdiagrams()
        {
            return this.ObjectContext.sysdiagrams;
        }

        public void InsertSysdiagrams(sysdiagrams sysdiagrams)
        {
            if ((sysdiagrams.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sysdiagrams, EntityState.Added);
            }
            else
            {
                this.ObjectContext.sysdiagrams.AddObject(sysdiagrams);
            }
        }

        public void UpdateSysdiagrams(sysdiagrams currentsysdiagrams)
        {
            this.ObjectContext.sysdiagrams.AttachAsModified(currentsysdiagrams, this.ChangeSet.GetOriginal(currentsysdiagrams));
        }

        public void DeleteSysdiagrams(sysdiagrams sysdiagrams)
        {
            if ((sysdiagrams.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sysdiagrams, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.sysdiagrams.Attach(sysdiagrams);
                this.ObjectContext.sysdiagrams.DeleteObject(sysdiagrams);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblAlarm' 查詢。
        public IQueryable<tblAlarm> GetTblAlarm()
        {
            return this.ObjectContext.tblAlarm;
        }

        public void InsertTblAlarm(tblAlarm tblAlarm)
        {
            if ((tblAlarm.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblAlarm, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblAlarm.AddObject(tblAlarm);
            }
        }

        public void UpdateTblAlarm(tblAlarm currenttblAlarm)
        {
            this.ObjectContext.tblAlarm.AttachAsModified(currenttblAlarm, this.ChangeSet.GetOriginal(currenttblAlarm));
        }

        public void DeleteTblAlarm(tblAlarm tblAlarm)
        {
            if ((tblAlarm.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblAlarm, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblAlarm.Attach(tblAlarm);
                this.ObjectContext.tblAlarm.DeleteObject(tblAlarm);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblEQ' 查詢。
        public IQueryable<tblEQ> GetTblEQ()
        {
            return this.ObjectContext.tblEQ;
        }

        public void InsertTblEQ(tblEQ tblEQ)
        {
            if ((tblEQ.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblEQ, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblEQ.AddObject(tblEQ);
            }
        }

        public void UpdateTblEQ(tblEQ currenttblEQ)
        {
            this.ObjectContext.tblEQ.AttachAsModified(currenttblEQ, this.ChangeSet.GetOriginal(currenttblEQ));
        }

        public void DeleteTblEQ(tblEQ tblEQ)
        {
            if ((tblEQ.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblEQ, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblEQ.Attach(tblEQ);
                this.ObjectContext.tblEQ.DeleteObject(tblEQ);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblEQHistory' 查詢。
        public IQueryable<tblEQHistory> GetTblEQHistory()
        {
            return this.ObjectContext.tblEQHistory;
        }

        public void InsertTblEQHistory(tblEQHistory tblEQHistory)
        {
            if ((tblEQHistory.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblEQHistory, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblEQHistory.AddObject(tblEQHistory);
            }
        }

        public void UpdateTblEQHistory(tblEQHistory currenttblEQHistory)
        {
            this.ObjectContext.tblEQHistory.AttachAsModified(currenttblEQHistory, this.ChangeSet.GetOriginal(currenttblEQHistory));
        }

        public void DeleteTblEQHistory(tblEQHistory tblEQHistory)
        {
            if ((tblEQHistory.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblEQHistory, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblEQHistory.Attach(tblEQHistory);
                this.ObjectContext.tblEQHistory.DeleteObject(tblEQHistory);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblUser' 查詢。
        public IQueryable<tblUser> GetTblUser()
        {
            return this.ObjectContext.tblUser.Include("tblUserGroup");
        }
      


        public void InsertTblUser(tblUser tblUser)
        {
            if ((tblUser.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUser, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblUser.AddObject(tblUser);
            }
        }

        public void UpdateTblUser(tblUser currenttblUser)
        {
            this.ObjectContext.tblUser.AttachAsModified(currenttblUser, this.ChangeSet.GetOriginal(currenttblUser));
        }

        public void DeleteTblUser(tblUser tblUser)
        {
            if ((tblUser.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUser, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblUser.Attach(tblUser);
                this.ObjectContext.tblUser.DeleteObject(tblUser);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblVerifyNote' 查詢。
        public IQueryable<tblVerifyNote> GetTblVerifyNote()
        {
            return this.ObjectContext.tblVerifyNote;
        }
 
     
        public void InsertTblVerifyNote(tblVerifyNote tblVerifyNote)
        {
            if ((tblVerifyNote.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblVerifyNote, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblVerifyNote.AddObject(tblVerifyNote);
            }
        }

        public void UpdateTblVerifyNote(tblVerifyNote currenttblVerifyNote)
        {
            this.ObjectContext.tblVerifyNote.AttachAsModified(currenttblVerifyNote, this.ChangeSet.GetOriginal(currenttblVerifyNote));
        }

        public void DeleteTblVerifyNote(tblVerifyNote tblVerifyNote)
        {
            if ((tblVerifyNote.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblVerifyNote, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblVerifyNote.Attach(tblVerifyNote);
                this.ObjectContext.tblVerifyNote.DeleteObject(tblVerifyNote);
            }
        }


        public IQueryable<tblMenu> GetTblMenu()
        {
            return this.ObjectContext.tblMenu;
        }

        public void InsertTblMenu(tblMenu tblMenu)
        {
            if ((tblMenu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMenu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblMenu.AddObject(tblMenu);
            }
        }

        public void UpdateTblMenu(tblMenu currenttblMenu)
        {
            this.ObjectContext.tblMenu.AttachAsModified(currenttblMenu, this.ChangeSet.GetOriginal(currenttblMenu));
        }

        public void DeleteTblMenu(tblMenu tblMenu)
        {
            if ((tblMenu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMenu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblMenu.Attach(tblMenu);
                this.ObjectContext.tblMenu.DeleteObject(tblMenu);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblMenuGroup' 查詢。
        public IQueryable<tblMenuGroup> GetTblMenuGroup()
        {
            return this.ObjectContext.tblMenuGroup;
        }

        public void InsertTblMenuGroup(tblMenuGroup tblMenuGroup)
        {
            if ((tblMenuGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMenuGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblMenuGroup.AddObject(tblMenuGroup);
            }
        }

        public void UpdateTblMenuGroup(tblMenuGroup currenttblMenuGroup)
        {
            this.ObjectContext.tblMenuGroup.AttachAsModified(currenttblMenuGroup, this.ChangeSet.GetOriginal(currenttblMenuGroup));
        }

        public void DeleteTblMenuGroup(tblMenuGroup tblMenuGroup)
        {
            if ((tblMenuGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMenuGroup, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblMenuGroup.Attach(tblMenuGroup);
                this.ObjectContext.tblMenuGroup.DeleteObject(tblMenuGroup);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblUser' 查詢。
       
        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblUserGroup' 查詢。
        public IQueryable<tblUserGroup> GetTblUserGroup()
        {
            return this.ObjectContext.tblUserGroup;
        }

        public void InsertTblUserGroup(tblUserGroup tblUserGroup)
        {
            if ((tblUserGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUserGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblUserGroup.AddObject(tblUserGroup);
            }
        }

        public void UpdateTblUserGroup(tblUserGroup currenttblUserGroup)
        {
            this.ObjectContext.tblUserGroup.AttachAsModified(currenttblUserGroup, this.ChangeSet.GetOriginal(currenttblUserGroup));
        }

        public void DeleteTblUserGroup(tblUserGroup tblUserGroup)
        {
            if ((tblUserGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUserGroup, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblUserGroup.Attach(tblUserGroup);
                this.ObjectContext.tblUserGroup.DeleteObject(tblUserGroup);
            }
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblUserGroupMenu' 查詢。
        public IQueryable<tblUserGroupMenu> GetTblUserGroupMenu()
        {
            return this.ObjectContext.tblUserGroupMenu.Include("tblMenu").Include("tblUserGroup");
        }

        public void InsertTblUserGroupMenu(tblUserGroupMenu tblUserGroupMenu)
        {
            if ((tblUserGroupMenu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUserGroupMenu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblUserGroupMenu.AddObject(tblUserGroupMenu);
            }
        }

        public void UpdateTblUserGroupMenu(tblUserGroupMenu currenttblUserGroupMenu)
        {
            this.ObjectContext.tblUserGroupMenu.AttachAsModified(currenttblUserGroupMenu, this.ChangeSet.GetOriginal(currenttblUserGroupMenu));
        }

        public void DeleteTblUserGroupMenu(tblUserGroupMenu tblUserGroupMenu)
        {
            if ((tblUserGroupMenu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUserGroupMenu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblUserGroupMenu.Attach(tblUserGroupMenu);
                this.ObjectContext.tblUserGroupMenu.DeleteObject(tblUserGroupMenu);
            }
        }

    
        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'vwUserMenuAllow' 查詢。
        public IQueryable<vwUserMenuAllow> GetVwUserMenuAllow()
        {
            return this.ObjectContext.vwUserMenuAllow;
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblVerifyTimeLog' 查詢。
        public IQueryable<tblVerifyTimeLog> GetTblVerifyTimeLog()
        {
            return this.ObjectContext.tblVerifyTimeLog;
        }

        // TODO:
        // 考慮限制查詢方法的結果。如果需要其他輸入，可以將
        // 參數加入至這個中繼資料，或建立其他不同名稱的其他查詢方法。
        // 為支援分頁，您必須將排序加入至 'tblVerifyTimeRef' 查詢。
        public IQueryable<tblVerifyTimeRef> GetTblVerifyTimeRef()
        {
            return this.ObjectContext.tblVerifyTimeRef;
        }

        public RptSchema.RptTouchDownSchema[] GetTouchDownTotalBySql(string sql, DateTime Startimes, DateTime StopTimes)
        {
            // this.ObjectContext.tblVerifyNote.
            // slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();
            //  var a =  this.ObjectContext.tblVerifyNote.Where("StartTimes< @p0",new System.Data.Objects.ObjectParameter("p0",new DateTime(2013,4,16)));

            //   a.ToArray();

            ObjectContext.CommandTimeout = 120;
            try
            {
                if (sql.Trim() == "")
                {
                    var q = from p in (from n in this.ObjectContext.tblVerifyNote join m in ObjectContext.PC_tbl on  n.PCID equals m.PC_ID 
                               into gs
                        from k in gs.DefaultIfEmpty()  select new {n.PCID,n.Pass,n.Fail,n.TouchDo,k.PC_status }     )
                        group p by new {p.PCID,p.PC_status} into g
                        select new RptSchema.RptTouchDownSchema
                        {
                             PCID = g.Key.PCID,
                             Touch_Down_Total  = (long)g.Sum(p => p.TouchDo),
                            Pass_Total = (long)g.Sum(p => p.Pass),
                            Fail_Total = (long)g.Sum(p => p.Fail),
                             PC_Status= g.Key.PC_status??""
                             
                        };

                    return q.ToArray<RptSchema.RptTouchDownSchema>();
                }
                else
                {
                    var q = from p in(from n in this.ObjectContext.tblVerifyNote.Where(sql, new System.Data.Objects.ObjectParameter("p0", Startimes), new System.Data.Objects.ObjectParameter("p1", StopTimes)) join m in ObjectContext.PC_tbl on  n.PCID equals m.PC_ID
                                  into gs
                                      from k in gs.DefaultIfEmpty()
                                      select new { n.PCID, n.Pass, n.Fail, n.TouchDo, k.PC_status })
                            group p by new { p.PCID, p.PC_status } into g
                            select new RptSchema.RptTouchDownSchema
                            {
                                PCID = g.Key.PCID,
                                Touch_Down_Total = (long)g.Sum(p => p.TouchDo),
                                Pass_Total = (long)g.Sum(p => p.Pass),
                                Fail_Total = (long)g.Sum(p => p.Fail),
                                PC_Status = g.Key.PC_status ?? ""

                            };
                    return q.ToArray<RptSchema.RptTouchDownSchema>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RptSchema.rptPerformanceSchema[] GetPerformanceTotalBySql(string sql, DateTime Startimes, DateTime StopTimes)
        {
            // this.ObjectContext.tblVerifyNote.
            // slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();
            //  var a =  this.ObjectContext.tblVerifyNote.Where("StartTimes< @p0",new System.Data.Objects.ObjectParameter("p0",new DateTime(2013,4,16)));

            //   a.ToArray();
            try
            {
                if (sql.Trim() == "")
                {
                    var q = from n in this.ObjectContext.tblEQHistory 
                            group n by n.@operator into g 
                            select new RptSchema.rptPerformanceSchema
                            {
                                 Operator = g.Key,
                                 ProductTotal = g.Count(p => p.status=="Product"),
                                 VerifyTotal = g.Count(p => p.status=="Verify"),
                                 Total = g.Count(p => p.status == "Product" || p.status == "Verify")
                            };

                    return q.ToArray<RptSchema.rptPerformanceSchema>();
                }
                else
                {
                    var q = from n in this.ObjectContext.tblEQHistory.Where(sql, new System.Data.Objects.ObjectParameter("p0", Startimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))
                            
                            group n by n.@operator into g
                            select new RptSchema.rptPerformanceSchema
                            {
                                Operator = g.Key,
                                ProductTotal = g.Count(p => p.status == "Product"),
                                VerifyTotal = g.Count(p => p.status == "Verify"),
                                Total = g.Count(p => p.status == "Product" || p.status == "Verify")
                            };

                    return q.ToArray<RptSchema.rptPerformanceSchema>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RptSchema.rptRCPProductivitySchema[] GetRCPProductivityTotalBySql(string sql, DateTime Startimes, DateTime StopTimes)
        {
            // this.ObjectContext.tblVerifyNote.
            // slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();
            //  var a =  this.ObjectContext.tblVerifyNote.Where("StartTimes< @p0",new System.Data.Objects.ObjectParameter("p0",new DateTime(2013,4,16)));

            //   a.ToArray();
            try
            {
                if (sql.Trim() == "")
                {
                    var q = from n in this.ObjectContext.tblVerifyNote
                            group n by new { n.RCP,n.TestVerify }  into g orderby g.Key
                            select new RptSchema.rptRCPProductivitySchema
                            {
                                RCP = g.Key.RCP,
                                TestVerify=g.Key.TestVerify,
                                Number = g.Count(),

                            } ;

                    return q.ToArray<RptSchema.rptRCPProductivitySchema>();
                }
                else
                {
                    var q = from n in this.ObjectContext.tblVerifyNote.Where(sql, new System.Data.Objects.ObjectParameter("p0", Startimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))

                            group n by new { n.RCP, n.TestVerify } into g
                            orderby g.Key
                            select new RptSchema.rptRCPProductivitySchema
                            {
                                RCP = g.Key.RCP,
                                Number = g.Count(),
                                TestVerify = g.Key.TestVerify
                            };

                    return q.ToArray<RptSchema.rptRCPProductivitySchema>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RptSchema.rptCurrentWIPSchema[] GetCurrentWIP()
        {


#if DEBUG
            PMS.WIP_Data[] data;
            data = PMS.PMSHelper.XmlToWIP_Data(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+"/App_Data/WIP-Result.xml"));
#else
            PMS.WIP_Data[] data = PMS.PMSHelper.GetWIP("PT", "");
#endif


            var PC_WIPStatusCnt = from n in ObjectContext.vwPC_RECWIPStatus
                                  group n by n.MaskID into g
                                  select new
                                  {
                                      MaskID = g.Key,
                                      OnlineSingle = g.Count(k => k.WIP_STATUS == "OS"),
                                      OnlineMulti = g.Count(k => k.WIP_STATUS == "OM"),
                                      PEConfirmSingle = g.Count(k => k.WIP_STATUS == "PS"),
                                      PEConfirmMulti = g.Count(k => k.WIP_STATUS == "PM"),
                                      NewS = g.Count(k => k.WIP_STATUS == "NS"),
                                      NewM = g.Count(k => k.WIP_STATUS == "NM"),
                                     
                                  };

            var q = from n in data

                    where n.Status.Trim() != ""
                    group n by new { n.MaskID, n.PF } into g
                    join m in PC_WIPStatusCnt.ToList() on g.Key.MaskID equals m.MaskID into gp

                    from k in gp.DefaultIfEmpty()

                    select new RptSchema.rptCurrentWIPSchema()
                    {
                        MaskID = g.Key.MaskID,
                        PF=g.Key.PF,
                        Processing = g.Where(p => p.Status.Trim() == "Processing"  ).Count(),
                        Waiting = g.Where(p => p.Status.Trim() == "Waiting").Count(),
                        Hold1 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0030" || p.Ope == "780.0150")).Count(),
                        Hold2 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0040" || p.Ope == "780.0200")).Count(),
                        Hold3 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "500.0100" || p.Ope == "780.0225" || p.Ope == "780.0250" || p.Ope == "792.0500")).Count(),
                        Other = g.Count(),
                        OnlineSingle = k == null ? 0 : k.OnlineSingle,
                        OnlineMulti = k == null ? 0 : k.OnlineMulti,
                        PEConfirmSingle = k == null ? 0 : k.PEConfirmSingle,
                        PEConfirmMulti = k == null ? 0 : k.PEConfirmMulti,
                        NewS = k == null ? 0 : k.NewS,
                        NewM = k == null ? 0 : k.NewM

                    };


            //var q = from n in data

            //        where n.Status.Trim() != ""
            //        group n by n.MaskID into g
            //        select new RptSchema.rptCurrentWIPSchema()
            //        {
            //            MaskID = g.Key,
            //            Processing = g.Where(p => p.Status.Trim() == "Processing").Count(),
            //            Waiting = g.Where(p => p.Status.Trim() == "Waiting").Count(),
            //            Hold1 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0030" || p.Ope == "780.0150")).Count(),
            //            Hold2 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0040" || p.Ope == "780.0200")).Count(),
            //            Hold3 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "500.0100" || p.Ope == "780.0225" || p.Ope == "780.0250" || p.Ope == "792.0500")).Count(),
            //            Other = g.Count()
            //        };
            RptSchema.rptCurrentWIPSchema[] array = q.ToArray < RptSchema.rptCurrentWIPSchema>();

            foreach (RptSchema.rptCurrentWIPSchema item in array)
            {
                item.Other = item.Other - item.Processing - item.Waiting - item.Hold1 - item.Hold2 - item.Hold3;
                tblMaskInfo minfo = ObjectContext.tblMaskInfo.FirstOrDefault(n => n.MaskID == item.MaskID);
                if (minfo != null)
                {
                   // item.PF = minfo.PF;
                    item.RFDC = minfo.RFDC;
                    item.Sponsor = minfo.Sponsor;
                    item.Customer = minfo.Customer;

                }
                //item.Other = item.Other - item.Processing - item.Waiting - item.Hold1 - item.Hold2 - item.Hold3;


            }

            return array;

        }

        public RptSchema.rptYieldVSRCPSchema[] GetYieldVSRCP(string MaskID, string rcp, DateTime StartTimes, DateTime StopTimes)
        {
#if DEBUG
            PMS.GoodDies_Data[] data;
            data = PMS.PMSHelper.XmlToGoodDies_Data(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+"App_Data/WIP-Result.xml"));
#else

            PMS.GoodDies_Data[] data = PMS.PMSHelper.GetTotalPassDieInfo(MaskID, StartTimes, StopTimes);
#endif

            IQueryable<tblVerifyNote> q = null; //db.tblVerifyNote.Where(n=>n.WaferID=="WS999");
            if (rcp.Trim() != "")
                q = from n in this.ObjectContext.tblVerifyNote where n.TestVerify == "Test" && n.Operators == rcp && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
            else
                q = from n in this.ObjectContext.tblVerifyNote where n.TestVerify == "Test" && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators


            var q1 = from n in data

                     join m in q on n.WaferID equals m.WaferID

                     select new
                     {   m.RCP,
                        m.WaferMask,
                      //   m.Operators,
                         m.Pass,
                         n.GoodDies,
                         Ratio = (double)m.Pass / n.GoodDies
                     };

            var q2 = (from n in q1 orderby n.Ratio
                      group n by n.RCP into g
                      select new RptSchema.rptYieldVSRCPSchema()
                      {
                          RCP = g.Key,
                          Max = g.Max(k => k.Ratio),
                          Min = g.Min(k => k.Ratio),
                          Avg = g.Average(k => k.Ratio),
                          Medium = g.Skip(g.Count() / 2).Take(1).ToArray()[0].Ratio,
                          Count=g.Count()
                      });
            return q2.ToArray();
        }


        public RptSchema.rptYieldVSOpSchema[] GetYieldVSOP(string MaskID, string op, DateTime StartTimes, DateTime StopTimes)
        {
#if DEBUG
            PMS.GoodDies_Data[] data;
            data = PMS.PMSHelper.XmlToGoodDies_Data(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+"App_Data/WIP-Result.xml"));
#else
          
            PMS.GoodDies_Data[] data = PMS.PMSHelper.GetTotalPassDieInfo(MaskID,StartTimes,StopTimes );
#endif

            IQueryable<tblVerifyNote> q = null; //db.tblVerifyNote.Where(n=>n.WaferID=="WS999");
            if (op.Trim() != "")
                q = from n in this.ObjectContext.tblVerifyNote where n.TestVerify == "Test" && n.Operators == op && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
            else
                q = from n in this.ObjectContext.tblVerifyNote where n.TestVerify == "Test" && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators


            var q1 = from n in data

                     join m in q on n.WaferID equals m.WaferID

                     select new
                     {
                         m.WaferMask,
                         m.Operators,
                         m.Pass,
                         n.GoodDies,
                         Ratio = (double)m.Pass / n.GoodDies
                     };

            var q2 = (from n in q1 orderby n.Ratio
                      group n by n.Operators into g
                      select new RptSchema.rptYieldVSOpSchema()
                      {
                          Operator = g.Key,
                          Max = g.Max(k => k.Ratio),
                          Min = g.Min(k => k.Ratio),
                          Avg = g.Average(k => k.Ratio),
                          Medium = g.Skip(g.Count() / 2).Take(1).ToArray()[0].Ratio,
                          Count=g.Count()

                      });
            return q2.ToArray();
        }
        public RptSchema.rptYieldVSPCSchema[] GetYieldVSPC(string MaskID, string pc, DateTime StartTimes, DateTime StopTimes)
        {
#if DEBUG
            PMS.GoodDies_Data[] data;
            data = PMS.PMSHelper.XmlToGoodDies_Data(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "App_Data/WIP-Result.xml"));
#else
          
            PMS.GoodDies_Data[] data = PMS.PMSHelper.GetTotalPassDieInfo(MaskID,StartTimes,StopTimes );
#endif

            IQueryable<tblVerifyNote> q = null; //db.tblVerifyNote.Where(n=>n.WaferID=="WS999");
            if (pc.Trim() != "")
                q = from n in this.ObjectContext.tblVerifyNote where n.TestVerify == "Test" && n.PCID.StartsWith( pc) && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
            else
                q = from n in this.ObjectContext.tblVerifyNote where n.TestVerify == "Test" && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators


            var q1 = from n in data

                     join m in q on n.WaferID equals m.WaferID

                     select new
                     {
                         m.WaferMask,
                         m.PCID,
                         m.Pass,
                         n.GoodDies,
                         Ratio = (double)m.Pass / n.GoodDies
                     };

            var q2 = (from n in q1   orderby n.Ratio
                      group n by n.PCID into g
                      select new RptSchema.rptYieldVSPCSchema()
                      {
                           PCID = g.Key,
                          Max = g.Max(k => k.Ratio),
                          Min = g.Min(k => k.Ratio),
                          Avg = g.Average(k => k.Ratio),
                          Medium = g.Skip(g.Count() / 2).Take(1).ToArray()[0].Ratio,
                          Count=g.Count()
                      });
            return q2.ToArray();
        }
        public RptSchema.rptRCPStatusIndex[] GetRCPStatusIndex(string status, DateTime start_times, DateTime stop_times)
        {
            AmidaEntities db = new AmidaEntities();


            var q = from n in db.tblEQHistory select n;/*join m in db.tblEQ on n.eq_id equals m.eqi_id select new { n.eq_id, n.start_time, n.stop_time, n.IsFinish, n.status, m.eq_area, m.eq_type, m.eq_tester }; */
            if (status.Trim() != "")
                q = q.Where(n => n.status == status);
          //  q = q.Where(n =>   n.start_time >= starttimes && n.stop_time <= stoptimes    && n.IsFinish == true);
            q = q.Where(n =>   !(n.start_time < start_times && n.stop_time < start_times || n.start_time > stop_times && n.stop_time > stop_times)|| n.start_time <= start_times && n.stop_time==null    );
            var q1 = from n in  q   join m in db.tblEQ  on n.eq_id equals m.eqi_id    
                select new RptSchema.rptStatusDetail()
                    {
                        Status = n.status,
                        Area = m.eq_area,
                        eqid = n.eq_id,
                        EQ_Tester = m.eq_tester,
                        EQ_Type = m.eq_prober,
                        starttimes = (n.start_time <start_times)?start_times:n.start_time,
                        stoptimes =( n.stop_time==null || n.stop_time >stop_times )?stop_times:n.stop_time

                        };




            var q2 = from n in q1.ToList()
                     group n by new { n.eqid, n.Status, n.EQ_Tester, n.EQ_Type, n.Area }
                         into g
                         select new RptSchema.rptRCPStatusIndex()
                             {
                                   EqID=g.Key.eqid,
                                    Area=g.Key.Area,
                                     Status=g.Key.Status,
                                      EQ_Type=g.Key.EQ_Type,
                                       TesterType=g.Key.EQ_Tester,
                                        TotalTime=g.Sum(p=>p.TotalHours)
                             };
            

           return q2.ToArray();



        }
        public IQueryable<tblMaskInfo> GetTblMaskInfo()
        {
            return this.ObjectContext.tblMaskInfo;
        }

        public void InsertTblMaskInfo(tblMaskInfo tblMaskInfo)
        {
            if ((tblMaskInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMaskInfo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblMaskInfo.AddObject(tblMaskInfo);
            }
        }

        public void UpdateTblMaskInfo(tblMaskInfo currenttblMaskInfo)
        {
            this.ObjectContext.tblMaskInfo.AttachAsModified(currenttblMaskInfo, this.ChangeSet.GetOriginal(currenttblMaskInfo));
        }

        public void DeleteTblMaskInfo(tblMaskInfo tblMaskInfo)
        {
            if ((tblMaskInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMaskInfo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblMaskInfo.Attach(tblMaskInfo);
                this.ObjectContext.tblMaskInfo.DeleteObject(tblMaskInfo);
            }
        }


    }


   
}


