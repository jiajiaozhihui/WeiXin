using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using SfSoft.Common;
using SfSoft.DBUtility;
namespace SfSoft.SfEmc
{

    public class DoAppFlow
    {
        public static BLL.Pub_AuditFlow bllPAF = new SfSoft.BLL.Pub_AuditFlow();
        public static BLL.Pub_AuditRec bllPAR = new SfSoft.BLL.Pub_AuditRec();
        public static BLL.Pub_FunDef bllpf = new SfSoft.BLL.Pub_FunDef();

        
        /// <summary>
        /// ��֤�Ƿ�ǰ������
        /// </summary>
        /// <param name="DocID">����ID</param>
        /// <param name="MID">ģ��ID</param>
        /// <param name="UserID">�û�ID</param>
        /// <returns>�ǵ�ǰ������ true</returns>
        public static bool CheckCurApproval(string DocID, string MID, string UserID)
        {
            Model.Pub_AuditRec model = new SfSoft.Model.Pub_AuditRec();
            model = bllPAR.GetModel(MID, DocID);
            if (model == null)
            {
                return false;
            }
            string ARID = model.ARID.ToString();
            string AuditUserID = model.AuditUserID.ToString();
            if (AuditUserID == UserID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetAuditRecID(string DocID, string MID)
        {
            Model.Pub_AuditRec model = new SfSoft.Model.Pub_AuditRec();
            model = bllPAR.GetModel(MID, DocID);
            if (model == null)
            {
                return "";
            }
            else
            {
                return  model.ARID.ToString();
            }
        }

        public static string SetAppInfo(DataView UserAcldv, string DocID, string MID, string CnName, string UserID, Button btnApprove, Button btnSave, Label lblUnDoFlag, TextBox txtAuditName, TextBox txtAuditdate, Panel panelApp)
        {
            Model.Pub_AuditRec model = new SfSoft.Model.Pub_AuditRec();
            model = bllPAR.GetModel(MID, DocID);
            string ARID = model.ARID.ToString();
            string UndoFlag = "";
            string UndoDate = "";
            string Status = "";
            string AuditName = "";
            string AuditUserID = "";

            //��֤Ȩ��
            DataSet dsrc = GetAuditRecInfo(UserID, ARID);//�Ƿ�Ϊ��ǰ�����˻���ʷ������
            //�Ƿ�Ϊ��������Ա
            bool IsAppMgt = SfEmc.UserAcl.checkMenuAcl(UserAcldv, "emc.rcm.todo.mgt");//�Ƿ�Ϊ��������Ա
            //��Ȩ��
            if (dsrc == null && IsAppMgt == false)
            {

                return "N";
            }
            else
            {
                UndoFlag = model.UndoFlag;
                UndoDate = model.UndoDate.ToString();
                Status = model.StatusFlag;
                AuditName = model.AuditName;
                AuditUserID = model.AuditUserID.ToString();
            }
            //���ð�Ť
            if (AuditUserID != UserID)
            {
                btnApprove.Visible = false;
                btnSave.Visible = false;
                panelApp.Visible = false;
            }
            else
            {
                if (Status == "Y" || Status == "N" || Status == "UN")
                {
                    btnApprove.Visible = false;
                    btnSave.Visible = false;
                    panelApp.Visible = false;
                }
                else
                {
                    txtAuditdate.Text = Common.Common.formatDate(DateTime.Now);
                    txtAuditName.Text = CnName;
                }
            }
            //������ʾ��Ϣ
            if (UndoFlag == "UNS")
            {
                lblUnDoFlag.Text = AppFlow.GetStatus(UndoFlag);
            }
            return "Y";

        }
        private static DataSet GetAuditRecInfo(string UserID, string ARID)
        {
            StringBuilder strWhere = new StringBuilder();


            strWhere.Append("  ( AuditUserID = '" + UserID + "' and ARID='" + ARID + "')");
            strWhere.Append(" or   ARID in ( select ARID from Pub_AuditResult where AuditUserID= '" + UserID + "' and ARID='" + ARID + "' )");

            DataSet ds = bllPAR.GetList(strWhere.ToString());

            return ds;
        }
        //����������
        public static Hashtable AuditDoApp(string DocID, string MID, string   AuditSign, string Contral, string AuditorCmnt)
        {
            Hashtable hash = new Hashtable();
            hash.Add("AuditSign", "");
            //hash��AuditSign��ȷ�����������������ڵ���������Ĵ���
            if (AuditSign == "")
            {
                //û����������
                hash["AuditSign"] = "NoSign";
                return hash;
            }
          
            
            //ȡ��������¼��Ϣ
            Model.Pub_AuditRec modelPAR = new SfSoft.Model.Pub_AuditRec();
            //ȡ���������еļ�¼
            modelPAR = bllPAR.GetModel(MID, DocID);
            int ARID = modelPAR.ARID;
            //ȡ�ı���
            string BoName = EmcCommon.GetFunDefValue("BoName", MID);
            //ȡ�ı��󵥾���Ϣ

            hash = AppFlow.GetDocAppInfo(DocID, BoName);
            string UserID = hash["UserID"].ToString();
            string DeptID = hash["DeptID"].ToString();
            string FilialeID = hash["FilialeID"].ToString();
            // string ConditionValue = hash["ConditionValue"].ToString();
            string NewStatus = "";
            string UndoFlag = hash["UndoFlag"].ToString();
            string UnDoDate = hash["UndoDate"].ToString();
            string SubmitDate = hash["SubmitDate"].ToString();
            string Remark = hash["Remark"].ToString();
            string Signs = hash["Signs"].ToString();
            string ObjPriority = hash["ObjPriority"].ToString();
            string AuditClass = "1";
            string AuditUserID = "";
            string AuditName = "";
            string AuditTypeName = "";
            string Msg = "";
            string AuditClass2 = "";
            string BoStatus = "";
            //BoName = modelPAR.BoName;
            int? AuditClass1 = modelPAR.AuditClass;
            int? AuditUserID1 = modelPAR.AuditUserID;
            AuditTypeName = modelPAR.AuditTypeName;
            AuditUserID = modelPAR.AuditUserID.ToString();
            AuditName = modelPAR.AuditName;
            AuditClass = modelPAR.AuditClass.ToString();

            string ObjName = modelPAR.ObjName;
            string TempAuditUserID = AuditUserID;
            string TempAuditName = AuditName;
            string TempAuditClass = AuditClass;
            string TempAuditTypeName = modelPAR.AuditTypeName;

            //������ͬ��
            if (AuditSign == "N")
            {
                //��������볷��
                if (UndoFlag == "UNS")
                {
                    //��д������Ϣ
                    BoStatus=UpdateBoInfoAudit(DocID, BoName, "NUNS");//��ͬ�⳷��
                    //��д������¼
                    NewStatus = "Y";
                    UnDoDate = "";
                    UndoFlag = "N";

                    hash["AuditSign"] = "NUNS";
                    //�����������
                    Msg = ObjName + "��������������ͬ��";
                }
                else//�������볷��
                {
                    //��д������Ϣ
                    BoStatus = UpdateBoInfoAudit(DocID, BoName, "N");//������ͬ��
                    //��д������¼
                    NewStatus = "N";
                    UnDoDate = "";
                    UndoFlag = "N";
                    //�����������
                    hash["AuditSign"] = "N";
                    Msg = ObjName + "������ͬ��";
                }
            }
            else//����ͬ��
            {
                //��������볷��
                if (UndoFlag == "UNS")
                {
                    //��д������Ϣ
                    BoStatus = UpdateBoInfoAudit(DocID, BoName, "YUNS");//ͬ�⳷��
                    Msg = BoName + "������������ͬ��";
                    hash["AuditSign"] = "YUNS";
                    NewStatus = "UN";
                    UnDoDate = Common.Common.formatDate(DateTime.Now);
                    UndoFlag = "YUNS";
                    Msg = ObjName + "������������ͬ��";

                }
                else//�������볷��
                {
                    //ȡ���ϼ�������
                    //�ϼ���������������
                    Hashtable hashad = new Hashtable();
                    AuditClass1 += 1;
                    hashad = GetAuditUserID(MID, UserID, AuditUserID, DeptID, FilialeID, AuditClass1.ToString(), DocID);
                    string IsAuditMan = hashad["IsAuditMan"].ToString();
                    AuditClass2 = hashad["AuditClass1"].ToString();


                    if (IsAuditMan == "Y")//���ϼ�����
                    {
                        int? AuditUserID2 = PageValidate.StringToInt(hashad["AuditUserID"].ToString());

                        //���������� 
                        NewStatus = "UP"; //�ϼ�����

                        string SurManID = AppFlow.CheckSurrogate(AuditUserID2.ToString(), MID, SubmitDate, FilialeID);
                        if (SurManID == "")
                        {
                            AuditUserID = AuditUserID2.ToString();
                            AuditName = hashad["AuditName"].ToString();
                        }
                        else
                        {
                            AuditUserID = SurManID;
                            AuditName = EmcCommon.getUserCnNameByID(AuditUserID) + "����";
                        }
                        AuditTypeName = hashad["AuditTypeName"].ToString();

                    }
                    else
                    {
                        NewStatus = "Y";
                    }
                    UndoFlag = "N";

                    //��д������Ϣ
                   BoStatus = UpdateBoInfoAudit(DocID, BoName, NewStatus);//����ͬ��



                    hash["AuditSign"] = "Y";
                    Msg = ObjName + "����ͬ��";
                }

            }
            DateTime? AuditDate = DateTime.Now;
            //��д������¼
            modelPAR.StatusFlag = NewStatus;
            modelPAR.UndoDate = AuditDate;
            modelPAR.UndoFlag = UndoFlag;
            modelPAR.AuditDate = AuditDate;
            if (NewStatus == "UP")
            {

                modelPAR.AuditUserID = PageValidate.StringToInt(AuditUserID);
                modelPAR.AuditTypeName = AuditTypeName;
                modelPAR.AuditName = AuditName;
                modelPAR.AuditClass = PageValidate.StringToInt(AuditClass2);
                AuditClass = AuditClass2.ToString();
            }

            bllPAR.Update(modelPAR);
            //�����������
            string StatusName = AppFlow.GetStatus(NewStatus);
            //����������¼
            SaveAuditResult(ARID, TempAuditClass, TempAuditName, AuditDate.ToString(), AuditorCmnt, hash["AuditSign"].ToString(), TempAuditTypeName, TempAuditUserID, Contral, MID);
            //����������Ϣ��������
            AppFlow.SendDoAppMsn(Msg, ObjName, DocID, SubmitDate, StatusName, Signs, UserID, TempAuditName, TempAuditUserID, ObjPriority, Contral,MID);
            if (NewStatus == "UP")//��������ϼ�������
            {
                //����Ϣ���ϼ�������
                Msg = ObjName + "��������";
                AppFlow.SendAppMsn(Msg, ObjName, DocID, SubmitDate, StatusName, Signs, UserID, AuditName, AuditUserID, ObjPriority, AuditorCmnt,MID);
            }
            hash["status"]=BoStatus ;
            return hash;

        }
        


        //����������
        public static Hashtable AuditDoApp(string DocID, string MID, RadioButtonList rblAuditSign, TextBox txtContral, TextBox txtAuditorCmnt, TextBox txtAuditName, TextBox txtAuditdate)
        {
            Hashtable hash = new Hashtable();
            hash.Add("AuditSign", "");
            //hash��AuditSign��ȷ�����������������ڵ���������Ĵ���
            if (rblAuditSign.SelectedItem == null)
            {
                //û����������
                hash["AuditSign"] = "NoSign";
                return hash;
            }
            //��������
            string AuditSign = rblAuditSign.SelectedItem.Value;
            //ȡ��������¼��Ϣ
            Model.Pub_AuditRec modelPAR = new SfSoft.Model.Pub_AuditRec();
            //ȡ���������еļ�¼
            modelPAR = bllPAR.GetModel(MID, DocID);
            int ARID = modelPAR.ARID;
            //ȡ�ı���
            string BoName = EmcCommon.GetFunDefValue("BoName", MID);
            //ȡ�ı��󵥾���Ϣ
 
            hash = AppFlow.GetDocAppInfo(DocID, BoName);
            string UserID = hash["UserID"].ToString();
            string DeptID = hash["DeptID"].ToString();
            string FilialeID = hash["FilialeID"].ToString();
           // string ConditionValue = hash["ConditionValue"].ToString();
            string NewStatus = "";
            string UndoFlag = hash["UndoFlag"].ToString();
            string UnDoDate = hash["UndoDate"].ToString();
            string SubmitDate = hash["SubmitDate"].ToString();
            string Remark = hash["Remark"].ToString();
            string Signs = hash["Signs"].ToString();
            string ObjPriority = hash["ObjPriority"].ToString();
            string BoStatus = "";
            string AuditClass = "1";
            string AuditUserID = "";
            string AuditName = "";
            string AuditTypeName = "";
            string Msg = "";
            string AuditClass2 = "";
            //BoName = modelPAR.BoName;
            int? AuditClass1 = modelPAR.AuditClass;
            int? AuditUserID1 = modelPAR.AuditUserID;
            AuditTypeName = modelPAR.AuditTypeName;
            AuditUserID = modelPAR.AuditUserID.ToString();
            AuditName = modelPAR.AuditName;
            AuditClass = modelPAR.AuditClass.ToString();

            string ObjName = modelPAR.ObjName;
            string TempAuditUserID = AuditUserID;
            string TempAuditName = AuditName;
            string TempAuditClass = AuditClass;
            string TempAuditTypeName = modelPAR.AuditTypeName;

            //������ͬ��
            if (AuditSign == "N")
            {
                //��������볷��
                if (UndoFlag == "UNS")
                {
                    //��д������Ϣ
                    BoStatus = UpdateBoInfoAudit(DocID, BoName, "NUNS");//��ͬ�⳷��
                    //��д������¼
                    NewStatus = "Y";
                    UnDoDate = "";
                    UndoFlag = "N";

                    hash["AuditSign"] = "NUNS";
                    //�����������
                    Msg = ObjName + "��������������ͬ��";
                }
                else//�������볷��
                {
                    //��д������Ϣ
                    BoStatus = UpdateBoInfoAudit(DocID, BoName, "N");//������ͬ��
                    //��д������¼
                    NewStatus = "N";
                    UnDoDate = "";
                    UndoFlag = "N";
                    //�����������
                    hash["AuditSign"] = "N";
                    Msg = ObjName + "������ͬ��";
                }
            }
            else//����ͬ��
            {
                //��������볷��
                if (UndoFlag == "UNS")
                {
                    //��д������Ϣ
                    BoStatus = UpdateBoInfoAudit(DocID, BoName, "YUNS");//ͬ�⳷��
                    Msg = BoName + "������������ͬ��";
                    hash["AuditSign"] = "YUNS";
                    NewStatus = "UN";
                    UnDoDate = Common.Common.formatDate(DateTime.Now);
                    UndoFlag = "YUNS";
                    Msg = ObjName + "������������ͬ��";

                }
                else//�������볷��
                {
                    //ȡ���ϼ�������
                    //�ϼ���������������
                    Hashtable hashad = new Hashtable();
                    AuditClass1 += 1;
                    hashad = GetAuditUserID(MID, UserID, AuditUserID, DeptID, FilialeID, AuditClass1.ToString(), DocID);
                    string IsAuditMan = hashad["IsAuditMan"].ToString();
                    AuditClass2 = hashad["AuditClass1"].ToString();


                    if (IsAuditMan == "Y")//���ϼ�����
                    {
                        int? AuditUserID2 = PageValidate.StringToInt(hashad["AuditUserID"].ToString());

                        //���������� 
                        NewStatus = "UP"; //�ϼ�����

                        string SurManID = AppFlow.CheckSurrogate(AuditUserID2.ToString (), MID, SubmitDate, FilialeID);
                        if (SurManID == "")
                        {
                            AuditUserID = AuditUserID2.ToString();
                            AuditName = hashad["AuditName"].ToString();
                        }
                        else
                        {
                            AuditUserID = SurManID;
                            AuditName = EmcCommon.getUserCnNameByID(AuditUserID) + "����";
                        }
                        AuditTypeName = hashad["AuditTypeName"].ToString();

                    }
                    else
                    {
                        NewStatus = "Y";
                    }
                    UndoFlag = "N";

                    //��д������Ϣ
                    BoStatus = UpdateBoInfoAudit(DocID, BoName, NewStatus);//����ͬ��



                    hash["AuditSign"] = "Y";
                    Msg = ObjName + "����ͬ��";
                }

            }
            DateTime? AuditDate = DateTime.Now;
            //��д������¼
            modelPAR.StatusFlag = NewStatus;
            modelPAR.UndoDate = AuditDate;
            modelPAR.UndoFlag = UndoFlag;
            modelPAR.AuditDate = AuditDate;
            if (NewStatus == "UP")
            {

                modelPAR.AuditUserID = PageValidate.StringToInt(AuditUserID);
                modelPAR.AuditTypeName = AuditTypeName;
                modelPAR.AuditName = AuditName;
                modelPAR.AuditClass = PageValidate.StringToInt(AuditClass2);
                AuditClass = AuditClass2.ToString();
            }

            bllPAR.Update(modelPAR);
            //�����������
            string AuditorCmnt = txtAuditorCmnt.Text;
            string Contral = txtContral.Text;
            string StatusName = AppFlow.GetStatus(NewStatus);
            //����������¼
            SaveAuditResult(ARID, TempAuditClass, TempAuditName, AuditDate.ToString(), AuditorCmnt, hash["AuditSign"].ToString(), TempAuditTypeName, TempAuditUserID, Contral, MID);
            //����������Ϣ��������
            AppFlow.SendDoAppMsn(Msg, ObjName, DocID, SubmitDate, StatusName, Signs, UserID, TempAuditName, TempAuditUserID, ObjPriority, Contral,MID);
            if (NewStatus == "UP")//��������ϼ�������
            {
                //����Ϣ���ϼ�������
                Msg = ObjName + "��������";
                AppFlow.SendAppMsn(Msg, ObjName, DocID, SubmitDate, StatusName, Signs, UserID, AuditName, AuditUserID, ObjPriority, AuditorCmnt,MID);
            }
            return hash;

        }
        
        
        //ȡ���ϼ�������
        public static Hashtable GetAuditUserID(string MID, string UserID, string AuditUserID, string DeptID, string FilialeID, string AuditClass, string DocID)
        {
            Hashtable hashAd = new Hashtable();

            string strWhereA = " AuditClass = '" + AuditClass + "' and FilialeID ='" + FilialeID + "'  and MID='" + MID + "' ";
            StringBuilder strWhere = new StringBuilder();

            strWhere.Append(" ( AuditMode='P' and  AuditBound='PT' and AFID in (select AFID from Pub_AuditFlow_Dept ");
            strWhere.Append(" where DeptID='" + DeptID + "' and MID='" + MID + "')");
            strWhere.Append(" and " + strWhereA + ")");
            strWhere.Append(" or (AuditMode='P' and AuditBound='DF' and " + strWhereA + ")");
            strWhere.Append(" or ( AuditMode='U' and " + strWhereA + ")");
            strWhere.Append("  order by ConditionValue desc ");
            DataSet ds = bllPAF.GetList(strWhere.ToString());
            // string IsAuditMan = "N";
            string AuditUserID1 = "";
            string AuditName1 = "";
            string AuditClass1 = "";
            string AuditMode1 = "";
            string ConditionValue1 = "";
            string LogicName1 = "";
            string FieldName1 = "";
            string AuditBound1 = "";
            string AuditTypeName1 = "";
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                bool CkCdValue = false;
                bool IsCd = false;
                foreach (DataRow drad in ds.Tables[0].Rows)
                {
                    AuditUserID1 = drad["AuditUserID"].ToString();
                    AuditName1 = drad["AuditName"].ToString();
                    AuditClass1 = drad["AuditClass"].ToString();
                    AuditMode1 = drad["AuditMode"].ToString();
                    ConditionValue1 = drad["ConditionValue"].ToString();
                    LogicName1 = drad["LogicName"].ToString();
                    FieldName1 = drad["FieldName"].ToString();
                    AuditBound1 = drad["AuditBound"].ToString();
                    AuditTypeName1 = drad["AuditTypeName"].ToString();
                    if (FieldName1 != "N") //����������
                    {
                        
                        string ConditionValue = AppFlow.GetConditionValue(MID, DocID, FieldName1);
                        //ȡ�ĵ�������ֵ
                        if (AppFlow.CheckCondtion(ConditionValue1, LogicName1, ConditionValue) == true)
                        {
                            CkCdValue = true;

                            break;
                        }

                    }
                    else
                    {
                        IsCd = true;
                    }

 
                }
                //����������������������,û������������
                if (CkCdValue != true && IsCd != true)
                {
                    //�����������ˣ���������
                    // hashAd.Add("IsAuditMan", "N");
                    // return hashAd;
                    int ac = int.Parse(AuditClass) + 1;
                    AuditClass = ac.ToString();
                    hashAd = GetAuditUserID(MID, UserID, AuditUserID, DeptID, FilialeID, AuditClass, DocID);

                    return hashAd;

                }
                //��������
                if (AuditMode1 == "P") //ָ������
                {
                    //�������Ƿ�Ϊ����,���������Ƿ���ڵ�ǰ������
                    if (UserID == AuditUserID1 || AuditUserID == AuditUserID1)
                    {
                        //��������������ѻ�����������,ȡ�ϼ�������,
                        int ac = int.Parse(AuditClass) + 1;
                        AuditClass = ac.ToString();
                        hashAd = GetAuditUserID(MID, UserID, AuditUserID, DeptID, FilialeID, AuditClass, DocID);
                        return hashAd;
                    }
                    else//���ϼ�������
                    {
                        hashAd.Add("AuditClass1", AuditClass1);
                        hashAd.Add("AuditUserID", AuditUserID1);
                        hashAd.Add("AuditName", AuditName1);
                        hashAd.Add("AuditTypeName", AuditTypeName1);
                        hashAd.Add("IsAuditMan", "Y");
                        return hashAd;
                    }
                }
                else
                {//�ϼ�����
                    //ȡ��������
                    //ȡ�����ǵڼ����ϼ�����
                    int UpAuditNum = GetUpAuditNum(MID, AuditClass, FilialeID);
                    //ȡ����ǰ��ʼ�����Ĳ���
                    if (UpAuditNum > 0)
                    {
                        string CurDeptID = GetCurAuditDept(UpAuditNum, DeptID, 0, FilialeID);
                        DeptID = CurDeptID;
                    }

                    Hashtable hastp = GetDeptAuditMan(DeptID, UserID, 0, "", FilialeID, AuditUserID);
                    if (hastp["IsAuditMan"].ToString() == "Y")
                    {
                        string AuditUserID2 = hastp["AuditUserID2"].ToString();
                        //�������Ƿ�Ϊ����
                        if (UserID == AuditUserID2)
                        {
                            //���������ȡ�ϼ�������,����һ������������������
                            int ac = int.Parse(AuditClass) + 1;
                            AuditClass = ac.ToString();
                            hashAd = GetAuditUserID(MID, UserID, AuditUserID, DeptID, FilialeID, AuditClass, DocID);
                            return hashAd;
                        }
                        else
                        {
                            hashAd.Add("AuditClass1", AuditClass1);
                            hashAd.Add("AuditUserID", hastp["AuditUserID2"].ToString());
                            hashAd.Add("AuditName", hastp["AuditName2"].ToString());
                            hashAd.Add("AuditTypeName", AuditTypeName1);
                            hashAd.Add("IsAuditMan", "Y");
                        }
                    }
                    else
                    {
                        hashAd.Add("AuditClass1", AuditClass1);
                        hashAd.Add("IsAuditMan", "N");
                        hashAd.Add("AuditUserID", "0");
                        hashAd.Add("AuditName", "");
                        hashAd.Add("AuditTypeName", "");
 
                    }
                    return hashAd;
                }

            }
            else //û���ϼ�����,��������
            {
                //�Ƿ�����һ��������������ǰ��������
                int ac = int.Parse(AuditClass) + 1;
                AuditClass = ac.ToString();
                if (CheckUpAuditClass(AuditClass, MID, FilialeID))
                {
                    hashAd = GetAuditUserID(MID, UserID, AuditUserID, DeptID, FilialeID, AuditClass, DocID);
                }
                else
                {
  
                        hashAd.Add("AuditClass1", ac - 1);
                        hashAd.Add("IsAuditMan", "N");
  
                }
                return hashAd;
            }


            //  return hashAd;
        }

        public static bool CheckUpAuditClass(string AuditClass,string MID,string FilialeID)
        {
            string strWhere = " AuditClass = '" + AuditClass + "' and FilialeID ='" + FilialeID + "'  and MID='" + MID + "' ";
            DataSet ds = bllPAF.GetList(strWhere.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //����ȡ�ϼ�������
        public static Hashtable GetDeptAuditMan(string DeptID, string UserID, int level, string AuditName, string FilialeID, string AuditUserID)
        {

            Hashtable hashdam = new Hashtable();
            BLL.Pub_Dept bllpd = new SfSoft.BLL.Pub_Dept();
            string strWhere1 = " DeptID = '" + DeptID + "' and FilialeID='" + FilialeID + "' and AuditID<>'0' ";
            DataSet dspd = bllpd.GetList(strWhere1);
            if (dspd != null && dspd.Tables[0].Rows.Count > 0)
            {
                string AuditUserID2 = dspd.Tables[0].Rows[0]["AuditID"].ToString();
                string AuditName2 = dspd.Tables[0].Rows[0]["AuditName"].ToString();
                hashdam.Add("IsAuditMan", "Y");
                hashdam.Add("AuditUserID2", AuditUserID2);
                hashdam.Add("AuditName2", AuditName2);
                return hashdam;

            }
            else //��������,��������
            {

                hashdam.Add("IsAuditMan", "N");

                return hashdam;
            }
        }

        /// <summary>
        /// ȡ��ǰ��������ID
        /// </summary>
        /// <param name="UpAuditNum">��������</param>
        /// <param name="DeptID">�����˲���ID</param>
        /// <param name="level">������</param>
        /// <param name="FilialeID">��˾ID</param>
        /// <returns></returns>
        public static string GetCurAuditDept(int UpAuditNum, string DeptID, int level, string FilialeID)
        {

            if (UpAuditNum == level)
            {
                return DeptID;
            }
            else
            {
                BLL.Pub_Dept blldp = new SfSoft.BLL.Pub_Dept();
                string strWhereDept = " FilialeID='" + FilialeID + "' and DeptID='" + DeptID + "'";
                DataSet dsdp = blldp.GetList(strWhereDept);
                if (dsdp != null && dsdp.Tables[0].Rows.Count > 0)
                {
                    string curPDeptID = dsdp.Tables[0].Rows[0]["ParentAuditID"].ToString();
                    level += 1;
                    return GetCurAuditDept(UpAuditNum, curPDeptID, level, FilialeID);
                }
                else
                {
                    return DeptID;
                }
            }
        }
        //��������Ϣ
        public static string  UpdateBoInfoAudit(string DocID, string BoName, string AuditSign)
        {
            string NewStatus2 = "";
            string UndoFlag2 = "";
            string UnDoDate2 = "";
            if (AuditSign == "NUNS") //��ͬ�⳷��
            {
                NewStatus2 = "Y";
                UndoFlag2 = "NUNS";

            }
            else if (AuditSign == "N")//������ͬ��
            {
                NewStatus2 = "N";
                UndoFlag2 = "N";
            }
            else if (AuditSign == "YUNS") //ͬ�⳷��
            {
                NewStatus2 = "UN";
                UndoFlag2 = "YUNS";

            }
            else if (AuditSign == "Y")//����ͬ��
            {
                NewStatus2 = "Y";
                UndoFlag2 = "N";
                UnDoDate2 = Common.Common.formatDate(DateTime.Now);
            }
            else if (AuditSign == "UP")
            {
                NewStatus2 = "UP";
                UndoFlag2 = "N";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update " + BoName.Trim() + " set ");
            strSql.Append(" status='" + NewStatus2.Trim() + "',");
            strSql.Append(" StatusName='" + AppFlow.GetStatus(NewStatus2.Trim()).Trim() + "',");
            strSql.Append(" UndoFlag='" + UndoFlag2.Trim() + "'");
            if (UnDoDate2 != "")
            {
                strSql.Append(", UnDoDate='" + UnDoDate2.Trim() + "'");
            }
            strSql.Append(" where ID='" + DocID.Trim() + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return NewStatus2;
        }

        //������������
        public static void SaveAuditResult(int ARID, string AuditClass, string AuditName, string Auditdate, string AuditorCmnt, string AuditSign, string AuditTypeName, string AuditUserID, string Contral, string MID)
        {
            Model.Pub_AuditResult modelR = new SfSoft.Model.Pub_AuditResult();
            BLL.Pub_AuditResult bllR = new SfSoft.BLL.Pub_AuditResult();
            modelR.ARID = ARID;
            modelR.AuditClass = PageValidate.StringToInt(AuditClass);
            modelR.AuditName = AuditName;
            modelR.Auditdate = PageValidate.StringToDatetime(Auditdate);
            modelR.AuditorCmnt = AuditorCmnt;
            modelR.AuditSign = AuditSign;
            modelR.AuditTypeName = AuditTypeName;
            modelR.AuditUserID = PageValidate.StringToInt(AuditUserID);
            modelR.Contral = Contral;
            modelR.MID = MID;
            bllR.Add(modelR);
        }


        //ȷ����ǰ�������м����ϼ�����
        public static int GetUpAuditNum(string MID, string AuditClass, string FilialeID)
        {
            string strWhere = " MID = '" + MID + "' and AuditClass < '" + AuditClass + "' and  FilialeID='" + FilialeID + "' and AuditMode='U'";
            DataSet ds = bllPAF.GetList(strWhere);
            int AuditNum = 0;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                AuditNum = ds.Tables[0].Rows.Count;
            }
            return AuditNum;
        }

        //ȡ��������
        public static void GetAppResult(string MID, string DocID, string Flag, PlaceHolder phAppResult)
        {
            Model.Pub_AuditRec model = bllPAR.GetModel(MID, DocID);
            if (model == null)
            {
                phAppResult.Visible = false;
                return;
            }
            string ARID = model.ARID.ToString();
            BLL.Pub_AuditResult bllar = new SfSoft.BLL.Pub_AuditResult();
            string strWhere = " ARID = '" + ARID + "' order by ARSID";
            DataSet ds = bllar.GetList(strWhere);
            if (ds.Tables[0].Rows.Count < 1)
            {
                phAppResult.Visible = false;
                return;
            }
            Table tb = new Table();
            TableRow tr = new TableRow();
            TableCell tc = null;
            tb.Attributes.Add("style", "width:100%;");


            tr.Attributes.Add("style", "background-color:#8caae7");
            tc = new TableCell();
            tc.Attributes.Add("style", "height: 22px");
            tc.Text = "����";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "������";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "��������";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "����ʱ��";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "�������";
            tr.Cells.Add(tc);
            if (Flag == "App")
            {
                tc = new TableCell();
                tc.Text = "������ע";
                tr.Cells.Add(tc);
            }
            tb.Rows.Add(tr);
            string AuditClass = "";
            string Auditdate = "";
            string AuditSign = "";
            string AuditName = "";
            string AuditorCmnt = "";
            string Contral = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Auditdate = dr["Auditdate"].ToString();
                AuditSign = dr["AuditSign"].ToString();
                AuditSign = AppFlow.GetStatus(AuditSign);
                AuditName = dr["AuditName"].ToString();
                AuditorCmnt = dr["AuditorCmnt"].ToString();
                Contral = dr["Contral"].ToString();
                AuditClass = dr["AuditClass"].ToString();
                TableRow tr1 = new TableRow();
                TableCell tc1 = null;
                //tr1.BackColor = "#8caae7";
                tc1 = new TableCell();
                tc1.Attributes.Add("style", "height: 22px");
                tc1.Text = AuditClass;
                tr1.Cells.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = AuditName;
                tr1.Cells.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = AuditSign;
                tr1.Cells.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = Auditdate;
                tr1.Cells.Add(tc1);
                tc1 = new TableCell();
                tc1.Text = Contral;
                tr1.Cells.Add(tc1);
                if (Flag == "App")
                {
                    tc1 = new TableCell();
                    tc1.Text = AuditorCmnt;
                    tr1.Cells.Add(tc1);
                }
                tb.Rows.Add(tr1);
            }
            phAppResult.Controls.Add(tb);

        }
    }
}
