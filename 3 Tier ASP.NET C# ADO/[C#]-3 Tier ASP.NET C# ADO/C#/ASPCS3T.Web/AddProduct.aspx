<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ASPCS3T.Web.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Add New Product"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
    &nbsp;<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    </div>
    </form>
</body>
</html>
