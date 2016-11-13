using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SfSoft.IDAL;
using SfSoft.DBUtility;//�����������
namespace SfSoft.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����Pub_AuditResult��
	/// </summary>
	public class Pub_AuditResult:IPub_AuditResult
	{
		public Pub_AuditResult()
		{}
		#region  ��Ա����

 

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ARSID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Pub_AuditResult");
			strSql.Append(" where ARSID=@ARSID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ARSID", SqlDbType.Int,4)};
			parameters[0].Value = ARSID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(SfSoft.Model.Pub_AuditResult model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Pub_AuditResult(");
			strSql.Append("MID,ARID,Auditdate,AuditSign,AuditUserID,AuditName,AuditorCmnt,Contral,AuditClass,AuditTypeName)");
			strSql.Append(" values (");
			strSql.Append("@MID,@ARID,@Auditdate,@AuditSign,@AuditUserID,@AuditName,@AuditorCmnt,@Contral,@AuditClass,@AuditTypeName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.NVarChar,80),
					new SqlParameter("@ARID", SqlDbType.Int,4),
					new SqlParameter("@Auditdate", SqlDbType.DateTime),
					new SqlParameter("@AuditSign", SqlDbType.NVarChar,5),
					new SqlParameter("@AuditUserID", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.NVarChar,20),
					new SqlParameter("@AuditorCmnt", SqlDbType.NVarChar,500),
					new SqlParameter("@Contral", SqlDbType.NVarChar,500),
					new SqlParameter("@AuditClass", SqlDbType.Int,4),
					new SqlParameter("@AuditTypeName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MID;
			parameters[1].Value = model.ARID;
			parameters[2].Value = model.Auditdate;
			parameters[3].Value = model.AuditSign;
			parameters[4].Value = model.AuditUserID;
			parameters[5].Value = model.AuditName;
			parameters[6].Value = model.AuditorCmnt;
			parameters[7].Value = model.Contral;
			parameters[8].Value = model.AuditClass;
			parameters[9].Value = model.AuditTypeName;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SfSoft.Model.Pub_AuditResult model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Pub_AuditResult set ");
			strSql.Append("MID=@MID,");
			strSql.Append("ARID=@ARID,");
			strSql.Append("Auditdate=@Auditdate,");
			strSql.Append("AuditSign=@AuditSign,");
			strSql.Append("AuditUserID=@AuditUserID,");
			strSql.Append("AuditName=@AuditName,");
			strSql.Append("AuditorCmnt=@AuditorCmnt,");
			strSql.Append("Contral=@Contral,");
			strSql.Append("AuditClass=@AuditClass,");
			strSql.Append("AuditTypeName=@AuditTypeName");
			strSql.Append(" where ARSID=@ARSID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ARSID", SqlDbType.Int,4),
					new SqlParameter("@MID", SqlDbType.NVarChar,80),
					new SqlParameter("@ARID", SqlDbType.Int,4),
					new SqlParameter("@Auditdate", SqlDbType.DateTime),
					new SqlParameter("@AuditSign", SqlDbType.NVarChar,5),
					new SqlParameter("@AuditUserID", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.NVarChar,20),
					new SqlParameter("@AuditorCmnt", SqlDbType.NVarChar,500),
					new SqlParameter("@Contral", SqlDbType.NVarChar,500),
					new SqlParameter("@AuditClass", SqlDbType.Int,4),
					new SqlParameter("@AuditTypeName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ARSID;
			parameters[1].Value = model.MID;
			parameters[2].Value = model.ARID;
			parameters[3].Value = model.Auditdate;
			parameters[4].Value = model.AuditSign;
			parameters[5].Value = model.AuditUserID;
			parameters[6].Value = model.AuditName;
			parameters[7].Value = model.AuditorCmnt;
			parameters[8].Value = model.Contral;
			parameters[9].Value = model.AuditClass;
			parameters[10].Value = model.AuditTypeName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ARSID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete Pub_AuditResult ");
			strSql.Append(" where ARSID=@ARSID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ARSID", SqlDbType.Int,4)};
			parameters[0].Value = ARSID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SfSoft.Model.Pub_AuditResult GetModel(int ARSID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ARSID,MID,ARID,Auditdate,AuditSign,AuditUserID,AuditName,AuditorCmnt,Contral,AuditClass,AuditTypeName from Pub_AuditResult ");
			strSql.Append(" where ARSID=@ARSID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ARSID", SqlDbType.Int,4)};
			parameters[0].Value = ARSID;

			SfSoft.Model.Pub_AuditResult model=new SfSoft.Model.Pub_AuditResult();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ARSID"].ToString()!="")
				{
					model.ARSID=int.Parse(ds.Tables[0].Rows[0]["ARSID"].ToString());
				}
				model.MID=ds.Tables[0].Rows[0]["MID"].ToString();
				if(ds.Tables[0].Rows[0]["ARID"].ToString()!="")
				{
					model.ARID=int.Parse(ds.Tables[0].Rows[0]["ARID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Auditdate"].ToString()!="")
				{
					model.Auditdate=DateTime.Parse(ds.Tables[0].Rows[0]["Auditdate"].ToString());
				}
				model.AuditSign=ds.Tables[0].Rows[0]["AuditSign"].ToString();
				if(ds.Tables[0].Rows[0]["AuditUserID"].ToString()!="")
				{
					model.AuditUserID=int.Parse(ds.Tables[0].Rows[0]["AuditUserID"].ToString());
				}
				model.AuditName=ds.Tables[0].Rows[0]["AuditName"].ToString();
				model.AuditorCmnt=ds.Tables[0].Rows[0]["AuditorCmnt"].ToString();
				model.Contral=ds.Tables[0].Rows[0]["Contral"].ToString();
				if(ds.Tables[0].Rows[0]["AuditClass"].ToString()!="")
				{
					model.AuditClass=int.Parse(ds.Tables[0].Rows[0]["AuditClass"].ToString());
				}
				model.AuditTypeName=ds.Tables[0].Rows[0]["AuditTypeName"].ToString();
				return model;
			}
			else
			{
			return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ARSID,MID,ARID,Auditdate,AuditSign,AuditUserID,AuditName,AuditorCmnt,Contral,AuditClass,AuditTypeName ");
			strSql.Append(" FROM Pub_AuditResult ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "Pub_AuditResult";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

