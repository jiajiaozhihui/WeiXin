using System;
namespace SfSoft.Model
{
	/// <summary>
	/// ʵ����Pub_Data_doc ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class Pub_Data_doc
	{
		public Pub_Data_doc()
		{}
		#region Model
		private int _dataaclid;
		private string _modulesid;
		private string _dataacldesc;
		private string _filialeid;
		/// <summary>
		/// 
		/// </summary>
		public int DataAclID
		{
			set{ _dataaclid=value;}
			get{return _dataaclid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModulesID
		{
			set{ _modulesid=value;}
			get{return _modulesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataAclDesc
		{
			set{ _dataacldesc=value;}
			get{return _dataacldesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilialeID
		{
			set{ _filialeid=value;}
			get{return _filialeid;}
		}
		#endregion Model

	}
}

