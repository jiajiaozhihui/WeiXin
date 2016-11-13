using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using SfSoft.Common;
using SfSoft.DBUtility;
using System.Data;

namespace SfSoft.SfEmc
{
    public class DataAcl
    {
        /// <summary>
        /// ȡ�ķ���Ȩ�޷�Χ����
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static string GetDataAssignWhere(string UserID, string DeptID, string FilialeID, string MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  ( ID in (select DataID from Pub_Data_Assign  where ModulesID ='" + MID + "'");
            strSql.Append(" and ((AssignType='C' and AssignID='" + FilialeID + "') or (AssignType='D' and AssignID='" + DeptID + "') or (AssignType='U' and AssignID='" + UserID + "'))))");
            strSql.Append(" or ((select count(dataID) from Pub_Data_Assign where DataID=ID and ModulesID='" + MID + "')='0' ");
            strSql.Append(" and (FilialeID='" + FilialeID + "')");
            strSql.Append(") ");

            return strSql.ToString();
        }

        /// <summary>
        /// ȡ�ķ���Ȩ�޷�Χ����,����Ǽ��Ź���Ͳ�Ҫ�Ӳ���
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static string GetDataAllAssignWhere(string UserID, string DeptID, string FilialeID, string MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  ( ID in (select DataID from Pub_Data_Assign  where ModulesID ='" + MID + "'");
            strSql.Append(" and ((AssignType='C' and AssignID='" + FilialeID + "') or (AssignType='D' and AssignID='" + DeptID + "') or (AssignType='U' and AssignID='" + UserID + "'))))");
            strSql.Append(" or ((select count(dataID) from Pub_Data_Assign where DataID=ID and ModulesID='" + MID + "')='0' ");
            strSql.Append(") ");

            return strSql.ToString();
        }

        /// <summary>
        /// ȡ�ķ���Ȩ�޷�Χ����,���ļ���
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static string GetDataAllAssignWhere(string UserID, string DeptID, string FilialeID, string MID,string FolderMID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  ( ID in (select DataID from Pub_Data_Assign  where ModulesID ='" + MID + "'");
            strSql.Append(" and ((AssignType='C' and AssignID='" + FilialeID + "') or (AssignType='D' and AssignID='" + DeptID + "') or (AssignType='U' and AssignID='" + UserID + "'))))");
            strSql.Append(" or ((select count(dataID) from Pub_Data_Assign where DataID=ID and ModulesID='" + MID + "')='0' and (select count(dataID) from Pub_Data_Assign where DataID=FolderID and ModulesID='" + FolderMID + "')='0' ");
            strSql.Append(") ");

            return strSql.ToString();
        }

        /// <summary>
        /// ȡ������Ȩ�޷�Χ����
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static string GetDataAclWhere(string UserID, string DeptID, string FilialeID, string MID)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" DeptID in (select a.FieldValue from Pub_Data_Acl as a ");

            strWhere.Append(" left join Pub_Data_Acl_Users as b on a.DataAclID=b.DataAclID ");
            strWhere.Append("where a.ModulesID='" + MID + "' and b.UID='" + UserID + "' and a.FieldName='D')");
            if (DeptID != "")
            {
                strWhere.Append(" and DeptID<>'" + DeptID + "' ");
            }
            if (FilialeID != "")
            {
                strWhere.Append("and FilialeID='" + FilialeID + "'");
            }

            return strWhere.ToString();
        }

        /// <summary>
        /// ȡ������Ȩ�޷�Χ����
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="MID"></param>
        /// <param name="DeptAlias">�������ڱ�ı���</param>
        /// <returns></returns>
        public static string GetDataAclWhere(string UserID, string DeptID, string FilialeID, string MID, string DeptAlias)
        {
            StringBuilder strWhere = new StringBuilder();
            if (DeptAlias != "")
            {
                DeptAlias += ".";
            }
            else
            {
                return "1<>1";
            }

            strWhere.Append(" " + DeptAlias + "DeptID in (select a.FieldValue from Pub_Data_Acl as a ");

            strWhere.Append(" left join Pub_Data_Acl_Users as b on a.DataAclID=b.DataAclID ");
            strWhere.Append("where a.ModulesID='" + MID + "' and b.UID='" + UserID + "' and a.FieldName='D')");
            if (DeptID != "")
            {
                strWhere.Append(" and DeptID<>'" + DeptID + "' ");
            }
            if (FilialeID != "")
            {
                strWhere.Append("and "   + DeptAlias +"FilialeID='" + FilialeID + "'");
            }

            return strWhere.ToString();
        }
        /// <summary>
        /// ȡ���û�����Ĳ��ž�������ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="DeptAlias">�������ڱ�ı���</param>
        /// <returns></returns>
        public static string GetDataDeptManagerWhere(string UserID, string FilialeID, string DeptAlias)
        {
            if (DeptAlias != "")
            {
                DeptAlias += ".";
            }
            return " " + DeptAlias + "DeptID in ( select  DeptID from Pub_Dept where ManagerID='" + UserID + "' and FilialeID='" + FilialeID + "' and DelFlag='N') ";
        }

        /// <summary>
        /// ȡ���û���λID
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="FilialeID"></param>
        /// <param name="DeptAlias">��λ���ڱ�ı���</param>
        /// <returns></returns>
        public static string GetDataUserPostWhere(string UserID, string FilialeID, string DeptAlias)
        {
            if (DeptAlias != "")
            {
                DeptAlias += ".";
            }
            return " " + DeptAlias + "PostID in ( select  PostID from Pub_DeptUsers where UserID='" + UserID + "' and FilialeID='" + FilialeID + "' ) ";
        }

        /// <summary>
        /// ȡ��ǩ��������
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static string GetDataSignsWhere(string UserID, string MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" (ID in  (select DocID from Pub_SignFile where MID='" + MID + "' and SignsID='" + UserID + "')) ");
            return strSql.ToString();
        }


        /// <summary>
        /// ȡ��������������
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static string GetDataBoWhere(string UserID)
        {
            return " creator='" + UserID + "' or UserID='" + UserID + "' ";//owner='" + UserID + "' or 
        }
        /// <summary>    
        /// ��������Ȩ����֤����ͨ��ֱ����ʾ
        /// </summary>
        /// <param name="_Response"></param>
        /// <param name="BoName"></param>
        /// <param name="DocID"></param>
        /// <param name="MID"></param>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        public static void CheckDataAcl(HttpResponse _Response, string BoName, string DocID, string MID, string UserID, string DeptID, string FilialeID)
        {
            string strSql = "select ID,UserID,DeptID,owner,creator from " + BoName + " where ID='" + DocID + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds.Tables[0].Rows.Count > 0)//�������ݵ�ӵ���߻�����
            {
                //�Ƿ�������Ȩ��
                string uid = ds.Tables[0].Rows[0]["UserID"].ToString();
                string owner = ds.Tables[0].Rows[0]["owner"].ToString();
                string creator = ds.Tables[0].Rows[0]["creator"].ToString();
                string did = ds.Tables[0].Rows[0]["DeptID"].ToString();
                if (uid != UserID && owner != UserID && creator != UserID)
                {
                    StringBuilder strWhere = new StringBuilder();
                    strWhere.Append(" select UID from Pub_Data_Acl_Users where UID='" + UserID + "' and DataAclID in ( ");
                    strWhere.Append(" select DataAclID from Pub_Data_doc where ModulesID='" + MID + "' and FilialeID='" + FilialeID + "' ");
                    strWhere.Append(" and DataAclID in ( select DataAclID from Pub_Data_Acl where ");
                    strWhere.Append(" ModulesID='" + MID + "' and ((FieldName='D' and FieldValue='" + did + "') or (FieldName='U' and FieldValue='" + uid + "'))))");
                    DataSet dsacl = DbHelperSQL.Query(strWhere.ToString());
                    if (dsacl.Tables[0].Rows.Count < 1)
                    {
                        _Response.Write("<script>document.location='../../message.aspx?msg=û�з������ݵ�Ȩ��'</script>");
                    }
                }

            }
            else
            {
                return;
                //   _Response.Write("<script>document.location='../../message.aspx?msg=û�з������ݵ�Ȩ��'</script>");
            }

        }

       public static void CheckDataAcl(HttpResponse _Response, string BoName, string DocID, string MID, string UserID, string DeptID, string FilialeID,string Flag)
        {
            string strSql = "select ID,UserID,DeptID,owner,creator from " + BoName + " where ID='" + DocID + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds.Tables[0].Rows.Count > 0)//�������ݵ�ӵ���߻�����
            {
                //�Ƿ�������Ȩ��
                string uid = ds.Tables[0].Rows[0]["UserID"].ToString();
                string owner = ds.Tables[0].Rows[0]["owner"].ToString();
                string creator = ds.Tables[0].Rows[0]["creator"].ToString();
                string did = ds.Tables[0].Rows[0]["DeptID"].ToString();
                if (uid != UserID && owner != UserID && creator != UserID && DeptID != did)
                {
                    StringBuilder strWhere = new StringBuilder();
                    strWhere.Append(" select UID from Pub_Data_Acl_Users where UID='" + UserID + "' and DataAclID in ( ");
                    strWhere.Append(" select DataAclID from Pub_Data_doc where ModulesID='" + MID + "' and FilialeID='" + FilialeID + "' ");
                    strWhere.Append(" and DataAclID in ( select DataAclID from Pub_Data_Acl where ");
                    strWhere.Append(" ModulesID='" + MID + "' and ((FieldName='D' and FieldValue='" + did + "') or (FieldName='U' and FieldValue='" + uid + "'))))");
                    DataSet dsacl = DbHelperSQL.Query(strWhere.ToString());
                    if (dsacl.Tables[0].Rows.Count < 1)
                    {
                        _Response.Write("<script>document.location='../../message.aspx?msg=û�з������ݵ�Ȩ��'</script>");
                    }
                }

            }
            else
            {
                return;
                //   _Response.Write("<script>document.location='../../message.aspx?msg=û�з������ݵ�Ȩ��'</script>");
            }

        }
        /// <summary>    
        /// ��������Ȩ����֤����ͨ������
        /// </summary>
        /// <param name="_Response"></param>
        /// <param name="BoName"></param>
        /// <param name="DocID"></param>
        /// <param name="MID"></param>
        /// <param name="UserID"></param>
        /// <param name="DeptID"></param>
        /// <param name="FilialeID"></param>
        public static bool CheckDataAcl(string BoName, string DocID, string MID, string UserID, string DeptID, string FilialeID)
        {
            string strSql = "select ID,UserID,DeptID,owner,creator from " + BoName + " where ID='" + DocID + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //�Ƿ�������Ȩ��
                string uid = ds.Tables[0].Rows[0]["UserID"].ToString();
                string owner = ds.Tables[0].Rows[0]["owner"].ToString();
                string creator = ds.Tables[0].Rows[0]["creator"].ToString();
                string did = ds.Tables[0].Rows[0]["DeptID"].ToString();
                if (uid != UserID && owner != UserID && creator != UserID)//�������ݵ�ӵ���߻�����
                {
                    StringBuilder strWhere = new StringBuilder();
                    strWhere.Append(" select UID from Pub_Data_Acl_Users where UID='" + UserID + "' and DataAclID in ( ");
                    strWhere.Append(" select DataAclID from Pub_Data_doc where ModulesID='" + MID + "' and FilialeID='" + FilialeID + "' ");
                    strWhere.Append(" and DataAclID in ( select DataAclID from Pub_Data_Acl where ");
                    strWhere.Append(" ModulesID='" + MID + "' and ((FieldName='D' and FieldValue='" + did + "') or (FieldName='U' and FieldValue='" + uid + "'))))");
                    DataSet dsacl = DbHelperSQL.Query(strWhere.ToString());
                    if (dsacl.Tables[0].Rows.Count < 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true ;
                }
            }
            else
            {
                return false;
                 
            }
            
        }
        public static void CheckDataUpdateAcl(DataView dv, string BoName,string UserID)
        {

        }
    }
}
