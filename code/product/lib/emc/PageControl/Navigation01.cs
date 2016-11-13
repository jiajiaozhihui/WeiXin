using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;

namespace SfSoft.PageControl
{
    /// <summary>
    /// Navigation01 的摘要说明。
    /// </summary>
    [DefaultProperty(""),
        ToolboxData("<{0}:Navigation01 runat=server></{0}:Navigation01>")]
    public class Navigation01 : System.Web.UI.WebControls.WebControl
    {
        public enum Mode
        {
            Add,
            Modify,
            Delete,
            Search,
            Show
        }
        private string page_Index = "index.aspx";
        private string page_Add = "add.aspx";
        private string page_Delete = "delete.aspx";
        private string page_Modify = "modify.aspx";
        private string page_Search = "search.aspx";
        private string page_Show = "show.aspx";
        private Mode page_Mode = Mode.Add;
        private string table_Name;
        private string para_Str;
        private string key_Str;
        private int page_width = 600;

        [Bindable(true),
            Category("Appearance"),
            DefaultValue("")]

        public int Page_Width
        {
            get { return page_width; }
            set { page_width = value; }
        }
        public string Page_Index
        {
            get { return page_Index; }
            set { page_Index = value; }
        }

        public string Page_Add
        {
            get { return page_Add; }
            set { page_Add = value; }
        }

        public string Page_Delete
        {
            get { return page_Delete; }
            set { page_Delete = value; }
        }

        public string Page_Modify
        {
            get { return page_Modify; }
            set { page_Modify = value; }
        }

        public string Page_Search
        {
            get { return page_Search; }
            set { page_Search = value; }
        }

        public string Page_Show
        {
            get { return page_Show; }
            set { page_Show = value; }
        }

        public Mode Page_Mode
        {
            get { return page_Mode; }
            set { page_Mode = value; }
        }

        public string Table_Name
        {
            get { return table_Name; }
            set { table_Name = value; }
        }

        public string Para_Str
        {
            get { return para_Str; }
            set { para_Str = value; }
        }

        public string Key_Str
        {
            get { return key_Str; }
            set { key_Str = value; }
        }

        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            StringBuilder strTemp = new StringBuilder("");
            strTemp.Append("<table width=\"" + page_width + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">");
            strTemp.Append("<tr>");
            strTemp.Append("<td height=\"22\" width=\"228\">");
            strTemp.Append("<font color=\"#CCCCCC\">≡ ≡</font>");
            strTemp.Append("</td>");
            strTemp.Append("<td height=\"22\">");

            if (Page_Add != "")
            {
                strTemp.Append("<div align=\"right\">");
                if (Page_Mode == Mode.Add)
                {
                    strTemp.Append(" [ <font color=\"#CCCCCC\">添加</font>");
                }
                else
                {
                    strTemp.Append(" [ <a href=\"" + Page_Add + "?" + Para_Str + "\">添加</a>");
                }
                strTemp.Append(" ]");
            }
            if (Page_Delete != "")
            {
                if (Page_Mode == Mode.Add)
                {
                    strTemp.Append(" [ <font color=\"#CCCCCC\">删除</font>");
                }
                else
                {
                    strTemp.Append(" [ <a href=\"" + Page_Delete + "?" + Para_Str + "\" onClick=\"if (!window.confirm('您真的要删除这条记录吗？')){return false;}\">删除</a>");
                }
                strTemp.Append(" ]");
            }
            if (Page_Modify != "")
            {
                if (Page_Mode == Mode.Add || Page_Mode == Mode.Modify)
                {
                    strTemp.Append(" [ <font color=\"#CCCCCC\">修改</font>");
                }
                else
                {
                    strTemp.Append(" [ <a href=\"" + Page_Modify + "?" + Para_Str + "\">修改</a>");
                }
                strTemp.Append(" ]");
            }
            if (Page_Show != "")
            {
                if (Page_Mode == Mode.Add || Page_Mode == Mode.Modify)
                {
                    strTemp.Append(" [ <a href=\"" + Page_Show + "?" + Para_Str + "\">取消</a>");
                }
                else
                {
                    strTemp.Append(" [ <font color=\"#CCCCCC\">取消</font>");
                }
                strTemp.Append(" ]");
            }
            strTemp.Append(" [ <a href=\"" + Page_Index + "\">返回</a> ] </div>");
            strTemp.Append("</td></tr></table>");

            output.Write(strTemp.ToString());
        }
    }
}
