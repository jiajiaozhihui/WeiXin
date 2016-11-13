using System;
using System.Data;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// ҵ���߼���Pub_AuditResult ��ժҪ˵����
	/// </summary>
	public class Pub_AuditResult
	{
		private readonly IPub_AuditResult dal=DataAccess.CreatePub_AuditResult();
		public Pub_AuditResult()
		{}
		#region  ��Ա����
 

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ARSID)
		{
			return dal.Exists(ARSID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SfSoft.Model.Pub_AuditResult model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_AuditResult model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ARSID)
		{
			dal.Delete(ARSID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_AuditResult GetModel(int ARSID)
		{
			return dal.GetModel(ARSID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SfSoft.Model.Pub_AuditResult GetModelByCache(int ARSID)
		{
			string CacheKey = "Pub_AuditResultModel-" + ARSID;
			object objModel = SfSoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ARSID);
					if (objModel != null)
					{
						int ModelCache = SfSoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						SfSoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SfSoft.Model.Pub_AuditResult)objModel;
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

