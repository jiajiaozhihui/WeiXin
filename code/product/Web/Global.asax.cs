﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.SessionState;
using SfSoft.SfEmc;
using SfSoft.Common;
using System.Timers;
using System.Threading;
using System.Net;
using System.IO;
using SfSoft.web.emc.common;
using log4net;
namespace SfSoft.web
{
    public class Global : System.Web.HttpApplication
    {
        SfSoft.web.emc.common.MsgTools msgTools = new SfSoft.web.emc.common.MsgTools();
        private static readonly ILog log = LogManager.GetLogger(typeof(Global));
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.DOMConfigurator.Configure();

            Application["UsersOnlineNum"] = 0;
            DataTable dt = this.CreateStructure();
            Application["UsersOnline"] = dt;
            string timerSms = ConfigurationManager.AppSettings["timerSms"];
            string timerBo = ConfigurationManager.AppSettings["timerBo"];


            Application["IsSiteCopy"] = 1;
            //SanbaoEbs.EbsCommon .GetIsSiteCopy();//是否允许Copy
            Application["IsSiteStart"] = "1";//是否开启网站
            string StartTimerSms = ConfigurationManager.AppSettings["StartTimerSms"];
            string StartTimerBo = ConfigurationManager.AppSettings["StartTimerBo"];
         
       

            //string StartRecMail = ConfigurationManager.AppSettings["StartRecMail"];
            //string timerMail = ConfigurationManager.AppSettings["timerMail"];

            //定义消息定时器 
            if (StartTimerSms == "1")
            {
                System.Timers.Timer SmsTimer = new System.Timers.Timer(int.Parse(timerSms));
                SmsTimer.Elapsed += new ElapsedEventHandler(SmsTimer_Elapsed);
                SmsTimer.Enabled = true;
                SmsTimer.AutoReset = true;
            }
            //定义业务消息定时器 
            if (StartTimerBo == "1")
            {
                System.Timers.Timer BoTimer = new System.Timers.Timer(int.Parse(timerBo));
                BoTimer.Elapsed += new ElapsedEventHandler(BoTimer_Elapsed);
                BoTimer.Enabled = true;
                BoTimer.AutoReset = true;
            }

            ////定义邮件接收定时器 
            //if (StartRecMail == "1")
            //{
            //    System.Timers.Timer MailTimer = new System.Timers.Timer(int.Parse(timerMail));
            //    MailTimer.Elapsed += new ElapsedEventHandler(MailTimer_Elapsed);
            //    MailTimer.Enabled = true;
            //    MailTimer.AutoReset = true;
            //}
        }
        void MailTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                //邮件接收
                ReceiveAllMail();
  
            }
            catch (Exception ee)
            {
                log.Debug(ee.Message);
            }
        }
        void ReceiveAllMail()
        {
           // EmcMail emcMail = new EmcMail();
            //emcMail.ReceiveMail();
        }
        void BoTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                //日程工作提醒
                SampleTaskCall();
                //订单流程业务提醒
                FlowTaskCall();
                //工作计划提醒
                //FlanWorkCall();
            }
            catch (Exception ee)
            {
                log.Debug("BO:"+ee.Message);
            }
        }

        //工作计划提醒
//        void FlanWorkCall()
//        {
//            string AppID = "emc";
//            string ModulesID = "emc.rcm.myplan";
//            //提前提醒

