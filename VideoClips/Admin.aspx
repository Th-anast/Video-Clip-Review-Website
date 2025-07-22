<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="VideoClips.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HOME</title>
</head>
<body style="background-color:#FEF5E7;font-family:arial">
    <form id="form1" runat="server" method="post">
        <p style="text-align:right;font-size:larger"><a href = "Home.aspx">Log Out</a>&emsp;&emsp;</p>
        <div style="display:inline-block; width: 766px;">            
            <h1><asp:Label ID="Label1" runat="server" Text="Welcome" ViewStateMode="Disabled"></asp:Label></h1>
            <p><asp:FileUpload ID="FileUpload1" runat="server"/></p>            
            <p><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" placeholder="Write a description for the video" Height="60px" Width="497px" Font-Names="arial"></asp:TextBox></p>
            <asp:Button id="Button1" Text="Upload File" OnClick="Button1_Click" runat="server" Width="105px" />
            <asp:Label ID="Label2" runat="server" Text="Labe2" Visible="False"></asp:Label>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show only my videos" />
        </div>
        <div style="display:inline-block; width: 534px;" hidden="hidden">
            <p>There are <b><asp:Label ID="Label3" runat="server" ViewStateMode="Disabled"></asp:Label>&nbsp;</b>Users.<br/></p>
            <asp:Panel ID="Panel1" runat="server" Font-Overline="False" GroupingText="ID,Username,Uploaded Videos,Posted Reviews" Width="379px">
                <asp:Panel ID="Panel2" runat="server" Height="123px" ScrollBars="Vertical">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </asp:Panel>
            </asp:Panel>
        </div>
        <h3 style="padding-left:37%">Select the video, that you want to watch:</h3>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
