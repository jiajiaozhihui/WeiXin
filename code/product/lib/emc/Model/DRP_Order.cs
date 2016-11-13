using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Order
	{
		public DRP_Order()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private int? _disid;
		private string _disno;
		private string _contact;
		private string _phone;
		private string _addr;
		private decimal? _totalamt;
		private int? _totalnum;
		private DateTime? _orderdate;
		private int? _orderstatus;
		private int? _payment;
		private int? _balancestatus;
		private string _remark;
		private DateTime? _mtime;
		private string _modifier;
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
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
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
		public string DisNo
		{
			set{ _disno=value;}
			get{return _disno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalAmt
		{
			set{ _totalamt=value;}
			get{return _totalamt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TotalNum
		{
			set{ _totalnum=value;}
			get{return _totalnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
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
		public int? BalanceStatus
		{
			set{ _balancestatus=value;}
			get{return _balancestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? mtime
		{
			set{ _mtime=value;}
			get{return _mtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string modifier
		{
			set{ _modifier=value;}
			get{return _modifier;}
		}
		#endregion Model

	}
}

