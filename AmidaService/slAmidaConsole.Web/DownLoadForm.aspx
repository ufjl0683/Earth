<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="DownLoadForm.aspx.cs" Inherits="slAmidaConsole.Web.DownLoadForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<body>
<script type="text/javascript">

</script>
    <form id="form1" runat="server">
  
    <H2  style="text-align:center;"><asp:Label  runat="server" ViewStateMode="Disabled" ID="lblTitle" /></H2>
    <div runat="server"  id="description" ></div>
    
    <asp:GridView ID="GridView1" runat="server"  ViewStateMode="Disabled">
       
      
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AmidaConnectionString %>" 
        SelectCommand="SELECT * FROM [tblVerifyNote]"></asp:SqlDataSource>

    </form>
</body>
</html>
