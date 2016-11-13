using System;
namespace SfSoft.Model
{
	/// <summary>
	/// DRP_Content_Temp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DRP_Content_Temp
	{
		public DRP_Content_Temp()
		{}
		#region Model
		private int _id;
		private string _temptopic;
		private string _tempno;
		private string _tempcontent;
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
		public string TempTopic
		{
			set{ _temptopic=value;}
			get{return _temptopic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TempNo
		{
			set{ _tempno=value;}
			get{return _tempno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TempContent
		{
			set{ _tempcontent=value;}
			get{return _tempcontent;}
		}
		#endregion Model

	}
}