//            string sql1 = @"select ID,Topic,UserID,CnName,StartDate+StartTime as StartDateTime,b.ReCallTime,b.CallTime, 
//c.CallTypeTime,b.CallType,a.UserID,a.CnName ,a.IsWake,a.Detail 
//from Emc_RcmPlan as a 
//left join (select DocID,CallType,ReCallTime,CallTime from Pub_CallType where AppID='emc' and ModulesID='emc.rcm.myplan') as b 
//on a.ID=b.DocID
//left join (select DocID,CallType,CallTypeTime,Flag,num from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.myplan' and Flag=1) as c 
//on a.ID=c.DocID
//where a.IsWake='Y' and (b.CallTime is not null and b.CallTime <>'0' and c.DocID is null ) 
//and datediff(minute,getdate(),(CASE b.CallTime  WHEN '0.25' THEN DATEADD ( n , -15,StartDate+StartTime )
//                 WHEN '0.5' THEN DATEADD ( n , -30, a.StartDate+a.StartTime ) 
//                 else   DATEADD ( hh , -b.CallTime, a.StartDate+a.StartTime ) 
// END))<=0";
//            DataSet ds1 = DBTools.GetList(sql1);
//            if (ds1.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow dr in ds1.Tables[0].Rows)
//                {
//                    string CallType = dr["CallType"].ToString();
//                    if (CallType == "")
//                    {
//                        continue;
//                    }
//                    string UserIds = dr["UserID"].ToString();
//                    string smsmsg = "";

//                    string SendUserID = "0";
//                    string SendCnName = "EMC系统";
//                    string Flag = "1";

//                    string DocID = dr["ID"].ToString();
//                    StringBuilder msg = new StringBuilder();
//                    msg.Append("日程提醒,『编号：" + DocID + "』<br>");
//                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
//                    msg.Append("内容：" + dr["Detail"].ToString() + "<br>");
//                    msg.Append("计划人：" + dr["CnName"].ToString() + "<br>");
//                    msg.Append("开始时间：" + dr["StartDateTime"].ToString() + "<br>");
//                    smsmsg = "EMC日程提醒：『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + ">>，开始时间：" + dr["StartDateTime"].ToString();
//                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID);
//                }
//            }
//            //周期提醒:
 
//            string sql2 = @"select ID,Topic,b.ReCallTime,EndDate+EndTime as EndDateTime, c.CallTypeTime,b.CallType,a.UserID,a.CnName, a.IsWake,a.Detail   from Emc_RcmPlan as a 
//left join (
//     select DocID,  CallType, ReCallTime from Pub_CallType where   AppID='emc' and  ModulesID='emc.rcm.myplan' ) as b
//     on a.ID=b.DocID
//left join (select ID as ListID,DocID,CallTypeTime,num,Status from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.myplan' and Flag=2) as c 
//     on a.id=c.DocID
// 
//where a.IsWake='Y' and b.DocID is not null and b.ReCallTime is not null and b.ReCallTime<>'0'   
// 
//    and ((c.ListID is null and datediff(minute,getdate(), DATEADD ( hh , b.ReCallTime, a.EndDate+a.EndTime ))<=0
//   ) or (c.ListID is not null and c.Status <>'2' 
//         and  datediff(minute,getdate(), DATEADD ( hh , b.ReCallTime, c.CallTypeTime ))<=0))";
//            DataSet ds2 = DBTools.GetList(sql2);
//            if (ds2.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow dr in ds2.Tables[0].Rows)
//                {
//                    string CallType = dr["CallType"].ToString();
//                    if (CallType == "")
//                    {
//                        continue;
//                    }
        

//                    string UserIds = dr["UserID"].ToString();
//                    string smsmsg = "";
//                    string SendUserID = "0";
//                    string SendCnName = "EMC系统";
//                    string Flag = "2";

//                    string DocID = dr["ID"].ToString();
       
