using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_Data_Assign ��ժҪ˵����
	/// </summary>
	public interface IPub_Data_Assign
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
		int Add(SfSoft.Model.Pub_Data_Assign model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_Data_Assign model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
        void Delete(int DocID, string ModulesID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_Data_Assign GetModel(int ID);
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
