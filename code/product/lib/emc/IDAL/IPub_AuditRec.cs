using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_AuditRec ��ժҪ˵����
	/// </summary>
	public interface IPub_AuditRec
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		//int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ARID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(SfSoft.Model.Pub_AuditRec model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_AuditRec model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ARID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_AuditRec GetModel(int ARID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
        /// <summary>
         /// ȡ���������е���Ϣ
         /// </summary>
         /// <param name="MID">ģ��ID</param>
         /// <param name="DocID">����ID</param>
         /// <returns></returns>
        SfSoft.Model.Pub_AuditRec GetModel(string MID, string DocID);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
