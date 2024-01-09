<%@ Page Title="" Language="C#" MasterPageFile="~/General/General.Master" AutoEventWireup="true" CodeBehind="WorkingSection.aspx.cs" Inherits="Jazira.General.WorkingSection" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 col-xs-6">
            <div class="page-heading">
                <h3>
                    <i class="fa fa-th-list fa-lg"></i>&nbsp;Working Section
                </h3>
            </div>
        </div>
        <div class="col-md-6">
            <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent">
                <li><a href="../About.aspx">Home</a><span class="divider"></span></li>
                <li><a href="../GoldInventory/GoldInventoryDashBoard.aspx">Gold Dash</a><span class="divider"></span></li>
                <li><a href="../GoldInventory/GoldConfigurationDash.aspx">Configuration</a><span class="divider"></span></li>
                <li class="active"><a href="WorkingSection.aspx?act=search">Working Section</a></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <hr class="hline" />
    </div>
    <!--Message box and icon for add/view-->
    <div class="row">
        <div class="col-md-12 row-fluid-icon-modified" runat="server">
            <div class="alert" runat="server" id="alert" visible="false">
                <button class="close" id="button_close" data-dismiss="alert" visible="false"><i class="fa fa-times"></i></button>
                <strong>
                    <asp:Label runat="server" ID="lblMsgType" CssClass="pull-left" Text="Message Type"></asp:Label>!&nbsp;
                </strong>
                <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
            </div>
            <a href="WorkingSection.aspx?act=search">
                <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                    <i class="fa fa-search-minus fa-inverse"></i>
                </div>
            </a>
            <a href="WorkingSection.aspx?act=add">
                <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add" style="margin-right:3px;">
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
            <div class="form-group has-success">
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtSearchFormCode" CssClass="form-control" placeholder="Search By Form Code..."></asp:TextBox>
                </div>
                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary-custom pull-left" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12"></div>
    </div><br />
    <%} %>
    <%if(act=="add"||act=="edit")
      { %>
        <div class="form-horizontal">
            <div class="row">
                <div class="col-md-12">

                    <div class="form-group has-success">
                        <label class="col-md-2 control-label">*Code</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtWorkingSectionCode" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-2 control-label">*Working Section</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtWorkingSectionName" runat="server" CssClass="form-control" placeholder="Working Section Name..."></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>
        </div>
     <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label class="col-md-7"></label>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary-custom pull-left" OnClick="btnSave_Click"/>
                </div>
            </div>
        </div>

    <%}if(act=="list"||act=="search")
      { %>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="dgvWorkingSection" runat="server" AutoGenerateColumns="false"
                CssClass="table table-hover" Width="100%"
                DataKeyNames="WorkingSectionId" AllowPaging="true" PageSize="8" PagerStyle-CssClass="pagination-lg"
                OnPageIndexChanging="dgvWorkingSection_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="WorkingSectionCode" HeaderText="Code" />
                        <asp:BoundField DataField="WorkingSectionName" HeaderText="Working Sec. Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px"
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#string.Format("WorkingSection.aspx?act=edit&Id={0}",Eval("WorkingSectionId")) %>";><i class="fa fa-edit"></i> </a>&nbsp;
                                <a href="javascript:confirmAction('<%#string.Format("WorkingSection.aspx?act=del&Id={0}",Eval("WorkingSectionId")) %>','')"> <i class="fa fa-trash-o"></i></a>
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
