<%@ Page Title="" Language="C#" MasterPageFile="~/Security/Security.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Jazira.Security.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         $(function () {
             $('[data-toggle="tooltip"]').tooltip()
         })
    </script>
    <script type="text/javascript">
        $('input:text').not(':first').on('blur', function () {
            var value = this.value;
            if (value.length) {
                $('input:text').not(this).each(function () {
                    if (this.value == value) {
                        alert('Error');
                        return false;
                    }
                });
            }
        });
    </script>
    <script type="text/javascript">
        function confirmAction(path, noPath) {
            if (confirm('Are you sure, You want to execute this action???')) {
                window.location = path;
            }
            else {
                window.location = noPath;
            }
        };
    </script>


    <style type="text/css">
 .margin-one
{
    margin:2px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-4 col-xs-4">
                <div class="page-heading">
                <h3>
                    <i class="fa fa-user"></i>&nbsp; User 
                </h3>
                </div>
            </div>
            <div class="col-md-8">
                <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                    <li><a href="../About.aspx">Home</a> <span class="divider"></span></li>
                    <li><a href="../General/GeneralDashBoard.aspx">Configuration</a> <span class="divider"></span></li>
                    <li><a href="../Security/SecurityDashBoard.aspx">Security </a><span class="divider"></span></li>
                    <li class="active"><a href="User.aspx">User</a></li>
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
                    <asp:Label runat="server" ID="lblMsgType" Text="Message"></asp:Label>
                </strong>
                <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
            </div>
            <a href="User.aspx?act=search">
                <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View">
                    <i class="fa fa-search-minus fa-inverse"></i>
                </div>
            </a>
            <a href="User.aspx?act=add">
                <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                    <i class="fa fa-plus-circle fa-inverse"></i>
                </div>
            </a>

             <a href="User.aspx?act=permission">
                <div class="permission" runat="server" visible="false">
                    
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
                    <asp:TextBox runat="server" ID="txtSearchUserName" CssClass="form-control" placeholder="Search By User Name.."></asp:TextBox>
                </div>
                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary-custom pull-left" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
    <%} %>
    <%if(act=="add"|| act=="edit")
      { %>
        <div class="form-horizontal">
            <div class="row">
                <div class="col-md-11 loginborder"><div class="row"></div><br />
                    <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Code</label> 
                        <div class="col-md-4">
                            <asp:TextBox ID="txtUserCode" runat="server" CssClass="form-control" placeholder="Your User Code Here..."></asp:TextBox>
                        </div>
                    </div>

                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*User Name</label> 
                        <div class="col-md-5">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Your User Name Here..."></asp:TextBox>
                        </div>
                    </div>

                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Super User</label> 
                        <div class="col-md-5">
                            <asp:RadioButton runat="server" ID="rbtSuperYes" GroupName="Super" />&nbsp;&nbsp;Yes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton runat="server" ID="rbtSuperNo" GroupName="Super" />&nbsp;&nbsp;No
                        </div>
                    </div>

                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*LoginID</label> 
                        <div class="col-md-5">
                            <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control" placeholder="Your User LoginID Here..."></asp:TextBox>
                        </div>
                    </div>
                    <%if(act=="add") //this is hide if edit page and if add display
                      { %>
                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Password</label> 
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPassword"  runat="server" CssClass="form-control"  TextMode="Password" Text="#" placeholder="Here Password"></asp:TextBox>
                        </div>
                    </div>

                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Confirm Password</label> 
                        <div class="col-md-5">
                            <asp:TextBox ID="txtConfirmPassword"  runat="server" CssClass="form-control"  TextMode="Password" Text="#" placeholder="Confirm Password"></asp:TextBox>
                        </div>
                    </div>
                <%} %>
                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">Allow User To</label> 
                        <div class="col-md-5">
                            <asp:CheckBox runat="server" ID="chkJobView" />&nbsp;&nbsp;Job View&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chkGroupView"/>&nbsp;&nbsp;Group View
                        </div>
                    </div>

                    <div class="form-group has-success">
                        <label class="col-md-4 control-label">*User Group</label> 
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlUserGroup" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Is Active</label> 
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbtActive" GroupName="Active" runat="server" />&nbsp;&nbsp;Yes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtInactive" GroupName="Active" runat="server" />&nbsp;&nbsp;No
                        </div>
                    </div>

                     <div class="form-group has-success">
                        <label class="col-md-4 control-label"></label> 
                        <div class="col-md-5">
                           <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    <%} if(act=="changepassword") //-----this is for to changing password----
      {%>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Old Password</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password" Text="#"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*New Password</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" Text="#"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-md-3 control-label">*Confirm Password</label>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtNewConfrim" runat="server" CssClass="form-control" TextMode="Password" Text="#"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group has-success">
                    <label class="col-md-3 control-label"></label>
                    <div class="col-md-5">
                        <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-primary" Text="Change" OnClick="btnChangePassword_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} if(act=="list"||act=="search") 
      {%>
    <div class="row"></div><br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="dgvUser" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover" Width="100%"
                        DataKeyNames="UserId" AllowPaging="true" PageSize="6" PagerStyle-CssClass="pagination"
                        OnPageIndexChanging="dgvUser_PageIndexChanging" onrowcommand="dgvUser_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UserCode" HeaderText="User Code" />
                            <asp:BoundField DataField="LoginName" HeaderText="User ID" />
                            <asp:BoundField DataField="UserName" HeaderText="Name" />
                            <asp:BoundField DataField="UserGroupName" HeaderText="Group" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="200px"
                                                ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                                <ItemTemplate>
                                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CommandName="ChangePassword" CssClass="btn btn-primary divgridbutton btn-small" BorderStyle="None" />
                                    <a href="<%#string.Format("User.aspx?act=edit&Id={0}",Eval("UserId")) %>"; data-toggle="tooltip" data-placement="top" title="Edit"> <i class="fa fa-edit"></i></a>&nbsp;
                                    <a href="javascript:confirmAction('<%#String.Format("User.aspx?act=del&Id={0}",Eval("UserId")) %>','')" data-toggle="tooltip" data-placement="top" title="Delete">  <i class="fa fa-trash-o"></i></a>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="divNoData" runat="server">
        <table class="table table-bordered">
            <tr>
                <th>No Recoed Found !!</th>
            </tr>
        </table>
    </div>

    <%} %>


</asp:Content>
