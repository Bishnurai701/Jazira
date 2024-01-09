<%@ Page Title="" Language="C#" MasterPageFile="~/GoldInventory/Main.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Jazira.GoldInventory.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
         function confirmAction(path, noPath) {
             if (confirm('Are you sure, you want to execute this action???')) {
                 window.location = path;
             }
             else {
                 window.location = noPath;
             }
         }
    </script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $("#liUserGroup").addClass("active");
            $('#MainContent_MainContent_close').click(function (e) {
                $('#new').removeClass('active')
                $('.nav-custom li').removeClass('active')
            })
        });
    </script>
  <div class="row">
        <div class="col-md-6 col-xs-6">
            <h3>
              <i class="fa fa-male"></i>&nbsp; Member Receipt
            </h3>
        </div>
        <div id="alert" runat="server" class="col-md-6 col-xs-6">
            <div id="divMsg" runat="server" class="alert alert-info pull-right">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <strong>
                    <asp:Label runat="server" ID="lblMsgType" CssClass="pull-left" Text="Message Type"></asp:Label>
                    &nbsp;!
                    &nbsp; </strong>

                <asp:Label runat="server" ID="lblMsg" Text="Message"></asp:Label>
            </div>
        </div>
    </div>
    <hr/>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
               <%-- <div class="entry-form" id="entry-form">--%>
                   <%-- <div class="row"></div>--%>
                    <div class="form-group">
                        <label class="col-sm-4 control-label" >Member Name</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlMemberName" runat="server" cssClass="form-control"  AutoPostBack="false"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group">
                        <label class="col-sm-4 control-label" >Charge</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="tctCharge" runat="server" cssClass="form-control" placeholder="Charge" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 control-label" >Duration</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDuration" runat="server" cssClass="form-control" placeholder="Duration" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 control-label" >Discount</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDiscount" runat="server" cssClass="form-control" placeholder="Discount" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 control-label" >Total Amount</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTotalAmount" runat="server" cssClass="form-control" placeholder="Total Amount" ></asp:TextBox>
                        </div>
                    </div>
                <%--this is I have test of project by Bishnu Khaling--%>
                <div class="form-group form-group-lg has-success has-feedback">
                    <label class="col-sm-4 control-label">Input with success</label>
                    <div class="col-sm-8">
                        <asp:Textbox runat="server" CssClass="form-control" id="inputSuccess1"/>
                        <span class="glyphicon glyphicon-ok form-control-feedback"></span>
                    </div>
                </div>

                <%--this is for testing colume wire breakbye Bishnu Khaling--%>
                <div class="row">
                     <label class="col-sm-4 control-label">Input colume</label>
                    <div class="col-xs-2">
                        <asp:TextBox ID="dd" runat="server" class="form-control" placeholder="DDr"/>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox ID="MM" runat="server" class="form-control" placeholder="MMr"/>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox ID="YYYY" runat="server" class="form-control" placeholder="YYYYr"/>
                    </div>
                </div>

               <%-- <div class="btn btn-group open">
                    <a class="btn btn-primary" href="#"><i class="fa fa-user fa-fw"></i>User</a>
                    <a class="btn btn-primary dropdown-toggle" data-toggle="dropdown" href="#">
                        <span class="fa fa-caret-down"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="#"><i class="fa fa-pencil fa-fw"></i>Edit</a></li>
                        <li><a href="#"><i class="fa fa-trash-o fa-fw"></i>Delete</a></li>
                        <li><a href="#"><i class="fa fa-ban fa-fw"></i>Ban</a></li>
                        <li class="divider"></li>
                        <li><a href="#"><i class="i"></i>Make admin</a></li>
                    </ul>
                </div>--%>


                   <%-- <div class="form-group">
                        <div class="col-sm-10">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary pull-right" Text="Save" OnClick="btnSave_Click"></asp:Button>
                        </div>
                    </div>--%>
              </div>
            
             <%-- <div class="form-group">
              <div class="col-sm-10">
               <asp:GridView ID="gdvMemberReceiptList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="table" DataKeyNames="MemberReceiptID" PagerStyle-CssClass="pagination" PageSize="10"
                EmptyDataText="NO DATA FOUND" 
                onpageindexchanging="gdvMemberReceiptList_PageIndexChanging" AllowPaging="True">
                <Columns>
                                <asp:BoundField DataField="MemberID" ReadOnly="true" HeaderText="Member ID" />
                                <asp:BoundField DataField="Charge" ReadOnly="true" HeaderText="Charge" />
                                <asp:BoundField DataField="Duration" ReadOnly="true" HeaderText="Duration" />
                                <asp:BoundField DataField="Discount" ReadOnly="true" HeaderText="Discount" />
                                <asp:BoundField DataField="TotalAmount" ReadOnly="true" HeaderText="TotalAmount" />
                                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="60px" HeaderText="Delete"
                        ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                        <ItemTemplate>
                    <a href="<%# String.Format("MemberReceipt.aspx?act=edit&MemberReceiptID={0}", Eval("MemberReceiptID")) %>";><i class="fa fa-edit"></i></a>
                    <a href="javascript:confirmAction('<%# String.Format("MemberReceipt.aspx?act=del&MemberReceiptID={0}", Eval("MemberReceiptID")) %>','')"><i class="fa fa-trash-o"></i></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
</div>
                </div>--%>
            </div>

            

        <%--</div>--%>
    </div>
    
</asp:Content>
