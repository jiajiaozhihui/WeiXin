using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;

namespace SfSoft.PageControl
{
    /// <summary>
    /// Page02 的摘要说明。
    /// </summary>
    [DefaultProperty(""),
    ToolboxData("<{0}:Page03 runat=server></{0}:Page03>")]
    public class Page03 : System.Web.UI.WebControls.WebControl
    {
        private int record_Count;
        private int page_Count;
        private int page_Size = 10;
        private int page_Current = 1;
        private string page_Index = "index.aspx";
        private int pageStep = 6;
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

        public int PageStep
        {
            get { return pageStep; }
            set { pageStep = value; }
        }

        public string Page_Index
        {
            get { return page_Index; }
            set { page_Index = value; }
        }

        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            StringBuilder strTemp = new StringBuilder("");
            strTemp.Append("<table width=\"" + page_width + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" height=\"22\">\n");
            strTemp.Append("\t<tr>\n");
            strTemp.Append("\t\t<td width=\"255\">");
            strTemp.Append("○ 页次：<font color=\"#e78a29\">" + Page_Current + "</font>/" + Page_Count + "，每页：<font color='#e78a29'>" + Page_Size + "</font>条");
            strTemp.Append("，共计：<font color='#e78a29'>" + Record_Count + "</font>条");
            strTemp.Append("</td>\n");
            strTemp.Append("\t\t<td width=\"*\">\n");
            strTemp.Append("\t\t<div align=\"right\">页数：\n");
            //
            int StartPage = 1;
            if (Page_Current > PageStep)
            {
                StartPage = Page_Current - PageStep;
            }
            else
            {
                StartPage = 1;
            }
            int EndPage = StartPage + 2 * PageStep;
            if (StartPage + 2 * PageStep > Page_Count)
            {
                if (2 * PageStep + 1 > Page_Count)
                    StartPage = 1;
                else
                    StartPage = Page_Count - 2 * PageStep;
                EndPage = Page_Count;
            }
            for (int i = StartPage; i <= EndPage; i++)
            {
                if (Page_Current != i)
                {
                    strTemp.Append("\t\t<a href=" + Page_Index + "?page=" + i + ">");
                    strTemp.Append("[<b>" + i + "</b>]</a>");
                }
                else
                {
                    strTemp.Append("\t\t[<font color=#e78a29><b>" + i + "</b></font>]");
                }
            }
            //
            strTemp.Append("\t\t</div>\n");
            strTemp.Append("\t\t</td>\n");
            strTemp.Append("\t</tr>\n");
            strTemp.Append("</table>");
            output.Write(strTemp.ToString());
        }
    }
}
