<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="6HW.aspx.cs" Inherits="_6HW._6HW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lb_Data" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="輸入姓名："></asp:Label>
        <asp:TextBox ID="tx_Name" runat="server" ></asp:TextBox>
        <asp:Label ID="lb_Hint" runat="server" Text="" ForeColor="Red"></asp:Label><br /><br />
        <asp:Button ID="btn_Del" runat="server" Text="Delete"  OnClick="btn_Del_Click"/>
    </form>
</body>
</html>
