using System;
using System.Data;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// 业务逻辑类Pub_Data_Acl 的摘要说明。
	/// </summary>
	public class Pub_Data_Acl
	{
		private readonly IPub_Data_Acl dal=DataAccess.CreatePub_Data_Acl();
		public Pub_Data_Acl()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		//public int GetMaxId()
		//{
		//	return dal.GetMaxId();
		//}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SfSoft.Model.Pub_Data_Acl model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SfSoft.Model.Pub_Data_Acl model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			dal.Delete(ID);
		}
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void Deletes(int DataAclID)
        {
            dal.Deletes(DataAclID);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SfSoft.Model.Pub_Data_Acl GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public SfSoft.Model.Pub_Data_Acl GetModelByCache(int ID)
		{
			string CacheKey = "Pub_Data_AclModel-" + ID;
			object objModel = SfSoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = SfSoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						SfSoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SfSoft.Model.Pub_Data_Acl)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}


        /// <summary>
        /// 增加全部数据权限部门
        /// </summary>
        public void AddAllDept(string sFilialeID,string sActId, string sModulesID)
        {
            dal.AddAllDept(sFilialeID,sActId, sModulesID);
        }


        /// <summary>
        /// 增加全部数据权限部门
        /// </summary>
        public void DelAllDept(string sFilialeID,string sActId, string sModulesID)
        {
            dal.DelAllDept(sFilialeID,sActId, sModulesID);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

