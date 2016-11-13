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
	/// DRP_Order_Cancels
	/// </summary>
	public partial class DRP_Order_Cancels
	{
		private readonly IDRP_Order_Cancels dal=DataAccess.CreateDRP_Order_Cancels();
		public DRP_Order_Cancels()
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
		public int  Add(SfSoft.Model.DRP_Order_Cancels model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Order_Cancels model)
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
		public SfSoft.Model.DRP_Order_Cancels GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SfSoft.Model.DRP_Order_Cancels GetModelByCache(int ID)
		{
			
			string CacheKey = "DRP_Order_CancelsModel-" + ID;
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
			return (SfSoft.Model.DRP_Order_Cancels)objModel;
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
		public List<SfSoft.Model.DRP_Order_Cancels> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Order_Cancels> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.DRP_Order_Cancels> modelList = new List<SfSoft.Model.DRP_Order_Cancels>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.DRP_Order_Cancels model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.DRP_Order_Cancels();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["OrderID"]!=null && dt.Rows[n]["OrderID"].ToString()!="")
					{
						model.OrderID=int.Parse(dt.Rows[n]["OrderID"].ToString());
					}
					if(dt.Rows[n]["OStatus"]!=null && dt.Rows[n]["OStatus"].ToString()!="")
					{
						model.OStatus=int.Parse(dt.Rows[n]["OStatus"].ToString());
					}
					if(dt.Rows[n]["CancelReason"]!=null && dt.Rows[n]["CancelReason"].ToString()!="")
					{
					model.CancelReason=dt.Rows[n]["CancelReason"].ToString();
					}
					if(dt.Rows[n]["CancelStatus"]!=null && dt.Rows[n]["CancelStatus"].ToString()!="")
					{
						model.CancelStatus=int.Parse(dt.Rows[n]["CancelStatus"].ToString());
					}
					if(dt.Rows[n]["DisName"]!=null && dt.Rows[n]["DisName"].ToString()!="")
					{
					model.DisName=dt.Rows[n]["DisName"].ToString();
					}
					if(dt.Rows[n]["DisID"]!=null && dt.Rows[n]["DisID"].ToString()!="")
					{
						model.DisID=int.Parse(dt.Rows[n]["DisID"].ToString());
					}
					if(dt.Rows[n]["CancelDate"]!=null && dt.Rows[n]["CancelDate"].ToString()!="")
					{
						model.CancelDate=DateTime.Parse(dt.Rows[n]["CancelDate"].ToString());
					}
					if(dt.Rows[n]["CheckMan"]!=null && dt.Rows[n]["CheckMan"].ToString()!="")
					{
					model.CheckMan=dt.Rows[n]["CheckMan"].ToString();
					}
					if(dt.Rows[n]["CheckManID"]!=null && dt.Rows[n]["CheckManID"].ToString()!="")
					{
						model.CheckManID=int.Parse(dt.Rows[n]["CheckManID"].ToString());
					}
					if(dt.Rows[n]["CheckDate"]!=null && dt.Rows[n]["CheckDate"].ToString()!="")
					{
						model.CheckDate=DateTime.Parse(dt.Rows[n]["CheckDate"].ToString());
					}
					if(dt.Rows[n]["CheckRemark"]!=null && dt.Rows[n]["CheckRemark"].ToString()!="")
					{
					model.CheckRemark=dt.Rows[n]["CheckRemark"].ToString();
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

