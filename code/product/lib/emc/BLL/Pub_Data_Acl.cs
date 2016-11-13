using System;
using System.Data;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// ҵ���߼���Pub_Data_Acl ��ժҪ˵����
	/// </summary>
	public class Pub_Data_Acl
	{
		private readonly IPub_Data_Acl dal=DataAccess.CreatePub_Data_Acl();
		public Pub_Data_Acl()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		//public int GetMaxId()
		//{
		//	return dal.GetMaxId();
		//}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SfSoft.Model.Pub_Data_Acl model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_Data_Acl model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			dal.Delete(ID);
		}
        /// <summary>
        /// ɾ����������
        /// </summary>
        public void Deletes(int DataAclID)
        {
            dal.Deletes(DataAclID);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_Data_Acl GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}


        /// <summary>
        /// ����ȫ������Ȩ�޲���
        /// </summary>
        public void AddAllDept(string sFilialeID,string sActId, string sModulesID)
        {
            dal.AddAllDept(sFilialeID,sActId, sModulesID);
        }


        /// <summary>
        /// ����ȫ������Ȩ�޲���
        /// </summary>
        public void DelAllDept(string sFilialeID,string sActId, string sModulesID)
        {
            dal.DelAllDept(sFilialeID,sActId, sModulesID);
        }
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

