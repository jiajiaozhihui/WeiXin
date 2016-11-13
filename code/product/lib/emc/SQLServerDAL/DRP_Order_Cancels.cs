using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Order_Cancels
	/// </summary>
	public partial class DRP_Order_Cancels:IDRP_Order_Cancels
	{
		public DRP_Order_Cancels()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Order_Cancels"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Order_Cancels");
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
		public int Add(SfSoft.Model.DRP_Order_Cancels model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Order_Cancels(");
			strSql.Append("OrderID,OStatus,CancelReason,CancelStatus,DisName,DisID,CancelDate,CheckMan,CheckManID,CheckDate,CheckRemark)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@OStatus,@CancelReason,@CancelStatus,@DisName,@DisID,@CancelDate,@CheckMan,@CheckManID,@CheckDate,@CheckRemark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OStatus", SqlDbType.Int,4),
					new SqlParameter("@CancelReason", SqlDbType.NVarChar,100),
					new SqlParameter("@CancelStatus", SqlDbType.Int,4),
					new SqlParameter("@DisName", SqlDbType.NVarChar,20),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@CancelDate", SqlDbType.DateTime),
					new SqlParameter("@CheckMan", SqlDbType.NVarChar,20),
					new SqlParameter("@CheckManID", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@CheckRemark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.OStatus;
			parameters[2].Value = model.CancelReason;
			parameters[3].Value = model.CancelStatus;
			parameters[4].Value = model.DisName;
			parameters[5].Value = model.DisID;
			parameters[6].Value = model.CancelDate;
			parameters[7].Value = model.CheckMan;
			parameters[8].Value = model.CheckManID;
			parameters[9].Value = model.CheckDate;
			parameters[10].Value = model.CheckRemark;

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
		public bool Update(SfSoft.Model.DRP_Order_Cancels model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Order_Cancels set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("OStatus=@OStatus,");
			strSql.Append("CancelReason=@CancelReason,");
			strSql.Append("CancelStatus=@CancelStatus,");
			strSql.Append("DisName=@DisName,");
			strSql.Append("DisID=@DisID,");
			strSql.Append("CancelDate=@CancelDate,");
			strSql.Append("CheckMan=@CheckMan,");
			strSql.Append("CheckManID=@CheckManID,");
			strSql.Append("CheckDate=@CheckDate,");
			strSql.Append("CheckRemark=@CheckRemark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@OStatus", SqlDbType.Int,4),
					new SqlParameter("@CancelReason", SqlDbType.NVarChar,100),
					new SqlParameter("@CancelStatus", SqlDbType.Int,4),
					new SqlParameter("@DisName", SqlDbType.NVarChar,20),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@CancelDate", SqlDbType.DateTime),
					new SqlParameter("@CheckMan", SqlDbType.NVarChar,20),
					new SqlParameter("@CheckManID", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@CheckRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.OStatus;
			parameters[2].Value = model.CancelReason;
			parameters[3].Value = model.CancelStatus;
			parameters[4].Value = model.DisName;
			parameters[5].Value = model.DisID;
			parameters[6].Value = model.CancelDate;
			parameters[7].Value = model.CheckMan;
			parameters[8].Value = model.CheckManID;
			parameters[9].Value = model.CheckDate;
			parameters[10].Value = model.CheckRemark;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from DRP_Order_Cancels ");
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
			strSql.Append("delete from DRP_Order_Cancels ");
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
		public SfSoft.Model.DRP_Order_Cancels GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrderID,OStatus,CancelReason,CancelStatus,DisName,DisID,CancelDate,CheckMan,CheckManID,CheckDate,CheckRemark from DRP_Order_Cancels ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Order_Cancels model=new SfSoft.Model.DRP_Order_Cancels();
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
				if(ds.Tables[0].Rows[0]["OStatus"]!=null && ds.Tables[0].Rows[0]["OStatus"].ToString()!="")
				{
					model.OStatus=int.Parse(ds.Tables[0].Rows[0]["OStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CancelReason"]!=null && ds.Tables[0].Rows[0]["CancelReason"].ToString()!="")
				{
					model.CancelReason=ds.Tables[0].Rows[0]["CancelReason"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CancelStatus"]!=null && ds.Tables[0].Rows[0]["CancelStatus"].ToString()!="")
				{
					model.CancelStatus=int.Parse(ds.Tables[0].Rows[0]["CancelStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisName"]!=null && ds.Tables[0].Rows[0]["DisName"].ToString()!="")
				{
					model.DisName=ds.Tables[0].Rows[0]["DisName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisID"]!=null && ds.Tables[0].Rows[0]["DisID"].ToString()!="")
				{
					model.DisID=int.Parse(ds.Tables[0].Rows[0]["DisID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CancelDate"]!=null && ds.Tables[0].Rows[0]["CancelDate"].ToString()!="")
				{
					model.CancelDate=DateTime.Parse(ds.Tables[0].Rows[0]["CancelDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CheckMan"]!=null && ds.Tables[0].Rows[0]["CheckMan"].ToString()!="")
				{
					model.CheckMan=ds.Tables[0].Rows[0]["CheckMan"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CheckManID"]!=null && ds.Tables[0].Rows[0]["CheckManID"].ToString()!="")
				{
					model.CheckManID=int.Parse(ds.Tables[0].Rows[0]["CheckManID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CheckDate"]!=null && ds.Tables[0].Rows[0]["CheckDate"].ToString()!="")
				{
					model.CheckDate=DateTime.Parse(ds.Tables[0].Rows[0]["CheckDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CheckRemark"]!=null && ds.Tables[0].Rows[0]["CheckRemark"].ToString()!="")
				{
					model.CheckRemark=ds.Tables[0].Rows[0]["CheckRemark"].ToString();
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
			strSql.Append("select ID,OrderID,OStatus,CancelReason,CancelStatus,DisName,DisID,CancelDate,CheckMan,CheckManID,CheckDate,CheckRemark ");
			strSql.Append(" FROM DRP_Order_Cancels ");
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
			strSql.Append(" ID,OrderID,OStatus,CancelReason,CancelStatus,DisName,DisID,CancelDate,CheckMan,CheckManID,CheckDate,CheckRemark ");
			strSql.Append(" FROM DRP_Order_Cancels ");
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
			strSql.Append("select count(1) FROM DRP_Order_Cancels ");
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
			strSql.Append(")AS Row, T.*  from DRP_Order_Cancels T ");
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
			parameters[0].Value = "DRP_Order_Cancels";
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

