using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Order
	/// </summary>
	public partial class DRP_Order:IDRP_Order
	{
		public DRP_Order()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Order");
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
		public int Add(SfSoft.Model.DRP_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Order(");
			strSql.Append("OrderNo,DisID,DisNo,Contact,Phone,Addr,TotalAmt,TotalNum,OrderDate,OrderStatus,Payment,BalanceStatus,Remark,mtime,modifier)");
			strSql.Append(" values (");
			strSql.Append("@OrderNo,@DisID,@DisNo,@Contact,@Phone,@Addr,@TotalAmt,@TotalNum,@OrderDate,@OrderStatus,@Payment,@BalanceStatus,@Remark,@mtime,@modifier)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,20),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@DisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@Contact", SqlDbType.NVarChar,40),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Addr", SqlDbType.NVarChar,200),
					new SqlParameter("@TotalAmt", SqlDbType.Float,8),
					new SqlParameter("@TotalNum", SqlDbType.Int,4),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@OrderStatus", SqlDbType.Int,4),
					new SqlParameter("@Payment", SqlDbType.Int,4),
					new SqlParameter("@BalanceStatus", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.OrderNo;
			parameters[1].Value = model.DisID;
			parameters[2].Value = model.DisNo;
			parameters[3].Value = model.Contact;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.Addr;
			parameters[6].Value = model.TotalAmt;
			parameters[7].Value = model.TotalNum;
			parameters[8].Value = model.OrderDate;
			parameters[9].Value = model.OrderStatus;
			parameters[10].Value = model.Payment;
			parameters[11].Value = model.BalanceStatus;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.mtime;
			parameters[14].Value = model.modifier;

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
		public bool Update(SfSoft.Model.DRP_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Order set ");
			strSql.Append("OrderNo=@OrderNo,");
			strSql.Append("DisID=@DisID,");
			strSql.Append("DisNo=@DisNo,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("TotalAmt=@TotalAmt,");
			strSql.Append("TotalNum=@TotalNum,");
			strSql.Append("OrderDate=@OrderDate,");
			strSql.Append("OrderStatus=@OrderStatus,");
			strSql.Append("Payment=@Payment,");
			strSql.Append("BalanceStatus=@BalanceStatus,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("mtime=@mtime,");
			strSql.Append("modifier=@modifier");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,20),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@DisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@Contact", SqlDbType.NVarChar,40),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Addr", SqlDbType.NVarChar,200),
					new SqlParameter("@TotalAmt", SqlDbType.Float,8),
					new SqlParameter("@TotalNum", SqlDbType.Int,4),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@OrderStatus", SqlDbType.Int,4),
					new SqlParameter("@Payment", SqlDbType.Int,4),
					new SqlParameter("@BalanceStatus", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderNo;
			parameters[1].Value = model.DisID;
			parameters[2].Value = model.DisNo;
			parameters[3].Value = model.Contact;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.Addr;
			parameters[6].Value = model.TotalAmt;
			parameters[7].Value = model.TotalNum;
			parameters[8].Value = model.OrderDate;
			parameters[9].Value = model.OrderStatus;
			parameters[10].Value = model.Payment;
			parameters[11].Value = model.BalanceStatus;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.mtime;
			parameters[14].Value = model.modifier;
			parameters[15].Value = model.ID;

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
			strSql.Append("delete from DRP_Order ");
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
			strSql.Append("delete from DRP_Order ");
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
		public SfSoft.Model.DRP_Order GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrderNo,DisID,DisNo,Contact,Phone,Addr,TotalAmt,TotalNum,OrderDate,OrderStatus,Payment,BalanceStatus,Remark,mtime,modifier from DRP_Order ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Order model=new SfSoft.Model.DRP_Order();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderNo"]!=null && ds.Tables[0].Rows[0]["OrderNo"].ToString()!="")
				{
					model.OrderNo=ds.Tables[0].Rows[0]["OrderNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisID"]!=null && ds.Tables[0].Rows[0]["DisID"].ToString()!="")
				{
					model.DisID=int.Parse(ds.Tables[0].Rows[0]["DisID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisNo"]!=null && ds.Tables[0].Rows[0]["DisNo"].ToString()!="")
				{
					model.DisNo=ds.Tables[0].Rows[0]["DisNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Addr"]!=null && ds.Tables[0].Rows[0]["Addr"].ToString()!="")
				{
					model.Addr=ds.Tables[0].Rows[0]["Addr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TotalAmt"]!=null && ds.Tables[0].Rows[0]["TotalAmt"].ToString()!="")
				{
					model.TotalAmt=decimal.Parse(ds.Tables[0].Rows[0]["TotalAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TotalNum"]!=null && ds.Tables[0].Rows[0]["TotalNum"].ToString()!="")
				{
					model.TotalNum=int.Parse(ds.Tables[0].Rows[0]["TotalNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderDate"]!=null && ds.Tables[0].Rows[0]["OrderDate"].ToString()!="")
				{
					model.OrderDate=DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderStatus"]!=null && ds.Tables[0].Rows[0]["OrderStatus"].ToString()!="")
				{
					model.OrderStatus=int.Parse(ds.Tables[0].Rows[0]["OrderStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Payment"]!=null && ds.Tables[0].Rows[0]["Payment"].ToString()!="")
				{
					model.Payment=int.Parse(ds.Tables[0].Rows[0]["Payment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BalanceStatus"]!=null && ds.Tables[0].Rows[0]["BalanceStatus"].ToString()!="")
				{
					model.BalanceStatus=int.Parse(ds.Tables[0].Rows[0]["BalanceStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mtime"]!=null && ds.Tables[0].Rows[0]["mtime"].ToString()!="")
				{
					model.mtime=DateTime.Parse(ds.Tables[0].Rows[0]["mtime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modifier"]!=null && ds.Tables[0].Rows[0]["modifier"].ToString()!="")
				{
					model.modifier=ds.Tables[0].Rows[0]["modifier"].ToString();
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
			strSql.Append("select ID,OrderNo,DisID,DisNo,Contact,Phone,Addr,TotalAmt,TotalNum,OrderDate,OrderStatus,Payment,BalanceStatus,Remark,mtime,modifier ");
			strSql.Append(" FROM DRP_Order ");
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
			strSql.Append(" ID,OrderNo,DisID,DisNo,Contact,Phone,Addr,TotalAmt,TotalNum,OrderDate,OrderStatus,Payment,BalanceStatus,Remark,mtime,modifier ");
			strSql.Append(" FROM DRP_Order ");
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
			strSql.Append("select count(1) FROM DRP_Order ");
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
			strSql.Append(")AS Row, T.*  from DRP_Order T ");
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
			parameters[0].Value = "DRP_Order";
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

