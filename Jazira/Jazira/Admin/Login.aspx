<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jazira.Admin.Login1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function calendarShown(sender, args) {
            sender._popupBehavior._element.style.zIndex = 10005;
        }

        function HideLabel() {
            document.getElementById('<%= lblMessage.ClientID %>').style.display = "none";
  }
  setTimeout(HideLabel, 5000);


  function scrolling_edited() {

      $("html, body").animate({ scrollTop: $('.showAfterData').offset().top }, "slow");
      return false;
  }

</script>

    <style type="text/css">
        body {
        background-color:#dedede;
    }
    .img-responsive {
    display: block;
    max-width: 100%;
    height: auto;
    margin: auto;
    }
    .panel {
        border-radius: 33px 33px 33px 33px;
        -moz-border-radius: 33px 33px 33px 33px;
        -webkit-border-radius: 33px 33px 33px 33px;
        border: 0px solid #000000;
        margin-bottom: 20px;
        background-color: rgba(255, 255, 255, 0.75);
        -webkit-box-shadow: -1px 0px 24px 11px rgba(193,199,199,1);
        -moz-box-shadow: -1px 0px 24px 11px rgba(193,199,199,1);
        box-shadow: -1px 0px 24px 11px rgba(193,199,199,1);
    }
.row-fluid 
{
    height:auto;
}
.loginlogo 
    {
      color:red;
    }
 .loginlogo h3 
        {
        padding-left:10px;
        font-family:'Arial Black','Bold';
        font-size:25px;
        }
  .wrapper 
        {
         padding-top:130px;
         padding-left:98px;
        }
        /*.photo 
        {
            height:150px;
            width:150px;
            background:url("../image/IconWeman.ico") no-repeat;
            border-radius: 200px 200px 200px 200px;
            -moz-border-radius: 200px 200px 200px 200px;
            -webkit-border-radius: 200px 200px 200px 200px;
            border: 1px solid #000000;
        }*/
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
                <div class="row wrapper">
                    <div class="col-md-5 col-md-offset-3">
                        <div class="panel"><!--panel-default-->
                            <div class="panel-heading">                                
                                <div class="row-fluid loginlogo">
                                 <h3> <i class="fa fa-lock"></i>&nbsp;Sign In</h3>
                                    <!--<img src="image/IconSecurity1.ico" class="img-responsive" alt="Conxole Admin" style="height:20px; width:90px;"/>-->
                                </div>
                            </div>
                            <div class="panel-body"><!--panel-body-->
                                <form accept-charset="UTF-8" role="form" class="form-signin">
                                    <fieldset>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-user fa-fw"></i></span>
                                                <asp:TextBox runat="server" class="form-control" placeholder="Username" ID="txtUserName" type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                                                <asp:TextBox runat="server" class="form-control" placeholder="Password" ID="txtPassword" type="password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                                <asp:TextBox runat="server" class="form-control"  ID="txtDate" type="date" placeholder="dd/mm/yyyy" ForeColor="#cc9900">
                                                </asp:TextBox>
                                               <%-- <cc1:CalendarExtender CssClass="CalendarExtender" ID="endtrydate" runat="server" TargetControlID="txtDate"></cc1:CalendarExtender>--%>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" class="btn btn-success btn-block" ValidationGroup="login" type="Sign in" ID="btnLogin" value="Login" Text="Login in" Width="80px" OnClick="btnLogin_Click" />

                                        <div style="padding-left: 50px; color: red; padding-top: -50px;">
                                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                        </div>

                                    </fieldset>
                                </form>
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
