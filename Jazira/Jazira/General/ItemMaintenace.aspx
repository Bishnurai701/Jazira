<%@ Page Title="" Language="C#" MasterPageFile="~/General/General.Master" AutoEventWireup="true" CodeBehind="ItemMaintenace.aspx.cs" Inherits="Jazira.General.ItemMaintenace" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function confirmAction(path, noPath) {
             if (confirm('Are you sure, You want to execute this action???')) {
                 window.location = path;
             }
             else {
                 window.location = noPath;
             }
         }
         //$(document).ready(function (e) {
         //    $("#liMasterMaintainance").addClass("active");
         //    $('#MainContent_MainContent_close').click(function (e) {
         //        $('#new').removeClass('active')
         //        $('.nav-custom li').removeClass('active')
         //    })
         //});
    </script>
     <script type="text/javascript">
         $(function () {
             $('[data-toggle="tooltip"]').tooltip()
         })
    </script>

     <style type="text/css">
         .divcontrols {
            float: left;
            width: 60%;
            position: relative;
            display: table;
            overflow: hidden;
        }
        .divlabel {
             text-align:right;
           float:left;
           padding:5px 10px 2px 2px;                      
           width:110px;                                    
           font-size:14px;
        }
        .divbutton
           {
               width:100%;
               margin:0px 0px 10px 5px;
               padding:7px 10px 7px 10px;
               font-weight:bold;
               font-family:Calibri;
               border-style:none;  
               font-size:15px;
           }
.margin-one
{
    margin:1px;
}
.divtextbox
       {
           float:left;
           padding:0px 10px 2px 2px;
           margin:0px 5px 0px 5px;           
        }
