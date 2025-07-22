<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VideoClips.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div style="font-family:arial; text-align:center">
            <p>Please enter your password and your username and select your category to connect to the Clips!</p>
            <h2><u>Login</u></h2>
            <p><b>Username: </b><asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Width="135px"></asp:TextBox></p>
            <p><b>Password: </b><asp:TextBox ID="TextBox2" runat="server" type="password" Font-Size="Medium" Width="135px"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="Login" Font-Bold="True" Font-Size="Large" ForeColor="Green" Height="33px" Width="75px" OnClick="Button1_Click" /></p>
            <p>Για να δημιουργήσετε έναν νέο λογαριασμό, πατήστε <a href = "SignUp.aspx">εδώ</a>.</p>
            <asp:Label ID="Label1" runat="server" ForeColor="Black"></asp:Label>
        </div>
    </form>
</body>
</html>