//                    StringBuilder msg = new StringBuilder();
//                    msg.Append("EMC日程再提醒,『编号：" + DocID + "』<br>");
//                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
//                    msg.Append("内容：" + dr["Detail"].ToString() + "<br>");
//                    msg.Append("计划人：" + dr["CnName"].ToString() + "<br>");
//                    msg.Append("结束时间：" + dr["EndDateTime"].ToString() + "<br>");
//                    smsmsg = "EMC日程再提醒：『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + ">>";
//                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID);
//                }
//            }
//        }

        //日程工作提醒主单提醒
        void SampleTaskCall()
        {
            string AppID = "emc";
            string ModulesID = "emc.rcm.task";

            //工作开始前提醒
            //没有开始的工作，没有提前提醒记录，有提前提醒时间设置且提前提醒时间+当前时间>=开始时间且没有提前提醒记录
            string sql0 = @"select ID,Topic,DoMan,DoManID,JoinMansID,StartDate+StartTime as StartDateTime,b.ReCallTime,b.CallTime, 
c.CallTypeTime,b.CallType,a.UserID,a.CnName ,a.Status,a.Detail 
from Emc_RcmTask as a 
left join (select DocID,CallType,ReCallTime,CallTime from Pub_CallType where AppID='emc' and ModulesID='emc.rcm.task') as b 
on a.ID=b.DocID
left join (select DocID,CallType,CallTypeTime,Flag,num from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.task' and Flag=1) as c 
on a.ID=c.DocID
where  a.Status='1'  and (b.CallTime is not null and b.CallTime <>'0' and c.DocID is null ) 
and datediff(minute,getdate(),(CASE b.CallTime  WHEN '0.25' THEN DATEADD ( n , -15,StartDate+StartTime )
                 WHEN '0.5' THEN DATEADD ( n , -30, a.StartDate+a.StartTime ) 
                 else   DATEADD ( hh , -b.CallTime, a.StartDate+a.StartTime ) 
 END))<=0";
            DataSet ds0 = DBTools.GetList(sql0);
            if (ds0.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds0.Tables[0].Rows)
                {
                    string CallType = dr["CallType"].ToString();
                    if (CallType == "")
                    {
                        continue;
                    }

                    //执行人
                    string DoManID = dr["DoManID"].ToString();

                    string UserIds = DoManID;
                    string smsmsg = "";
                    string SendUserID = "0";
                    string SendCnName = "EMC系统";
                    string Flag = "1";
                    string statusName = EmcCommon.GetTaskStatusNameByStatus(dr["Status"].ToString());
                    string DocID = dr["ID"].ToString();
                    StringBuilder msg = new StringBuilder();
                    msg.Append("日程工作：工作开始前提醒,『编号：" + DocID + "』<br>");
                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
                    msg.Append("状态：" + statusName + "<br>");
                    msg.Append("内容：" + dr["Detail"].ToString() + "<br>");
                    msg.Append("创建人：" + SendCnName + "<br>");
                    msg.Append("工作要求开始时间：" + dr["StartDateTime"].ToString() + "<br>");
                    smsmsg = "EMC短信提醒：日程工作-工作开始前提醒，『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + ">>，状态：" + statusName;
                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID);
                }
            }

            //工作结束提前提醒
            //没有完成的工作务，没有提前提醒记录，有提前提醒时间设置且提前提醒时间+当前时间>=结束时间且没有提前提醒记录
            string sql1 = @"select ID,Topic,DoMan,DoManID,JoinMansID,EndDate+EndTime as EndDateTime,b.ReCallTime,b.CallTime, 
