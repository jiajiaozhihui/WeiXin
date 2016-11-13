using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;

namespace SfSoft.PageControl
{
    /// <summary>
    /// Page01 的摘要说明。
    /// </summary>
    [DefaultProperty(""),
        ToolboxData("<{0}:Page01 runat=server></{0}:Page01>")]
    public class Page01 : System.Web.UI.WebControls.WebControl
    {
        private int record_Count;
        private int page_Count;
        private int page_Size = 10;
        private int page_Current = 1;
        private string page_Index = "index.aspx";
        private string page_Add = "add.aspx";
        private string page_Search = "search.aspx";
        private string page_Makesql = "makesql.aspx";
        private int page_width = 700;

        [Bindable(true),
            Category("Appearance"),
            DefaultValue("")]

        public int Page_Width
        {
            get { return page_width; }
            set { page_width = value; }
        }
        public int Record_Count
        {
            get { return record_Count; }
            set { record_Count = value; }
        }

        public int Page_Count
        {
            get { return page_Count; }
            set { page_Count = value; }
        }

        public int Page_Size
        {
            get { return page_Size; }
            set { page_Size = value; }
        }

        public int Page_Current
        {
            get { return page_Current; }
            set { page_Current = value; }
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

        public string Page_Search
        {
            get { return page_Search; }
            set { page_Search = value; }
        }

        public string Page_Makesql
        {
            get { return page_Makesql; }
            set { page_Makesql = value; }
        }

        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            StringBuilder strTemp = new StringBuilder("");
            strTemp.Append("<table width=\"" + page_width + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\" align=\"center\" height=\"22\">\n");
            strTemp.Append("\t<tr>\n");
            strTemp.Append("\t\t<td width=\"28%\">");
            strTemp.Append("○ 共" + Record_Count + "条，共" + Page_Count + "页，第<font color=\"#e78a29\">" + Page_Current + "</font>页</td>\n");
            strTemp.Append("\t\t<td width=\"72%\">");
            strTemp.Append("\t\t<div align=\"right\">\n");
            //
            if (Page_Makesql != "")
            {
                strTemp.Append("\t\t\t[ <a href=" + Page_Makesql + ">全部</a> ]&nbsp;\n");
            }
            if (Page_Add != "")
            {
                strTemp.Append("\t\t\t[ <a href=" + Page_Add + ">添加</a> ]&nbsp;\n");
            }
            if (Page_Search != "")
            {
                strTemp.Append("\t\t\t[ <a href=" + Page_Search + ">搜索</a> ]&nbsp;\n");
            }
            strTemp.Append("\t\t\t[ <a href=" + Page_Index + ">刷新</a> ]&nbsp;&nbsp;[");
            if (Page_Current > 1)
            {
                strTemp.Append("\t\t\t<a href=" + Page_Index + "?page=1>首页</a>\n");
            }
            else
            {
                strTemp.Append("\t\t\t<font color=#cccccc>首页</font> \n");
            }
            strTemp.Append("]&nbsp;[");
            if (Page_Current - 1 > 0)
            {
                strTemp.Append("\t\t\t<a href=" + Page_Index + "?page=" + (Page_Current - 1) + ">上页</a>\n");
            }
            else
            {
                strTemp.Append("\t\t\t<font color=#cccccc>上页</font> \n");
            }
            strTemp.Append("]&nbsp;[");
            if (Page_Current + 1 <= Page_Count)
            {
                strTemp.Append("\t\t\t<a href=" + Page_Index + "?page=" + (Page_Current + 1) + ">下页</a> \n");
            }
            else
            {
                strTemp.Append("\t\t\t<font color=#cccccc>下页</font> \n");
            }
            strTemp.Append("]&nbsp;[");
            if (Page_Current < Page_Count)
            {
                strTemp.Append("\t\t\t<a href=" + Page_Index + "?page=" + Page_Count + ">尾页</a>\n");
            }
            else
            {
                strTemp.Append("\t\t\t<font color=#cccccc>尾页</font>\n");
            }
            strTemp.Append("]");
            //
            strTemp.Append("\t\t</div>\n");
            strTemp.Append("\t\t</td>\n");
            strTemp.Append("\t</tr>");
            strTemp.Append("</table>\n");
            output.Write(strTemp.ToString());
        }
    }
}
