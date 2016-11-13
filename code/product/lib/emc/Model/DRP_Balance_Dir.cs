using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Balance_Dir:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Balance_Dir
	{
		public DRP_Balance_Dir()
		{}
		#region Model
		private int _id;
		private string _balno;
		private int? _balid;
		private int? _distype;
		private int? _disid;
		private string _disno;
		private string _disname;
		private string _disname1;
		private DateTime? _baltimestart;
		private DateTime? _baltimeend;
		private decimal? _balprice;
		private int? _balnums;
		private decimal? _balamt;
		private DateTime? _baldate;
		private string _balman;
		private int? _balmanid;
		private int? _paystatus;
		private DateTime? _paydate;
		private string _payman;
		private string _payremark;
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
		public string BalNo
		{
			set{ _balno=value;}
			get{return _balno;}
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
		public int? DisType
		{
			set{ _distype=value;}
			get{return _distype;}
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
		public string DisName
		{
			set{ _disname=value;}
			get{return _disname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisName1
		{
			set{ _disname1=value;}
			get{return _disname1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BalTimeStart
		{
			set{ _baltimestart=value;}
			get{return _baltimestart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BalTimeEnd
		{
			set{ _baltimeend=value;}
			get{return _baltimeend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BalPrice
		{
			set{ _balprice=value;}
			get{return _balprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BalNums
		{
			set{ _balnums=value;}
			get{return _balnums;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BalAmt
		{
			set{ _balamt=value;}
			get{return _balamt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BalDate
		{
			set{ _baldate=value;}
			get{return _baldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BalMan
		{
			set{ _balman=value;}
			get{return _balman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BalManID
		{
			set{ _balmanid=value;}
			get{return _balmanid;}
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
		public DateTime? PayDate
		{
			set{ _paydate=value;}
			get{return _paydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PayMan
		{
			set{ _payman=value;}
			get{return _payman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PayRemark
		{
			set{ _payremark=value;}
			get{return _payremark;}
		}
		#endregion Model

	}
}

