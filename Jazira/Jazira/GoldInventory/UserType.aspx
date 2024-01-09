<%@ Page Title="" Language="C#" MasterPageFile="~/GoldInventory/Main.Master" AutoEventWireup="true" CodeBehind="UserType.aspx.cs" Inherits="Jazira.GoldInventory.UserType" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <script type="text/javascript">
         function confirmAction(path, noPath) {
             if (confirm('Do want to Delete this data!')) {
                 window.location = path;
             }
             else {
                 window.location = noPath;
             }
         }
     </script>
    <script type="text/javascript">
        function confirmSubmit() {
            var agree = confirm("Do you really want to delete this item?");
            if (agree)
                return true;
            else
                return false;
        }
    </script>

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
                <i class="fa fa-user"></i>&nbsp; User Type
            </h3>
        </div>
        </div>
        <div class="col-md-8">
            <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                <li><a href="../About.aspx">Home</a> <span class="divider"></span></li>
                <li><a href="../General/GeneralDashBoard.aspx">Configuration</a> <span class="divider"></span></li>
                <li><a href="../Security/SecurityDashBoard.aspx">Security </a><span class="divider"></span></li>
                <li class="active"><a href="UserType.aspx?act=search">User Type</a></li>
            </ul>
        </div>
    </div>
     <div class="row-fluid">
            <hr class="hline" />
    </div>
    <div class="row">
        <div class="col-md-12  row-fluid-icon-modified" id="alert" runat="server">
            <div id="messaging_alert" runat="server" class="col-md-6 pull-left" visible="false">
                <% 
                    if ((Session["msgInfo"] != null) && Session["msgInfo"] != "")
                   { %>

                       <button data-dismiss="alert" runat="server" id="button_close" class="close" visible="false"><i class="fa fa-times"></i></button>
                <% Session["msgInfo"] = "";
                  }%>
                <strong>
                    <asp:Label ID="lblAlertMessage" runat="server" Text=""></asp:Label>
                </strong>
            </div>
           
            <a href="UserType.aspx?act=search">
                   <div class="btn btn-primary pull-right" data-toggle="tooltip" data-placement="top" title="View"> 
                       <i class="fa fa-search-minus fa-inverse"></i>
                   </div>
               </a>
               <a href="UserType.aspx?act=add">
                   <div class="btn btn-primary pull-right margin-one" data-toggle="tooltip" data-placement="top" title="Add">
                       <i class="fa fa-plus-circle fa-inverse"></i>
                   </div>
               </a>
        </div>
    </div>
            <% string act = Request.QueryString["act"];%>
              <%  if (act == "list" || act == "search")
                  {%>
              <div class="row">
                  <div class="col-md-12  row-fluid-icon-modified">
                      <div class="col-md-8 has-success form-group">
                          <asp:Label ID="Label1" class="col-sm-3 control-label" runat="server">User Type
                          </asp:Label>
                          <div class="col-sm-6">
                              <asp:TextBox runat="server" ID="txtTypeNameSearch" placeholder="Search User Type" CssClass="form-control"></asp:TextBox>
                          </div>
                          <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary-custom pull-left" OnClick="btnSearch_Click" />
                      </div>
                  </div>
              </div>
           <%} %>

    <% //string act = Request.QueryString["act"];
        if ((act == "add") || (act == "edit"))
        {%>
          <div class="row">
              <div class="col-md-10 form-group has-success">
                  <label class="col-md-3 control-label">*User Type</label>
                  <div class="col-md-7">
                      <asp:TextBox runat="server" ID="txtUserType" CssClass="form-control" placeholder="Here User Type"></asp:TextBox>
                  </div>
              </div>
          </div>
          <div class="row">
              <div class="form-group">
                  <div class="col-md-8">
                      <asp:Button ID="tbnSave" runat="server" Text="Save" CssClass="btn btn-primary-custom pull-right" OnClick="tbnSave_Click" />
                  </div>
              </div>
          </div>

    <%} if (act == "list" || act == "search")
          { %>
              <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="dgvUserType" runat="server" AutoGenerateColumns="False" 
                                CssClass="table table-hover"
                                Width="100%" DataKeyNames="UserTypeId"                                 
                                onpageindexchanging="dgvUserType_PageIndexChanging" AllowPaging="true" pagerStyle-CssClass="pagination" PageSize="8">
                                <Columns>
                                 <asp:BoundField DataField="UserTypeName" HeaderText="User Type Name" />
                                 <asp:BoundField DataField="Status" HeaderText="Status" />
                                 <asp:TemplateField HeaderText="Action" HeaderStyle-Width="170px" ShowHeader="false" ItemStyle-CssClass="hide-data-when-print" HeaderStyle-CssClass="hide-header-when-print">
                                     <ItemTemplate>
                                         <a href="<%#String.Format("UserType.aspx?act=edit&Id={0}", Eval("UserTypeId")) %>";><i class="fa fa-edit"></i></a> &nbsp;
                                         <a href="javascript:confirmAction('<%#String.Format("UserType.aspx?act=del&Id={0}", Eval("UserTypeId")) %>','')"><i class="fa fa-trash-o"></i></a>
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
