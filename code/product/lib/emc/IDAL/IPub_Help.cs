using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_Help ��ժҪ˵����
	/// </summary>
	public interface IPub_Help
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(SfSoft.Model.Pub_Help model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_Help model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_Help GetModel(int ID);
        SfSoft.Model.Pub_Help GetModel(string  HelpID);
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
