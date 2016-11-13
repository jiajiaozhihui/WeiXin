using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Invite_My_Arts:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Invite_My_Arts
	{
		public DRP_Invite_My_Arts()
		{}
		#region Model
		private int _id;
		private int? _inviteid;
		private int? _disid;
		private string _topic;
		private string _keyword;
		private int? _arttype;
		private int? _sendstatus;
		private string _artcontent;
		private DateTime? _pubdate;
		private string _creator;
		private int? _issales;
		private int? _iscontact;
		private int? _isjoin;
		private int? _turnnum;
		private int? _clicknum;
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
		public int? InviteID
		{
			set{ _inviteid=value;}
			get{return _inviteid;}
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
		public string Topic
		{
			set{ _topic=value;}
			get{return _topic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyWord
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArtType
		{
			set{ _arttype=value;}
			get{return _arttype;}
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
		public string ArtContent
		{
			set{ _artcontent=value;}
			get{return _artcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PubDate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
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
		public int? IsSales
		{
			set{ _issales=value;}
			get{return _issales;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsContact
		{
			set{ _iscontact=value;}
			get{return _iscontact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsJoin
		{
			set{ _isjoin=value;}
			get{return _isjoin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TurnNum
		{
			set{ _turnnum=value;}
			get{return _turnnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClickNum
		{
			set{ _clicknum=value;}
			get{return _clicknum;}
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

