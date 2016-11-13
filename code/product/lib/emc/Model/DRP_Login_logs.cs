using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Login_logs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Login_logs
	{
		public DRP_Login_logs()
		{}
		#region Model
		private int _id;
		private string _logname;
		private DateTime? _logtime;
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
		public string LogName
		{
			set{ _logname=value;}
			get{return _logname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LogTime
		{
			set{ _logtime=value;}
			get{return _logtime;}
		}
		#endregion Model

	}
}

