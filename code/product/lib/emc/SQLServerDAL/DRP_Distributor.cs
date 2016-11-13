using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Distributor
	/// </summary>
	public partial class DRP_Distributor:IDRP_Distributor
	{
		public DRP_Distributor()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Distributor"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Distributor");
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
		public int Add(SfSoft.Model.DRP_Distributor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Distributor(");
			strSql.Append("DisNo,PassWord,DisName,Contact,Mobile,QQ,Province,City,Addr,PDisID,PDisNo,DisAmt,Bank,AccountName,CardNo,DisType,Status,Head,SignName,JoinDate,Remark,mtime,modifier)");
			strSql.Append(" values (");
			strSql.Append("@DisNo,@PassWord,@DisName,@Contact,@Mobile,@QQ,@Province,@City,@Addr,@PDisID,@PDisNo,@DisAmt,@Bank,@AccountName,@CardNo,@DisType,@Status,@Head,@SignName,@JoinDate,@Remark,@mtime,@modifier)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@DisName", SqlDbType.NVarChar,50),
					new SqlParameter("@Contact", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@Addr", SqlDbType.NVarChar,100),
					new SqlParameter("@PDisID", SqlDbType.Int,4),
					new SqlParameter("@PDisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@DisAmt", SqlDbType.Float,8),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@AccountName", SqlDbType.NVarChar,50),
					new SqlParameter("@CardNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DisType", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Head", SqlDbType.NVarChar,100),
					new SqlParameter("@SignName", SqlDbType.NVarChar,50),
					new SqlParameter("@JoinDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.DisNo;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.DisName;
			parameters[3].Value = model.Contact;
			parameters[4].Value = model.Mobile;
			parameters[5].Value = model.QQ;
			parameters[6].Value = model.Province;
			parameters[7].Value = model.City;
			parameters[8].Value = model.Addr;
			parameters[9].Value = model.PDisID;
			parameters[10].Value = model.PDisNo;
			parameters[11].Value = model.DisAmt;
			parameters[12].Value = model.Bank;
			parameters[13].Value = model.AccountName;
			parameters[14].Value = model.CardNo;
			parameters[15].Value = model.DisType;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.Head;
			parameters[18].Value = model.SignName;
			parameters[19].Value = model.JoinDate;
			parameters[20].Value = model.Remark;
			parameters[21].Value = model.mtime;
			parameters[22].Value = model.modifier;

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
		public bool Update(SfSoft.Model.DRP_Distributor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Distributor set ");
			strSql.Append("DisNo=@DisNo,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("DisName=@DisName,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Province=@Province,");
			strSql.Append("City=@City,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("PDisID=@PDisID,");
			strSql.Append("PDisNo=@PDisNo,");
			strSql.Append("DisAmt=@DisAmt,");
			strSql.Append("Bank=@Bank,");
			strSql.Append("AccountName=@AccountName,");
			strSql.Append("CardNo=@CardNo,");
			strSql.Append("DisType=@DisType,");
			strSql.Append("Status=@Status,");
			strSql.Append("Head=@Head,");
			strSql.Append("SignName=@SignName,");
			strSql.Append("JoinDate=@JoinDate,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("mtime=@mtime,");
			strSql.Append("modifier=@modifier");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@DisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@DisName", SqlDbType.NVarChar,50),
					new SqlParameter("@Contact", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@Addr", SqlDbType.NVarChar,100),
					new SqlParameter("@PDisID", SqlDbType.Int,4),
					new SqlParameter("@PDisNo", SqlDbType.NVarChar,20),
					new SqlParameter("@DisAmt", SqlDbType.Float,8),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@AccountName", SqlDbType.NVarChar,50),
					new SqlParameter("@CardNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DisType", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Head", SqlDbType.NVarChar,100),
					new SqlParameter("@SignName", SqlDbType.NVarChar,50),
					new SqlParameter("@JoinDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.DisNo;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.DisName;
			parameters[3].Value = model.Contact;
			parameters[4].Value = model.Mobile;
			parameters[5].Value = model.QQ;
			parameters[6].Value = model.Province;
			parameters[7].Value = model.City;
			parameters[8].Value = model.Addr;
			parameters[9].Value = model.PDisID;
			parameters[10].Value = model.PDisNo;
			parameters[11].Value = model.DisAmt;
			parameters[12].Value = model.Bank;
			parameters[13].Value = model.AccountName;
			parameters[14].Value = model.CardNo;
			parameters[15].Value = model.DisType;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.Head;
			parameters[18].Value = model.SignName;
			parameters[19].Value = model.JoinDate;
			parameters[20].Value = model.Remark;
			parameters[21].Value = model.mtime;
			parameters[22].Value = model.modifier;
			parameters[23].Value = model.ID;

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
			strSql.Append("delete from DRP_Distributor ");
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
			strSql.Append("delete from DRP_Distributor ");
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
		public SfSoft.Model.DRP_Distributor GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DisNo,PassWord,DisName,Contact,Mobile,QQ,Province,City,Addr,PDisID,PDisNo,DisAmt,Bank,AccountName,CardNo,DisType,Status,Head,SignName,JoinDate,Remark,mtime,modifier from DRP_Distributor ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Distributor model=new SfSoft.Model.DRP_Distributor();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisNo"]!=null && ds.Tables[0].Rows[0]["DisNo"].ToString()!="")
				{
					model.DisNo=ds.Tables[0].Rows[0]["DisNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PassWord"]!=null && ds.Tables[0].Rows[0]["PassWord"].ToString()!="")
				{
					model.PassWord=ds.Tables[0].Rows[0]["PassWord"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisName"]!=null && ds.Tables[0].Rows[0]["DisName"].ToString()!="")
				{
					model.DisName=ds.Tables[0].Rows[0]["DisName"].ToString();
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
				if(ds.Tables[0].Rows[0]["PDisID"]!=null && ds.Tables[0].Rows[0]["PDisID"].ToString()!="")
				{
					model.PDisID=int.Parse(ds.Tables[0].Rows[0]["PDisID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PDisNo"]!=null && ds.Tables[0].Rows[0]["PDisNo"].ToString()!="")
				{
					model.PDisNo=ds.Tables[0].Rows[0]["PDisNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisAmt"]!=null && ds.Tables[0].Rows[0]["DisAmt"].ToString()!="")
				{
					model.DisAmt=decimal.Parse(ds.Tables[0].Rows[0]["DisAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bank"]!=null && ds.Tables[0].Rows[0]["Bank"].ToString()!="")
				{
					model.Bank=ds.Tables[0].Rows[0]["Bank"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AccountName"]!=null && ds.Tables[0].Rows[0]["AccountName"].ToString()!="")
				{
					model.AccountName=ds.Tables[0].Rows[0]["AccountName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardNo"]!=null && ds.Tables[0].Rows[0]["CardNo"].ToString()!="")
				{
					model.CardNo=ds.Tables[0].Rows[0]["CardNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DisType"]!=null && ds.Tables[0].Rows[0]["DisType"].ToString()!="")
				{
					model.DisType=int.Parse(ds.Tables[0].Rows[0]["DisType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Head"]!=null && ds.Tables[0].Rows[0]["Head"].ToString()!="")
				{
					model.Head=ds.Tables[0].Rows[0]["Head"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SignName"]!=null && ds.Tables[0].Rows[0]["SignName"].ToString()!="")
				{
					model.SignName=ds.Tables[0].Rows[0]["SignName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["JoinDate"]!=null && ds.Tables[0].Rows[0]["JoinDate"].ToString()!="")
				{
					model.JoinDate=DateTime.Parse(ds.Tables[0].Rows[0]["JoinDate"].ToString());
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
			strSql.Append("select ID,DisNo,PassWord,DisName,Contact,Mobile,QQ,Province,City,Addr,PDisID,PDisNo,DisAmt,Bank,AccountName,CardNo,DisType,Status,Head,SignName,JoinDate,Remark,mtime,modifier ");
			strSql.Append(" FROM DRP_Distributor ");
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
			strSql.Append(" ID,DisNo,PassWord,DisName,Contact,Mobile,QQ,Province,City,Addr,PDisID,PDisNo,DisAmt,Bank,AccountName,CardNo,DisType,Status,Head,SignName,JoinDate,Remark,mtime,modifier ");
			strSql.Append(" FROM DRP_Distributor ");
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
			strSql.Append("select count(1) FROM DRP_Distributor ");
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
			strSql.Append(")AS Row, T.*  from DRP_Distributor T ");
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
			parameters[0].Value = "DRP_Distributor";
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

