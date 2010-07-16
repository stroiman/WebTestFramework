<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage1.aspx.cs" Inherits="TestWebApplication.TestPage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:TextBox runat="server" ID="TextField" />
		<asp:Label runat="server" ID="TextFieldOutput" />
		<asp:Button runat="server" ID="UpdateButton" OnClick="UpdateButtonClick" />
    </div>
    </form>
</body>
</html>
