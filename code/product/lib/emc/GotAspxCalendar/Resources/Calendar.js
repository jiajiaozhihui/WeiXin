
//======================================================================
//         CUDIGITAL CUCalendar Script 
//         Version 1.0 Code by EDISON1024.(mciro1024@163.com)
//         Copyright(C)2004-2008 CUDIGITAL Co,ltd. All Rights Reserved.
//=======================================================================

if (typeof (cucalendar_state) != "object") {
    var cucalendar_state = new Object();
   
}
 

function CUCalendar(calendarID)
{
	cucalendar_state[calendarID] = this;
	this.Id = calendarID;
	this.MinYear = 1900; 
	this.MaxYear = 2100; 
	this.Width = 170; 
	this.Height = 200; 
	this.DateFormat = "<yyyy>-<mm>-<dd>";
	this.Source = null;
	this.Target = null;
	
	this.UnselectBgColor = ""; 
	this.MainColor = "#FF0000";
	this.Shadow = "#666666";
	this.Alpha = "100";
	this.SelectedColor = "#FFFFFF"; 
	this.DayBdWidth = "1"; 
	this.DayBdColor = this.UnselectBgColor; 
	this.TodayBdColor = "#000000"; 
	this.InvalidColor = "#808080";
	this.ValidColor = "#000099";
	this.WeekendBgColor = this.UnselectBgColor;
	this.WeekendColor = "#006600";

	this.YearListStyle = "font-size:12px; font-family:宋体;"; 
	this.MonthListStyle = "font-size:12px; font-family:宋体;"; 
	this.TitleStyle = "cursor:default; height:24px; color:#000000; background-color:" + this.UnselectBgColor + "; font-size:12px;  text-align:center; vertical-align:bottom;";  
	this.FooterOverStyle = "height:20px; cursor:hand; color:#000000; background-color:#999999; font-size:12px; font-family:Verdana; text-align:center; vertical-align:middle;"; 
	this.FooterStyle = "height:20px; cursor:hand; color:#FFFFFF; background-color:#333333; font-size:12px; font-family:Verdana; text-align:center; vertical-align:middle;";
	
	this.TodayTitle = "今天：";
	
	this.LineBgStyle = "height:6px; background-color:" + this.UnselectBgColor + "; text-align:center; vertical-align:middle;";
	this.LineStyle = "width:94%; height:1px; background-color:#000000;"; 
	this.DayStyle = "cursor:hand; font-size:12px; font-family:Verdana; text-align:center; vertical-align:middle;"; 
	this.OverDayStyle = "this.style.textDecoration='underline';"; 
	this.OutDayStyle = "this.style.textDecoration='none';"; 
	
	this.MonthName = new Array("1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月");
	this.WeekName = new Array("日", "一", "二", "三", "四", "五", "六"); 
	
	this.boolCalendarPadExist = false;
	
	this.CreateCalendarPad = function()
	{
		this.boolCalendarPadExist = true;
		var theValue = this.Source.value; 
		var theCurrentDate = new Date(this.GetTextDate(theValue)); 
		if (isNaN(theCurrentDate))
		{ 
			theCurrentDate = new Date(); 
		}
		var CalendarPadHTML = "";
		CalendarPadHTML += " <div id=\"" + this.Id + "_CalendarPad\" style=\"Z-INDEX: 99999; POSITION: absolute;top:-100;left:-100;"; 
		if(this.Shadow != "")
		{
			CalendarPadHTML += "FILTER:progid:DXImageTransform.Microsoft.Shadow(direction=135,color=" + this.Shadow + ",strength=3);";
		}
		if(this.Alpha != "100" && this.Alpha != "")
		{
			CalendarPadHTML += "FILTER: progid:DXImageTransform.Microsoft.Alpha( style=0,opacity=" + this.Alpha + ");";
		}
		CalendarPadHTML += " \">";
		CalendarPadHTML += " <iframe frameborder=0 width=\"" + (this.Width+2).toString() + "\" height=\"" + (this.Height+2).toString() + "\"></iframe>";
		CalendarPadHTML += " <div style=\"Z-INDEX:202;position:absolute;top:0;left:0;\"><table width=\"" + this.Width.toString() + "\" height=\"" + this.Height.toString() + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr><td align=\"center\" style=\"font-size:24px;font-family:Arial Black;color:#E6E6E6\">CUDIGITAL</td></tr></table></div>";
		CalendarPadHTML += " <div style=\"Z-INDEX:203;position:absolute;top:0;left:0;border:1px solid #000000;\" onclick=\"CUCalendar_getCalendarById('" + this.Id + "').Source.select()\">";
		CalendarPadHTML += " <table width=\"" + this.Width.toString() + "\" height=\"" + this.Height.toString() + "\" cellpadding=\"0\" cellspacing=\"0\">"; 
		CalendarPadHTML += " <tr>"; 
		CalendarPadHTML += " <td align=\"center\" valign=\"top\">"; 
		CalendarPadHTML += " <table width=\"100%\" height=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">"; 
		CalendarPadHTML += " <tr align=\"center\" style=\"height:30px; background-color:" + this.MainColor + ";\">"; 
		CalendarPadHTML += " <td align=\"center\">"; 
		CalendarPadHTML += " <table border=\"0\" cellspacing=\"0\" cellpadding=\"3\">"; 
		CalendarPadHTML += " <tr>"; 
		CalendarPadHTML += " <td align=\"center\">"; 
		CalendarPadHTML += " <input type=\"button\" tabIndex=\"-1\" style=\"font-family:Marlett; CURSOR:hand; font-size:12px;width:14px;height:18px;border:1px solid #EEEEEE;color:#EEEEEE;background-color:" + this.MainColor + ";\" id=\"" + this.Id + "_goPreviousMonth\" value=\"3\" onClick=\"CUCalendar_getCalendarById('" + this.Id + "').UpdateCalendarGrid(this)\" onmouseover=\"this.style.cssText='border:1px solid #FFFFFF;color:#FFFFFF;font-family:Marlett; CURSOR:hand; font-size:12px;width:14px;height:18px;background-color:" + this.MainColor + ";'\" onmouseout=\"this.style.cssText='font-family:Marlett; CURSOR:hand; font-size:12px;width:14px;height:18px;border:1px solid #EEEEEE;color:#EEEEEE;background-color:" + this.MainColor + ";'\">"; 
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " <td align=\"center\">"; 
		CalendarPadHTML += " <select id=\"" + this.Id + "_YearList\">"; 
		CalendarPadHTML += " </select>"; 
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " <td align=\"center\">"; 
		CalendarPadHTML += " <select id=\"" + this.Id + "_MonthList\">"; 
		CalendarPadHTML += " </select>"; 
		CalendarPadHTML += " <input type=\"hidden\" id=\"" + this.Id + "_DayList\" value=\"1\">"; 
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " <td align=\"center\">"; 
		CalendarPadHTML += " <input type=\"button\" tabIndex=\"-1\" style=\"font-family:Marlett; CURSOR:hand; font-size:12px;width:14px;height:18px;border:1px solid #EEEEEE;color:#EEEEEE;background-color:" + this.MainColor + ";\" id=\"" + this.Id + "_goNextMonth\" value=\"4\" onClick=\"CUCalendar_getCalendarById('" + this.Id + "').UpdateCalendarGrid(this)\" onmouseover=\"this.style.cssText='border:1px solid #FFFFFF;color:#FFFFFF;font-family:Marlett; CURSOR:hand; font-size:12px;width:14px;height:18px;background-color:" + this.MainColor + ";'\" onmouseout=\"this.style.cssText='font-family:Marlett; CURSOR:hand; font-size:12px;width:14px;height:18px;border:1px solid #EEEEEE;color:#EEEEEE;background-color:" + this.MainColor + ";'\">";
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " </tr>"; 
		CalendarPadHTML += " </table>";
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " </tr>"; 
		CalendarPadHTML += " <tr>"; 
		CalendarPadHTML += " <td align=\"center\">"; 
		CalendarPadHTML += " <div id=\"" + this.Id + "_CalendarGrid\"></div>"; 
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " </tr>"; 
		CalendarPadHTML += " </table>"; 
		CalendarPadHTML += " </td>"; 
		CalendarPadHTML += " </tr>"; 
		CalendarPadHTML += " </table>"; 
		CalendarPadHTML += "</div>";
		CalendarPadHTML += "</div>"; 
		document.body.insertAdjacentHTML("beforeEnd", CalendarPadHTML);
		this.CreateYearList(this.MinYear, this.MaxYear); 
		this.CreateMonthList();
		theCalendarPadObject = document.getElementById(this.Id + "_CalendarPad"); 
		theCalendarPadObject.style.position = "absolute"; 
		theCalendarPadObject.style.posLeft = this.GetCalendarPadLeft(this.Source); 
		theCalendarPadObject.style.posTop = this.GetCalendarPadTop(this.Source); 
		this.CreateCalendarGrid(theCurrentDate.getFullYear(), theCurrentDate.getMonth(), theCurrentDate.getDate()); 
	} 
	
	//创建年下拉菜单
	this.CreateYearList = function(MinYear, MaxYear)
	{
		var theYearObject = document.getElementById(this.Id + "_YearList"); 
		if (theYearObject == null)
		{ 
			return; 
		} 
		var theYear = 0; 
		var theYearHTML = "<select id=\"" + this.Id + "_YearList\"  style=\"" + this.YearListStyle + "\"  tabIndex=\"-1\" onChange=\"CUCalendar_getCalendarById('" + this.Id + "').UpdateCalendarGrid(this)\">"; 
		for (theYear = MinYear; theYear <= MaxYear; theYear++)
		{ 
			theYearHTML += "<option value=\"" + theYear.toString() + "\">" + theYear.toString() + "年</option>"; 
		} 
		theYearHTML += "</select>"; 
		theYearObject.outerHTML = theYearHTML; 
	} 

	//创建月下拉菜单
	this.CreateMonthList = function( )
	{
		var theMonthObject = document.getElementById(this.Id + "_MonthList"); 
		if (theMonthObject == null)
		{ 
			return; 
		} 
		var theMonth = 0; 
		var theMonthHTML = "<select id=\"" + this.Id + "_MonthList\" tabIndex=\"-1\" style=\"" + this.MonthListStyle + "\"  onChange=\"CUCalendar_getCalendarById('" + this.Id + "').UpdateCalendarGrid(this)\">"; 
		for (theMonth = 0; theMonth < 12; theMonth++)
		{ 
			theMonthHTML += "<option value=\"" + theMonth.toString() + "\">" + this.MonthName[theMonth] + "</option>"; 
		} 
		theMonthHTML +="</select>"; 
		theMonthObject.outerHTML = theMonthHTML; 
	} 
	
	this.CreateCalendarGrid = function(theYear, theMonth, theDay)
	{ 
		var theTextObject = this.Source; 
		if (theTextObject == null)
		{ 
			return; 
		}
		var theYearObject = document.getElementById(this.Id + "_YearList"); 
		var theMonthObject = document.getElementById(this.Id + "_MonthList"); 
		var tmpYear = theYear; 
		var tmpMonth = theMonth; 
		var tmpDay = 1; 
		if (tmpMonth < 0)
		{ 
			tmpYear--; 
			tmpMonth = 11; 
		} 
		if (tmpMonth > 11)
		{ 
			tmpYear++; 
			tmpMonth = 0; 
		} 
		if (tmpYear < this.MinYear)
		{ 
			tmpYear = this.MinYear; 
		} 
		if (tmpYear > this.MaxYear)
		{ 
			tmpYear = this.MaxYear; 
		} 
		if (theDay < 1)
		{ 
			tmpDay = 1; 
		}
		else
		{ 
			tmpDay = this.GetMonthDays(tmpYear, tmpMonth); 
			if (theDay < tmpDay)
			{ 
				tmpDay = theDay; 
			} 
		} 
		theYearObject.value = tmpYear; 
		theMonthObject.value = tmpMonth; 
		this.setDayList(tmpYear, tmpMonth, tmpDay);  
		theTextObject.value = this.SetDateFormat(tmpYear, tmpMonth, tmpDay); 
		theTextObject.select(); 
	} 
	
	/****** setDayList Start ******/
	this.setDayList = function(theYear, theMonth, theDay)
	{ 
		var theDayObject = document.getElementById(this.Id + "_DayList"); 
		if (theDayObject == null)
		{ 
			return; 
		} 
		theDayObject.value = theDay.toString(); 
		var theFirstDay = new Date(theYear, theMonth, 1); 
		var theCurrentDate = new Date(); 
		var theWeek = theFirstDay.getDay(); 
		if (theWeek == 0)
		{ 
			theWeek = 7; 
		} 
		var theLeftDay = 0; 
		if (theMonth == 0)
		{ 
			theLeftDay = 31; 
		}
		else
		{ 
			theLeftDay = this.GetMonthDays(theYear, theMonth - 1); 
		} 
		var theRightDay = this.GetMonthDays(theYear, theMonth); 
		var theCurrentDay = theLeftDay - theWeek + 1; 
		var offsetMonth = -1; 
		var theColor = this.InvalidColor; 
		var theBgColor = this.UnselectBgColor; 
		var theBdColor = theBgColor; 
		var WeekId = 0 
		var DayId = 0; 
		var theStyle = ""; 
		var theDayHTML = "<table width=\"100%\" height=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\">"; 
		theDayHTML += " <tr style=\"cursor:default; height:24px; color:#000000; font-size:12px;  text-align:center; vertical-align:bottom;\">"; 
		for (DayId = 0; DayId < 7; DayId++)
		{ 
			theDayHTML += " <td>" + this.WeekName[DayId] + "</td>"; 
		} 
		theDayHTML += " </tr>"; 
		theDayHTML += " <tr>"; 
		theDayHTML += " <td colspan=\"7\" style=\"" + this.LineBgStyle + "\">"; 
		theDayHTML += " <table style=\"" + this.LineStyle + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr><td></td></tr></table>"; 
		theDayHTML += " </td>";
		theDayHTML += " </td>"; 
		theDayHTML += " </tr>"; 
		for (WeekId = 0; WeekId < 6; WeekId++)
		{ 
			theDayHTML += " <tr  style=\"" + this.DayStyle + "\">"; 
			for (DayId = 0; DayId < 7; DayId++)
			{ 
				if ((theCurrentDay > theLeftDay) && (WeekId < 3))
				{ 
					offsetMonth++; 
					theCurrentDay = 1; 
				} 
				if ((theCurrentDay > theRightDay) && (WeekId > 3))
				{ 
					offsetMonth++; 
					theCurrentDay = 1; 
				} 
				switch (offsetMonth)
				{ 
					case -1: 
					theColor = this.InvalidColor; 
					break; 
					case 1: 
					theColor = this.InvalidColor; 
					break; 
					case 0: 
					if ((DayId==0)||(DayId==6))
					{ 
						theColor = this.WeekendColor; 
					}
					else
					{ 
						theColor = this.ValidColor; 
					} 
					break; 
				} 
				if ((DayId==0)||(DayId==6))
				{ 
					theBgColor = this.WeekendBgColor; 
				}
				else
				{ 
					theBgColor = this.UnselectBgColor; 
				} 
				theBdColor = this.DayBdColor; 
				if ((theCurrentDay == theDay) && (offsetMonth == 0))
				{ 
					theColor = this.SelectedColor; 
					theBgColor = this.MainColor; 
					theBdColor = theBgColor; 
				} 
				if ((theYear == theCurrentDate.getFullYear()) && (theMonth == theCurrentDate.getMonth()) && (theCurrentDay == theCurrentDate.getDate()) && (offsetMonth == 0))
				{ 
					theBdColor = this.TodayBdColor; 
				} 
				theStyle = "border:" + this.DayBdWidth + "px solid " + theBdColor + "; color:" + theColor + "; background-color:" + theBgColor + ";"; 
				theDayHTML += " <td style=\"" + theStyle + "\" onMouseOver=\"" + this.OverDayStyle + "\" onMouseOut=\"" + this.OutDayStyle + "\" onMouseDown=\"CUCalendar_getCalendarById('" + this.Id + "').CreateCalendarGrid(" + theYear.toString() + ", " + (theMonth + offsetMonth).toString() + ", " + theCurrentDay.toString() + ")\">"; 
				theDayHTML += theCurrentDay.toString(); 
				theDayHTML += " </td>"; 
				theCurrentDay++; 
			} 
			theDayHTML += " </tr>"; 
		}
		
		theDayHTML += " <tr>"; 
		theDayHTML += " <td colspan=\"7\" style=\"" + this.FooterStyle + "\" onmouseover=\"this.style.cssText='" + this.FooterOverStyle + "'\" onmouseout=\"this.style.cssText='" + this.FooterStyle + "'\" onMouseDown=\"CUCalendar_getCalendarById('" + this.Id + "').CreateCalendarGrid(" + theCurrentDate.getFullYear().toString() + ", " + theCurrentDate.getMonth().toString() + ", " + theCurrentDate.getDate().toString() + ");\" >" + this.TodayTitle + " " + this.SetDateFormat(theCurrentDate.getFullYear(), theCurrentDate.getMonth(), theCurrentDate.getDate()) + "</td>"; 
		theDayHTML += " </tr>"; 
		theDayHTML += " </table>"; 
		var theCalendarGrid = document.getElementById(this.Id + "_CalendarGrid"); 
		theCalendarGrid.innerHTML = theDayHTML; 
	} 
	/****** setDayList End ******/
	
	this.GetCalendarPadLeft = function(theObject)
	{
		var absLeft = 0; 
		var thePosition=""; 
		var tmpObject = theObject; 
		while (tmpObject != null)
		{ 
			thePosition = tmpObject.position; 
			tmpObject.position = "static"; 
			absLeft += tmpObject.offsetLeft; 
			tmpObject.position = thePosition; 
			tmpObject = tmpObject.offsetParent; 
		} 
		return absLeft; 
	} 
	
	this.GetCalendarPadTop = function(theObject)
	{
		var absTop = 0; 
		var thePosition = ""; 
		var tmpObject = theObject; 
		while (tmpObject != null)
		{ 
			thePosition = tmpObject.position; 
			tmpObject.position = "static"; 
			absTop += tmpObject.offsetTop; 
			tmpObject.position = thePosition; 
			tmpObject = tmpObject.offsetParent;
		} 
		return absTop + this.Source.offsetHeight; 
	} 
	
	//转换字符串为日期格式
	/*******GetTextDate Start******/ 
	this.GetTextDate = function(theString)
	{ 
		var i = 0, tmpChar = "", find_tag = ""; 
		var start_at = 0, end_at = 0, year_at = 0, month_at = 0, day_at = 0; 
		var tmp_at = 0, one_at = 0, two_at = 0, one_days = 0, two_days = 0; 
		var aryDate = new Array(); 
		var tmpYear = -1, tmpMonth = -1, tmpDay = -1; 
		var tmpDate = theString.toLowerCase(); 
		var defDate = ""; 
		end_at = tmpDate.length; 
		
		for (i=1;i<end_at;i++)
		{ 
			if (tmpDate.charAt(i)=="0")
			{ 
				tmpChar = tmpDate.charAt(i-1); 
				if (tmpChar<"0" || tmpChar>"9")
				{ 
					tmpDate = tmpDate.substr(0,i-1) + "-" + tmpDate.substr(i+1); 
				} 
			} 
		} 
		for (i=0;i<9;i++)
		{ 
			tmpDate = tmpDate.replace(this.MonthName[i].toLowerCase().substr(0,3), "-00" + (i+1).toString() + "-"); 
		} 
		for (i=9;i<12;i++)
		{ 
			tmpDate = tmpDate.replace(this.MonthName[i].toLowerCase().substr(0,3), "-0" + (i+1).toString() + "-"); 
		} 
		tmpDate = tmpDate.replace(/jan/g, "-001-"); 
		tmpDate = tmpDate.replace(/feb/g, "-002-"); 
		tmpDate = tmpDate.replace(/mar/g, "-003-"); 
		tmpDate = tmpDate.replace(/apr/g, "-004-"); 
		tmpDate = tmpDate.replace(/may/g, "-005-"); 
		tmpDate = tmpDate.replace(/jun/g, "-006-"); 
		tmpDate = tmpDate.replace(/jul/g, "-007-"); 
		tmpDate = tmpDate.replace(/aug/g, "-008-"); 
		tmpDate = tmpDate.replace(/sep/g, "-009-"); 
		tmpDate = tmpDate.replace(/oct/g, "-010-"); 
		tmpDate = tmpDate.replace(/nov/g, "-011-"); 
		tmpDate = tmpDate.replace(/dec/g, "-012-"); 
		for (i=0;i<tmpDate.length;i++)
		{ 
			tmpChar = tmpDate.charAt(i); 
			if ((tmpChar<"0" || tmpChar>"9") && (tmpChar != "-"))
			{ 
				tmpDate = tmpDate.replace(tmpChar,"-") 
			} 
		} 
		while(tmpDate.indexOf("--") != -1)
		{ 
			tmpDate = tmpDate.replace(/--/g,"-"); 
		} 
		start_at = 0; 
		end_at = tmpDate.length-1; 
		while (tmpDate.charAt(start_at)=="-")
		{ 
			start_at++; 
		} 
		while (tmpDate.charAt(end_at)=="-")
		{ 
			end_at--; 
		} 
		if (start_at < end_at+1)
		{ 
			tmpDate = tmpDate.substring(start_at,end_at+1); 
		}
		else
		{ 
			tmpDate = ""; 
		} 
		aryDate = tmpDate.split("-"); 
		if (aryDate.length != 3)
		{ 
			return(defDate); 
		} 
		for (i=0;i<3;i++)
		{ 
			if (parseInt(aryDate[i],10)<1)
			{ 
				aryDate[i] = "1"; 
			} 
		} 
		find_tag="000"; 
		for (i=2;i>=0;i--)
		{ 
			if (aryDate[i].length==3)
			{ 
				if (aryDate[i]>="001" && aryDate[i]<="012")
				{ 
					tmpMonth = parseInt(aryDate[i],10)-1; 
					switch (i)
					{ 
						case 0: 
						find_tag = "100"; 
						one_at = parseInt(aryDate[1],10); 
						two_at = parseInt(aryDate[2],10); 
						break; 
						case 1: 
						find_tag = "010"; 
						one_at = parseInt(aryDate[0],10); 
						two_at = parseInt(aryDate[2],10); 
						break; 
						case 2: 
						find_tag = "001"; 
						one_at = parseInt(aryDate[0],10); 
						two_at = parseInt(aryDate[1],10); 
						break; 
					} 
				} 
			} 
		} 
		if (find_tag!="000")
		{ 
			one_days = this.GetMonthDays(two_at,tmpMonth); 
			two_days = this.GetMonthDays(one_at,tmpMonth); 
			if ((one_at>one_days)&&(two_at>two_days))
			{ 
				return(defDate); 
			} 
			if ((one_at<=one_days)&&(two_at>two_days))
			{ 
				tmpYear = this.GetFormatYear(two_at); 
				tmpDay = one_at; 
			} 
			if ((one_at>one_days)&&(two_at<=two_days))
			{ 
				tmpYear = this.GetFormatYear(one_at); 
				tmpDay = two_at; 
			} 
			if ((one_at<=one_days)&&(two_at<=two_days))
			{ 
				tmpYear = this.GetFormatYear(one_at); 
				tmpDay = two_at; 
				tmpDate = this.DateFormat; 
				year_at = tmpDate.indexOf("<yyyy>"); 
				if (year_at == -1)
				{ 
					year_at = tmpDate.indexOf("<yy>"); 
				} 
				day_at = tmpDate.indexOf("<dd>"); 
				if (day_at == -1)
				{ 
					day_at = tmpDate.indexOf("<d>"); 
				} 
				if (year_at >= day_at)
				{ 
					tmpYear = this.GetFormatYear(two_at); 
					tmpDay = one_at; 
				} 
			} 
			return(new Date(tmpYear, tmpMonth, tmpDay)); 
		}
		find_tag = "000"; 
		for (i=2;i>=0;i--)
		{ 
			if (parseInt(aryDate[i],10)>31)
			{ 
				tmpYear = this.GetFormatYear(parseInt(aryDate[i],10)); 
				switch (i)
				{ 
					case 0: 
					find_tag = "100"; 
					one_at = parseInt(aryDate[1],10); 
					two_at = parseInt(aryDate[2],10); 
					break; 
					case 1: 
					find_tag = "010"; 
					one_at = parseInt(aryDate[0],10); 
					two_at = parseInt(aryDate[2],10); 
					break; 
					case 2: 
					find_tag = "001"; 
					one_at = parseInt(aryDate[0],10); 
					two_at = parseInt(aryDate[1],10); 
					break; 
				} 
			} 
		} 
		if (find_tag=="000")
		{ 
			tmpDate = this.DateFormat; 
			year_at = tmpDate.indexOf("<yyyy>"); 
			if (year_at == -1)
			{ 
				year_at = tmpDate.indexOf("<yy>"); 
			} 
			month_at = tmpDate.indexOf("<MMMMMM>"); 
			if (month_at == -1)
			{ 
				month_at = tmpDate.indexOf("<MMM>"); 
			} 
			if (month_at == -1)
			{ 
				month_at = tmpDate.indexOf("<mm>"); 
			} 
			if (month_at == -1)
			{ 
				month_at = tmpDate.indexOf("<m>"); 
			} 
			day_at = tmpDate.indexOf("<dd>"); 
			if (day_at == -1)
			{ 
				day_at = tmpDate.indexOf("<d>"); 
			} 
			if ((year_at>month_at)&&(year_at>day_at))
			{ 
				find_tag="001" 
			} 
			if ((year_at>month_at)&&(year_at<=day_at))
			{ 
				find_tag="010"; 
			} 
			if ((year_at<=month_at)&&(year_at>day_at))
			{ 
				find_tag="010"; 
			} 
			if ((year_at<=month_at)&&(year_at<=day_at))
			{ 
				find_tag="100"; 
			} 
			switch (find_tag)
			{ 
				case "100": 
				tmpYear = parseInt(aryDate[0],10); 
				one_at = parseInt(aryDate[1],10); 
				two_at = parseInt(aryDate[2],10); 
				break; 
				case "010": 
				one_at = parseInt(aryDate[0],10); 
				tmpYear = parseInt(aryDate[1],10); 
				two_at = parseInt(aryDate[2],10); 
				break; 
				case "001": 
				one_at = parseInt(aryDate[0],10); 
				two_at = parseInt(aryDate[1],10); 
				tmpYear = parseInt(aryDate[2],10); 
				break; 
			} 
			tmpYear = this.GetFormatYear(tmpYear); 
		} 

		if (find_tag!="000")
		{ 
			if ((one_at>12)&&(two_at>12))
			{ 
				return(defDate); 
			} 
			if (one_at<=12)
			{ 
				if (two_at > this.GetMonthDays(tmpYear,one_at-1))
				{ 
					return(new Date(tmpYear, one_at-1, this.GetMonthDays(tmpYear,one_at-1))); 
				} 
				if (two_at>12)
				{ 
					return(new Date(tmpYear, one_at-1, two_at)); 
				} 
			} 
			if (two_at<=12)
			{ 
				if (one_at > this.GetMonthDays(tmpYear,two_at-1))
				{ 
					return(new Date(tmpYear, two_at-1, this.GetMonthDays(tmpYear,two_at-1))); 
				} 
				if (one_at>12)
				{ 
					return(new Date(tmpYear, two_at-1, one_at)); 
				} 
			} 
			if ((one_at<=12)&&(two_at<=12))
			{ 
				tmpMonth = one_at-1; 
				tmpDay = two_at; 
				tmpDate = this.DateFormat; 
				month_at = tmpDate.indexOf("<MMMMMM>"); 
				if (month_at == -1)
				{ 
					month_at = tmpDate.indexOf("<MMM>"); 
				} 
				if (month_at == -1)
				{ 
					month_at = tmpDate.indexOf("<mm>"); 
				} 
				if (month_at == -1)
				{ 
					month_at = tmpDate.indexOf("<m>"); 
				} 
				day_at = tmpDate.indexOf("<dd>"); 
				if (day_at == -1)
				{ 
					day_at = tmpDate.indexOf("<d>"); 
				} 
				if (month_at >= day_at)
				{ 
					tmpMonth = two_at-1; 
					tmpDay = one_at; 
				} 
				return(new Date(tmpYear, tmpMonth, tmpDay)); 
			} 
		} 
	}
	/*******GetTextDate End******/ 
	
	//格式花年为4位纪元
	this.GetFormatYear = function(theYear)
	{
		var tmpYear = theYear; 
		if (tmpYear < 100)
		{ 
			tmpYear += 1900; 
			if (tmpYear < 1970)
			{ 
				tmpYear += 100; 
			} 
		} 

		if (tmpYear < this.MinYear)
		{ 
			tmpYear = this.MinYear; 
		} 

		if (tmpYear > this.MaxYear)
		{ 
			tmpYear = this.MaxYear; 
		} 
		return(tmpYear); 
	} 
	
	//获取日期
	this.GetMonthDays = function(theYear, theMonth)
	{ 
		var theDays = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31); 
		var theMonthDay = 0, tmpYear = this.GetFormatYear(theYear); 
		theMonthDay = theDays[theMonth]; 
		if (theMonth == 1)
		{ //theMonth is February 
			if(((tmpYear % 4 == 0) && (tmpYear % 100 != 0)) || (tmpYear % 400 == 0))
			{ 
				theMonthDay++; 
			} 
		} 
		return(theMonthDay); 
	}
	 
	//格式化日期
	this.SetDateFormat = function(theYear, theMonth, theDay)
	{
		var theDate = this.DateFormat; 
		var tmpYear = this.GetFormatYear(theYear); 
		var tmpMonth = theMonth; 
		if (tmpMonth < 0)
		{ 
			tmpMonth = 0; 
		} 
		if (tmpMonth > 11)
		{ 
			tmpMonth = 11; 
		} 
		var tmpDay = theDay; 
		if (tmpDay < 1)
		{ 
			tmpDay = 1; 
		}
		else
		{ 
			tmpDay = this.GetMonthDays(tmpYear, tmpMonth); 
			if (theDay < tmpDay)
			{ 
				tmpDay = theDay; 
			} 
		} 
		theDate = theDate.replace(/<yyyy>/g, tmpYear.toString()); 
		theDate = theDate.replace(/<yy>/g, tmpYear.toString().substr(2,2)); 
		theDate = theDate.replace(/<MMMMMM>/g, this.MonthName[tmpMonth]); 
		theDate = theDate.replace(/<MMM>/g, this.MonthName[tmpMonth].substr(0,3)); 
		if (theMonth < 9)
		{ 
			theDate = theDate.replace(/<mm>/g, "0" + (tmpMonth + 1).toString()); 
		}
		else
		{ 
			theDate = theDate.replace(/<mm>/g, (tmpMonth + 1).toString()); 
		} 
		theDate = theDate.replace(/<m>/g, (tmpMonth + 1).toString()); 
		if (theDay < 10)
		{ 
			theDate = theDate.replace(/<dd>/g, "0" + tmpDay.toString()); 
		}
		else
		{ 
			theDate = theDate.replace(/<dd>/g, tmpDay.toString()); 
		}
		theDate = theDate.replace(/<d>/g, tmpDay.toString()); 
		return(theDate); 
	} 
	
	this.UpdateCalendarGrid = function(theObject)
	{ 
		var theTextObject = this.Source; 
		var theYearObject = document.getElementById(this.Id + "_YearList"); 
		var theMonthObject = document.getElementById(this.Id + "_MonthList"); 
		var theDayObject = document.getElementById(this.Id + "_DayList"); 
		var tmpName = theObject.id.substr(theObject.id.lastIndexOf("_")); 
		switch (tmpName)
		{ 
			case "_goPreviousMonth": //go previous month button 
			theObject.disabled = true; 
			this.CreateCalendarGrid(parseInt(theYearObject.value, 10), parseInt(theMonthObject.value, 10) - 1, parseInt(theDayObject.value, 10)); 
			theObject.disabled = false; 
			break; 
			case "_goNextMonth": //go next month button 
			theObject.disabled = true; 
			this.CreateCalendarGrid(parseInt(theYearObject.value, 10), parseInt(theMonthObject.value, 10) + 1, parseInt(theDayObject.value, 10)); 
			theObject.disabled = false; 
			break; 
			case "_YearList": //year list 
			this.CreateCalendarGrid(parseInt(theYearObject.value, 10), parseInt(theMonthObject.value, 10), parseInt(theDayObject.value, 10)); 
			break; 
			case "_MonthList": //month list 
			this.CreateCalendarGrid(parseInt(theYearObject.value, 10), parseInt(theMonthObject.value, 10), parseInt(theDayObject.value, 10)); 
			break; 
			default: 
			return; 
		} 
	}

	this.DeleteCalendarPad = function () {
	    var theCalendarPadObject = document.getElementById(this.Id + "_CalendarPad");
	
	    if (theCalendarPadObject == null) {
	        return;
	    }
	    var tmpObject = document.activeElement;
	    while (tmpObject != null) {
	        if (tmpObject.id == this.Id + "_CalendarPad") {
	            return;
	        }
	        if (tmpObject.id == this.Id + "_CalendarGrid") {
	            return;
	        }
	        if (tmpObject == this.Source) {
	            return;
	        }
	        if (tmpObject.id == this.Id + "_goPreviousMonth") {
	            return;
	        }
	        if (tmpObject.id == this.Id + "_goNextMonth") {
	            return;
	        }
	        if (tmpObject.id == this.Id + "_YearList") {
	            return;
	        }
	        if (tmpObject.id == this.Id + "_MonthList") {
	            return;
	        }
	        if (tmpObject.id == this.Id + "_DayList") {
	            return;
	        }
	        tmpObject = tmpObject.parentElement;
	    }
	    //Delete CalendarPad
	    if (tmpObject == null) {
	         theCalendarPadObject.outerHTML = "";
	        this.boolCalendarPadExist = false;
	        var theDate = new Date(this.GetTextDate(this.Source.value));
	        if (isNaN(theDate)) {
	            this.Source.value = "";
	        }
	        else {
	            this.Source.value = this.SetDateFormat(theDate.getFullYear(), theDate.getMonth(), theDate.getDate());
	        }
	        this.Source = null;
	    }
	} 
	
	this.Show = function(targetObject, sourceObject)
	{
		if(targetObject == undefined) 
		{
			alert("未设置目标对像. \n方法: CUalendar.show(obj 目标对像,obj 点击对像);\n\n点击对像:点击这个对像弹出CUalendar,默认为目标对像.\n\n目标对像:接受日期返回值的对像");
			return false;
		}
		else
		{
			this.Target = targetObject;
		}
		if(sourceObject == undefined)
		{
			this.Source=this.Target;
		}
		else
		{
			this.Source=sourceObject;
		}
		if(this.Source != undefined)
		{
			var theCalendarPadObject = document.getElementById(this.Id + "_CalendarPad"); 
			if (theCalendarPadObject != null)
			{ 
				return; 
			}
			else if(!this.boolCalendarPadExist)
			{
				this.CreateCalendarPad();
			}
			else return;
		}
		else return;
	}
	
	this.Hidden = function()
	{
		var theCalendarPadObject = document.getElementById(this.Id + "_CalendarPad"); 
		this.DeleteCalendarPad();
		if(this.Source == null)
		{
			theCalendarPadObject = null
		}
	}
	
	
}
function ChangeDate() {

}
function CUCalendar_getCalendarById(id)
{
	var o = cucalendar_state[id];

	if(o != null) return o;
	for(var i in cucalendar_state) if((o = cucalendar_state[i]) != null) if(o.clientId == id || o.UniqueId == id) return o;
	return null;
	
}
if (typeof(Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();