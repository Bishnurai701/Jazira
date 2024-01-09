<%@ Page Title="" Language="C#" MasterPageFile="~/General/General.Master" AutoEventWireup="true" CodeBehind="MasterMaintainance.aspx.cs" Inherits="Jazira.General.MasterMaintainance"%> <%--ValidateRequest="false" EnableEventValidation="false"--%>
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
            <div class="col-md-4 col-xs-4">
                <div class="page-heading">
                    <h3>
                        <i class="fa fa-th-list fa-lg"></i>&nbsp; Master Maintainance
                    </h3>
                </div>
            </div>
            <div class="col-md-8">
                <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                    <li><a href="../About.aspx">Home</a> <span class="divider"></span></li>
                    <li><a href="../GoldInventory/GoldInventoryDashBoard.aspx">Gold Inventory</a> <span class="divider"></span></li>
                    <li class="active"><a href="MasterMaintainance.aspx?act=GoldType">Master Maintenace </a></li>
                </ul>
            </div>
        </div>
    <div class="row-fluid">
          <hr class="hline" />
    </div>

    <div class="row">
        <ul class="nav nav-tabs" runat="server" id="list">
            <li runat="server" id="liGoldType"><a href="?act=GoldType">Gold Type</a></li>
            <li runat="server" id="liSection"><a href="?act=Section">Section</a></li>
            <li runat="server" id="liSalaryType"><a href="?act=SalaryType">Salary Type</a></li>
            <li runat="server" id="liStoneShape"><a href="?act=StoneShape">Stone Shape</a></li>
            <li runat="server" id="liStoneColor"><a href="?act=StoneColor">Stone Color</a></li>
            <li runat="server" id="liStoneCUT"><a href="?act=StoneCUT">Stone Shape CUT</a></li>
            <li runat="server" id="liMasterOrnament"><a href="?act=MasterOrnament">Ornaments</a></li>
            <li runat="server" id="liStoneShapeClearity"><a href="?act=StoneShapeClearity">Stone Clearity</a></li>
        </ul>
    </div>
    <div class="row">
        <hr class="hline" />
    </div>



     <div class="row">
         <div class="col-md-8">
             <div runat="server" id="alert" class="alert" visible="false">
                 <button  class="close" id="button_close" data-dismiss="alert" visible="false"><i class="fa fa-times"></i></button>
                 <strong>
                     <asp:Label runat="server" ID="lblMsgType" CssClass="pull-left" Text="Message Type"></asp:Label>!&nbsp;
                 </strong>
                 <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
             </div>
         </div>
           <%-- <div id="alert" runat="server" class="col-md-12 row-fluid-icon-modified">
                <div id="messaging_alert" runat="server" class="col-md-6 pull-left alert" visible="false">
                    <%
                        if ((Session["msgInfo"] != null) && (Session["msgInfo"] != ""))
                        {
                            Response.Write(Session["msgInfo"]);%>
                            <button  class="close" id="button_close" runat="server" data-dismiss="alert" Visible="false"><i class="fa fa-times"></i></button>
                       
                   <%Session["msgInfo"]="";
                        }%>
                    <strong>
                         <asp:Label runat="server" ID="lblAlertMessage" Text=""></asp:Label>
                    </strong>
                </div>
            </div>--%>
       </div>

   
        <%-- <a href="MasterMaintainace.aspx?act=searchG">
               <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                   <i class="fa fa-search-minus fa-inverse"></i>
               </div>
           </a>
           <a href="MasterMaintainace.aspx?act=addG">
               <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                   <i class="fa fa-plus-circle fa-inverse"></i>
               </div>
           </a>--%>
    <% string act = Request.QueryString["act"]; %>

    <%if (act == "GoldType" || act == "editG")
      { %>


         <%-- <a href="MasterMaintainance.aspx?act=searchG">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addG">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>--%>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">*Gold Code</label>
                    <div class="col-sm-3" id="GoldIdd">
                        <asp:TextBox runat="server" ID="txtGoldTypeCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        <%--<asp:Label ID="lblGoldCode" Text="" runat="server"></asp:Label>--%>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">*Gold Type Name</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtGoldTypeName" CssClass="form-control" placeholder="Here Gold Type..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                   <asp:Button ID="btnGSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnGSearch_Click" /> &nbsp;&nbsp;
                    <asp:Button ID="tbnGSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="tbnGSave_Click" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvGoldType" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="GoldTypeId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvGoldType_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="GoldTypeCode" HeaderText="Code" />
                        <asp:BoundField DataField="GoldTypeName" HeaderText="Gold Type Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editG&Id={0}",Eval("GoldTypeId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delG&Id={0}",Eval("GoldTypeId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
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




    </div> <%--closing formhorizontal div--%>


   <%-- <%} %>--%>

<%--    <%if(act == "GoldType" || act=="list"||act=="searchG")
      { %>
          <a href="MasterMaintainance.aspx?act=searchG">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addG">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>
       <div class="row">
           <div class="col-md-10 has-success form-group">
               <asp:Label ID="Label1" Class="col-md-3 control-laber" runat="server">Gold Type</asp:Label>
               <div class="col-md-6">
                   <asp:TextBox ID="txtSearchGoldType" runat="server" placeholder="Search By Gold Type Name" CssClass="form-control"></asp:TextBox>
               </div>
               <asp:Button ID="btnGSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left"/>
           </div>
       </div>
       <%}if(act=="list"||act=="searchG")
         { %> --%>

       <%-- <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvGoldType" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="GoldTypeId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvGoldType_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="GoldTypeId" HeaderText="GOld Code" />
                        <asp:BoundField DataField="GoldTypeName" HeaderText="GOld Type" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editG&Id={0}",Eval("GoldTypeId")) %>";><i class="fa fa-edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delG&Id={0}",Eval("GoldTypeId")) %>','')"><i class="fa fa-trash-o"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>--%>

  <%--  <%} %>--%>

    <%--here gridview--%>


    <%} if (act == "Section" || act == "editSec") 
      {%>

       <%-- <a href="MasterMaintainance.aspx?act=searchSec">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSec">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>--%>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">*Section Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtSectionCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">*Section Name</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtSectionName" CssClass="form-control" placeholder="Here Section Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                    <asp:Button ID="btnSecSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnSecSearch_Click" /> &nbsp;&nbsp;
                    <asp:Button ID="btnSecSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="btnSecSave_Click" />
                </div>
            </div>
        </div>
          <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvSection" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="SectionCode" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvSection_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SectionCode" HeaderText="Code" />
                        <asp:BoundField DataField="SectionName" HeaderText="Section Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editSec&Id={0}",Eval("SectionCode")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delSec&Id={0}",Eval("SectionCode")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoSecData" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>

    </div>

   <%-- <%} %>--%>


