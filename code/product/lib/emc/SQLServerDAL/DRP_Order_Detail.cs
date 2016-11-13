﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Order_Detail
	/// </summary>
	public partial class DRP_Order_Detail:IDRP_Order_Detail
	{
		public DRP_Order_Detail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Order_Detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Order_Detail");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SfSoft.Model.DRP_Order_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Order_Detail(");
			strSql.Append("OrderID,ProductNo,ProductName,ProductType,ProductKind,Price,Num,TotalPrice,SNO,LRemark)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@ProductNo,@ProductName,@ProductType,@ProductKind,@Price,@Num,@TotalPrice,@SNO,@LRemark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@ProductNo", SqlDbType.NVarChar,20),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,100),
					new SqlParameter("@ProductType", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductKind", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@TotalPrice", SqlDbType.Float,8),
					new SqlParameter("@SNO", SqlDbType.NVarChar,50),
					new SqlParameter("@LRemark", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.ProductNo;
			parameters[2].Value = model.ProductName;
			parameters[3].Value = model.ProductType;
			parameters[4].Value = model.ProductKind;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.Num;
			parameters[7].Value = model.TotalPrice;
			parameters[8].Value = model.SNO;
			parameters[9].Value = model.LRemark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SfSoft.Model.DRP_Order_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Order_Detail set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("ProductNo=@ProductNo,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("ProductType=@ProductType,");
			strSql.Append("ProductKind=@ProductKind,");
			strSql.Append("Price=@Price,");
			strSql.Append("Num=@Num,");
			strSql.Append("TotalPrice=@TotalPrice,");
			strSql.Append("SNO=@SNO,");
			strSql.Append("LRemark=@LRemark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@ProductNo", SqlDbType.NVarChar,20),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,100),
					new SqlParameter("@ProductType", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductKind", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@TotalPrice", SqlDbType.Float,8),
					new SqlParameter("@SNO", SqlDbType.NVarChar,50),
					new SqlParameter("@LRemark", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.ProductNo;
			parameters[2].Value = model.ProductName;
			parameters[3].Value = model.ProductType;
			parameters[4].Value = model.ProductKind;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.Num;
			parameters[7].Value = model.TotalPrice;
			parameters[8].Value = model.SNO;
			parameters[9].Value = model.LRemark;
			parameters[10].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DRP_Order_Detail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DRP_Order_Detail ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SfSoft.Model.DRP_Order_Detail GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrderID,ProductNo,ProductName,ProductType,ProductKind,Price,Num,TotalPrice,SNO,LRemark from DRP_Order_Detail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Order_Detail model=new SfSoft.Model.DRP_Order_Detail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderID"]!=null && ds.Tables[0].Rows[0]["OrderID"].ToString()!="")
				{
					model.OrderID=int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductNo"]!=null && ds.Tables[0].Rows[0]["ProductNo"].ToString()!="")
				{
					model.ProductNo=ds.Tables[0].Rows[0]["ProductNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductName"]!=null && ds.Tables[0].Rows[0]["ProductName"].ToString()!="")
				{
					model.ProductName=ds.Tables[0].Rows[0]["ProductName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductType"]!=null && ds.Tables[0].Rows[0]["ProductType"].ToString()!="")
				{
					model.ProductType=ds.Tables[0].Rows[0]["ProductType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductKind"]!=null && ds.Tables[0].Rows[0]["ProductKind"].ToString()!="")
				{
					model.ProductKind=int.Parse(ds.Tables[0].Rows[0]["ProductKind"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Num"]!=null && ds.Tables[0].Rows[0]["Num"].ToString()!="")
				{
					model.Num=int.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TotalPrice"]!=null && ds.Tables[0].Rows[0]["TotalPrice"].ToString()!="")
				{
					model.TotalPrice=decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SNO"]!=null && ds.Tables[0].Rows[0]["SNO"].ToString()!="")
				{
					model.SNO=ds.Tables[0].Rows[0]["SNO"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LRemark"]!=null && ds.Tables[0].Rows[0]["LRemark"].ToString()!="")
				{
					model.LRemark=ds.Tables[0].Rows[0]["LRemark"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,OrderID,ProductNo,ProductName,ProductType,ProductKind,Price,Num,TotalPrice,SNO,LRemark ");
			strSql.Append(" FROM DRP_Order_Detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,OrderID,ProductNo,ProductName,ProductType,ProductKind,Price,Num,TotalPrice,SNO,LRemark ");
			strSql.Append(" FROM DRP_Order_Detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM DRP_Order_Detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from DRP_Order_Detail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "DRP_Order_Detail";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}
