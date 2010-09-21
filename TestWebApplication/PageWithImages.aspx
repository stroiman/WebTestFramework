<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageWithImages.aspx.cs" Inherits="TestWebApplication.PageWithImages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<img id="imageWithAbsolutePath" src="/image.jpg" />
		<img id="imageWithRelativePath" src="image.jpg" />    
    </div>
    </form>
</body>
</html>
