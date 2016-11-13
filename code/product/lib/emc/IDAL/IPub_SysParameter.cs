using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IPub_SysParameter ��ժҪ˵����
	/// </summary>
	public interface IPub_SysParameter
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
		int Add(SfSoft.Model.Pub_SysParameter model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Pub_SysParameter model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Pub_SysParameter GetModel(int ID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);

        SfSoft.Model.Pub_SysParameter GetModel(string  FilialeID);
        void Delete(string  FilialeID);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
