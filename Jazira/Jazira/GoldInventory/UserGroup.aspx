<%@ Page Title="" Language="C#" MasterPageFile="~/GoldInventory/Main.Master" AutoEventWireup="true" CodeBehind="UserGroup.aspx.cs" Inherits="Jazira.GoldInventory.UserGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function confirmAction(path, noPath) {
             if (confirm('Do, you want to  Delete This Data !')) {
                 window.location = path;
             }
             else {
                 window.location = noPath;
             }
         }
  
        $(document).ready(function (e) {
            $("#liUserGroup").addClass("active");
            $('#MainContent_MainContent_close').click(function (e) {
                $('#new').removeClass('active')
                $('.nav-custom li').removeClass('active')
            })
        });
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
                    <i class="fa fa-user"></i>&nbsp; User Group
                </h3>
                </div>
            </div>
            <div class="col-md-8">
                <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                    <li><a href="../About.aspx">Home</a> <span class="divider"></span></li>
                    <li><a href="../General/GeneralDashBoard.aspx">Configuration</a> <span class="divider"></span></li>
                    <li><a href="../Security/SecurityDashBoard.aspx">Security </a><span class="divider"></span></li>
                    <li class="active"><a href="UserGroup.aspx?act=search">User Group</a></li>
                </ul>
            </div>
        </div>
    <div class="row-fluid">
                <hr class="hline" />
    </div>
      
    <div class="row">
            <div id="alert" runat="server" class="col-md-12 row-fluid-icon-modified">
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

                <a href="UserGroup.aspx?act=search">
                    <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View" >
                        <i class="fa fa-search-minus fa-inverse"></i>
                    </div>
                </a>
                <a href="UserGroup.aspx?act=add">
                    <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                        <i class="fa fa-plus-circle fa-inverse"></i>
                    </div>
                </a>
            </div>
       </div>


       <% string act = Request.QueryString["act"];%>
          
      <% if(act=="list"||act=="search")
      { %>
       <div class="row">
           <div class="col-md-10 has-success form-group">
               <asp:Label Class="col-md-3 control-laber" runat="server">* User Group Name</asp:Label>
               <div class="col-md-6">
                   <asp:TextBox ID="txtSearchUserGroup" runat="server" placeholder="Search By Group Name" CssClass="form-control"></asp:TextBox>
               </div>
               <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" OnClick="btnSearch_Click"/>
           </div>
       </div>
    <%} %>
        <%  if((act=="add")||(act=="edit"))
          { %>

           <div class="row">
               <div class="col-md-10 form-group has-success">
                      <div class="form-group">
                           <label class="col-md-3 control-label" >* Group Name</label>
                            <div class="col-md-7">
                                <asp:TextBox runat="server" ID="txtUserGroupName" CssClass ="form-control" placeholder="Here User Group Name..."></asp:TextBox>
                            </div>
                     </div>
               </div>
           </div>

           <div class="row">
               <div class="col-xs-10 form-group has-success">
                      <div class="form-group">
                           <label class="col-md-3 control-label" >* Group Type</label>
                            <div class="col-md-7">
                                 <asp:DropDownList ID="ddlUserGroupType" runat="server" cssClass="form-control"  AutoPostBack="false">
                                 </asp:DropDownList>
                            </div>
                     </div>
               </div>
           </div>
          
         <div class="row">
               <div class="form-group">
                   <div class="col-md-8">
                       <asp:Button ID="tbnSave" runat="server" Text="Save" CssClass="btn btn-primary-custom pull-right" OnClick="tbnSave_Click"/>
                       <%--<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom" />--%>
                   </div>
               </div>
           </div>
    <%} if(act=="list"||act=="search")
      {%>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvUserGroup" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover" Width="100%"
                    DataKeyNames="UserGroupId" AllowPaging="true" PageSize="6" PagerStyle-CssClass="pagination"
                    OnPageIndexChanging="dgvUserGroup_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="UserGroupName" HeaderText="Group Name" />
                        <asp:BoundField DataField="UserTypeName" HeaderText="Type Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="170px" 
                            ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                            <ItemTemplate>
                                <a href="<%#String.Format("UserGroup.aspx?act=edit&Id={0}",Eval("UserGroupId")) %>";><i class="fa fa-edit"></i> </a>&nbsp;
                                <a href="javascript:confirmAction('<%#String.Format("UserGroup.aspx?act=del&Id={0}",Eval("UserGroupId")) %>','')"><i class="fa fa-trash-o"></i></a>
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
