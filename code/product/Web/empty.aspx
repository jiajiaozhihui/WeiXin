﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="empty.aspx.cs" Inherits="SfSoft.web.empty"
    Title="无标题页" %>

<html>
<head runat="server">
    <title>css圆角效果</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8">
<style type="text/css"> 
 div.RoundedCorner{background: #9BD1FA;width:100px;font-size:12px} 
 b.rtop, b.rbottom{display:block;background: #FFF} 
 b.rtop b, b.rbottom b{display:block;height: 1px;overflow: hidden; background: #9BD1FA} 
 b.r1{margin: 0 5px} 
 b.r2{margin: 0 3px} 
 b.r3{margin: 0 2px} 
 b.rtop b.r4, b.rbottom b.r4{margin: 0 1px;height: 2px} 
 </style> 
</head>
<body>
<div class="RoundedCorner"> 
 <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b> 
 <br>(div)实现圆角框<br><br> 
 <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1"></b></b> 
 </div> 
</body>
</html>