<%--    <%if (act == "Section" || act == "searchSec" || act == "list") 
      {%>
          <a href="MasterMaintainance.aspx?act=searchSec">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSec">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>
            
          <div class="row">
              <div class="col-md-10 has-success form-group">
                  <asp:Label ID="Label2" Class="col-md-3 control-laber" runat="server">Section Name</asp:Label>
                  <div class="col-md-6">
                      <asp:TextBox ID="txtSearchSection" runat="server" placeholder="Search By Section Name" CssClass="form-control"></asp:TextBox>
                  </div>
                  <asp:Button ID="btnSecSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
              </div>
          </div>
    <%} %>--%>

   <%-- here gridview--%>

    <%} if ((act == "SalaryType") || (act == "editSal"))
      { %>

           <%--  <a href="MasterMaintainance.aspx?act=searchSal">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSal">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>--%>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group  has-success">
                    <label class="col-sm-3 control-label">*Salary Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtSalaryCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">*Salary Type</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtSalaryTypeName" CssClass="form-control" placeholder="Here Salary Type..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                    <asp:Button ID="btnSalSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnSalSearch_Click" />&nbsp;&nbsp;
                      <asp:Button ID="btnSalSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="btnSalSave_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvSalaryType" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="SalaryTypeId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvSalaryType_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SalaryTypeCode" HeaderText="Code" />
                        <asp:BoundField DataField="SalaryTypeName" HeaderText="Salary Type" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editSal&Id={0}",Eval("SalaryTypeId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delSal&Id={0}",Eval("SalaryTypeId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoSalData" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>



    </div>

    <%-- <%} %>--%>


