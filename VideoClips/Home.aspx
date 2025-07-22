<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VideoClips.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HOME</title>
</head>
<body style="background-color:#FEF5E7;">
    <form id="form1" runat="server" method="post">
        <div style="font-family:arial">
            <p style="text-align:right;font-size:larger"><a href = "Login.aspx">Log In</a>&emsp;&emsp;<a href = "SignUp.aspx">Sign Up</a>&emsp;&emsp;</p>
            <h1><asp:Label ID="Label1" runat="server" Text="Welcome to the CLips!!!" ViewStateMode="Disabled"></asp:Label></h1>
            <h3 style="padding-left:37%">Select the video, that you want to watch:</h3>
            <p><asp:Literal ID="Literal1" runat="server"></asp:Literal></p>
        </div>
    </form>
</body>
</html>
