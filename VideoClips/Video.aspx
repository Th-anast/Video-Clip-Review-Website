<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="VideoClips.Video" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="Title" runat="server"></title>
</head>
<body style="background-color:#FEF5E7;">
    <form id="form1" runat="server"  method="post">
        <div style="font-family:arial">
            <p style="font-size:larger"><asp:Literal ID="Literal2" runat="server"></asp:Literal></p>
            <p><asp:Literal ID="Literal1" runat="server"></asp:Literal></p>
            <p><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" placeholder="Write a review for the video" Height="50px" Width="990px" Font-Names="arial"></asp:TextBox><br/>
            <asp:Button ID="Button1" runat="server" Text="Post your review" OnClick="Button1_Click" /></p>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Reviews"><asp:Literal ID="Literal3" runat="server"></asp:Literal></asp:Panel>
        </div>        
    </form>
</body>
</html>
