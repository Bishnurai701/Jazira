<%@ Page Title="" Language="C#" MasterPageFile="~/BarcodeManagement/Barcode.Master" AutoEventWireup="true" CodeBehind="BarcodeDashBoard.aspx.cs" Inherits="Jazira.BarcodeManagement.BarcodeDashBoard" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-5 col-xs-5">
            <div class="page-heading">
                <h3>
                    <i class="fa fa-calendar-o"></i>&nbsp;Barcode Management
                </h3>
            </div>
        </div>
        <div class="col-md-7">
            <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                <li><a href="../About.aspx">Home</a><span class="divider"></span></li>
                <li class="active"><a href="BarcodeDashBoard.aspx">BarcodeDashBoard</a></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <hr class="hline" />
    </div>
    <div class="row"> <!--frist row-->
        <div class="col-xs-4 col-md-3">
            <a href="#" class="gridboxsilver" data-toggle="tooltip" data-placement="bottom" title="SILVER MAIN MENU">
                <div class="silver">
                    <div class="col-md-12 btntext">Name</div>  <!--<div class="subtitle">Inventory Management</div>-->
                   
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="#" class="gridboxsilver" data-toggle="tooltip" data-placement="bottom" title="SILVER MAIN MENU">
                <div class="silver1">
                    <div class="col-md-12 btntext">Name</div> <!--<div class="subtitle">Inventory Management</div>-->
                    
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="#" class="gridboxsilver" data-toggle="tooltip" data-placement="bottom" title="SILVER MAIN MENU">
                <div class="silver2">
                    <div class="col-md-12 btntext">Name</div>  <!--<div class="subtitle">Inventory Management</div>-->
                   
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="#" class="gridboxsilver" data-toggle="tooltip" data-placement="bottom" title="SILVER MAIN MENU">
                <div class="silver3">
                    <div class="col-md-12 btntext">Name</div> <!--<div class="subtitle">Inventory Management</div>-->
                    
                </div>
            </a>
        </div>
    </div><!--frist row end-->
</asp:Content>
