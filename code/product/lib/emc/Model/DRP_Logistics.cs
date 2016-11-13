using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Logistics:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Logistics
	{
		public DRP_Logistics()
		{}
		#region Model
		private int _id;
		private int? _orderid;
		private string _logistics;
		private string _logisticsno;
		private int? _sendstatus;
		private decimal? _lexpense;
		private decimal? _lcharge;
		private DateTime? _senddate;
		private string _sendman;
		private string _remark;
		private string _creator;
		private int? _creatorid;
		private DateTime? _ctime;
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
		public string Logistics
		{
			set{ _logistics=value;}
			get{return _logistics;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogisticsNo
		{
			set{ _logisticsno=value;}
			get{return _logisticsno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SendStatus
		{
			set{ _sendstatus=value;}
			get{return _sendstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LExpense
		{
			set{ _lexpense=value;}
			get{return _lexpense;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LCharge
		{
			set{ _lcharge=value;}
			get{return _lcharge;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SendDate
		{
			set{ _senddate=value;}
			get{return _senddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendMan
		{
			set{ _sendman=value;}
			get{return _sendman;}
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
		public DateTime? ctime
		{
			set{ _ctime=value;}
			get{return _ctime;}
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