<%--    <% if (act == "SalaryType" || act == "list" || act == "searchSal")
      {%>
            <a href="MasterMaintainance.aspx?act=searchSal">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSal">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>
            
          <div class="row">
              <div class="col-md-10 has-success form-group">
                  <asp:Label ID="Label3" Class="col-md-3 control-laber" runat="server">Salary Type</asp:Label>
                  <div class="col-md-6">
                      <asp:TextBox ID="txtSalaryType" runat="server" placeholder="Search By Salary Type" CssClass="form-control"></asp:TextBox>
                  </div>
                  <asp:Button ID="btnSalSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
              </div>
          </div>--%>
   <%-- <%} %>--%>

     <%--here gridview--%>

    <%}if(act=="StoneShape" || act=="editStoneS")
      { %>
             
    <%--<a href="MasterMaintainance.aspx?act=searchStoneS">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addStoneS">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>--%>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone Shape Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtStoneShapeCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone Shape</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtStoneShape" CssClass="form-control" placeholder="Here Stone Shape..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                    <asp:Button ID="btnStonaSSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnStonaSSearch_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnStoneSSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="btnStoneSSave_Click" />
                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvStoneShape" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="StoneShapeId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvStoneShape_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="StoneShapeCode" HeaderText="Code" />
                        <asp:BoundField DataField="StoneShapeName" HeaderText="Stone Shape" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editStoneS&Id={0}",Eval("StoneShapeId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delStoneS&Id={0}",Eval("StoneShapeId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoStoneSData" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>

    </div>
<%--    <%} %>--%>

