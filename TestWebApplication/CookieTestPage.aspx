<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieTestPage.aspx.cs" Inherits="TestWebApplication.CookieTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:TextBox runat="server" ID="textField" ClientIDMode="Static" />
		<asp:Button runat="server" ID="submitButton" ClientIDMode="Static" OnClick="SaveCookieClick" />
    </div>
    </form>
</body>
</html>
