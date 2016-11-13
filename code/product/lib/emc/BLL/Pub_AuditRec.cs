using System;
using System.Data;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// ҵ���߼���Pub_AuditRec ��ժҪ˵����
	/// </summary>
	public class Pub_AuditRec
	{
		private readonly IPub_AuditRec dal=DataAccess.CreatePub_AuditRec();
		public Pub_AuditRec()
		{}
		#region  ��Ա����

 

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ARID)
		{
			return dal.Exists(ARID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SfSoft.Model.Pub_AuditRec model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_AuditRec model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ARID)
		{
			dal.Delete(ARID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_AuditRec GetModel(int ARID)
		{
			return dal.GetModel(ARID);
		}
        /// <summary>
         /// ȡ���������е���Ϣ
         /// </summary>
         /// <param name="MID">ģ��ID</param>
         /// <param name="DocID">����ID</param>
         /// <returns></returns>
        public SfSoft.Model.Pub_AuditRec GetModel(string MID, string DocID)
        {
            return dal.GetModel(MID, DocID);
        }
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SfSoft.Model.Pub_AuditRec GetModelByCache(int ARID)
		{
			string CacheKey = "Pub_AuditRecModel-" + ARID;
			object objModel = SfSoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ARID);
					if (objModel != null)
					{
						int ModelCache = SfSoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						SfSoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SfSoft.Model.Pub_AuditRec)objModel;
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
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