c.CallTypeTime,b.CallType,a.UserID,a.CnName ,a.Status,a.Detail 
from Emc_RcmTask as a 
left join (select DocID,CallType,ReCallTime,CallTime from Pub_CallType where AppID='emc' and ModulesID='emc.rcm.task') as b 
on a.ID=b.DocID
left join (select DocID,CallType,CallTypeTime,Flag,num from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.task' and Flag=3) as c 
on a.ID=c.DocID
where  (a.Status='1' or a.Status='3')  and (b.CallTime is not null and b.CallTime <>'0' and c.DocID is null ) 
and datediff(minute,getdate(),(CASE b.CallTime  WHEN '0.25' THEN DATEADD ( n , -15,EndDate+EndTime )
                 WHEN '0.5' THEN DATEADD ( n , -30, a.EndDate+a.EndTime ) 
                 else   DATEADD ( hh , -b.CallTime, a.EndDate+a.EndTime ) 
 END))<=0";
            DataSet ds1 = DBTools.GetList(sql1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    string CallType = dr["CallType"].ToString();
                    if (CallType == "")
                    {
                        continue;
                    }

                    //执行人
                    string DoManID = dr["DoManID"].ToString();
                    string UserIds = DoManID;
                    string smsmsg = "";

                    string SendUserID = "0";
                    string SendCnName = "EMC系统";
                    string Flag = "3";
                    string statusName = EmcCommon.GetTaskStatusNameByStatus(dr["Status"].ToString());
                    string DocID = dr["ID"].ToString();
                    StringBuilder msg = new StringBuilder();
                    msg.Append("日程工作：工作到期前提醒,『编号：" + DocID + "』<br>");
                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
                    msg.Append("状态：" + statusName + "<br>");
                    msg.Append("内容：" + dr["Detail"].ToString() + "<br>");
                    msg.Append("创建人：" + SendCnName + "<br>");
                    msg.Append("工作要求完成时间：" + dr["EndDateTime"].ToString() + "<br>");
                    smsmsg = "EMC短信提醒：日程工作-工作到期前提醒，『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + ">>，状态：" + statusName;
                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID);
                }
            }
            //周期提醒:
            //没有完成的任务，有提前提醒时间设置且有周期提醒设置，如果没有周期提醒记录，则周期提醒时间+结束时间<=当前时间
            //如果有周期提醒时间，最后提醒时间+周期提醒时间<=当前时间
            string sql2 = @"select ID,Topic,DoMan,DoManID,JoinMansID,b.ReCallTime,EndDate+EndTime as EndDateTime, c.CallTypeTime,b.CallType,a.UserID,a.CnName, a.Status,a.Detail   from Emc_RcmTask as a 
left join (
     select DocID,  CallType, ReCallTime from Pub_CallType where   AppID='emc' and  ModulesID='emc.rcm.task' ) as b
     on a.ID=b.DocID
