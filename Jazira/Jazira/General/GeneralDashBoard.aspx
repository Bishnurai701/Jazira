<%@ Page Title="" Language="C#" MasterPageFile="~/General/General.Master" AutoEventWireup="true" CodeBehind="GeneralDashBoard.aspx.cs" Inherits="Jazira.General.GeneralDashBoard" %>
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
  .gridiconboxSDB
         {
    
     float:left;
    min-width:50px !important;
    width:120px;
    height:120px;    
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
  gridiconboxSDB-medium
  {
          height:100px !important;
          padding-bottom:5px;
  }
  .gridiconboxSDB-small
  {
          height:60px !important;
          padding:3px;
          vertical-align:middle;
  }
  
  .gridiconboxSDB:hover
  {    
    margin-top:0px;   
    box-shadow:0 0 5px #A9CF48;
  }
              
  .gridiconboxSDB:hover .subtext
  {
    display:block;
   
  }
.imgsize 
        {
            width:100px;
            height:90px;
            float:left;
            padding-left:13px;
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
            <div class="col-md-4">
                <div class="page-heading">
                    <h4>
                        <i class="fa fa-cog"></i>&nbsp; Configuration  Dash Board
                    </h4>
                </div>
            </div>
            <div class="col-md-8">
                <ul class="breadcrumb breadcrumb-modified pull-right" style="background-color: transparent;">
                    <li><a href="../About.aspx">Home</a> <span class="divider"></span></li>
                    <li class="active"><a href="GeneralDashBoard.aspx">Configuration </a></li>
                </ul>
            </div>
        </div>
        <div class="row-fluid">
                <hr class="hline" />
        </div>




     <div class="row"> <%--<this is first row of dashboard>--%>
        <div class="col-xs-3 col-md-2">
           <%-- <ul>
            <li runat="server" id="liMasterMaintainance"><a href="MasterMaintainance.aspx?act=GoldType"><i class="fa fa-cog fa-fw"></i>&nbsp;MasterMaintainance</a></li> </ul>--%>
           <a href="MasterMaintainance.aspx?act=GoldType" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Master Maintainance"><%--thumbnail--or -- user defined scc class --gridiconboxSDB--%>
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Master</div>
                    <img src="image/IconMaster.ico" class="img-responsive imgsize" />
                    <%--<div class="subtitle">Inventory Management</div>--%>
                </div>
               </a>
        </div>
         <div class="col-xs-3 col-md-2">
            <a href="GroupMasterMaintenace.aspx?act=search" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Group Master Maintenace">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Group Master</div>
                    <img src="image/IconMaster3.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-3 col-md-2">
            <a href="ItemMaintenace.aspx?act=search" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Item Maintenance">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Item Mtnce</div>
                    <img src="image/IconMaster2.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-3 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add SAFE Master Ornament"> 
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Ornament</div>
                    <img src="../image/IconBarCode.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-3 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add SAFE Gold Type">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Gold Type</div>
                    <img src="../image/IconHumanResource.ico" class="img-responsive imgsize" />
                </div>
            </a>
       </div>
    </div>  <%-- <first row ended here>--%>
    <hr class="inline" />

    <div class="row"> <%--second row started--%>
         <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add SAFE Items">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Items</div>
                    <img src="../image/IconVehicle2.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" >
                <div class="Inventory">
                    <div class ="col-md-12 btntext"></div>
                    <img src="../image/IconTools1.ico" class="img-responsive imgsize" />
                    <div class="subtitle">Tools Management</div>
                </div>
            </a>
        </div>
        <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add Stone Clearity">
                <div class="Inventory">
                    <div class="col-md-12 btntext">Stone Shape</div>
                    <img src="../image/IconBalance.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
        <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add Stone Clearity">
                <div class="Inventory">
                    <div class="col-md-12 btntext"></div>
                    <img src="../image/IconBalance.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
        <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add Stone Clearity">
                <div class="Inventory">
                    <div class="col-md-12 btntext"></div>
                    <img src="../image/IconBalance.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
   </div> <%--< second row ended>--%>
  
       <hr class="inline" />
     <div class="row"> <%--<this is forth row of dashboard>--%>
        
         <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add SAFE Stone Color">
                <div class="Inventory">
                    <div class ="col-md-12 btntext"></div>
                    <img src="../image/IconeCash.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB"data-toggle="tooltip" data-placement="bottom" title="Add SAFE Stone Shape CUT">
                <div class="Inventory">
                    <div class ="col-md-12 btntext"></div>
                    <img src="../image/IconTime.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
          <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Add SAFE Stone Color">
                <div class="Inventory">
                    <div class ="col-md-12 btntext"></div>
                    <img src="../image/IconeCash.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-2">
            <a href="Member.aspx" class="gridiconboxSDB"data-toggle="tooltip" data-placement="bottom" title="Add SAFE Stone Shape CUT">
                <div class="Inventory">
                    <div class ="col-md-12 btntext"></div>
                    <img src="../image/IconTime.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
         <div class="col-xs-4 col-md-2">
            <a href="../Security/SecurityDashBoard.aspx" class="gridiconboxSDB" data-toggle="tooltip" data-placement="bottom" title="Security Setting">
                <div class="Inventory">
                    <div class ="col-md-12 btntext">Security</div>
                    <img src="../Security/image/IconSecurity2.ico" class="img-responsive imgsize" />
                </div>
            </a>
        </div>
    </div>  <%-- <third row ended here>--%>
    <hr class="inline" />
</asp:Content>
