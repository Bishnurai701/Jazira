<%@ Page Title="" Language="C#" MasterPageFile="~/GoldInventory/Main.Master" AutoEventWireup="true" CodeBehind="MaintenaceDashBoard.aspx.cs" Inherits="Jazira.GoldInventory.MaintenaceDashBoard" %>
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

    <style type="text/css">
  .gridiconbox
         {
     float:left;
    min-width:50px !important;
    width:170px;       /*140px*/
    height:190px;    /*140px*/
    border:1.5px solid #ddd;/*solid 2px #A9CF48*/
    border-radius: 15px;   
    -moz-border-radius: 15px;
    -webkit-border-radius: 15px;      
    transition:margin-top 1s, box-shadow 1s;    
   -webkit-transition:margin-top 1s, box-shadow 1s;  
   transition-delay:.5s;
    -webkit-transition-delay:.5s;
     background-color:transparent;
    /*background: rgb(252,255,244);*/
    position:relative;
    padding-left:2px;
    margin:20px 0px 1px 0px;  
        }
  gridiconbox-medium
  {
          height:100px !important;
          padding-bottom:5px;
  }
  .gridiconbox-small
  {
          height:60px !important;
          padding:3px;
          vertical-align:middle;
  }
  
  .gridiconbox:hover
  {    
    margin-top:0px;   
    box-shadow:0 0 5px #A9CF48;
  }
              
  .gridiconbox:hover .subtext
  {
    display:block;
   
  }
.Inventory {
    float:none;
    /*background:url(../image/IconInvetory.ico) no-repeat;*/
    background-position:center center;
    width:100%;
    height:100%;
    clear:both;  
    border-image-source:inherit;
    -moz-border-radius: 10px;
    -webkit-border-radius: 10px;
    border-radius: 10px;
        }
.btntext {
  font-family:Calibri;
  line-height:20px;
  padding-top:0px;    
  position:relative; 
  font-weight: bold;
  font-size: 1.2em; /*0.9em*/
  text-align:center;      
  color: #000000;
  text-shadow: 0px 1px 8px rgba(61, 122, 59, 0.98);
}
        
.subtitle {
   
   font-size:0.7em;  
   text-align:center;
   display:none;     
   padding-top:0px; 
   /*top:px;*/  
   padding-left:1px;
   padding-right:1px;
   font-weight:bold;
   
    white-space:nowrap; 
    overflow:hidden;
    text-overflow:ellipsis;
        }
a:hover {
       text-decoration:none !important;   
       border-color :#027be4;  /*#ec5e00 here i amd changing some new over*/ 
        }
a:hover .subtitle 
{
    display:block;
    overflow:visible;
    /*z-index:100;*/
}
.general:hover
{
    background:url("") no-repeat scroll  -175px 0 #fff  !important;
    height:174px;
    width:175px;
    float:left;
    display:block;
  }
 #Main 
       {
    height:460px;
    background-color:#d7effc;/*#a4ceda*/
    border-radius: 9px 9px 9px 9px;
    -moz-border-radius: 9px 9px 9px 9px;
    -webkit-border-radius: 9px 9px 9px 9px;
    border: 0px solid #000000;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-5 col-xs-5">
            <div class="page-heading">
                <h3>
                    <i class="fa fa-th fa-lg"></i>&nbsp;MAINTENANCE MENU
                </h3>
            </div>
        </div>
        <div class="col-md-7">
            <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                <li><a href="../About.aspx">Home</a> <span class="divider"></span></li>
                <li><a href="GoldInventoryDashBoard.aspx">Gold Inventory</a><span class="divider"></span></li>
                <li class="active"><a href="MaintenaceDashBoard.aspx">Maintenance Menu</a></li>
            </ul>
        </div>
    </div>
    <div class="row">
          <hr class="hline" />
    </div>

    <div class="row"> <%--<this is first row of dashboard>--%>
        <div class="col-xs-5 col-md-4">
            <a href="MenuDashBoard.aspx" class="gridiconbox" data-toggle="tooltip" data-placement="bottom" title="SAFE BILL DETAILS"><%--thumbnail--or -- user defined scc class --gridiconbox--%>
                <div class="Inventory">
                    <div class="col-md-12 btntext">SAFE BILL</div>
                    <img src="image/IconSafeBill.ico" class="img-responsive" />
                    <%--<div class="subtitle">Inventory Management</div>--%>
                </div>
            </a>
        </div>
        <div class="col-xs-5 col-md-4">
            <a href="MaintenaceDashBoard.aspx" class="gridiconbox" data-toggle="tooltip" data-placement="bottom" title="MAINTENANCE DETAILS">
                <div class="Inventory">
                    <div class="col-md-12 btntext">MAINTENANCE</div>
                    <img src="image/IconMaintenance.ico" class="img-responsive" />
                    <%--<div class="subtitle">Inventory Management</div>--%>
                </div>
            </a>
        </div>
        <div class="col-xs-5 col-md-4">
            <a href="CastingDashBoard.aspx" class="gridiconbox" data-toggle="tooltip" data-placement="bottom" title="CASTING SECTION DETAILS">
                <div class="Inventory">
                    <div class="col-md-12 btntext">CASTING SECTION</div>
                    <img src="image/IconCasting.ico" class="img-responsive" />
                    <%--<div class="subtitle">Currier Management</div>--%>
                </div>
            </a>
        </div>
    </div><br /> <%-- <first row ended here>--%>
     <div class="row">
          <hr class="hline" />
    </div>

    <div class="row" id="Main"><br /><br /><%--<this is second row of dashboard>--%>
        <div class="col-xs-5 col-md-4">
            <a href="GoldInventory/GoldInventoryDashBoard.aspx" class="gridiconbox" data-toggle="tooltip" data-placement="bottom" title="Advance And Absent Updation"><%--thumbnail--or -- user defined scc class --gridiconbox--%>
                <div class="Inventory">
                    <div class="col-md-12 btntext">Adv/Abt Updation</div>
                    <img src="image/IconBill2.ico" class="img-responsive" />
                    <%--<div class="subtitle">Inventory Management</div>--%>
                </div>
            </a>
        </div>
        <div class="col-xs-5 col-md-4">
            <a href="Member.aspx" class="gridiconbox" data-toggle="tooltip" data-placement="bottom" title="Report Printing">
                <div class="Inventory">
                    <div class="col-md-12 btntext">PRINTING</div>
                    <img src="image/IconReport.ico" class="img-responsive" />
                    <%--<div class="subtitle">Inventory Management</div>--%>
                </div>
            </a>
        </div>
        <div class="col-xs-5 col-md-4">
            <a href="Member.aspx" class="gridiconbox" data-toggle="tooltip" data-placement="bottom" title="Transfer Balance New Month">
                <div class="Inventory">
                    <div class="col-md-12 btntext">Transfer</div>
                    <img src="image/IconNextMonth.ico" class="img-responsive" />
                    <%--<div class="subtitle">Currier Management</div>--%>
                </div>
            </a>
        </div>
    </div> <%-- <Second row ended here>--%>
</asp:Content>