left join (select ID as ListID,DocID,CallTypeTime,num,Status from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.task' and Flag=2) as c 
     on a.id=c.DocID
 
where   (a.Status='1' or a.Status='3')  and b.DocID is not null and b.ReCallTime is not null and b.ReCallTime<>'0'   
 
    and ((c.ListID is null and datediff(minute,getdate(), DATEADD ( hh , b.ReCallTime, a.EndDate+a.EndTime ))<=0
   ) or (c.ListID is not null and c.Status <>'2' 
         and  datediff(minute,getdate(), DATEADD ( hh , b.ReCallTime, c.CallTypeTime ))<=0))";
            DataSet ds2 = DBTools.GetList(sql2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string CallType = dr["CallType"].ToString();
                    if (CallType == "")
                    {
                        continue;
                    }
                    //执行人
                    string DoManID = dr["DoManID"].ToString();

                    string UserIds = DoManID;
                    string smsmsg = "";

                    string SendUserID = "0";
                    string SendCnName = "EMC系统";
                    string Flag = "2";
                    string statusName = EmcCommon.GetTaskStatusNameByStatus(dr["Status"].ToString());
                    string DocID = dr["ID"].ToString();
                    StringBuilder msg = new StringBuilder();
                    msg.Append("日程工作：工作到期再次提醒,『编号：" + DocID + "』<br>");
                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
                    msg.Append("状态：" + statusName + "<br>"); 
                    msg.Append("内容：" + dr["Detail"].ToString() + "<br>");
                    msg.Append("创建人：" + dr["CnName"].ToString() + "<br>");
                    msg.Append("工作要求完成时间：" + dr["EndDateTime"].ToString() + "<br>");
                    smsmsg = "EMC短信提醒：日程工作-工作到期再次提醒，『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + ">>，状态：" + statusName;
                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID);
                }
            }
        }

        //流程明细业务提醒
        void FlowTaskCall()
        {
            string AppID = "emc";
            string ModulesID = "emc.rcm.task";

            //流程工作
            //工作结束提前提醒
            //没有完成的工作，没有提前提醒记录，有提前提醒时间设置且提前提醒时间+当前时间>=结束时间且没有提前提醒记录
            string sql0 = @"select a.ID,a.Topic,b.CallType, b.ReCallTime,b.FlowDesc,b.UserID as domanid,b.UserName as doman,b.StartDate+b.StartTime as StartDateTime,b.CallTime,c.ListID ,c.Status as SendStatus, a.UserID,a.CnName, b.FlowDesc  ,b.FlowNo
 from Emc_RcmTask as a 
left join (
     select m.DocID, m.CallType, m.ReCallTime,n.FlowDesc,n.UserID,n.UserName,n.StartDate,n.StartTime,n.CallTime,n.FlowStatus,n.FlowNo from Pub_CallType as m
     left join (select DocID,FlowDesc,UserID,UserName,StartDate,StartTime,CallTime,FlowStatus,FlowNo from Emc_RcmTask_List where  ModulesID='emc.rcm.task' and CallTime>0 and  FlowStatus='1') as n 
     on m.docid=n.docid 
     where   m.AppID='emc' and m.ModulesID='emc.rcm.task' ) as b on a.ID=b.DocID
 left join (select ID as ListID,DocID,CallTypeTime,num,Status from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.task' and Flag=3) as c 
 on a.id=c.DocID
where a.TaskFlag<>'emc.rcm.myplan' and (a.Status='1' or a.Status='3')  and (b.CallTime is not null and b.CallTime <>'0' and c.DocID is null ) 
and datediff(minute,getdate(),   DATEADD ( hh , -b.CallTime, b.StartDate+b.StartTime ) )<=0";

            DataSet ds0 = DBTools.GetList(sql0);
            if (ds0.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds0.Tables[0].Rows)
                {
                    string CallType = dr["CallType"].ToString();
                    if (CallType == "")
                    {
                        continue;
                    }
                    string UserIds = dr["domanid"].ToString();
                    string smsmsg = "";

                    string SendUserID = "0";
                    string SendCnName = "EMC系统";
                    string Flag = "1";

                    string DocID = dr["ID"].ToString();
                    StringBuilder msg = new StringBuilder();
                    msg.Append("工作开始前提醒,『编号：" + DocID + "』<br>");
                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
                    msg.Append("明细：" + dr["FlowDesc"].ToString() + "<br>");
                    msg.Append("创建人：" + dr["CnName"].ToString() + "<br>");
                    msg.Append("工作要求开始时间：" + dr["StartDateTime"].ToString() + "<br>");
                    smsmsg = "EMC短信提醒：日程工作-工作开始前提醒，『编号：" + DocID + "』，<<" + dr["Topic"].ToString()+"-"+dr["FlowDesc"].ToString() + ">>";
                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID, dr["FlowNo"].ToString());
                }
            }


            //流程工作
            //工作结束提前提醒
            //没有完成的工作，没有提前提醒记录，有提前提醒时间设置且提前提醒时间+当前时间>=结束时间且没有提前提醒记录
            string sql1 = @"select a.ID,a.Topic,b.CallType, b.ReCallTime,b.FlowDesc,b.UserID as domanid,b.UserName as doman,b.EndDate+b.EndTime as EndDateTime,b.CallTime,c.ListID ,c.Status as SendStatus, a.UserID,a.CnName, b.FlowDesc  ,b.FlowNo
 from Emc_RcmTask as a 
