using System;
using System.Data;
namespace SfSoft.IDAL
{
	/// <summary>
	/// 接口层IPub_Data_Assign 的摘要说明。
	/// </summary>
	public interface IPub_Data_Assign
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		//int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(SfSoft.Model.Pub_Data_Assign model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(SfSoft.Model.Pub_Data_Assign model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int ID);
        void Delete(int DocID, string ModulesID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		SfSoft.Model.Pub_Data_Assign GetModel(int ID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	}
}
