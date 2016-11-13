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
	/// DRP_Invite_Arts
	/// </summary>
	public partial class DRP_Invite_Arts
	{
		private readonly IDRP_Invite_Arts dal=DataAccess.CreateDRP_Invite_Arts();
		public DRP_Invite_Arts()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

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
		public int  Add(SfSoft.Model.DRP_Invite_Arts model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Invite_Arts model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SfSoft.Model.DRP_Invite_Arts GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SfSoft.Model.DRP_Invite_Arts GetModelByCache(int ID)
		{
			
			string CacheKey = "DRP_Invite_ArtsModel-" + ID;
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
			return (SfSoft.Model.DRP_Invite_Arts)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Invite_Arts> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Invite_Arts> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.DRP_Invite_Arts> modelList = new List<SfSoft.Model.DRP_Invite_Arts>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.DRP_Invite_Arts model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.DRP_Invite_Arts();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Topic"]!=null && dt.Rows[n]["Topic"].ToString()!="")
					{
					model.Topic=dt.Rows[n]["Topic"].ToString();
					}
					if(dt.Rows[n]["KeyWord"]!=null && dt.Rows[n]["KeyWord"].ToString()!="")
					{
					model.KeyWord=dt.Rows[n]["KeyWord"].ToString();
					}
					if(dt.Rows[n]["ArtType"]!=null && dt.Rows[n]["ArtType"].ToString()!="")
					{
						model.ArtType=int.Parse(dt.Rows[n]["ArtType"].ToString());
					}
					if(dt.Rows[n]["SendStatus"]!=null && dt.Rows[n]["SendStatus"].ToString()!="")
					{
						model.SendStatus=int.Parse(dt.Rows[n]["SendStatus"].ToString());
					}
					if(dt.Rows[n]["ArtContent"]!=null && dt.Rows[n]["ArtContent"].ToString()!="")
					{
					model.ArtContent=dt.Rows[n]["ArtContent"].ToString();
					}
					if(dt.Rows[n]["PubDate"]!=null && dt.Rows[n]["PubDate"].ToString()!="")
					{
						model.PubDate=DateTime.Parse(dt.Rows[n]["PubDate"].ToString());
					}
					if(dt.Rows[n]["Creator"]!=null && dt.Rows[n]["Creator"].ToString()!="")
					{
					model.Creator=dt.Rows[n]["Creator"].ToString();
					}
					if(dt.Rows[n]["OrderID"]!=null && dt.Rows[n]["OrderID"].ToString()!="")
					{
						model.OrderID=int.Parse(dt.Rows[n]["OrderID"].ToString());
					}
					if(dt.Rows[n]["TurnNum"]!=null && dt.Rows[n]["TurnNum"].ToString()!="")
					{
						model.TurnNum=int.Parse(dt.Rows[n]["TurnNum"].ToString());
					}
					if(dt.Rows[n]["ClickNum"]!=null && dt.Rows[n]["ClickNum"].ToString()!="")
					{
						model.ClickNum=int.Parse(dt.Rows[n]["ClickNum"].ToString());
					}
					if(dt.Rows[n]["modifier"]!=null && dt.Rows[n]["modifier"].ToString()!="")
					{
					model.modifier=dt.Rows[n]["modifier"].ToString();
					}
					if(dt.Rows[n]["mtime"]!=null && dt.Rows[n]["mtime"].ToString()!="")
					{
						model.mtime=DateTime.Parse(dt.Rows[n]["mtime"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

