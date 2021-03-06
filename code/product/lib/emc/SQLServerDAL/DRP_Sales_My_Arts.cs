﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//Please add references
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DRP_Sales_My_Arts
	/// </summary>
	public partial class DRP_Sales_My_Arts:IDRP_Sales_My_Arts
	{
		public DRP_Sales_My_Arts()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "DRP_Sales_My_Arts"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DRP_Sales_My_Arts");
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
		public int Add(SfSoft.Model.DRP_Sales_My_Arts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DRP_Sales_My_Arts(");
			strSql.Append("ArtID,DisID,Topic,KeyWord,ArtType,SendStatus,ArtContent,PubDate,Creator,IsSales,IsProduct,IsContact,IsOrder,IsAuth,TurnNum,ClickNum,modifier,mtime)");
			strSql.Append(" values (");
			strSql.Append("@ArtID,@DisID,@Topic,@KeyWord,@ArtType,@SendStatus,@ArtContent,@PubDate,@Creator,@IsSales,@IsProduct,@IsContact,@IsOrder,@IsAuth,@TurnNum,@ClickNum,@modifier,@mtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.Int,4),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@Topic", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@ArtType", SqlDbType.Int,4),
					new SqlParameter("@SendStatus", SqlDbType.Int,4),
					new SqlParameter("@ArtContent", SqlDbType.NText),
					new SqlParameter("@PubDate", SqlDbType.DateTime),
					new SqlParameter("@Creator", SqlDbType.NVarChar,20),
					new SqlParameter("@IsSales", SqlDbType.Int,4),
					new SqlParameter("@IsProduct", SqlDbType.Int,4),
					new SqlParameter("@IsContact", SqlDbType.Int,4),
					new SqlParameter("@IsOrder", SqlDbType.Int,4),
					new SqlParameter("@IsAuth", SqlDbType.Int,4),
					new SqlParameter("@TurnNum", SqlDbType.Int,4),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@mtime", SqlDbType.DateTime)};
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.DisID;
			parameters[2].Value = model.Topic;
			parameters[3].Value = model.KeyWord;
			parameters[4].Value = model.ArtType;
			parameters[5].Value = model.SendStatus;
			parameters[6].Value = model.ArtContent;
			parameters[7].Value = model.PubDate;
			parameters[8].Value = model.Creator;
			parameters[9].Value = model.IsSales;
			parameters[10].Value = model.IsProduct;
			parameters[11].Value = model.IsContact;
			parameters[12].Value = model.IsOrder;
			parameters[13].Value = model.IsAuth;
			parameters[14].Value = model.TurnNum;
			parameters[15].Value = model.ClickNum;
			parameters[16].Value = model.modifier;
			parameters[17].Value = model.mtime;

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
		public bool Update(SfSoft.Model.DRP_Sales_My_Arts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DRP_Sales_My_Arts set ");
			strSql.Append("ArtID=@ArtID,");
			strSql.Append("DisID=@DisID,");
			strSql.Append("Topic=@Topic,");
			strSql.Append("KeyWord=@KeyWord,");
			strSql.Append("ArtType=@ArtType,");
			strSql.Append("SendStatus=@SendStatus,");
			strSql.Append("ArtContent=@ArtContent,");
			strSql.Append("PubDate=@PubDate,");
			strSql.Append("Creator=@Creator,");
			strSql.Append("IsSales=@IsSales,");
			strSql.Append("IsProduct=@IsProduct,");
			strSql.Append("IsContact=@IsContact,");
			strSql.Append("IsOrder=@IsOrder,");
			strSql.Append("IsAuth=@IsAuth,");
			strSql.Append("TurnNum=@TurnNum,");
			strSql.Append("ClickNum=@ClickNum,");
			strSql.Append("modifier=@modifier,");
			strSql.Append("mtime=@mtime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.Int,4),
					new SqlParameter("@DisID", SqlDbType.Int,4),
					new SqlParameter("@Topic", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@ArtType", SqlDbType.Int,4),
					new SqlParameter("@SendStatus", SqlDbType.Int,4),
					new SqlParameter("@ArtContent", SqlDbType.NText),
					new SqlParameter("@PubDate", SqlDbType.DateTime),
					new SqlParameter("@Creator", SqlDbType.NVarChar,20),
					new SqlParameter("@IsSales", SqlDbType.Int,4),
					new SqlParameter("@IsProduct", SqlDbType.Int,4),
					new SqlParameter("@IsContact", SqlDbType.Int,4),
					new SqlParameter("@IsOrder", SqlDbType.Int,4),
					new SqlParameter("@IsAuth", SqlDbType.Int,4),
					new SqlParameter("@TurnNum", SqlDbType.Int,4),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@modifier", SqlDbType.NVarChar,20),
					new SqlParameter("@mtime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.DisID;
			parameters[2].Value = model.Topic;
			parameters[3].Value = model.KeyWord;
			parameters[4].Value = model.ArtType;
			parameters[5].Value = model.SendStatus;
			parameters[6].Value = model.ArtContent;
			parameters[7].Value = model.PubDate;
			parameters[8].Value = model.Creator;
			parameters[9].Value = model.IsSales;
			parameters[10].Value = model.IsProduct;
			parameters[11].Value = model.IsContact;
			parameters[12].Value = model.IsOrder;
			parameters[13].Value = model.IsAuth;
			parameters[14].Value = model.TurnNum;
			parameters[15].Value = model.ClickNum;
			parameters[16].Value = model.modifier;
			parameters[17].Value = model.mtime;
			parameters[18].Value = model.ID;

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
			strSql.Append("delete from DRP_Sales_My_Arts ");
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
			strSql.Append("delete from DRP_Sales_My_Arts ");
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
		public SfSoft.Model.DRP_Sales_My_Arts GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ArtID,DisID,Topic,KeyWord,ArtType,SendStatus,ArtContent,PubDate,Creator,IsSales,IsProduct,IsContact,IsOrder,IsAuth,TurnNum,ClickNum,modifier,mtime from DRP_Sales_My_Arts ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SfSoft.Model.DRP_Sales_My_Arts model=new SfSoft.Model.DRP_Sales_My_Arts();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArtID"]!=null && ds.Tables[0].Rows[0]["ArtID"].ToString()!="")
				{
					model.ArtID=int.Parse(ds.Tables[0].Rows[0]["ArtID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DisID"]!=null && ds.Tables[0].Rows[0]["DisID"].ToString()!="")
				{
					model.DisID=int.Parse(ds.Tables[0].Rows[0]["DisID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Topic"]!=null && ds.Tables[0].Rows[0]["Topic"].ToString()!="")
				{
					model.Topic=ds.Tables[0].Rows[0]["Topic"].ToString();
				}
				if(ds.Tables[0].Rows[0]["KeyWord"]!=null && ds.Tables[0].Rows[0]["KeyWord"].ToString()!="")
				{
					model.KeyWord=ds.Tables[0].Rows[0]["KeyWord"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ArtType"]!=null && ds.Tables[0].Rows[0]["ArtType"].ToString()!="")
				{
					model.ArtType=int.Parse(ds.Tables[0].Rows[0]["ArtType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendStatus"]!=null && ds.Tables[0].Rows[0]["SendStatus"].ToString()!="")
				{
					model.SendStatus=int.Parse(ds.Tables[0].Rows[0]["SendStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArtContent"]!=null && ds.Tables[0].Rows[0]["ArtContent"].ToString()!="")
				{
					model.ArtContent=ds.Tables[0].Rows[0]["ArtContent"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PubDate"]!=null && ds.Tables[0].Rows[0]["PubDate"].ToString()!="")
				{
					model.PubDate=DateTime.Parse(ds.Tables[0].Rows[0]["PubDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Creator"]!=null && ds.Tables[0].Rows[0]["Creator"].ToString()!="")
				{
					model.Creator=ds.Tables[0].Rows[0]["Creator"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsSales"]!=null && ds.Tables[0].Rows[0]["IsSales"].ToString()!="")
				{
					model.IsSales=int.Parse(ds.Tables[0].Rows[0]["IsSales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsProduct"]!=null && ds.Tables[0].Rows[0]["IsProduct"].ToString()!="")
				{
					model.IsProduct=int.Parse(ds.Tables[0].Rows[0]["IsProduct"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsContact"]!=null && ds.Tables[0].Rows[0]["IsContact"].ToString()!="")
				{
					model.IsContact=int.Parse(ds.Tables[0].Rows[0]["IsContact"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsOrder"]!=null && ds.Tables[0].Rows[0]["IsOrder"].ToString()!="")
				{
					model.IsOrder=int.Parse(ds.Tables[0].Rows[0]["IsOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsAuth"]!=null && ds.Tables[0].Rows[0]["IsAuth"].ToString()!="")
				{
					model.IsAuth=int.Parse(ds.Tables[0].Rows[0]["IsAuth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TurnNum"]!=null && ds.Tables[0].Rows[0]["TurnNum"].ToString()!="")
				{
					model.TurnNum=int.Parse(ds.Tables[0].Rows[0]["TurnNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClickNum"]!=null && ds.Tables[0].Rows[0]["ClickNum"].ToString()!="")
				{
					model.ClickNum=int.Parse(ds.Tables[0].Rows[0]["ClickNum"].ToString());
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
			strSql.Append("select ID,ArtID,DisID,Topic,KeyWord,ArtType,SendStatus,ArtContent,PubDate,Creator,IsSales,IsProduct,IsContact,IsOrder,IsAuth,TurnNum,ClickNum,modifier,mtime ");
			strSql.Append(" FROM DRP_Sales_My_Arts ");
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
			strSql.Append(" ID,ArtID,DisID,Topic,KeyWord,ArtType,SendStatus,ArtContent,PubDate,Creator,IsSales,IsProduct,IsContact,IsOrder,IsAuth,TurnNum,ClickNum,modifier,mtime ");
			strSql.Append(" FROM DRP_Sales_My_Arts ");
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
			strSql.Append("select count(1) FROM DRP_Sales_My_Arts ");
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
			strSql.Append(")AS Row, T.*  from DRP_Sales_My_Arts T ");
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
			parameters[0].Value = "DRP_Sales_My_Arts";
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