.divgridbutton
           {
               width:35%;              
               padding:7px 10px 7px 10px;
               font-weight:bold;
               font-family:Calibri;
                
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-6 col-xs-6">
            <div class="page-heading">
                <h3>
                    <i class="fa fa-th-list fa-lg"></i>&nbsp;Item Maintenance
                </h3>
            </div>
        </div> 
        <div class="col-md-6">
            <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color:transparent">
                <li><a href="../About.aspx">Home</a><span class="divider"></span></li>
                <li ><a href="../GoldInventory/GoldInventoryDashBoard.aspx">Gold Inventory</a><span class="divider"></span></li>
                <li class="active"><a href="ItemMaintenace.aspx?act=search">Item Maintenance</a></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <hr class="hline" />
    </div>
    <div class="row">
        <div class="col-md-12 row-fluid-icon-modified" runat="server">
            <div class="alert" runat="server" id="alert" visible="false">
                <button class="close" id="button_close" data-dismiss="alert" visible="false"><i class="fa fa-times"></i></button>
                <strong>
                    <asp:Label runat="server" ID="lblMsgType" CssClass="pull-left" Text="Message Type"></asp:Label>!&nbsp;
                </strong>
                <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
            </div>
            <a href="ItemMaintenace.aspx?act=search">
                <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                    <i class="fa fa-search-minus fa-inverse"></i>
                </div>
            </a>
            <a href="ItemMaintenace.aspx?act=add">
                <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                    <i class="fa fa-plus-circle fa-inverse"></i>
                </div>
            </a>
        </div>
    </div>

    <%string act = Request.QueryString["act"]; %>
    <%if(act=="list"||act=="search")
      { %>
     <div class="row">
        <div class="col-md-10">
            <div class="form-group has-success" >
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtSearchItemCode" CssClass="form-control" placeholder="Search By Item Code..."></asp:TextBox>
                </div>
                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary-custom pull-left" OnClick="btnSearch_Click"></asp:Button>
            </div>
        </div>
         <div class="col-md-10">

             <label class="col-sm-2 control-label"></label>
             <div class="col-md-6">
             </div>
             <div class="col-sm-4">
                 <label class="col-sm-2 control-label"></label>
             </div>
             <div class="col-sm-4">
                 <label class="col-sm-2 control-label"></label>
             </div>
         </div>
    </div>

    <%} %>
    <%if(act=="add"||act=="edit")
      { %>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Item Code.</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtItemCode" runat="server" CssClass="form-control" placeholder="Item Code.."></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Item Description.</label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtItemDescription" runat="server" CssClass="form-control" placeholder="Item Description.."></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Price.</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="SR.000.00"></asp:TextBox>
                    </div>
                    <label class="col-md-1 control-label">*CARAT.</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtCARAT" runat="server" CssClass="form-control" placeholder="875.00"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Delv Colm.</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlDelvColm" runat="server" CssClass="form-control">
                            <asp:ListItem Value="1" Text="D-CUTT"></asp:ListItem>
                            <asp:ListItem Value="2" Text="R/MADE"></asp:ListItem>
                            <asp:ListItem Value="3" Text="STONE"></asp:ListItem>
                            <asp:ListItem Value="4" Text="OTHERS"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 checkbox" style="color: #ff8000">
                        <strong>
                            <asp:CheckBox runat="server" ID="chkDelvWrkLoss" />Delv-Wrk-Loss</strong>
                    </div>
                    <div class="col-xs-2 checkbox" style="color: #ff8000">
                        <strong>
                            <asp:CheckBox runat="server" ID="chkDelvWthChrg" />Delv-Wth-Chrg</strong>
                    </div>
                </div>

                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Recv Colm.</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlRecvColm" runat="server" CssClass="form-control">
                            <asp:ListItem Value="1" Text="H.R/MADE"></asp:ListItem>
                            <asp:ListItem Value="2" Text="R/MADE"></asp:ListItem>
                            <asp:ListItem Value="3" Text="STONE"></asp:ListItem>
                            <asp:ListItem Value="4" Text="OTHERS"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 checkbox" style="color: #ff8000">
                        <strong>
                            <asp:CheckBox runat="server" ID="chkRecvWrkLoss" />Recv-Wrk-Loss</strong>
                    </div>
                    <div class="col-xs-2 checkbox" style="color: #ff8000">
                        <strong>
                            <asp:CheckBox runat="server" ID="chkRecvWthChrg" />Recv-Wth-Chrg</strong>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group has-success">
                    <label class="col-md-1 control-label"></label>
                    <div class="col-md-2 checkbox" style="color: #0088cc" runat="server">
                        <strong><asp:CheckBox runat="server" ID="chkStoneItem" AutoPostBack="true" OnCheckedChanged="chkItemChecked"/>STONE ITEM</strong>
                    </div>
                </div>
            </div>
        </div>

        <div class="row" id="ListaEmOutrosDocumentos" runat="server"  style="background-color:#dce5e0;display:none">
            <div class="col-md-12">
                <label class="control-label"></label>
                <div class="form-group has-success">
                    <label class="col-md-2 control-label">*STONE CUT.</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlStoneCUT" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="col-md-2 control-label">*SIZE.</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtSize" runat="server" CssClass="form-control" placeholder="875.00"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group has-success">
                    <label class="col-md-2 control-label">*STONE Clearity.</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlStoneClearity" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="col-md-2 control-label">*Weight.</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtWeight" runat="server" CssClass="form-control" placeholder="875.00"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group has-success">
                    <label class="col-md-2 control-label">*Color.</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlColor" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="col-md-2 control-label">*Date.</label>
                    <div class="col-md-4" style="color:red;font-family:Arial Black">
                       <asp:Label ID="lblDate" runat="server"  Visible="true"></asp:Label>
                    </div>
                </div>
                 <div class="form-group has-success">
                    <label class="col-md-2 control-label">*Shape.</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlShape" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label class="col-md-2 control-label">*R.O.L.</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtROL" runat="server" CssClass="form-control" placeholder="875.00"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <label class="col-md-12"></label>
    </div>
    <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label class="col-md-6"></label>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary-custom pull-left" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
           
    <%} if(act=="list"||act=="search")
      {%>
     <div class="row"></div>
    <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvTypeMaster" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="TypeMastId" AllowPaging="true"  PageSize="6" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvTypeMaster_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="TypeCodee" HeaderText="Item Code" />
                        <asp:BoundField DataField="TypeDescription" HeaderText="Item Description" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="170px" 
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#String.Format("ItemMaintenace.aspx?act=edit&Id={0}",Eval("TypeMastId")) %>";>  <i class="fa fa-edit"></i> </a>&nbsp;
                                <a href="javascript:confirmAction('<%#String.Format("ItemMaintenace.aspx?act=del&Id={0}",Eval("TypeMastId")) %>','')">  <i class="fa fa-trash-o"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    <div id="divNoDaa" runat="server">
        <table class="table table-bordered">
            <tr>
                <th>No Record Found !!</th>
            </tr>
        </table>
    </div>



    <%} %>
 


</asp:Content>
