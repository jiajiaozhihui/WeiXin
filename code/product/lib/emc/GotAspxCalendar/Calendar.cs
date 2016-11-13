using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Resources;


namespace GotAspx.WebControls.Calendar
{
	/// <summary>
	/// Calendar 的摘要说明。
	/// </summary>
    [Designer("GotAspx.WebControls.Calendar.CalendarTextBoxDesigner, GotAspxCalendar"), DefaultProperty("Text"),
      ToolboxData("<{0}:CalendarTextBox runat=server></{0}:CalendarTextBox>")]
	public class CalendarTextBox : System.Web.UI.WebControls.TextBox
	{
        public CalendarTextBox()
		{
			this.m_Clicked = false;
			this.m_MinYear = "";
			this.m_MaxYear = "";
			this.m_DateFormat = "";
			this.m_MainColor = "";
			this.m_Shadow = "";
			this.m_Alpha = "";
			this.m_Expand = false;
		}


		protected override void OnPreRender(EventArgs e)
		{
            this.Attributes.Add("onFocus", this.ClientID + "_Calendar" + ".Show(this)");
            this.Attributes.Add("onBlur", this.ClientID + "_Calendar" + ".Hidden()");
            //this.Attributes.Add("readonly", "false");

            string strScriptBlock = "";
			if(!Page.ClientScript.IsClientScriptIncludeRegistered("CUCalendarScript"))
			{
                string scriptFile = this.Page.ClientScript.GetWebResourceUrl(typeof(CalendarTextBox), "GotAspx.WebControls.Calendar.Resources.Calendar.js");
                //this.Page.ClientScript.RegisterClientScriptInclude("CUCalendarScript", scriptFile);
                ClientScriptProxy.Current.RegisterClientScriptInclude(this,this.GetType(),"CUCalendarScript", scriptFile);
			}

			strScriptBlock = String.Format(@"
try{{var {0} = new CUCalendar(""{0}"");
{0}.DateFormat = ""{1}"";
{0}.MinYear = ""{2}"";
{0}.MaxYear = ""{3}"";
{0}.MainColor = ""{4}"";
{0}.Shadow = ""{5}"";
{0}.Alpha = ""{6}"";
}}catch(e){{status = ""Error to init CUCalendar"";}}
"
                , this.ClientID + "_Calendar"
				,this.DateFormat
				,this.MinYear
				,this.MaxYear
				,this.MainColor
				,this.Shadow
				,this.Alpha
				);

            //Page.ClientScript.RegisterStartupScript(this.GetType(),"Cu" + this.ClientID, strScriptBlock);
            ClientScriptProxy.Current.RegisterStartupScript(this,this.GetType(), "Cu" + this.ClientID, strScriptBlock,true);

		}
        
		[Bindable(true), DefaultValue("100"), Category("External"), Browsable(true), Description("透明度")]
		public string Alpha
		{
			get
			{
				return ((this.m_Alpha == "") ? "100" : this.m_Alpha);
			}
			set
			{
				this.m_Alpha = value;
			}
		}

		[Description("是否需要点击显示控件"), Category("External"), Bindable(true), DefaultValue(false)]
		public bool Clicked
		{
			get
			{
				return this.m_Clicked;
			}
			set
			{
				this.m_Clicked = value;
			}
		}

		[Category("External"), Bindable(true), Browsable(true), Description("日期格式化字符串"), DefaultValue("<yyyy>-<mm>-<dd>")]
		public string DateFormat
		{
			get
			{
				return ((this.m_DateFormat == "") ? "<yyyy>-<mm>-<dd>" : this.m_DateFormat);
			}
			set
			{
				this.m_DateFormat = value;
			}
		}

		[Browsable(true), Description("展示"), DefaultValue(false), Bindable(true), Category("External")]
		public bool Expand
		{
			get
			{
				return this.m_Expand;
			}
			set
			{
				this.m_Expand = value;
			}
		}

		[DefaultValue("#FF0000"), Browsable(true), Description("主要区域颜色"), Bindable(true), Category("External")]
		public string MainColor
		{
			get
			{
				return ((this.m_MainColor == "") ? "#FF0000" : this.m_MainColor);
			}
			set
			{
				this.m_MainColor = value;
			}
		}

		[Category("External"), Description("最大年"), DefaultValue("2100"), Bindable(true), Browsable(true)]
		public string MaxYear
		{
			get
			{
				return ((this.m_MaxYear == "") ? "2100" : this.m_MaxYear);
			}
			set
			{
				this.m_MaxYear = value;
			}
		}

		[Description("最小年"), DefaultValue("1900"), Category("External"), Browsable(true), Bindable(true)]
		public string MinYear
		{
			get
			{
				return ((this.m_MinYear == "") ? "1900" : this.m_MinYear);
			}
			set
			{
				this.m_MinYear = value;
			}
		}

		[Category("External"), Description("阴影颜色"), DefaultValue("#666666"), Bindable(true), Browsable(true)]
		public string Shadow
		{
			get
			{
				return ((this.m_Shadow == "") ? "#666666" : this.m_Shadow);
			}
			set
			{
				this.m_Shadow = value;
			}
		}


		// Fields
		private string m_Alpha;
		private bool m_Clicked;
		private string m_DateFormat;
		private bool m_Expand;
		private string m_MainColor;
		private string m_MaxYear;
		private string m_MinYear;
		private string m_Shadow;
    }
}
