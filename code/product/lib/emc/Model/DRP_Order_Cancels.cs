using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Order_Cancels:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Order_Cancels
	{
		public DRP_Order_Cancels()
		{}
		#region Model
		private int _id;
		private int? _orderid;
		private int? _ostatus;
		private string _cancelreason;
		private int? _cancelstatus;
		private string _disname;
		private int? _disid;
		private DateTime? _canceldate;
		private string _checkman;
		private int? _checkmanid;
		private DateTime? _checkdate;
		private string _checkremark;
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
		public int? OStatus
		{
			set{ _ostatus=value;}
			get{return _ostatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CancelReason
		{
			set{ _cancelreason=value;}
			get{return _cancelreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CancelStatus
		{
			set{ _cancelstatus=value;}
			get{return _cancelstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisName
		{
			set{ _disname=value;}
			get{return _disname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DisID
		{
			set{ _disid=value;}
			get{return _disid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CancelDate
		{
			set{ _canceldate=value;}
			get{return _canceldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckMan
		{
			set{ _checkman=value;}
			get{return _checkman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckManID
		{
			set{ _checkmanid=value;}
			get{return _checkmanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckRemark
		{
			set{ _checkremark=value;}
			get{return _checkremark;}
		}
		#endregion Model

	}
}

