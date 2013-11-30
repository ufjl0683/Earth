<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProbecardWorkSheet.aspx.cs" Inherits="slAmidaConsole.Web.ProbecardWorkSheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" title="currentStyle">
			@import "jquery/media/css/demo_page.css";
			@import "jquery/media/css/jquery.dataTables.css";
		</style>

    <script type="text/javascript" language="javascript" src="jquery/media/js/jquery.js"></script>
<script type="text/javascript" language="javascript" src="jquery/media/js/jquery.dataTables.js"></script>

 <script type="text/javascript" charset="utf-8">
     $(document).ready(function () {
         var oTable = $('#tblProbecardWorkSheet').dataTable(
           {
               "bPaginate": false,
               "bSort": true //,
               //  "sScrollY": "200px"
           }


         );

         fnShowHide(12);


     });
       function load() {
           document.getElementById("PCID").focus();
        //   window.scrollTo(0, document.body.scrollHeight);

       }

       function fnShowHide(iCol) {
           /* Get the DataTables object again - this is not a recreation, just a get of the object */
          
           var oTable = $('#tblProbecardWorkSheet').dataTable();
           if($('#tblProbecardWorkSheet').length == 0)
                 return;
        //   alert(oTable);
           
           var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
           oTable.fnSetColumnVis(iCol, bVis ? false : true);
         //  alert(oTable.fnSettings().aoColumns[iCol].bVisible);
           
           if (oTable.fnSettings().aoColumns[iCol].bVisible )
               $('#HideShow').val("隱藏備註");
               else
                $('#HideShow').val("顯示備註");
       }

		</script>
</head>
<body  onload="load()" >
    
    <form id="form1"  method="get" action="ProbecardWorkSheet.aspx" style="text-align:center"  >
      PCID: <input type="text" name="PCID" id="PCID" size="50"  
             />
     <input type="submit" />
     <input type="button" id="HideShow"  value="隱藏備註" onclick="fnShowHide(12)" />
    </form>
    <asp:Label ID="Label1" runat="server"  ></asp:Label><br />
    <div id="dvTable"  runat="server" >
    
    
      
    
    </div>
</body>
</html>
