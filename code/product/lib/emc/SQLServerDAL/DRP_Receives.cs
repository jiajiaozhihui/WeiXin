using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Receives
	/// </summary>
	public partial class DRP_Receives:IDRP_Receives
	{
		public DRP_Receives()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Receives"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Receives");
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
		public int Add(SfSoft.Model.DRP_Receives model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Receives(");
			strSql.Append("OrderID,PayStatus,Payment,PayRemark,PayDate,ReceiveMan,Creator,CreatorID,modifier,mtime)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@PayStatus,@Payment,@PayRemark,@PayDate,@ReceiveMan,@Creator,@CreatorID,@modifier,@mtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@PayStatus", SqlDbType.Int,4),
					new SqlParameter("@Payment", SqlDbType.Int,4),
					new SqlParameter("@PayRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@PayDate", SqlDbType.DateTime),
					new SqlParameter("@ReceiveMan", SqlDbType.NVarChar,20),
					new SqlParameter("@Creator", SqlDbType.NVarChar,20),
					new SqlParameter("@CreatorID", SqlDbType.Int,4),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@mtime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.PayStatus;
			parameters[2].Value = model.Payment;
			parameters[3].Value = model.PayRemark;
			parameters[4].Value = model.PayDate;
			parameters[5].Value = model.ReceiveMan;
			parameters[6].Value = model.Creator;
			parameters[7].Value = model.CreatorID;
			parameters[8].Value = model.modifier;
			parameters[9].Value = model.mtime;

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
		public bool Update(SfSoft.Model.DRP_Receives model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Receives set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("PayStatus=@PayStatus,");
			strSql.Append("Payment=@Payment,");
			strSql.Append("PayRemark=@PayRemark,");
			strSql.Append("PayDate=@PayDate,");
			strSql.Append("ReceiveMan=@ReceiveMan,");
			strSql.Append("Creator=@Creator,");
			strSql.Append("CreatorID=@CreatorID,");
			strSql.Append("modifier=@modifier,");
			strSql.Append("mtime=@mtime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@PayStatus", SqlDbType.Int,4),
					new SqlParameter("@Payment", SqlDbType.Int,4),
					new SqlParameter("@PayRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@PayDate", SqlDbType.DateTime),
					new SqlParameter("@ReceiveMan", SqlDbType.NVarChar,20),
					new SqlParameter("@Creator", SqlDbType.NVarChar,20),
					new SqlParameter("@CreatorID", SqlDbType.Int,4),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.PayStatus;
			parameters[2].Value = model.Payment;
			parameters[3].Value = model.PayRemark;
			parameters[4].Value = model.PayDate;
			parameters[5].Value = model.ReceiveMan;
			parameters[6].Value = model.Creator;
			parameters[7].Value = model.CreatorID;
			parameters[8].Value = model.modifier;
			parameters[9].Value = model.mtime;
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
			strSql.Append("delete from DRP_Receives ");
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
			strSql.Append("delete from DRP_Receives ");
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
		public SfSoft.Model.DRP_Receives GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrderID,PayStatus,Payment,PayRemark,PayDate,ReceiveMan,Creator,CreatorID,modifier,mtime from DRP_Receives ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Receives model=new SfSoft.Model.DRP_Receives();
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
				if(ds.Tables[0].Rows[0]["PayStatus"]!=null && ds.Tables[0].Rows[0]["PayStatus"].ToString()!="")
				{
					model.PayStatus=int.Parse(ds.Tables[0].Rows[0]["PayStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Payment"]!=null && ds.Tables[0].Rows[0]["Payment"].ToString()!="")
				{
					model.Payment=int.Parse(ds.Tables[0].Rows[0]["Payment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PayRemark"]!=null && ds.Tables[0].Rows[0]["PayRemark"].ToString()!="")
				{
					model.PayRemark=ds.Tables[0].Rows[0]["PayRemark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PayDate"]!=null && ds.Tables[0].Rows[0]["PayDate"].ToString()!="")
				{
					model.PayDate=DateTime.Parse(ds.Tables[0].Rows[0]["PayDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReceiveMan"]!=null && ds.Tables[0].Rows[0]["ReceiveMan"].ToString()!="")
				{
					model.ReceiveMan=ds.Tables[0].Rows[0]["ReceiveMan"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Creator"]!=null && ds.Tables[0].Rows[0]["Creator"].ToString()!="")
				{
					model.Creator=ds.Tables[0].Rows[0]["Creator"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatorID"]!=null && ds.Tables[0].Rows[0]["CreatorID"].ToString()!="")
				{
					model.CreatorID=int.Parse(ds.Tables[0].Rows[0]["CreatorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modifier"]!=null && ds.Tables[0].Rows[0]["modifier"].ToString()!="")
				{
					model.modifier=ds.Tables[0].Rows[0]["modifier"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mtime"]!=null && ds.Tables[0].Rows[0]["mtime"].ToString()!="")
				{
					model.mtime=DateTime.Parse(ds.Tables[0].Rows[0]["mtime"].ToString());
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
			strSql.Append("select ID,OrderID,PayStatus,Payment,PayRemark,PayDate,ReceiveMan,Creator,CreatorID,modifier,mtime ");
			strSql.Append(" FROM DRP_Receives ");
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
			strSql.Append(" ID,OrderID,PayStatus,Payment,PayRemark,PayDate,ReceiveMan,Creator,CreatorID,modifier,mtime ");
			strSql.Append(" FROM DRP_Receives ");
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
			strSql.Append("select count(1) FROM DRP_Receives ");
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
			strSql.Append(")AS Row, T.*  from DRP_Receives T ");
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
			parameters[0].Value = "DRP_Receives";
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

