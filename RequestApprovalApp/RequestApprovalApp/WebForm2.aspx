<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="RequestApprovalApp.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 531px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <h1 style="text-align:left">User Page</h1>
            <asp:Button ID="Button2"  align="right" runat="server" CssClass="auto-style1" OnClick="Button2_Click" Text="Logout" Width="136px" />
            
        </div>
   <br />
    <br />
    <h3>Create Request</h3> 

        <asp:Label ID="Label1" runat="server" Text="Type your Request :"></asp:Label>
        
        <asp:TextBox ID="TextBox1" runat="server" Height="53px" Width="695px"></asp:TextBox>
        
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Create" Width="126px" />
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Show All Request" />
        </p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
   
</body>
</html>