left join (
     select m.DocID, m.CallType, m.ReCallTime,n.FlowDesc,n.UserID,n.UserName,n.EndDate,n.EndTime,n.CallTime,n.FlowStatus,n.FlowNo from Pub_CallType as m
     left join (select DocID,FlowDesc,UserID,UserName,EndDate,EndTime,CallTime,FlowStatus,FlowNo from Emc_RcmTask_List where  ModulesID='emc.rcm.task' and CallTime>0 and  (FlowStatus='1' or FlowStatus='3') ) as n 
     on m.docid=n.docid 
     where   m.AppID='emc' and m.ModulesID='emc.rcm.task' ) as b on a.ID=b.DocID
 left join (select ID as ListID,DocID,CallTypeTime,num,Status from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.task' and Flag=3) as c 
 on a.id=c.DocID
where a.TaskFlag<>'emc.rcm.myplan' and (a.Status='1' or a.Status='3')  and (b.CallTime is not null and b.CallTime <>'0' and c.DocID is null ) 
and datediff(minute,getdate(),   DATEADD ( hh , -b.CallTime, b.EndDate+b.EndTime ) )<=0";
        
            DataSet ds1 = DBTools.GetList(sql1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    string CallType = dr["CallType"].ToString();
                    if (CallType == "")
                    {
                        continue;
                    }
                    string UserIds = dr["domanid"].ToString();
                    string smsmsg = "";

                    string SendUserID = "0";
                    string SendCnName = "EMC系统";
                    string Flag = "3";

                    string DocID = dr["ID"].ToString();
                    StringBuilder msg = new StringBuilder();
                    msg.Append("工作到期提醒,『编号：" + DocID + "』<br>");
                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
                    msg.Append("明细：" + dr["FlowDesc"].ToString() + "<br>");
                    msg.Append("创建人：" + dr["CnName"].ToString() + "<br>");
                    msg.Append("工作要求完成时间：" + dr["EndDateTime"].ToString() + "<br>");
                    smsmsg = "EMC短信提醒：日程工作-工作到期提醒，『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + "-" + dr["FlowDesc"].ToString() + ">>";
                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID,dr["FlowNo"].ToString ());
                }
            }

                       //周期提醒:
            //没有完成的任务，有提前提醒时间设置且有周期提醒设置，如果没有周期提醒记录，则周期提醒时间+结束时间<=当前时间
            //如果有周期提醒时间，最后提醒时间+周期提醒时间<=当前时间
            string sql2 = @"
select a.ID,a.Topic,b.CallType, b.ReCallTime,b.FlowDesc,b.UserID as domanid,b.UserName as doman,b.EndDate+b.EndTime as EndDateTime,b.CallTime,c.ListID ,c.Status as SendStatus , a.UserID,a.CnName, b.FlowDesc,b.FlowNo 
 from Emc_RcmTask as a 
left join (
     select m.DocID, m.CallType, m.ReCallTime,n.FlowDesc,n.UserID,n.UserName,n.EndDate,n.EndTime,n.CallTime,n.FlowStatus,n.FlowNo from Pub_CallType as m
     left join (select DocID,FlowDesc,UserID,UserName,EndDate,EndTime,CallTime,FlowStatus,FlowNo from Emc_RcmTask_List where  ModulesID='emc.rcm.task' and CallTime>0 and  (FlowStatus='1' or FlowStatus='3')  ) as n 
     on m.docid=n.docid 
     where   m.AppID='emc' and m.ModulesID='emc.rcm.task' ) as b on a.ID=b.DocID
 left join (select ID as ListID,DocID,CallTypeTime,num,Status from Pub_CallList where AppID='emc' and ModulesID='emc.rcm.task' and Flag=2) as c 
 on a.id=c.DocID
 
