using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_AuditFlow ��ժҪ˵����
	/// </summary>
	public interface IPub_AuditFlow
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		//int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        /// <summary>
        /// ȡ����󼶱�
        /// </summary>
        int GetMaxClass(string strWhere);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AFID"></param>
        /// <returns></returns>
		bool Exists(int AFID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(SfSoft.Model.Pub_AuditFlow model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_AuditFlow model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int AFID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_AuditFlow GetModel(int AFID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
        SfSoft.Model.Pub_AuditFlow GetModel(string MID, string AuditClass, string FilialeID);
        void UpAuditClass(int AuditClass, string MID, string FilialeID);
        void LwAuditClass(int AuditClass, string MID, string FilialeID);
        /// <summary>
        /// ȡ�ı�����������Ϣ
        /// </summary>
        /// <param name="DocID">����ID</param>
        /// <param name="BoName">����</param>
        /// <returns></returns>
        DataSet GetBoInfo(string DocID, string BoName);

//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
