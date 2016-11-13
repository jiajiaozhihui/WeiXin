using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_Data_Acl ��ժҪ˵����
	/// </summary>
	public interface IPub_Data_Acl
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		//int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(SfSoft.Model.Pub_Data_Acl model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_Data_Acl model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// ɾ����������
		/// </summary>
		void Deletes(int DataAclID);
 
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_Data_Acl GetModel(int ID);

        /// <summary>
        /// ����ȫ������Ȩ�޲���
        /// </summary>
        void AddAllDept(string sFilialeID,string sActId, string sModulesID);
        /// <summary>
        /// ɾ��ȫ������Ȩ�޲���
        /// </summary>
         void DelAllDept(string sFilialeID,string sActId, string sModulesID);

		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
