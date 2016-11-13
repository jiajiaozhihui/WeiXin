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
	/// DRP_Distributor
	/// </summary>
	public partial class DRP_Distributor
	{
		private readonly IDRP_Distributor dal=DataAccess.CreateDRP_Distributor();
		public DRP_Distributor()
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
		public int  Add(SfSoft.Model.DRP_Distributor model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Distributor model)
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
		public SfSoft.Model.DRP_Distributor GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SfSoft.Model.DRP_Distributor GetModelByCache(int ID)
		{
			
			string CacheKey = "DRP_DistributorModel-" + ID;
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
			return (SfSoft.Model.DRP_Distributor)objModel;
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
		public List<SfSoft.Model.DRP_Distributor> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SfSoft.Model.DRP_Distributor> DataTableToList(DataTable dt)
		{
			List<SfSoft.Model.DRP_Distributor> modelList = new List<SfSoft.Model.DRP_Distributor>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SfSoft.Model.DRP_Distributor model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SfSoft.Model.DRP_Distributor();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["DisNo"]!=null && dt.Rows[n]["DisNo"].ToString()!="")
					{
					model.DisNo=dt.Rows[n]["DisNo"].ToString();
					}
					if(dt.Rows[n]["PassWord"]!=null && dt.Rows[n]["PassWord"].ToString()!="")
					{
					model.PassWord=dt.Rows[n]["PassWord"].ToString();
					}
					if(dt.Rows[n]["DisName"]!=null && dt.Rows[n]["DisName"].ToString()!="")
					{
					model.DisName=dt.Rows[n]["DisName"].ToString();
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["Mobile"]!=null && dt.Rows[n]["Mobile"].ToString()!="")
					{
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					}
					if(dt.Rows[n]["QQ"]!=null && dt.Rows[n]["QQ"].ToString()!="")
					{
					model.QQ=dt.Rows[n]["QQ"].ToString();
					}
					if(dt.Rows[n]["Province"]!=null && dt.Rows[n]["Province"].ToString()!="")
					{
					model.Province=dt.Rows[n]["Province"].ToString();
					}
					if(dt.Rows[n]["City"]!=null && dt.Rows[n]["City"].ToString()!="")
					{
					model.City=dt.Rows[n]["City"].ToString();
					}
					if(dt.Rows[n]["Addr"]!=null && dt.Rows[n]["Addr"].ToString()!="")
					{
					model.Addr=dt.Rows[n]["Addr"].ToString();
					}
					if(dt.Rows[n]["PDisID"]!=null && dt.Rows[n]["PDisID"].ToString()!="")
					{
						model.PDisID=int.Parse(dt.Rows[n]["PDisID"].ToString());
					}
					if(dt.Rows[n]["PDisNo"]!=null && dt.Rows[n]["PDisNo"].ToString()!="")
					{
					model.PDisNo=dt.Rows[n]["PDisNo"].ToString();
					}
					if(dt.Rows[n]["DisAmt"]!=null && dt.Rows[n]["DisAmt"].ToString()!="")
					{
						model.DisAmt=decimal.Parse(dt.Rows[n]["DisAmt"].ToString());
					}
					if(dt.Rows[n]["Bank"]!=null && dt.Rows[n]["Bank"].ToString()!="")
					{
					model.Bank=dt.Rows[n]["Bank"].ToString();
					}
					if(dt.Rows[n]["AccountName"]!=null && dt.Rows[n]["AccountName"].ToString()!="")
					{
					model.AccountName=dt.Rows[n]["AccountName"].ToString();
					}
					if(dt.Rows[n]["CardNo"]!=null && dt.Rows[n]["CardNo"].ToString()!="")
					{
					model.CardNo=dt.Rows[n]["CardNo"].ToString();
					}
					if(dt.Rows[n]["DisType"]!=null && dt.Rows[n]["DisType"].ToString()!="")
					{
						model.DisType=int.Parse(dt.Rows[n]["DisType"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Head"]!=null && dt.Rows[n]["Head"].ToString()!="")
					{
					model.Head=dt.Rows[n]["Head"].ToString();
					}
					if(dt.Rows[n]["SignName"]!=null && dt.Rows[n]["SignName"].ToString()!="")
					{
					model.SignName=dt.Rows[n]["SignName"].ToString();
					}
					if(dt.Rows[n]["JoinDate"]!=null && dt.Rows[n]["JoinDate"].ToString()!="")
					{
						model.JoinDate=DateTime.Parse(dt.Rows[n]["JoinDate"].ToString());
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

