using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Balance_Dir_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Balance_Dir_Detail
	{
		public DRP_Balance_Dir_Detail()
		{}
		#region Model
		private int _id;
		private int? _balid;
		private int? _orderid;
		private int? _orderdetailid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BalID
		{
			set{ _balid=value;}
			get{return _balid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderDetailID
		{
			set{ _orderdetailid=value;}
			get{return _orderdetailid;}
		}
		#endregion Model

	}
}

