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
	/// DRP_Logistics
	/// </summary>
	public partial class DRP_Logistics
	{
		private readonly IDRP_Logistics dal=DataAccess.CreateDRP_Logistics();
		public DRP_Logistics()
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
		public int  Add(SfSoft.Model.DRP_Logistics model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Logistics model)
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
		public SfSoft.Model.DRP_Logistics GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SfSoft.Model.DRP_Logistics GetModelByCache(int ID)
		{
			
			string CacheKey = "DRP_LogisticsModel-" + ID;
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
			return (SfSoft.Model.DRP_Logistics)objModel;
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
		public List<SfSoft.Model.DRP_Logistics> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Logistics> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.DRP_Logistics> modelList = new List<SfSoft.Model.DRP_Logistics>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.DRP_Logistics model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.DRP_Logistics();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["OrderID"]!=null && dt.Rows[n]["OrderID"].ToString()!="")
					{
						model.OrderID=int.Parse(dt.Rows[n]["OrderID"].ToString());
					}
					if(dt.Rows[n]["Logistics"]!=null && dt.Rows[n]["Logistics"].ToString()!="")
					{
					model.Logistics=dt.Rows[n]["Logistics"].ToString();
					}
					if(dt.Rows[n]["LogisticsNo"]!=null && dt.Rows[n]["LogisticsNo"].ToString()!="")
					{
					model.LogisticsNo=dt.Rows[n]["LogisticsNo"].ToString();
					}
					if(dt.Rows[n]["SendStatus"]!=null && dt.Rows[n]["SendStatus"].ToString()!="")
					{
						model.SendStatus=int.Parse(dt.Rows[n]["SendStatus"].ToString());
					}
					if(dt.Rows[n]["LExpense"]!=null && dt.Rows[n]["LExpense"].ToString()!="")
					{
						model.LExpense=decimal.Parse(dt.Rows[n]["LExpense"].ToString());
					}
					if(dt.Rows[n]["LCharge"]!=null && dt.Rows[n]["LCharge"].ToString()!="")
					{
						model.LCharge=decimal.Parse(dt.Rows[n]["LCharge"].ToString());
					}
					if(dt.Rows[n]["SendDate"]!=null && dt.Rows[n]["SendDate"].ToString()!="")
					{
						model.SendDate=DateTime.Parse(dt.Rows[n]["SendDate"].ToString());
					}
					if(dt.Rows[n]["SendMan"]!=null && dt.Rows[n]["SendMan"].ToString()!="")
					{
					model.SendMan=dt.Rows[n]["SendMan"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["Creator"]!=null && dt.Rows[n]["Creator"].ToString()!="")
					{
					model.Creator=dt.Rows[n]["Creator"].ToString();
					}
					if(dt.Rows[n]["CreatorID"]!=null && dt.Rows[n]["CreatorID"].ToString()!="")
					{
						model.CreatorID=int.Parse(dt.Rows[n]["CreatorID"].ToString());
					}
					if(dt.Rows[n]["ctime"]!=null && dt.Rows[n]["ctime"].ToString()!="")
					{
						model.ctime=DateTime.Parse(dt.Rows[n]["ctime"].ToString());
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

