using System;
using System.Data;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// ҵ���߼���Pub_FunDef ��ժҪ˵����
	/// </summary>
	public class Pub_FunDef
	{
		private readonly IPub_FunDef dal=DataAccess.CreatePub_FunDef();
		public Pub_FunDef()
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
		public int  Add(SfSoft.Model.Pub_FunDef model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_FunDef model)
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
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_FunDef GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SfSoft.Model.Pub_FunDef GetModelByCache(int ID)
		{
			string CacheKey = "Pub_FunDefModel-" + ID;
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
			return (SfSoft.Model.Pub_FunDef)objModel;
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

        /// <summary>
        /// �����Ƿ���Ҫ�����ֶ�
        /// </summary>
        public void UpdateIsApprove(string FunID, string FunType, string IsApprove)
        {
            dal.UpdateIsApprove(FunID, FunType, IsApprove);
        }

		#endregion  ��Ա����
	}
}

