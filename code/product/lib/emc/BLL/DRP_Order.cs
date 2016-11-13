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
	/// DRP_Order
	/// </summary>
	public partial class DRP_Order
	{
		private readonly IDRP_Order dal=DataAccess.CreateDRP_Order();
		public DRP_Order()
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
		public int  Add(SfSoft.Model.DRP_Order model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Order model)
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
		public SfSoft.Model.DRP_Order GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SfSoft.Model.DRP_Order GetModelByCache(int ID)
		{
			
			string CacheKey = "DRP_OrderModel-" + ID;
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
			return (SfSoft.Model.DRP_Order)objModel;
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
		public List<SfSoft.Model.DRP_Order> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Order> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.DRP_Order> modelList = new List<SfSoft.Model.DRP_Order>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.DRP_Order model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.DRP_Order();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["OrderNo"]!=null && dt.Rows[n]["OrderNo"].ToString()!="")
					{
					model.OrderNo=dt.Rows[n]["OrderNo"].ToString();
					}
					if(dt.Rows[n]["DisID"]!=null && dt.Rows[n]["DisID"].ToString()!="")
					{
						model.DisID=int.Parse(dt.Rows[n]["DisID"].ToString());
					}
					if(dt.Rows[n]["DisNo"]!=null && dt.Rows[n]["DisNo"].ToString()!="")
					{
					model.DisNo=dt.Rows[n]["DisNo"].ToString();
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["Addr"]!=null && dt.Rows[n]["Addr"].ToString()!="")
					{
					model.Addr=dt.Rows[n]["Addr"].ToString();
					}
					if(dt.Rows[n]["TotalAmt"]!=null && dt.Rows[n]["TotalAmt"].ToString()!="")
					{
						model.TotalAmt=decimal.Parse(dt.Rows[n]["TotalAmt"].ToString());
					}
					if(dt.Rows[n]["TotalNum"]!=null && dt.Rows[n]["TotalNum"].ToString()!="")
					{
						model.TotalNum=int.Parse(dt.Rows[n]["TotalNum"].ToString());
					}
					if(dt.Rows[n]["OrderDate"]!=null && dt.Rows[n]["OrderDate"].ToString()!="")
					{
						model.OrderDate=DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
					}
					if(dt.Rows[n]["OrderStatus"]!=null && dt.Rows[n]["OrderStatus"].ToString()!="")
					{
						model.OrderStatus=int.Parse(dt.Rows[n]["OrderStatus"].ToString());
					}
					if(dt.Rows[n]["Payment"]!=null && dt.Rows[n]["Payment"].ToString()!="")
					{
						model.Payment=int.Parse(dt.Rows[n]["Payment"].ToString());
					}
					if(dt.Rows[n]["BalanceStatus"]!=null && dt.Rows[n]["BalanceStatus"].ToString()!="")
					{
						model.BalanceStatus=int.Parse(dt.Rows[n]["BalanceStatus"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["mtime"]!=null && dt.Rows[n]["mtime"].ToString()!="")
					{
						model.mtime=DateTime.Parse(dt.Rows[n]["mtime"].ToString());
					}
					if(dt.Rows[n]["modifier"]!=null && dt.Rows[n]["modifier"].ToString()!="")
					{
					model.modifier=dt.Rows[n]["modifier"].ToString();
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

