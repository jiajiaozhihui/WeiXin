using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.Design;

namespace GotAspx.WebControls.Calendar
{
	/// <summary>
    /// CalendarTextBoxDesigner ��ժҪ˵����
	/// </summary>
    public class CalendarTextBoxDesigner : ControlDesigner
    {
        public CalendarTextBoxDesigner()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        public override string GetDesignTimeHtml()
        {
            CalendarTextBox calendar = (CalendarTextBox)base.Component;

            return String.Format("<input style=\"width:{0};\" value=\"{1}\">", calendar.Width, calendar.Text);
        }

        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            string text = "Error:" + e.Message;
            return base.CreatePlaceHolderDesignTimeHtml(text);
        }

    }
}
