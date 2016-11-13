using System;
using System.Reflection;
using System.Configuration;

namespace SfSoft.DALFactory
{
	/// <summary>
    /// Abstract Factory pattern to create the DAL銆?


	/// </summary>
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //涓嶄娇鐢ㄧ紦瀛?


        private static object CreateObjectNoCache(string path, string CacheKey)
        {
            try
            {
                object objType = Assembly.Load(path).CreateInstance(CacheKey);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 璁板綍閿欒鏃ュ織
                return null;
            }

        }
        //浣跨敤缂撳瓨
        private static object CreateObject(string path, string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);
                    DataCache.SetCache(CacheKey, objType);// 鍐欏叆缂撳瓨
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 璁板綍閿欒鏃ュ織
                }
            }
            return objType;
        }


        #endregion

        #region 系统管理
        /// <summary>
        /// 鍒涘缓pub_modules鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Modules CreatePub_Modules()
        {

            string CacheKey = path + ".Pub_Modules";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Modules)objType;
        }
        /// <summary>
        /// 鍒涘缓Pub_Modules_Fun鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Modules_Fun CreatePub_Modules_Fun()
        {

            string CacheKey = path + ".Pub_Modules_Fun";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Modules_Fun)objType;
        }


        /// <summary>
        /// 鍒涘缓Pub_Help鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Help CreatePub_Help()
        {

            string CacheKey = path + ".Pub_Help";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Help)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_EmpInfo鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_EmpInfo CreatePub_EmpInfo()
        {

            string CacheKey = path + ".Pub_EmpInfo";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_EmpInfo)objType;
        }
        /// <summary>
        /// 鍒涘缓Pub_Roles_Fun鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Roles_Fun CreatePub_Roles_Fun()
        {

            string CacheKey = path + ".Pub_Roles_Fun";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Roles_Fun)objType;
        }

        /// <summary>
        /// 鍒涘缓aspnet_Roles鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.Iaspnet_Roles Createaspnet_Roles()
        {

            string CacheKey = path + ".aspnet_Roles";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.Iaspnet_Roles)objType;
        }
        /// <summary>
        /// 鍒涘缓Pub_Dept鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Dept CreatePub_Dept()
        {

            string CacheKey = path + ".Pub_Dept";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Dept)objType;
        }

        		
		/// <summary>
		/// 鍒涘缓Pub_Company鏁版嵁灞傛帴鍙?


		/// </summary>
		public static SfSoft.IDAL.IPub_Company CreatePub_Company()
		{

			string CacheKey = path+".Pub_Company";
			object objType=CreateObject(path,CacheKey);
			return (SfSoft.IDAL.IPub_Company)objType;
		}

        /// <summary>
        /// 鍒涘缓Pub_DeptUsers鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_DeptUsers CreatePub_DeptUsers()
        {

            string CacheKey = path + ".Pub_DeptUsers";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_DeptUsers)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_Roles_Company鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Roles_Company CreatePub_Roles_Company()
        {

            string CacheKey = path + ".Pub_Roles_Company";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Roles_Company)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_BaseData_Classc鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_BaseData_Classc CreatePub_BaseData_Classc()
        {

            string CacheKey = path + ".Pub_BaseData_Classc";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_BaseData_Classc)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_BaseData鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_BaseData CreatePub_BaseData()
        {

            string CacheKey = path + ".Pub_BaseData";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_BaseData)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_FunDef鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_FunDef CreatePub_FunDef()
        {

            string CacheKey = path + ".Pub_FunDef";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_FunDef)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_Data_Acl鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Data_Acl CreatePub_Data_Acl()
        {

            string CacheKey = path + ".Pub_Data_Acl";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Data_Acl)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_Data_Acl_Users鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Data_Acl_Users CreatePub_Data_Acl_Users()
        {

            string CacheKey = path + ".Pub_Data_Acl_Users";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Data_Acl_Users)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_Data_Assign鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Data_Assign CreatePub_Data_Assign()
        {

            string CacheKey = path + ".Pub_Data_Assign";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Data_Assign)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_Data_doc鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Data_doc CreatePub_Data_doc()
        {

            string CacheKey = path + ".Pub_Data_doc";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Data_doc)objType;
        }
      

        /// <summary>
        /// 鍒涘缓Pub_EmpInfo_Holiday鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_EmpInfo_Holiday CreatePub_EmpInfo_Holiday()
        {

            string CacheKey = path + ".Pub_EmpInfo_Holiday";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_EmpInfo_Holiday)objType;
        }

        public static SfSoft.IDAL.IPub_CallType CreatePub_CallType()
        {

            string CacheKey = path + ".Pub_CallType";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_CallType)objType;
        }


        public static SfSoft.IDAL.IPub_SysParameter CreatePub_SysParameter()
        {

            string CacheKey = path + ".Pub_SysParameter";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_SysParameter)objType;
        }
        public static SfSoft.IDAL.IPub_CallList_Add CreatePub_CallList_Add()
        {

            string CacheKey = path + ".Pub_CallList_Add";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_CallList_Add)objType;
        }

        #endregion
        #region 消息


        /// <summary>
        /// 鍒涘缓Pub_Msn鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Msn CreatePub_Msn()
        {

            string CacheKey = path + ".Pub_Msn";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Msn)objType;
        }
        /// <summary>
        /// 鍒涘缓Pub_Msn_Addressee鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_Msn_Addressee CreatePub_Msn_Addressee()
        {

            string CacheKey = path + ".Pub_Msn_Addressee";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_Msn_Addressee)objType;
        }
        #endregion 
        #region 工作流程
        /// <summary>
        /// 鍒涘缓Pub_ACFlow鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_ACFlow CreatePub_ACFlow()
        {

            string CacheKey = path + ".Pub_ACFlow";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_ACFlow)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_AuditFlow鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_AuditFlow CreatePub_AuditFlow()
        {

            string CacheKey = path + ".Pub_AuditFlow";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_AuditFlow)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_AuditRec鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_AuditRec CreatePub_AuditRec()
        {

            string CacheKey = path + ".Pub_AuditRec";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_AuditRec)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_AuditFlow_Dept鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_AuditFlow_Dept CreatePub_AuditFlow_Dept()
        {

            string CacheKey = path + ".Pub_AuditFlow_Dept";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_AuditFlow_Dept)objType;
        }

        /// <summary>
        /// 鍒涘缓Pub_AuditResult鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_AuditResult CreatePub_AuditResult()
        {

            string CacheKey = path + ".Pub_AuditResult";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_AuditResult)objType;
        }
        #endregion

        #region 附件
        /// <summary>
        /// 鍒涘缓Pub_AttFiles鏁版嵁灞傛帴鍙?


        /// </summary>
        public static SfSoft.IDAL.IPub_AttFiles CreatePub_AttFiles()
        {

            string CacheKey = path + ".Pub_AttFiles";
            object objType = CreateObject(path, CacheKey);
            return (SfSoft.IDAL.IPub_AttFiles)objType;
        }
        #endregion
  
 
 
     
  
  
 

 
        #region

        public static SfSoft.IDAL.IPub_SignFile CreatePub_SignFile()
        {

            string ClassNamespace = path + ".Pub_SignFile";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IPub_SignFile)objType;
        }
        public static SfSoft.IDAL.IPub_Surrogate CreatePub_Surrogate()
        {

            string ClassNamespace = path + ".Pub_Surrogate";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IPub_Surrogate)objType;
        }
        public static SfSoft.IDAL.IPub_CallList CreatePub_CallList()
        {

            string ClassNamespace = path + ".Pub_CallList";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IPub_CallList)objType;
        }

        
        
		/// <summary>
		/// 日志
		/// </summary>
		public static SfSoft.IDAL.IEmc_logs CreateEmc_logs()
		{

			string ClassNamespace = path +".Emc_logs";
			object objType=CreateObject(path,ClassNamespace);
			return (SfSoft.IDAL.IEmc_logs)objType;
		}
        #endregion

 
   
       
 
        /// <summary>
        /// 创建Pub_ComputerKey数据层接口
        /// </summary>
        public static SfSoft.IDAL.IPub_ComputerKey CreatePub_ComputerKey()
        {

            string ClassNamespace = path + ".Pub_ComputerKey";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IPub_ComputerKey)objType;
        }
 

     

      

        /// <summary>
        /// 创建Pub_UnSystem数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IPub_UnSystem CreatePub_UnSystem()
        {

            string ClassNamespace = path + ".Pub_UnSystem";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IPub_UnSystem)objType;
        }


        #region
   
        #endregion
 

 
  
        /// <summary>
        /// 创建Emc_Msg_Interface数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IEmc_Msg_Interface CreateEmc_Msg_Interface()
        {

            string ClassNamespace = path + ".Emc_Msg_Interface";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IEmc_Msg_Interface)objType;
        }


        #region 分销系统
        /// <summary>
        /// 创建DRP_Balance_Dir数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Balance_Dir CreateDRP_Balance_Dir()
        {

            string ClassNamespace = path + ".DRP_Balance_Dir";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Balance_Dir)objType;
        }


        /// <summary>
        /// 创建DRP_Balance_Dir_Detail数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Balance_Dir_Detail CreateDRP_Balance_Dir_Detail()
        {

            string ClassNamespace = path + ".DRP_Balance_Dir_Detail";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Balance_Dir_Detail)objType;
        }


        /// <summary>
        /// 创建DRP_Content_Temp数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Content_Temp CreateDRP_Content_Temp()
        {

            string ClassNamespace = path + ".DRP_Content_Temp";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Content_Temp)objType;
        }


        /// <summary>
        /// 创建DRP_Customer数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Customer CreateDRP_Customer()
        {

            string ClassNamespace = path + ".DRP_Customer";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Customer)objType;
        }


        /// <summary>
        /// 创建DRP_Distributor数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Distributor CreateDRP_Distributor()
        {

            string ClassNamespace = path + ".DRP_Distributor";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Distributor)objType;
        }


        /// <summary>
        /// 创建DRP_Invite_Arts数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Invite_Arts CreateDRP_Invite_Arts()
        {

            string ClassNamespace = path + ".DRP_Invite_Arts";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Invite_Arts)objType;
        }


        /// <summary>
        /// 创建DRP_Invite_My_Arts数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Invite_My_Arts CreateDRP_Invite_My_Arts()
        {

            string ClassNamespace = path + ".DRP_Invite_My_Arts";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Invite_My_Arts)objType;
        }


        /// <summary>
        /// 创建DRP_Login_logs数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Login_logs CreateDRP_Login_logs()
        {

            string ClassNamespace = path + ".DRP_Login_logs";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Login_logs)objType;
        }


        /// <summary>
        /// 创建DRP_Logistics数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Logistics CreateDRP_Logistics()
        {

            string ClassNamespace = path + ".DRP_Logistics";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Logistics)objType;
        }


        /// <summary>
        /// 创建DRP_Order数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Order CreateDRP_Order()
        {

            string ClassNamespace = path + ".DRP_Order";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Order)objType;
        }


        /// <summary>
        /// 创建DRP_Order_Cancels数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Order_Cancels CreateDRP_Order_Cancels()
        {

            string ClassNamespace = path + ".DRP_Order_Cancels";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Order_Cancels)objType;
        }


        /// <summary>
        /// 创建DRP_Order_Detail数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Order_Detail CreateDRP_Order_Detail()
        {

            string ClassNamespace = path + ".DRP_Order_Detail";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Order_Detail)objType;
        }


        /// <summary>
        /// 创建DRP_Products数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Products CreateDRP_Products()
        {

            string ClassNamespace = path + ".DRP_Products";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Products)objType;
        }


        /// <summary>
        /// 创建DRP_Products_Detail数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Products_Detail CreateDRP_Products_Detail()
        {

            string ClassNamespace = path + ".DRP_Products_Detail";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Products_Detail)objType;
        }


        /// <summary>
        /// 创建DRP_Receives数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Receives CreateDRP_Receives()
        {

            string ClassNamespace = path + ".DRP_Receives";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Receives)objType;
        }


        /// <summary>
        /// 创建DRP_Sales_Arts数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Sales_Arts CreateDRP_Sales_Arts()
        {

            string ClassNamespace = path + ".DRP_Sales_Arts";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Sales_Arts)objType;
        }


        /// <summary>
        /// 创建DRP_Sales_My_Arts数据层接口。
        /// </summary>
        public static SfSoft.IDAL.IDRP_Sales_My_Arts CreateDRP_Sales_My_Arts()
        {

            string ClassNamespace = path + ".DRP_Sales_My_Arts";
            object objType = CreateObject(path, ClassNamespace);
            return (SfSoft.IDAL.IDRP_Sales_My_Arts)objType;
        }


        #endregion
    }
}
