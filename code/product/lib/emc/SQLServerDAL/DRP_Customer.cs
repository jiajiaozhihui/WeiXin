using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Customer
	/// </summary>
	public partial class DRP_Customer:IDRP_Customer
	{
		public DRP_Customer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Customer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Customer");
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
		public int Add(SfSoft.Model.DRP_Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Customer(");
			strSql.Append("Contact,Mobile,QQ,Province,City,Addr,DisID,BuyDate,Remark,mtime,modifier)");
			strSql.Append(" values (");
			strSql.Append("@Contact,@Mobile,@QQ,@Province,@City,@Addr,@DisID,@BuyDate,@Remark,@mtime,@modifier)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Contact", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@Addr", SqlDbType.NVarChar,100),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.Contact;
			parameters[1].Value = model.Mobile;
			parameters[2].Value = model.QQ;
			parameters[3].Value = model.Province;
			parameters[4].Value = model.City;
			parameters[5].Value = model.Addr;
			parameters[6].Value = model.DisID;
			parameters[7].Value = model.BuyDate;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.mtime;
			parameters[10].Value = model.modifier;

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
		public bool Update(SfSoft.Model.DRP_Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Customer set ");
			strSql.Append("Contact=@Contact,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Province=@Province,");
			strSql.Append("City=@City,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("DisID=@DisID,");
			strSql.Append("BuyDate=@BuyDate,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("mtime=@mtime,");
			strSql.Append("modifier=@modifier");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Contact", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@Addr", SqlDbType.NVarChar,100),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Contact;
			parameters[1].Value = model.Mobile;
			parameters[2].Value = model.QQ;
			parameters[3].Value = model.Province;
			parameters[4].Value = model.City;
			parameters[5].Value = model.Addr;
			parameters[6].Value = model.DisID;
			parameters[7].Value = model.BuyDate;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.mtime;
			parameters[10].Value = model.modifier;
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
			strSql.Append("delete from DRP_Customer ");
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
			strSql.Append("delete from DRP_Customer ");
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
		public SfSoft.Model.DRP_Customer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Contact,Mobile,QQ,Province,City,Addr,DisID,BuyDate,Remark,mtime,modifier from DRP_Customer ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Customer model=new SfSoft.Model.DRP_Customer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Mobile"]!=null && ds.Tables[0].Rows[0]["Mobile"].ToString()!="")
				{
					model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QQ"]!=null && ds.Tables[0].Rows[0]["QQ"].ToString()!="")
				{
					model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Province"]!=null && ds.Tables[0].Rows[0]["Province"].ToString()!="")
				{
					model.Province=ds.Tables[0].Rows[0]["Province"].ToString();
				}
				if(ds.Tables[0].Rows[0]["City"]!=null && ds.Tables[0].Rows[0]["City"].ToString()!="")
				{
					model.City=ds.Tables[0].Rows[0]["City"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Addr"]!=null && ds.Tables[0].Rows[0]["Addr"].ToString()!="")
				{
					model.Addr=ds.Tables[0].Rows[0]["Addr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisID"]!=null && ds.Tables[0].Rows[0]["DisID"].ToString()!="")
				{
					model.DisID=int.Parse(ds.Tables[0].Rows[0]["DisID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuyDate"]!=null && ds.Tables[0].Rows[0]["BuyDate"].ToString()!="")
				{
					model.BuyDate=DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
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
			strSql.Append("select ID,Contact,Mobile,QQ,Province,City,Addr,DisID,BuyDate,Remark,mtime,modifier ");
			strSql.Append(" FROM DRP_Customer ");
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
			strSql.Append(" ID,Contact,Mobile,QQ,Province,City,Addr,DisID,BuyDate,Remark,mtime,modifier ");
			strSql.Append(" FROM DRP_Customer ");
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
			strSql.Append("select count(1) FROM DRP_Customer ");
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
			strSql.Append(")AS Row, T.*  from DRP_Customer T ");
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
			parameters[0].Value = "DRP_Customer";
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

