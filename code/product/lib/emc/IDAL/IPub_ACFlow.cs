using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_ACFlow ��ժҪ˵����
	/// </summary>
	public interface IPub_ACFlow
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
 
		bool Exists(int ACID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(SfSoft.Model.Pub_ACFlow model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_ACFlow model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ACID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_ACFlow GetModel(int ACID);
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
