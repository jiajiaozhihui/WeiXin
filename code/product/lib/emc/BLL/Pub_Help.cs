using System;
using System.Data;
using System.Collections.Generic;
using SfSoft.Common;
using SfSoft.Model;
using SfSoft.DALFactory;
using SfSoft.IDAL;
namespace SfSoft.BLL
{
	/// <summary>
	/// ҵ���߼���Pub_Help ��ժҪ˵����
	/// </summary>
	public class Pub_Help
	{
		private readonly IPub_Help dal=DataAccess.CreatePub_Help();
		public Pub_Help()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

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
		public int  Add(SfSoft.Model.Pub_Help model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_Help model)
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
		public SfSoft.Model.Pub_Help GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}
        public SfSoft.Model.Pub_Help GetModel(string  HelpID)
        {

            return dal.GetModel(HelpID);
        }
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SfSoft.Model.Pub_Help GetModelByCache(int ID)
		{
			
			string CacheKey = "Pub_HelpModel-" + ID;
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
			return (SfSoft.Model.Pub_Help)objModel;
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
		public List<SfSoft.Model.Pub_Help> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SfSoft.Model.Pub_Help> modelList = new List<SfSoft.Model.Pub_Help>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.Pub_Help model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.Pub_Help();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.ModulesID=ds.Tables[0].Rows[n]["ModulesID"].ToString();
					model.ModulesName=ds.Tables[0].Rows[n]["ModulesName"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					model.NoteInfo=ds.Tables[0].Rows[n]["NoteInfo"].ToString();
					model.Mpath=ds.Tables[0].Rows[n]["Mpath"].ToString();
					model.CaseInfo=ds.Tables[0].Rows[n]["CaseInfo"].ToString();
					model.FlowInfo=ds.Tables[0].Rows[n]["FlowInfo"].ToString();
					model.AppInfo=ds.Tables[0].Rows[n]["AppInfo"].ToString();
					model.Others=ds.Tables[0].Rows[n]["Others"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
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

