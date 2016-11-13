using System;
using System.Data;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// ҵ���߼���Pub_AuditFlow ��ժҪ˵����
	/// </summary>
	public class Pub_AuditFlow
	{
		private readonly IPub_AuditFlow dal=DataAccess.CreatePub_AuditFlow();
		public Pub_AuditFlow()
		{}
		#region  ��Ա����

        /// <summary>
        ///  
        /// </summary>
        public int GetMaxClass(string strWhere)
        {
            return dal.GetMaxClass(strWhere);
        }

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int AFID)
		{
			return dal.Exists(AFID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SfSoft.Model.Pub_AuditFlow model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_AuditFlow model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AFID)
		{
			dal.Delete(AFID);
		}
        /// <summary>
        /// �����ϼ�����
        /// </summary>
        public void UpAuditClass(int AuditClass, string MID, string FilialeID)
        {
            dal.UpAuditClass(AuditClass, MID, FilialeID);
        }
        /// <summary>
        /// �����ϼ�����
        /// </summary>
        public void LwAuditClass(int AuditClass, string MID, string FilialeID)
        {
            dal.LwAuditClass(AuditClass, MID, FilialeID);
        }
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_AuditFlow GetModel(int AFID)
		{
			return dal.GetModel(AFID);
		}
        public SfSoft.Model.Pub_AuditFlow GetModel(string MID, string AuditClass, string FilialeID)
        {
            return dal.GetModel(MID, AuditClass, FilialeID);
        }
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SfSoft.Model.Pub_AuditFlow GetModelByCache(int AFID)
		{
			string CacheKey = "Pub_AuditFlowModel-" + AFID;
			object objModel = SfSoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AFID);
					if (objModel != null)
					{
						int ModelCache = SfSoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						SfSoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SfSoft.Model.Pub_AuditFlow)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
        /// <summary>
        /// ȡ�ı�����������Ϣ
        /// </summary>
        /// <param name="DocID">����ID</param>
        /// <param name="BoName">����</param>
        /// <returns></returns>
        public DataSet GetBoInfo(string DocID, string BoName)
        {
            return dal.GetBoInfo( DocID, BoName);
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

