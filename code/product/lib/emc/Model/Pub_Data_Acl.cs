using System;
namespace SfSoft.Model
{
    /// <summary>
    /// ʵ����Pub_Data_Acl ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class Pub_Data_Acl
    {
        public Pub_Data_Acl()
        { }
        #region Model
        private int _id;
        private int _dataaclid;
        private string _modulesid;
        private string _fieldname;
        private string _operator;
        private string _fieldvalue;
        private string _fieldtext;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DataAclID
        {
            set { _dataaclid = value; }
            get { return _dataaclid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModulesID
        {
            set { _modulesid = value; }
            get { return _modulesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FieldValue
        {
            set { _fieldvalue = value; }
            get { return _fieldvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FieldText
        {
            set { _fieldtext = value; }
            get { return _fieldtext; }
        }
        #endregion Model

    }
}

