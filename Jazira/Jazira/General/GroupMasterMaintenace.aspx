<%@ Page Title="" Language="C#" MasterPageFile="~/General/General.Master" AutoEventWireup="true" CodeBehind="GroupMasterMaintenace.aspx.cs" Inherits="Jazira.General.GroupMasterMaintenace" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--this is used javascript-->
     <script type="text/javascript">
         function confirmAction(path, noPath) {
             if (confirm('Are you sure, you want to execute this action???')) {
                 window.location = path;
             }
             else {
                 window.location = noPath;
             }
         }

         function HideLabel() {
             document.getElementById('<%= lblGridMessage.ClientID %>').style.display = "none";
        }
        setTimeout(HideLabel, 5000);
    </script>

    <script type="" language="javascript">
        function CallPrint(strid) {
            $('.hide-data-when-print').css({ 'display': 'none' });
            $('.hide-header-when-print').css({ 'display': 'none' });
            $('.logo-show-on-print').css({ 'display': 'block' });
            var prtContent = document.getElementById(strid);
            var WinPrint =
        window.open('', '', 'left=0,top=0,width=1000,height=800,toolbar=0,scrollbars=0,sta¬tus=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        } 

</script>

     <!--<script type="text/javascript">
         function confirmAction(path, noPath) {
             if (confirm('Are you sure, You want to execute this action???')) {
                 window.location = path;
             }
             else {
                 window.location = noPath;
             }
         }
         
    </script>-->
    <!--<script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                     '<img src="images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB'
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("dgvView");
            $.blockUI.defaults.css = {};
        });
    </script>-->

    <script type="text/javascript">

        $(document).ready(function (e) {
            $("#liUserType").addClass("active");
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
     <script type="text/javascript">
         /*This is for popover*/
         !function ($) {

             "use strict"

             var Popover = function (element, options) {
                 this.$element = $(element)
                 this.options = options
                 this.enabled = true
                 this.fixTitle()
             }

             /* NOTE: POPOVER EXTENDS BOOTSTRAP-TWIPSY.js
                ========================================= */

             Popover.prototype = $.extend({}, $.fn.twipsy.Twipsy.prototype, {

                 setContent: function () {
                     var $tip = this.tip()
                     $tip.find('.title')[this.options.html ? 'html' : 'text'](this.getTitle())
                     $tip.find('.content p')[this.options.html ? 'html' : 'text'](this.getContent())
                     $tip[0].className = 'popover'
                 }

             , hasContent: function () {
                 return this.getTitle() || this.getContent()
             }

             , getContent: function () {
                 var content
                  , $e = this.$element
                  , o = this.options

                 if (typeof this.options.content == 'string') {
                     content = this.options.content
                 } else if (typeof this.options.content == 'function') {
                     content = this.options.content.call(this.$element[0])
                 }
                 return content
             }

             , tip: function () {
                 if (!this.$tip) {
                     this.$tip = $('<div class="popover" />')
                       .html(this.options.template)
                 }
                 return this.$tip
             }

             })


             /* POPOVER PLUGIN DEFINITION
              * ======================= */

             $.fn.popover = function (options) {
                 if (typeof options == 'object') options = $.extend({}, $.fn.popover.defaults, options)
                 $.fn.twipsy.initWith.call(this, options, Popover, 'popover')
                 return this
             }

             $.fn.popover.defaults = $.extend({}, $.fn.twipsy.defaults, {
                 placement: 'right'
             , template: '<div class="arrow"></div><div class="inner"><h3 class="title"></h3><div class="content"><p></p></div></div>'
             })

         }(window.jQuery || window.ender);

</script>
       
    <script type="text/javascript">/*this is dropdaown menu*/
        !function ($) {

            "use strict"

            /* DROPDOWN PLUGIN DEFINITION
             * ========================== */

            $.fn.dropdown = function (selector) {
                return this.each(function () {
                    $(this).delegate(selector || d, 'click', function (e) {
                        var li = $(this).parent('li')
                          , isActive = li.hasClass('open')

                        clearMenus()
                        !isActive && li.toggleClass('open')
                        return false
                    })
                })
            }

            /* APPLY TO STANDARD DROPDOWN ELEMENTS
             * =================================== */

            var d = 'a.menu, .dropdown-toggle'

            function clearMenus() {
                $(d).parent('li').removeClass('open')
            }

            $(function () {
                $('html').bind("click", clearMenus)
                $('body').dropdown('[data-dropdown] a.menu, [data-dropdown] .dropdown-toggle')
            })

        }(window.jQuery || window.ender);
    </script>

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
   
   <%-- <script type="text/javascript"> 	
        $('#chkSafeAcc').change(function () {
            if ($(this).attr("checked")) {

                $('#showHide').fadeIn();
                return;
            }
            $('#showHide').fadeOut();
        });

 </script>--%>
    <%--<script type="text/javascript"> 	
        $(document).ready(function(){
            $('#chkSafeAcc').change(function(){
                var checked = $(this).attr('checked');
                if (checked) { 
                    $('#showHide').show();             
                } else {
                    $('#showHide').hide();
                }
            });        
        });​
 </script>--%>
   <%--<script type="text/javascript">
       $(document).ready(function () {
           $('#<%=chkSafeAcc.ClientID%>').click(function () {
               var checkval = $('#<%=chkSafeAcc.ClientID%>[asp:checkbox]:checked').val();
               if (checkval == 1) {
                   $('#ShowHide').css("display", "block");

                   $('#<%=txtSerialNo.ClientID%>').val('');
                   $('#<%=txtNextMonthSerNo.ClientID%>').val('');
                   $('#<%=txtFirstLetter.ClientID%>').val('');
                   $('#<%=chkMainSafe.ClientID%>').val('');
                   $('#<%=txtUniqueID.ClientID%>').val('');
                   $('#<%=txtSerialNo.ClientID%>').focus();
               }
               else
               {
                   $('ShowHide').css("display", "none");
               }
           });
       });
    </script>--%>

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
.gridrow 
    {
      padding-left:70px;
      border-radius: 20px 20px 20px 20px;
-moz-border-radius: 20px 20px 20px 20px;
-webkit-border-radius: 20px 20px 20px 20px;
border: 1px solid #808080;

    }
#ddlWSection
 {
        /*margin: 0 15px 0 0;*/
        /*direction: rtl;*/
        /*max-height: 200px;*/
        /*overflow-y: scroll;
        position: relative; 
        z-index:18000;  
        overflow: -moz-scrollbars-vertical;*/
         /*onmousedown="this.size=7;" 
          onfocusout="this.size=1;" 
          ondblclick="this.size=1;"
          AppendDataBoundItems="True"
          AutoPostBack="true"*/
 }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 col-xs-6">
            <div class="page-heading">
                <h3>
                    <i class="fa fa-th-list fa-lg"></i>&nbsp;Group Master Maintenance
                </h3>
            </div>
        </div> 
        <div class="col-md-6">
            <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color:transparent">
                <li><a href="../About.aspx">Home</a><span class="divider"></span></li>
                <li ><a href="../GoldInventory/GoldInventoryDashBoard.aspx">Gold Inventory</a><span class="divider"></span></li>
                <li class="active"><a href="GroupMasterMaintenace.aspx?act=search">Group Master</a></li>
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
            
            <a href="GroupMasterMaintenace.aspx?act=search">
                   <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View"> 
                       <i class="fa fa-search-minus fa-inverse"></i>
                   </div>
               </a>
               <a href="GroupMasterMaintenace.aspx?act=add">
                   <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                       <i class="fa fa-plus-circle fa-inverse"></i>
                   </div>
               </a>
        </div>
    </div>
    <%string act = Request.QueryString["act"]; %>
    <%if(act=="list"||act=="search") 
      {%>
    <div class="row">
        <div class="col-md-10">
            <div class="form-group has-success" >
                <%--<label class="col-sm-2 control-label">*Group No.</label>--%> 
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtGroupNoSearch" CssClass="form-control" placeholder="Search By Group No..."></asp:TextBox>
                </div>
               <%-- <label class="col-sm-2 control-label">*Section</label> --%>
                <div class="col-sm-4">
                    <asp:DropDownList runat="server" ID="ddlSectionSearch" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                    <%--<asp:TextBox ID="txtSectionSearch" runat="server" CssClass="form-control" placeholder="Search By Section..."></asp:TextBox>--%>
                </div>
                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary-custom pull-left"></asp:Button>
            </div>
        </div>
    </div>

    <%} %>
    <%if((act=="add")||(act=="edit")) 
      {%>
   
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group has-success">
                    <label class="col-xs-2 control-label">*Group No.</label>
                    <div class="col-xs-2">
                        <asp:TextBox ID="txtGroupNo" runat="server" CssClass="form-control" placeholder="Group No."></asp:TextBox>
                    </div>
                    <label class="col-xs-2 control-label" style="color: red">Related Group</label>
                    <div class="col-xs-2">
                        <asp:TextBox ID="txtRelatedGroup" runat="server" CssClass="form-control" placeholder="Related Group.."></asp:TextBox>
                    </div>
                    <div class="col-xs-2 checkbox" style="color: red">
                        <asp:CheckBox runat="server" ID="chkDisabledGroup" />Disabled Group
                    </div>
                </div>
          
                <%--this is left column--%>
                <div class="col-md-6">
                    <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Name Desc.</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtGroupDesc" runat="server" CssClass="form-control" placeholder="Group Description.."></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Section</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Working Sec.</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlWSection" runat="server" CssClass="form-control" ></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Salary Type</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSalaryType" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*Salary.</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Salary..."></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-4 control-label">*CARAT.</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCARAT" runat="server" CssClass="form-control" placeholder="875.00."></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group has-success">
                          <label class="col-md-4 control-label"></label>
                        <div class="col-sm-8" style="color:#3c7642">
                           <strong> <asp:CheckBox runat="server" ID="chkIDRequired" />&nbsp;&nbsp;ID Required</strong>
                        </div>
                    </div>
                </div>

               <%-- this is right column--%>
                <div class="col-xs-6"  runat="server">
                    <strong><asp:CheckBox runat="server" ID="chkSafeAcc" AutoPostBack="true" OnCheckedChanged="chkSafe"/>&nbsp;&nbsp;SAFE A/C</strong>
                </div>

                <div class="col-md-6" id="ListaEmOutrosDocumentos" style="background-color:#dce5e0;display:none" runat="server">
                      <label class="control-label"></label>                                             <%--this is just for gape maintain--%>
                    <div class="form-group has-success">
                        <label class="col-md-5 control-label">*Serial No..</label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="form-control" placeholder="Serial No..."></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-5 control-label">*Nxt month S.No.</label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtNextMonthSerNo" runat="server" CssClass="form-control" placeholder="875.00."></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-md-5 control-label">*First Letter.</label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtFirstLetter" runat="server" CssClass="form-control" placeholder="First Letter."></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12">
                       <strong> <asp:CheckBox runat="server" ID="chkMainSafe" />&nbsp;&nbsp;Main SAFE*</strong>
                    </div>
                     <div class="form-group has-success">
                        <label class="col-md-5 control-label">*Unique ID.</label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtUniqueID" runat="server" CssClass="form-control" placeholder="Unique ID..,"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group has-success">
                    <label class="col-md-2 control-label">*Productive Code.</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtProdctive" runat="server" CssClass="form-control" placeholder="Code."></asp:TextBox>
                    </div>
                    <div class="col-xs-7">
                        <asp:TextBox ID="txtProductDesc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group has-success" style="color:#3c7642">
                    <label class="col-md-2 control-label">*Type</label>
                    <div class="col-md-2">
                        <strong> <asp:RadioButton runat="server" ID="rbProsuctive"  GroupName="Productive"/>&nbsp;&nbsp;Productive</strong>
                    </div>
                 <div class="col-md-3">
                        <strong> <asp:RadioButton runat="server" ID="rbNonProductive"  GroupName="Productive"/>&nbsp;&nbsp;Non-Productive</strong>
                    </div>
                </div>
         </div>
        <div class="row">
            <h4 style="color:#3c7643">
                <hr class="hline" style="width:290px;color:red; float:left" /><i class="fa fa-check-square-o">&nbsp;&nbsp;&nbsp;Default Type Code</i>
            </h4>
            
        </div>
        <div class="row ">
            <div class="col-md-11 gridrow">
                <div class="col-md-1"></div><br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="row">
                                <asp:Label runat="server" ID="lblGridMessage" Text="" CssClass="label label-danger" ForeColor="White"></asp:Label>
                            </div>
                            <asp:GridView runat="server" ID="dgvGroupCodeNew" AutoGenerateColumns="false" CssClass="table-bordered table table-condensed table-hover"
                                Width="90%" OnRowDeleting="dgvGroupCodeNew_RowDeleting" DataKeyNames="GroupCodeId" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Safe No.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSafeNo" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receipt Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRecCode" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delivery Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDelCode" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <div class="btn btn-group pull-right">
                                                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success btn-small" Text="+"
                                                    Style="font-size: large" CommandField="Update" Width="45px"  OnClick="addGridRow"/>
                                                <asp:Button runat="server" ID="btnRemove" CssClass="btn btn-danger btn-small" Text="-"
                                                    Style="font-size: large" Width="45px" CommandName="Delete" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
 </div>
    <div>
        <label class="col-md-12"></label>
    </div>
    <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label class="col-md-2"></label>
                    <asp:Button ID="btnSave"  runat="server" Text="Save" CssClass="btn btn-primary-custom pull-left" OnClick="btnSave_Click"/>&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary-custom"/>
                </div>
            </div>
        </div>
   





        <!--this code is being changed-->
        <%--
        <div class="row">
            <div class="col-md-8">
                <div class="row">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="divlabelgrid" ForeColor="Red"></asp:Label>
                </div>
                <asp:UpdatePanel ID="updatepanell" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="dgvGroupCode" runat="server"  DataKeyNames="GroupCodeId" AutoGenerateColumns="false"
                            AllowPaging="true" ShowFooter="true" CssClass="table table-hover table-bordered"
                            OnPageIndexChanging="dgvGroupCode_PageIndexChanging" OnRowCommand="dgvGroupCode_RowCommand"
                             OnRowUpdating="dgvGroupCode_RowUpdating" OnRowCancelingEdit="dgvGroupCode_RowCancelingEdit"
                             OnRowDeleting="dgvGroupCode_RowDeleting" OnRowEditing="dgvGroupCode_RowEditing" 
                             PageSize="3"  style="background-color:#f0f0f0;width:810px" >
                            <Columns>
                                <asp:TemplateField HeaderText="GroupCodeId">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGroupCodeId" runat="server" Text='<%#Eval("GroupCodeId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtGroupCodeId" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Safe No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSafeNo" runat="server" Enabled="true"  Text='<%#Eval("SafeNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSafeNo" runat="server" Text='<%#Eval("SafeNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtSafeNo" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Receipt Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecCode" runat="server" Text='<%#Eval("RecCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRecCode" runat="server" Text='<%#Eval("RecCode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtRecCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delivery Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDelCode" runat="server" Text='<%#Eval("DelCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDelCode" runat="server" Text='<%#Eval("DelCode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtDelCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Action">
                                   <EditItemTemplate>
                                       <asp:LinkButton ID="lblUpdate" runat="server" CommandName="Update"><i class="fa fa-refresh" data-toggle="tooltip" data-placement="left" title="Update"></i></asp:LinkButton>&nbsp;&nbsp;
                                       <asp:LinkButton ID="lblCancel" runat="server" CommandName="Cancel"><i class="fa fa-reply-all" data-toggle="tooltip" data-placement="right" title="Cancel"></i></asp:LinkButton>
                                   </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblEdit" runat="server" CommandName="Edit"><i class="fa fa-pencil-square-o"data-toggle="tooltip" data-placement="left" title="Edit"></i></asp:LinkButton>&nbsp;&nbsp;
                                       <asp:LinkButton ID="lblDelete" runat="server" CommandName="Delete"  OnClientClick="return confirmAction('')"><i class="fa fa-trash-o" data-toggle="tooltip" data-placement="right" title="Delete"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lblNew" runat="server" CommandName="New"><i class="fa fa-plus-circle" data-toggle="tooltip" data-placement="top" title="Add New">Add</i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>






            <%-- <asp:GridView ID="dgvDetail" runat="server" AutoGenerateColumns="false"
                DataKeyNames="ddId" CssClass="table-bordered table table-condensed table-hover">

                <Columns>
                    <asp:TemplateField HeaderText="SAFE No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtSafeNo" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="SAFE No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDelCode" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="SAFE No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRecCode" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="btn-group" align="center">
                                <asp:Button runat="server" ID="bntAdd" CssClass="bnt btn-success" Text="+" Style="font-size:large"
                                     Width="50px" />
                                <asp:Button runat="server" ID="bntRemove" CssClass="bnt btn-danger" Text="-" style="font-size:large"
                                    Width="50px"  />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
           
       
         

    <%} %>



</asp:Content>