<%--    <%if(act=="StoneShape" || act=="list"|| act=="searchStoneS") 
      {%>
           <a href="MasterMaintainance.aspx?act=searchStoneS">
               <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                   <i class="fa fa-search-minus fa-inverse"></i>
               </div>
           </a>
           <a href="MasterMaintainance.aspx?act=addStoneS">
               <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                   <i class="fa fa-plus-circle fa-inverse"></i>
               </div>
           </a>
           
           <div class="row">
               <div class="col-md-10 has-success form-group">
                   <asp:Label ID="Label4" Class="col-md-3 control-laber" runat="server">Stone Shape</asp:Label>
                   <div class="col-md-6">
                       <asp:TextBox ID="txtSearchStoneShape" runat="server" placeholder="Search By Stone Shape" CssClass="form-control"></asp:TextBox>
                   </div>
                   <asp:Button ID="btnStonaSSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
               </div>
           </div>
    <%} %>--%>

    <%--here gridview--%>

    <%} if (act == "StoneColor" || act == "editSC")
      { %>

            <%-- <a href="MasterMaintainance.aspx?act=searchSC">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSC">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>--%>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone Color Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtStoneColorCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone Color Name</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtStoneColorName" CssClass="form-control" placeholder="Here Stone Color..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                    <asp:Button ID="btnSCSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnSCSearch_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnSCSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="btnSCSave_Click" />
                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvStoneColor" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="StoneColorId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvStoneColor_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="StoneColorCode" HeaderText="Code" />
                        <asp:BoundField DataField="StoneColorName" HeaderText="Stone Color" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editSC&Id={0}",Eval("StoneColorId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delSC&Id={0}",Eval("StoneColorId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoDataSC" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>



    </div>

<%--    <%} if(act=="StoneColor" || act=="list" || act=="searchSC") 
      {%>
          <a href="MasterMaintainance.aspx?act=searchSC">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSC">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>
          
          <div class="row">
              <div class="col-md-10 has-success form-group">
                  <asp:Label ID="Label5" Class="col-md-3 control-laber" runat="server">Stone Color</asp:Label>
                  <div class="col-md-6">
                      <asp:TextBox ID="txtSearchStoneColor" runat="server" placeholder="Search By Stone Color" CssClass="form-control"></asp:TextBox>
                  </div>
                  <asp:Button ID="btnSCSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
              </div>
          </div>
    <%} %>--%>

    <%--here gridview--%>

    <%} if (act == "StoneCUT" || act == "editSCUT")
      { %>

<%--           <a href="MasterMaintainance.aspx?act=searchSCUT">
               <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                   <i class="fa fa-search-minus fa-inverse"></i>
               </div>
           </a>
           <a href="MasterMaintainance.aspx?act=addSCUT">
               <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                   <i class="fa fa-plus-circle fa-inverse"></i>
               </div>
           </a>--%>
           
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone CUT Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtStoneCUTCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone CUT Name</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtStoneCUTName" CssClass="form-control" placeholder="Here Stone CUT Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float:right">
                    <asp:Button ID="btnSCUTSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnSCUTSearch_Click" />&nbsp;&nbsp;
                       <asp:Button ID="btnSCUTSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="btnSCUTSave_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvStoneCUT" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="StoneCUTId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvStoneCUT_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="StoneCUTCode" HeaderText="Code" />
                        <asp:BoundField DataField="StoneShapeCUTName" HeaderText="Stone CUT Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editSCUT&Id={0}",Eval("StoneCUTId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delSCUT&Id={0}",Eval("StoneCUTId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoDataSCUT" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>



    </div>

    <%--    <%}if(act=="StoneCUT"||act=="list"||act=="searchSCUT") 
      {%>
          <a href="MasterMaintainance.aspx?act=searchSCUT">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addSCUT">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>
          
          <div class="row">
              <div class="col-md-10 has-success form-group">
                  <asp:Label ID="Label6" Class="col-md-3 control-laber" runat="server">Stone CUT Name</asp:Label>
                  <div class="col-md-6">
                      <asp:TextBox ID="txtSearchStoneCUT" runat="server" placeholder="Search By Stone CUT Name" CssClass="form-control"></asp:TextBox>
                  </div>
                  <asp:Button ID="btnSCUTSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
              </div>
          </div>
           
    <%} %>
    --%>
    <%--here gridview--%>

    <%} if (act == "MasterOrnament" || act == "editMO")
      { %>
             
            <%--<a href="MasterMaintainance.aspx?act=searchMO">
               <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                   <i class="fa fa-search-minus fa-inverse"></i>
               </div>
           </a>
           <a href="MasterMaintainance.aspx?act=addMO">
               <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                   <i class="fa fa-plus-circle fa-inverse"></i>
               </div>
           </a>--%>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group  has-success">
                    <label class="col-sm-3 control-label">Ornament Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtOrnamentCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Ornament Name</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtOrnamentName" CssClass="form-control" placeholder="Here Ornament Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                    <asp:Button ID="btnOMSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnOMSearch_Click" />&nbsp;&nbsp;
                       <asp:Button ID="btnOMSave" runat="server" Text="Save" CssClass="btn btn-primary-custom" OnClick="btnOMSave_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvMasterOrnament" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="MasterOrnamentId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvMasterOrnament_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="OrnamentCode" HeaderText="Code" />
                        <asp:BoundField DataField="MasterOrnamentName" HeaderText="Ornament Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editMO&Id={0}",Eval("MasterOrnamentId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delMO&Id={0}",Eval("MasterOrnamentId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoDataMO" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>


    </div>

    <%--    <%}if(act=="MasterOrnament"||act=="list"||act=="searchMO") 
      {%>
        <a href="MasterMaintainance.aspx?act=searchMO">
              <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                  <i class="fa fa-search-minus fa-inverse"></i>
              </div>
          </a>
          <a href="MasterMaintainance.aspx?act=addMO">
              <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                  <i class="fa fa-plus-circle fa-inverse"></i>
              </div>
          </a>
          
          <div class="row">
              <div class="col-md-10 has-success form-group">
                  <asp:Label ID="Label7" Class="col-md-3 control-laber" runat="server">Ornaments Name</asp:Label>
                  <div class="col-md-6">
                      <asp:TextBox ID="txtSearchOrnament" runat="server" placeholder="Search By Ornament Name" CssClass="form-control"></asp:TextBox>
                  </div>
                  <asp:Button ID="btnOMSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
              </div>
          </div>

    <%} %>--%>

    <%--hre gridview--%>

    <%} if (act == "StoneShapeClearity" || act == "editSSC")
      { %>

          <%-- <a href="MasterMaintainance.aspx?act=searchSSC">
               <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                   <i class="fa fa-search-minus fa-inverse"></i>
               </div>
           </a>
           <a href="MasterMaintainance.aspx?act=addSSC">
               <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                   <i class="fa fa-plus-circle fa-inverse"></i>
               </div>
           </a>--%>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group  has-success">
                    <label class="col-sm-3 control-label">Stone Clearity Code</label>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtStoneClearityCode" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-sm-3 control-label">Stone Shape Clearity</label>
                    <div class="col-sm-7">
                        <asp:TextBox runat="server" ID="txtStoneClearityName" CssClass="form-control" placeholder="Here Stone Shape Clearity Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-group" style="float: right">
                    <asp:Button ID="btnSSCSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" OnClick="btnSSCSearch_Click" />&nbsp;&nbsp;
                       <asp:Button ID="btnSSCSave" runat="server" Text="Save" CssClass="btn btn-primary-custom pull-right" OnClick="btnSSCSave_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvStoneClearity" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="StoneClearityId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvStoneClearity_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="StoneClearityCode" HeaderText="Code" />
                        <asp:BoundField DataField="StoneClearityName" HeaderText="Clearity Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("MasterMaintainance.aspx?act=editSSC&Id={0}",Eval("StoneClearityId")) %>";><i class="fa fa-edit" data-toggle="tooltip" data-placement="top" title="Edit"></i></a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("MasterMaintainance.aspx?act=delSSC&Id={0}",Eval("StoneClearityId")) %>','')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="top" title="Delete"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divNoDataSSC" runat="server">
            <table class="table table-bordered">
                <tr>
                    <th>No Record Found !!</th>
                </tr>
            </table>
        </div>




    </div>


    <%--<%}if(act=="StoneShapeClearity"||act=="list"||act=="searchSSC") 
              {%>
                <a href="MasterMaintainance.aspx?act=searchSSC">
                    <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                        <i class="fa fa-search-minus fa-inverse"></i>
                    </div>
                </a>
                <a href="MasterMaintainance.aspx?act=addSSC">
                    <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                        <i class="fa fa-plus-circle fa-inverse"></i>
                    </div>
                </a>
          
               <div class="row">
                   <div class="col-md-10 has-success form-group">
                       <asp:Label Class="col-md-3 control-laber" runat="server">Stone Shape Clearity</asp:Label>
                       <div class="col-md-6">
                           <asp:TextBox ID="txtSearchStoneSClearity" runat="server" placeholder="Search By Stone Shape Clearity Name" CssClass="form-control"></asp:TextBox>
                       </div>
                       <asp:Button ID="btnSSCSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" />
                   </div>
               </div>--%>
        <%} %>
</asp:Content>
