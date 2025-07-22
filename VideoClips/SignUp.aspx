<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="VideoClips.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIGN UP</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:verdana; text-align:center">
            <h1>Welcome to the CLips! Thank you for growing our team!</h1>
            <h2><u>Sing up</u></h2>
            <p><b>Username: </b><asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Width="135px"></asp:TextBox></p>
            <p><b>Password: </b><asp:TextBox ID="TextBox2" runat="server" type="password" Font-Size="Medium" Width="135px"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="Sing up" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Height="35px" Width="80px" OnClick="Button1_Click" /></p>
            <p><asp:Label ID="Label1" runat="server" ForeColor="Black"></asp:Label></p>
        </div>
    </form>
</body>
</html>
