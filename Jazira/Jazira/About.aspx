<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Jazira.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
  .gridiconbox
         {
    
     float:left;
    min-width:50px !important;
    width:140px;
    height:160px;    
    border:1.5px solid #ddd;/*solid 2px #A9CF48*/
    border-radius: 15px;   
    -moz-border-radius: 15px;
    -webkit-border-radius: 15px;      
    transition:margin-top 1s, box-shadow 1s;    
   -webkit-transition:margin-top 1s, box-shadow 1s;  
   transition-delay:.5s;
    -webkit-transition-delay:.5s;
     background-color:#fff;
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
  font-size: 0.9em;
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
            <div class="col-md-12 col-xs-4">
                <div class="page-heading">
                <h3>
                    <i class="fa fa-th fa-lg"></i>&nbsp; Welcome To Jazira System Dash Board
                </h3>
            </div>
            </div>
        </div>
    <div class="row">
          <hr class="hline" />
    </div>









     <div class="row"> <%--<this is first row of dashboard>--%>
        <div class="col-xs-4 col-md-3">
            <a href="GoldInventory/GoldInventoryDashBoard.aspx" class="gridiconbox"><%--thumbnail--or -- user defined scc class --gridiconbox--%>
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Gold Inventory</div>
                    <img src="../image/IconGoldCoin.ico" class="img-responsive" />
                    <div class="subtitle">Inventory Management</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="SilverInventory/SilverDashBoard.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Silver Inventory</div>
                    <img src="../image/IconSilver1.ico" class="img-responsive" />
                    <div class="subtitle">Inventory Management</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="CourierManament/CourierDashBoard.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">TNT</div>
                    <img src="../image/IconTNT.ico" class="img-responsive" />
                    <div class="subtitle">Currier Management</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox"> 
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Bar Code</div>
                    <img src="../image/IconBarCode.ico" class="img-responsive" />
                    <div class="subtitle">BarCode Management</div>
                </div>
            </a>
        </div>
    </div>  <%-- <first row ended here>--%>
   <%-- <hr class="inline" />--%>

    <div class="row"> <%--<this is second row of dashboard>--%>
        <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">HR Management</div>
                    <img src="../image/IconHumanResource.ico" class="img-responsive" />
                    <div class="subtitle">Human Resource Mgt.</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Vehicle</div>
                    <img src="../image/IconVehicle2.ico" class="img-responsive" />
                    <div class="subtitle">Vehicle Management</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Tools</div>
                    <img src="../image/IconTools1.ico" class="img-responsive" />
                    <div class="subtitle">Tools Management</div>
                </div>
            </a>
        </div>
        <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class="col-md-12 btntext">Daily</div>
                    <img src="../image/IconBalance.ico" class="img-responsive" />
                    <div class="subtitle">Daily Balance</div>
                </div>
            </a>
        </div>
   </div> <%--< second row ended>--%>

     <div class="row"> <%--<this is third row of dashboard>--%>
        <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Account</div>
                    <img src="../image/IconeAccount.ico" class="img-responsive" />
                    <div class="subtitle">Account Section</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Cash</div>
                    <img src="../image/IconeCash.ico" class="img-responsive" />
                    <div class="subtitle">Cash Management</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="Member.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Time</div>
                    <img src="../image/IconTime.ico" class="img-responsive" />
                    <div class="subtitle">Time Management</div>
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-3">
            <a href="General/GeneralDashBoard.aspx" class="gridiconbox">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Configuration</div>
                    <img src="../image/IconConfiguration.ico" class="img-responsive" />
                    <div class="subtitle">Manage Master Setting</div>
                </div>
            </a>
        </div>
    </div>  <%-- <third row ended here>--%>


    <hr class="inline" />



    <div class="row"><%--<second row start here>--%>
        <div class="col-xs-4 col-md-2">
            <a href="#" class="thumbnail">

                <img src="../image/IconeAccount.ico">
            </a>
        </div>
        <div class="col-xs-4 col-md-2">
            <a href="#" class="thumbnail">
                <img src="../image/IconWeman.ico">
            </a>
        </div>
        <div class="col-xs-4 col-md-2">
            <a href="#" class="thumbnail">
                <img src="../image/IconBook.ico">
            </a>
        </div>
        <div class="col-xs-4 col-md-2">
            <a href="#" class="thumbnail">
                <img src="../image/IconWeman.ico">
            </a>
        </div>
          <div class="col-xs-4 col-md-2">
            <a href="#" class="thumbnail">
                <img src="../image/IconBar.ico">
            </a>
        </div>
    </div> <%--<second row ended here>--%>
</asp:Content>
