using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// �ӿڲ�IEmc_logs ��ժҪ˵����
	/// </summary>
	public interface IEmc_logs
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
		int Add(SfSoft.Model.Emc_logs model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(SfSoft.Model.Emc_logs model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		SfSoft.Model.Emc_logs GetModel(int ID);
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
