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
	/// DRP_Balance_Dir
	/// </summary>
	public partial class DRP_Balance_Dir
	{
		private readonly IDRP_Balance_Dir dal=DataAccess.CreateDRP_Balance_Dir();
		public DRP_Balance_Dir()
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
		public int  Add(SfSoft.Model.DRP_Balance_Dir model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Balance_Dir model)
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
		public SfSoft.Model.DRP_Balance_Dir GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SfSoft.Model.DRP_Balance_Dir GetModelByCache(int ID)
		{
			
			string CacheKey = "DRP_Balance_DirModel-" + ID;
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
			return (SfSoft.Model.DRP_Balance_Dir)objModel;
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
		public List<SfSoft.Model.DRP_Balance_Dir> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Balance_Dir> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.DRP_Balance_Dir> modelList = new List<SfSoft.Model.DRP_Balance_Dir>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.DRP_Balance_Dir model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.DRP_Balance_Dir();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["BalNo"]!=null && dt.Rows[n]["BalNo"].ToString()!="")
					{
					model.BalNo=dt.Rows[n]["BalNo"].ToString();
					}
					if(dt.Rows[n]["BalID"]!=null && dt.Rows[n]["BalID"].ToString()!="")
					{
						model.BalID=int.Parse(dt.Rows[n]["BalID"].ToString());
					}
					if(dt.Rows[n]["DisType"]!=null && dt.Rows[n]["DisType"].ToString()!="")
					{
						model.DisType=int.Parse(dt.Rows[n]["DisType"].ToString());
					}
					if(dt.Rows[n]["DisID"]!=null && dt.Rows[n]["DisID"].ToString()!="")
					{
						model.DisID=int.Parse(dt.Rows[n]["DisID"].ToString());
					}
					if(dt.Rows[n]["DisNo"]!=null && dt.Rows[n]["DisNo"].ToString()!="")
					{
					model.DisNo=dt.Rows[n]["DisNo"].ToString();
					}
					if(dt.Rows[n]["DisName"]!=null && dt.Rows[n]["DisName"].ToString()!="")
					{
					model.DisName=dt.Rows[n]["DisName"].ToString();
					}
					if(dt.Rows[n]["DisName1"]!=null && dt.Rows[n]["DisName1"].ToString()!="")
					{
					model.DisName1=dt.Rows[n]["DisName1"].ToString();
					}
					if(dt.Rows[n]["BalTimeStart"]!=null && dt.Rows[n]["BalTimeStart"].ToString()!="")
					{
						model.BalTimeStart=DateTime.Parse(dt.Rows[n]["BalTimeStart"].ToString());
					}
					if(dt.Rows[n]["BalTimeEnd"]!=null && dt.Rows[n]["BalTimeEnd"].ToString()!="")
					{
						model.BalTimeEnd=DateTime.Parse(dt.Rows[n]["BalTimeEnd"].ToString());
					}
					if(dt.Rows[n]["BalPrice"]!=null && dt.Rows[n]["BalPrice"].ToString()!="")
					{
						model.BalPrice=decimal.Parse(dt.Rows[n]["BalPrice"].ToString());
					}
					if(dt.Rows[n]["BalNums"]!=null && dt.Rows[n]["BalNums"].ToString()!="")
					{
						model.BalNums=int.Parse(dt.Rows[n]["BalNums"].ToString());
					}
					if(dt.Rows[n]["BalAmt"]!=null && dt.Rows[n]["BalAmt"].ToString()!="")
					{
						model.BalAmt=decimal.Parse(dt.Rows[n]["BalAmt"].ToString());
					}
					if(dt.Rows[n]["BalDate"]!=null && dt.Rows[n]["BalDate"].ToString()!="")
					{
						model.BalDate=DateTime.Parse(dt.Rows[n]["BalDate"].ToString());
					}
					if(dt.Rows[n]["BalMan"]!=null && dt.Rows[n]["BalMan"].ToString()!="")
					{
					model.BalMan=dt.Rows[n]["BalMan"].ToString();
					}
					if(dt.Rows[n]["BalManID"]!=null && dt.Rows[n]["BalManID"].ToString()!="")
					{
						model.BalManID=int.Parse(dt.Rows[n]["BalManID"].ToString());
					}
					if(dt.Rows[n]["PayStatus"]!=null && dt.Rows[n]["PayStatus"].ToString()!="")
					{
						model.PayStatus=int.Parse(dt.Rows[n]["PayStatus"].ToString());
					}
					if(dt.Rows[n]["PayDate"]!=null && dt.Rows[n]["PayDate"].ToString()!="")
					{
						model.PayDate=DateTime.Parse(dt.Rows[n]["PayDate"].ToString());
					}
					if(dt.Rows[n]["PayMan"]!=null && dt.Rows[n]["PayMan"].ToString()!="")
					{
					model.PayMan=dt.Rows[n]["PayMan"].ToString();
					}
					if(dt.Rows[n]["PayRemark"]!=null && dt.Rows[n]["PayRemark"].ToString()!="")
					{
					model.PayRemark=dt.Rows[n]["PayRemark"].ToString();
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

