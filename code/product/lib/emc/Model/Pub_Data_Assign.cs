using System;
namespace SfSoft.Model
{
    /// <summary>
    /// ʵ����Pub_Data_Assign ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class Pub_Data_Assign
    {
        public Pub_Data_Assign()
        { }
        #region Model
        private int _asid;
        private string _modulesid;
        private int? _dataid;
        private string _assigntype;
        private int? _assignid;
        private string _assignname;
        /// <summary>
        /// 
        /// </summary>
        public int AsID
        {
            set { _asid = value; }
            get { return _asid; }
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
        public int? DataID
        {
            set { _dataid = value; }
            get { return _dataid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AssignType
        {
            set { _assigntype = value; }
            get { return _assigntype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AssignID
        {
            set { _assignid = value; }
            get { return _assignid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AssignName
        {
            set { _assignname = value; }
            get { return _assignname; }
        }
        #endregion Model

    }
}

