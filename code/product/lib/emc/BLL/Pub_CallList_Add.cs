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
	/// Pub_CallList_Add
	/// </summary>
	public class Pub_CallList_Add
	{
		private readonly IPub_CallList_Add dal=DataAccess.CreatePub_CallList_Add();
		public Pub_CallList_Add()
		{}
		#region  Method

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
		public int  Add(SfSoft.Model.Pub_CallList_Add model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(SfSoft.Model.Pub_CallList_Add model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_CallList_Add GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public SfSoft.Model.Pub_CallList_Add GetModelByCache(int ID)
		{
			
			string CacheKey = "Pub_CallList_AddModel-" + ID;
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
			return (SfSoft.Model.Pub_CallList_Add)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<SfSoft.Model.Pub_CallList_Add> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<SfSoft.Model.Pub_CallList_Add> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.Pub_CallList_Add> modelList = new List<SfSoft.Model.Pub_CallList_Add>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.Pub_CallList_Add model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.Pub_CallList_Add();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["CallListID"].ToString()!="")
					{
						model.CallListID=int.Parse(dt.Rows[n]["CallListID"].ToString());
					}
					if(dt.Rows[n]["CallType"].ToString()!="")
					{
						model.CallType=int.Parse(dt.Rows[n]["CallType"].ToString());
					}
					model.CallAdd=dt.Rows[n]["CallAdd"].ToString();
					model.CallName=dt.Rows[n]["CallName"].ToString();
					model.CallUid=dt.Rows[n]["CallUid"].ToString();
					model.Status=dt.Rows[n]["Status"].ToString();
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
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