where a.TaskFlag<>'emc.rcm.myplan' and (a.Status='1' or a.Status='3')  and b.DocID is not null and b.ReCallTime is not null and b.ReCallTime<>'0' 
 
    and ((c.ListID is null and datediff(minute,getdate(), DATEADD ( hh , b.ReCallTime, b.EndDate+b.EndTime ))<=0
   ) or (c.ListID is not null and c.Status <>'2' 
         and  datediff(minute,getdate(), DATEADD ( hh , b.ReCallTime, c.CallTypeTime ))<=0))";
            DataSet ds2 = DBTools.GetList(sql2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string CallType = dr["CallType"].ToString();
                    if (CallType == "")
                    {
                        continue;
                    }
 
                    string UserIds = dr["domanid"].ToString();
                    string smsmsg = "";

                    string SendUserID = "0";
                    string SendCnName = "EMC系统";
                    string Flag = "2";
                    string DocID = dr["ID"].ToString();
                    StringBuilder msg = new StringBuilder();
                    msg.Append("工作到期再次提醒,『编号：" + DocID + "』<br>");
                    msg.Append("主题：" + dr["Topic"].ToString() + "<br>");
                    msg.Append("明细：" + dr["FlowDesc"].ToString() + "<br>");
                    msg.Append("创建人：" + dr["CnName"].ToString () + "<br>");
                    msg.Append("工作要求完成时间：" + dr["EndDateTime"].ToString() + "<br>");
                    smsmsg = "EMC短信提醒：日程工作-工作到期再次提醒，『编号：" + DocID + "』，<<" + dr["Topic"].ToString() + "-" + dr["FlowDesc"].ToString() + ">>";
                    EmcCommon.SendMsg(msg.ToString(), smsmsg, UserIds, CallType, SendUserID, SendCnName, Flag, AppID, ModulesID, DocID,dr["FlowNo"].ToString ());
                }
            }
        }

        

        void SmsTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {

                SendPlanSms();//发定时短信
                SendPlanFax();//发定时传真
                SendBoMsg();//发业务提醒

            }
            catch (Exception ee)
            {
                log.Debug("SMS:"+ee.Message);
            }
        }

        //发送定时短信
        void SendPlanSms()
        {

            //取的定时短信
            string sql = @"select top 50  ID ,Mobiles,Msn   from  Emc_GtmMobileMsn   where SendFlag=0 and  SendType='定时' and  Status='未发送' 
 and SendHH<>'' and datediff(minute,getdate(),SendTime+SendHH)<=0 order by ID";
            DataSet ds = DBTools.GetList(sql);
            string strMobile = "";
            string strID = "";
            string MsnID = "";
            string strMsg = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    MsnID = dr["ID"].ToString();
                    strMsg = dr["Msn"].ToString();
                    strMobile = dr["Mobiles"].ToString() + ",";
                    strID += "'" + MsnID + "',";
                    if (strMobile != "")
                    {

                        msgTools.SendSms(strMobile, strMsg, "");
                    }
                }
                if (strID != "")
                {
                    strID = strID.Substring(0, strID.Length - 1);
                    string sqlup = "update Emc_GtmMobileMsn set status='发送' where ID in (" + strID + ")";
                    DBTools.UpdateTableBySql(sqlup);
                }
            }
        }


        //发送定时传真
        void SendPlanFax()
        {
            //取的定时短信
            string sql = @"select top 50  ID ,Mobiles,Title,FaxFileName,FaxFilePath 
   from  Emc_GtmMobileMsn   where SendFlag=1 and  SendType='定时' and  Status='未发送' 
 and SendHH<>'' and datediff(minute,getdate(),SendTime+SendHH)<=0 order by ID";
            DataSet ds = DBTools.GetList(sql);
            string strMobile = "";
            string strID = "";
            string MsnID = "";
            string strMsg = "";
            string title = "";
            string FaxFileName = ""; 
            string FaxFilePath = "";
            string faxnos = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    MsnID = dr["ID"].ToString();
                    strID += "'" + MsnID + "',";
                    faxnos = dr["Mobiles"].ToString();
                    FaxFilePath = Server.MapPath(dr["FaxFilePath"].ToString());
                    if (faxnos == "" || FaxFilePath=="")
                    {
                        continue;
                    }
                    title = dr["Title"].ToString();
                    FaxFileName = dr["FaxFileName"].ToString();
                    byte[] buffer = new byte[0];
                    if (File.Exists(FaxFilePath))
                    {
                        FileStream fs = new FileStream(FaxFilePath, FileMode.Open);

                        buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        fs.Close();
                        msgTools.SendFax(faxnos, title, buffer, FaxFileName);
                    }

                  
                }
                if (strID != "")
                {
                    strID = strID.Substring(0, strID.Length - 1);
                    string sqlup = "update Emc_GtmMobileMsn set status='发送' where ID in (" + strID + ")";
                    DBTools.UpdateTableBySql(sqlup);
                }
            }
        }

        //发业务提醒
        protected void SendBoMsg()
        {
            //取的定时短信
            string sql = @"select  *   from  Pub_CallList   where Status=0  ";
            DataSet ds = DBTools.GetList(sql);
            string UserID = "";
            string CnName = "";
            string ContactIDs = "";
            string ContactNames = "";
            string CallType = "";
            string Msg = "";
            string UserContact = "";
            string strID = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    UserID = dr["UserID"].ToString();
                    CallType = dr["CallType"].ToString();
                    CnName = dr["CnName"].ToString();
                    UserContact = dr["UserContact"].ToString();
                    ContactIDs = dr["ContactIDs"].ToString();
                    ContactNames = dr["ContactNames"].ToString();
                    Msg = dr["Msg"].ToString();
                    strID += "'" + dr["ID"].ToString() + "',";
                    if (ContactIDs != "")
                    {
                        if (CallType == "0")//消息
                        {
                            EmcCommon.SendMsn(UserID, CnName, Msg, ContactIDs, ContactNames);
                        }
                        else if (CallType == "1")//短信
                        {
                            msgTools.SendSms(ContactIDs, Msg, "");
                        }
                        else if (CallType == "2")//Email
                        {
                            string topic = "EMC邮件提醒";
                            if (UserContact == "")
                            {
                                UserContact = CnName;
                            }
                            string From = UserContact;
                            EmcCommon.SendMail(From, ContactIDs, "", "", topic, Msg, "html", null);
                        }
                    }
                    
                }

                if (strID != "")
                {
                    strID = strID.Substring(0, strID.Length - 1);
                    string sqlup = "update Pub_CallList set status='1' where ID in (" + strID + ")";
                    DBTools.UpdateTableBySql(sqlup);
                }
            }
        }




        protected void Application_End(object sender, EventArgs e)
        {
            //下面的代码是关键，可解决IIS应用程序池自动回收的问题 
            Thread.Sleep(1000);
            //这里设置你的web地址，可以随便指向你的任意一个aspx页面甚至不存在的页面，目的是要激发Application_Start 
            //string url = "http://www.qumiao.com";手机主题 
            string url = "/empty.aspx";
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流 


        }
        protected void Session_Start()
        {
            Application.Lock();
            //Application["UsersOnlineNum"] = (int)Application["UsersOnlineNum"] + 1;
            //Session["timerMsn"] = ConfigurationManager.AppSettings["timerMsn"];
            Application.UnLock();
        }

        protected void Session_End()
        {
            if (Session["LogID"] != null)
            {
                string LogID = Session["LogID"].ToString();
                //更新退出日志
                EmcCommon.UpdateSysLogs(LogID);
            }
            Application.Lock();
            if (Session["Uid"] != null)
            {
                string uid = Session["Uid"].ToString();

                DataTable dt = (DataTable)Application["UsersOnline"];

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["UID"].ToString() == uid)
                    {
                        Application["UsersOnlineNum"] = (int)Application["UsersOnlineNum"] - 1;
                        dt.Rows.Remove(dr);
                        break;
                    }
                }
            }
            Application.UnLock();
        }

        private DataTable CreateStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("UID", typeof(string)));
            dt.Columns.Add(new DataColumn("CnName", typeof(string)));
            dt.Columns.Add(new DataColumn("DeptID", typeof(string)));
            dt.Columns.Add(new DataColumn("FilialeID", typeof(string)));
            dt.Columns.Add(new DataColumn("Face", typeof(string)));
            return dt;
        }

        void Application_Error(object sender, EventArgs e)
        {
            string StartError = ConfigurationManager.AppSettings["StartError"];
            if (StartError == "1")
            {
                HttpUnhandledException eHttp = this.Server.GetLastError() as HttpUnhandledException;
                Exception eApp = eHttp.InnerException;
                log.Debug(eApp.Message);
                Response.Redirect("/emc/error.aspx?msg='" + Server.UrlEncode(eApp.Message) + "'");
                Server.ClearError();
                Response.End();
            }
        }
    }
}