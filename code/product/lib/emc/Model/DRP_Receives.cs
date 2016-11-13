using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Receives:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Receives
	{
		public DRP_Receives()
		{}
		#region Model
		private int _id;
		private int? _orderid;
		private int? _paystatus;
		private int? _payment;
		private string _payremark;
		private DateTime? _paydate;
		private string _receiveman;
		private string _creator;
		private int? _creatorid;
		private string _modifier;
		private DateTime? _mtime;
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
		public int? OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PayStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Payment
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PayRemark
		{
			set{ _payremark=value;}
			get{return _payremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PayDate
		{
			set{ _paydate=value;}
			get{return _paydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiveMan
		{
			set{ _receiveman=value;}
			get{return _receiveman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatorID
		{
			set{ _creatorid=value;}
			get{return _creatorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string modifier
		{
			set{ _modifier=value;}
			get{return _modifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? mtime
		{
			set{ _mtime=value;}
			get{return _mtime;}
		}
		#endregion Model

	}
}

