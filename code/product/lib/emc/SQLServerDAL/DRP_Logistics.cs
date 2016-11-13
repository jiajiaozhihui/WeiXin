using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Logistics
	/// </summary>
	public partial class DRP_Logistics:IDRP_Logistics
	{
		public DRP_Logistics()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Logistics"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Logistics");
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
		public int Add(SfSoft.Model.DRP_Logistics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Logistics(");
			strSql.Append("OrderID,Logistics,LogisticsNo,SendStatus,LExpense,LCharge,SendDate,SendMan,Remark,Creator,CreatorID,ctime,modifier,mtime)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@Logistics,@LogisticsNo,@SendStatus,@LExpense,@LCharge,@SendDate,@SendMan,@Remark,@Creator,@CreatorID,@ctime,@modifier,@mtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Logistics", SqlDbType.NVarChar,50),
					new SqlParameter("@LogisticsNo", SqlDbType.NVarChar,20),
					new SqlParameter("@SendStatus", SqlDbType.Int,4),
					new SqlParameter("@LExpense", SqlDbType.Float,8),
					new SqlParameter("@LCharge", SqlDbType.Float,8),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@SendMan", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Creator", SqlDbType.NVarChar,20),
					new SqlParameter("@CreatorID", SqlDbType.Int,4),
					new SqlParameter("@ctime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@mtime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.Logistics;
			parameters[2].Value = model.LogisticsNo;
			parameters[3].Value = model.SendStatus;
			parameters[4].Value = model.LExpense;
			parameters[5].Value = model.LCharge;
			parameters[6].Value = model.SendDate;
			parameters[7].Value = model.SendMan;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.Creator;
			parameters[10].Value = model.CreatorID;
			parameters[11].Value = model.ctime;
			parameters[12].Value = model.modifier;
			parameters[13].Value = model.mtime;

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
		public bool Update(SfSoft.Model.DRP_Logistics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Logistics set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("Logistics=@Logistics,");
			strSql.Append("LogisticsNo=@LogisticsNo,");
			strSql.Append("SendStatus=@SendStatus,");
			strSql.Append("LExpense=@LExpense,");
			strSql.Append("LCharge=@LCharge,");
			strSql.Append("SendDate=@SendDate,");
			strSql.Append("SendMan=@SendMan,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Creator=@Creator,");
			strSql.Append("CreatorID=@CreatorID,");
			strSql.Append("ctime=@ctime,");
			strSql.Append("modifier=@modifier,");
			strSql.Append("mtime=@mtime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Logistics", SqlDbType.NVarChar,50),
					new SqlParameter("@LogisticsNo", SqlDbType.NVarChar,20),
					new SqlParameter("@SendStatus", SqlDbType.Int,4),
					new SqlParameter("@LExpense", SqlDbType.Float,8),
					new SqlParameter("@LCharge", SqlDbType.Float,8),
					new SqlParameter("@SendDate", SqlDbType.DateTime),
					new SqlParameter("@SendMan", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Creator", SqlDbType.NVarChar,20),
					new SqlParameter("@CreatorID", SqlDbType.Int,4),
					new SqlParameter("@ctime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.Logistics;
			parameters[2].Value = model.LogisticsNo;
			parameters[3].Value = model.SendStatus;
			parameters[4].Value = model.LExpense;
			parameters[5].Value = model.LCharge;
			parameters[6].Value = model.SendDate;
			parameters[7].Value = model.SendMan;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.Creator;
			parameters[10].Value = model.CreatorID;
			parameters[11].Value = model.ctime;
			parameters[12].Value = model.modifier;
			parameters[13].Value = model.mtime;
			parameters[14].Value = model.ID;

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
			strSql.Append("delete from DRP_Logistics ");
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
			strSql.Append("delete from DRP_Logistics ");
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
		public SfSoft.Model.DRP_Logistics GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrderID,Logistics,LogisticsNo,SendStatus,LExpense,LCharge,SendDate,SendMan,Remark,Creator,CreatorID,ctime,modifier,mtime from DRP_Logistics ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Logistics model=new SfSoft.Model.DRP_Logistics();
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
				if(ds.Tables[0].Rows[0]["Logistics"]!=null && ds.Tables[0].Rows[0]["Logistics"].ToString()!="")
				{
					model.Logistics=ds.Tables[0].Rows[0]["Logistics"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LogisticsNo"]!=null && ds.Tables[0].Rows[0]["LogisticsNo"].ToString()!="")
				{
					model.LogisticsNo=ds.Tables[0].Rows[0]["LogisticsNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SendStatus"]!=null && ds.Tables[0].Rows[0]["SendStatus"].ToString()!="")
				{
					model.SendStatus=int.Parse(ds.Tables[0].Rows[0]["SendStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LExpense"]!=null && ds.Tables[0].Rows[0]["LExpense"].ToString()!="")
				{
					model.LExpense=decimal.Parse(ds.Tables[0].Rows[0]["LExpense"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LCharge"]!=null && ds.Tables[0].Rows[0]["LCharge"].ToString()!="")
				{
					model.LCharge=decimal.Parse(ds.Tables[0].Rows[0]["LCharge"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendDate"]!=null && ds.Tables[0].Rows[0]["SendDate"].ToString()!="")
				{
					model.SendDate=DateTime.Parse(ds.Tables[0].Rows[0]["SendDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendMan"]!=null && ds.Tables[0].Rows[0]["SendMan"].ToString()!="")
				{
					model.SendMan=ds.Tables[0].Rows[0]["SendMan"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Creator"]!=null && ds.Tables[0].Rows[0]["Creator"].ToString()!="")
				{
					model.Creator=ds.Tables[0].Rows[0]["Creator"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatorID"]!=null && ds.Tables[0].Rows[0]["CreatorID"].ToString()!="")
				{
					model.CreatorID=int.Parse(ds.Tables[0].Rows[0]["CreatorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ctime"]!=null && ds.Tables[0].Rows[0]["ctime"].ToString()!="")
				{
					model.ctime=DateTime.Parse(ds.Tables[0].Rows[0]["ctime"].ToString());
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
			strSql.Append("select ID,OrderID,Logistics,LogisticsNo,SendStatus,LExpense,LCharge,SendDate,SendMan,Remark,Creator,CreatorID,ctime,modifier,mtime ");
			strSql.Append(" FROM DRP_Logistics ");
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
			strSql.Append(" ID,OrderID,Logistics,LogisticsNo,SendStatus,LExpense,LCharge,SendDate,SendMan,Remark,Creator,CreatorID,ctime,modifier,mtime ");
			strSql.Append(" FROM DRP_Logistics ");
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
			strSql.Append("select count(1) FROM DRP_Logistics ");
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
			strSql.Append(")AS Row, T.*  from DRP_Logistics T ");
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
			parameters[0].Value = "DRP_Logistics";
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

