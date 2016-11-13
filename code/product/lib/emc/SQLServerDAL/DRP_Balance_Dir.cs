using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Balance_Dir
	/// </summary>
	public partial class DRP_Balance_Dir:IDRP_Balance_Dir
	{
		public DRP_Balance_Dir()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Balance_Dir"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Balance_Dir");
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
		public int Add(SfSoft.Model.DRP_Balance_Dir model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Balance_Dir(");
			strSql.Append("BalNo,BalID,DisType,DisID,DisNo,DisName,DisName1,BalTimeStart,BalTimeEnd,BalPrice,BalNums,BalAmt,BalDate,BalMan,BalManID,PayStatus,PayDate,PayMan,PayRemark)");
			strSql.Append(" values (");
			strSql.Append("@BalNo,@BalID,@DisType,@DisID,@DisNo,@DisName,@DisName1,@BalTimeStart,@BalTimeEnd,@BalPrice,@BalNums,@BalAmt,@BalDate,@BalMan,@BalManID,@PayStatus,@PayDate,@PayMan,@PayRemark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BalNo", SqlDbType.NVarChar,20),
					new SqlParameter("@BalID", SqlDbType.Int,4),
					new SqlParameter("@DisType", SqlDbType.Int,4),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@DisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@DisName", SqlDbType.NVarChar,50),
					new SqlParameter("@DisName1", SqlDbType.NVarChar,50),
					new SqlParameter("@BalTimeStart", SqlDbType.DateTime),
					new SqlParameter("@BalTimeEnd", SqlDbType.DateTime),
					new SqlParameter("@BalPrice", SqlDbType.Float,8),
					new SqlParameter("@BalNums", SqlDbType.Int,4),
					new SqlParameter("@BalAmt", SqlDbType.Float,8),
					new SqlParameter("@BalDate", SqlDbType.DateTime),
					new SqlParameter("@BalMan", SqlDbType.NVarChar,20),
					new SqlParameter("@BalManID", SqlDbType.Int,4),
					new SqlParameter("@PayStatus", SqlDbType.Int,4),
					new SqlParameter("@PayDate", SqlDbType.DateTime),
					new SqlParameter("@PayMan", SqlDbType.NVarChar,20),
					new SqlParameter("@PayRemark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.BalNo;
			parameters[1].Value = model.BalID;
			parameters[2].Value = model.DisType;
			parameters[3].Value = model.DisID;
			parameters[4].Value = model.DisNo;
			parameters[5].Value = model.DisName;
			parameters[6].Value = model.DisName1;
			parameters[7].Value = model.BalTimeStart;
			parameters[8].Value = model.BalTimeEnd;
			parameters[9].Value = model.BalPrice;
			parameters[10].Value = model.BalNums;
			parameters[11].Value = model.BalAmt;
			parameters[12].Value = model.BalDate;
			parameters[13].Value = model.BalMan;
			parameters[14].Value = model.BalManID;
			parameters[15].Value = model.PayStatus;
			parameters[16].Value = model.PayDate;
			parameters[17].Value = model.PayMan;
			parameters[18].Value = model.PayRemark;

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
		public bool Update(SfSoft.Model.DRP_Balance_Dir model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Balance_Dir set ");
			strSql.Append("BalNo=@BalNo,");
			strSql.Append("BalID=@BalID,");
			strSql.Append("DisType=@DisType,");
			strSql.Append("DisID=@DisID,");
			strSql.Append("DisNo=@DisNo,");
			strSql.Append("DisName=@DisName,");
			strSql.Append("DisName1=@DisName1,");
			strSql.Append("BalTimeStart=@BalTimeStart,");
			strSql.Append("BalTimeEnd=@BalTimeEnd,");
			strSql.Append("BalPrice=@BalPrice,");
			strSql.Append("BalNums=@BalNums,");
			strSql.Append("BalAmt=@BalAmt,");
			strSql.Append("BalDate=@BalDate,");
			strSql.Append("BalMan=@BalMan,");
			strSql.Append("BalManID=@BalManID,");
			strSql.Append("PayStatus=@PayStatus,");
			strSql.Append("PayDate=@PayDate,");
			strSql.Append("PayMan=@PayMan,");
			strSql.Append("PayRemark=@PayRemark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BalNo", SqlDbType.NVarChar,20),
					new SqlParameter("@BalID", SqlDbType.Int,4),
					new SqlParameter("@DisType", SqlDbType.Int,4),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@DisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@DisName", SqlDbType.NVarChar,50),
					new SqlParameter("@DisName1", SqlDbType.NVarChar,50),
					new SqlParameter("@BalTimeStart", SqlDbType.DateTime),
					new SqlParameter("@BalTimeEnd", SqlDbType.DateTime),
					new SqlParameter("@BalPrice", SqlDbType.Float,8),
					new SqlParameter("@BalNums", SqlDbType.Int,4),
					new SqlParameter("@BalAmt", SqlDbType.Float,8),
					new SqlParameter("@BalDate", SqlDbType.DateTime),
					new SqlParameter("@BalMan", SqlDbType.NVarChar,20),
					new SqlParameter("@BalManID", SqlDbType.Int,4),
					new SqlParameter("@PayStatus", SqlDbType.Int,4),
					new SqlParameter("@PayDate", SqlDbType.DateTime),
					new SqlParameter("@PayMan", SqlDbType.NVarChar,20),
					new SqlParameter("@PayRemark", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.BalNo;
			parameters[1].Value = model.BalID;
			parameters[2].Value = model.DisType;
			parameters[3].Value = model.DisID;
			parameters[4].Value = model.DisNo;
			parameters[5].Value = model.DisName;
			parameters[6].Value = model.DisName1;
			parameters[7].Value = model.BalTimeStart;
			parameters[8].Value = model.BalTimeEnd;
			parameters[9].Value = model.BalPrice;
			parameters[10].Value = model.BalNums;
			parameters[11].Value = model.BalAmt;
			parameters[12].Value = model.BalDate;
			parameters[13].Value = model.BalMan;
			parameters[14].Value = model.BalManID;
			parameters[15].Value = model.PayStatus;
			parameters[16].Value = model.PayDate;
			parameters[17].Value = model.PayMan;
			parameters[18].Value = model.PayRemark;
			parameters[19].Value = model.ID;

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
			strSql.Append("delete from DRP_Balance_Dir ");
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
			strSql.Append("delete from DRP_Balance_Dir ");
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
		public SfSoft.Model.DRP_Balance_Dir GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BalNo,BalID,DisType,DisID,DisNo,DisName,DisName1,BalTimeStart,BalTimeEnd,BalPrice,BalNums,BalAmt,BalDate,BalMan,BalManID,PayStatus,PayDate,PayMan,PayRemark from DRP_Balance_Dir ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Balance_Dir model=new SfSoft.Model.DRP_Balance_Dir();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalNo"]!=null && ds.Tables[0].Rows[0]["BalNo"].ToString()!="")
				{
					model.BalNo=ds.Tables[0].Rows[0]["BalNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BalID"]!=null && ds.Tables[0].Rows[0]["BalID"].ToString()!="")
				{
					model.BalID=int.Parse(ds.Tables[0].Rows[0]["BalID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisType"]!=null && ds.Tables[0].Rows[0]["DisType"].ToString()!="")
				{
					model.DisType=int.Parse(ds.Tables[0].Rows[0]["DisType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisID"]!=null && ds.Tables[0].Rows[0]["DisID"].ToString()!="")
				{
					model.DisID=int.Parse(ds.Tables[0].Rows[0]["DisID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisNo"]!=null && ds.Tables[0].Rows[0]["DisNo"].ToString()!="")
				{
					model.DisNo=ds.Tables[0].Rows[0]["DisNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisName"]!=null && ds.Tables[0].Rows[0]["DisName"].ToString()!="")
				{
					model.DisName=ds.Tables[0].Rows[0]["DisName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisName1"]!=null && ds.Tables[0].Rows[0]["DisName1"].ToString()!="")
				{
					model.DisName1=ds.Tables[0].Rows[0]["DisName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BalTimeStart"]!=null && ds.Tables[0].Rows[0]["BalTimeStart"].ToString()!="")
				{
					model.BalTimeStart=DateTime.Parse(ds.Tables[0].Rows[0]["BalTimeStart"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalTimeEnd"]!=null && ds.Tables[0].Rows[0]["BalTimeEnd"].ToString()!="")
				{
					model.BalTimeEnd=DateTime.Parse(ds.Tables[0].Rows[0]["BalTimeEnd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalPrice"]!=null && ds.Tables[0].Rows[0]["BalPrice"].ToString()!="")
				{
					model.BalPrice=decimal.Parse(ds.Tables[0].Rows[0]["BalPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalNums"]!=null && ds.Tables[0].Rows[0]["BalNums"].ToString()!="")
				{
					model.BalNums=int.Parse(ds.Tables[0].Rows[0]["BalNums"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalAmt"]!=null && ds.Tables[0].Rows[0]["BalAmt"].ToString()!="")
				{
					model.BalAmt=decimal.Parse(ds.Tables[0].Rows[0]["BalAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalDate"]!=null && ds.Tables[0].Rows[0]["BalDate"].ToString()!="")
				{
					model.BalDate=DateTime.Parse(ds.Tables[0].Rows[0]["BalDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalMan"]!=null && ds.Tables[0].Rows[0]["BalMan"].ToString()!="")
				{
					model.BalMan=ds.Tables[0].Rows[0]["BalMan"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BalManID"]!=null && ds.Tables[0].Rows[0]["BalManID"].ToString()!="")
				{
					model.BalManID=int.Parse(ds.Tables[0].Rows[0]["BalManID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PayStatus"]!=null && ds.Tables[0].Rows[0]["PayStatus"].ToString()!="")
				{
					model.PayStatus=int.Parse(ds.Tables[0].Rows[0]["PayStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PayDate"]!=null && ds.Tables[0].Rows[0]["PayDate"].ToString()!="")
				{
					model.PayDate=DateTime.Parse(ds.Tables[0].Rows[0]["PayDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PayMan"]!=null && ds.Tables[0].Rows[0]["PayMan"].ToString()!="")
				{
					model.PayMan=ds.Tables[0].Rows[0]["PayMan"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PayRemark"]!=null && ds.Tables[0].Rows[0]["PayRemark"].ToString()!="")
				{
					model.PayRemark=ds.Tables[0].Rows[0]["PayRemark"].ToString();
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
			strSql.Append("select ID,BalNo,BalID,DisType,DisID,DisNo,DisName,DisName1,BalTimeStart,BalTimeEnd,BalPrice,BalNums,BalAmt,BalDate,BalMan,BalManID,PayStatus,PayDate,PayMan,PayRemark ");
			strSql.Append(" FROM DRP_Balance_Dir ");
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
			strSql.Append(" ID,BalNo,BalID,DisType,DisID,DisNo,DisName,DisName1,BalTimeStart,BalTimeEnd,BalPrice,BalNums,BalAmt,BalDate,BalMan,BalManID,PayStatus,PayDate,PayMan,PayRemark ");
			strSql.Append(" FROM DRP_Balance_Dir ");
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
			strSql.Append("select count(1) FROM DRP_Balance_Dir ");
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
			strSql.Append(")AS Row, T.*  from DRP_Balance_Dir T ");
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
			parameters[0].Value = "DRP_Balance_Dir";
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

