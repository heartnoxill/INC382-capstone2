#pragma checksum "C:\Users\computer\Desktop\Capstonetest1\Views\ManagerDashboard\Weekly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb77b6dd16f8956ed4474cbcc625a67dbf516d27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerDashboard_Weekly), @"mvc.1.0.view", @"/Views/ManagerDashboard/Weekly.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\computer\Desktop\Capstonetest1\Views\_ViewImports.cshtml"
using Capstonetest1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\computer\Desktop\Capstonetest1\Views\_ViewImports.cshtml"
using Capstonetest1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb77b6dd16f8956ed4474cbcc625a67dbf516d27", @"/Views/ManagerDashboard/Weekly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4bf2ce06d2348b1b31570fc36637b69493ab809", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ManagerDashboard_Weekly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ManagerDashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\computer\Desktop\Capstonetest1\Views\ManagerDashboard\Weekly.cshtml"
  
    ViewData["Title"] = "Weekly";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb77b6dd16f8956ed4474cbcc625a67dbf516d274322", async() => {
                WriteLiteral("Back to Manager Dashboard Page");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<h1>Weekly Manager Dashboard</h1>

<input type=""date"" name=""selDate"" id=""selDate"" value=""2022-03-31"" min=""2022-03-01"" max=""2022-05-01""/>
<button onclick=""myFunction()"">Search</button>

        <!-- Small boxes (Stat box) -->
        <div class=""row"">
          <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""WDieselVolDaily""></><sup style=""font-size: 20px""></sup></h3>

                <p>Weekly Diesel Volume</p>
              </div>
              <div class=""icon"">
                <i class=""ion ion-stats-bars""></i>
              </div>
");
            WriteLiteral(@"              <div class=""small-box-footer""></div>
            </div>
          </div>
          <!-- ./col -->
          <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""WGas95VolDaily""></><sup style=""font-size: 20px""></sup></h3>

                <p>Weekly Gas95 Volume</p>
              </div>
              <div class=""icon"">
                <i class=""ion ion-stats-bars""></i>
              </div>
");
            WriteLiteral(@"              <div class=""small-box-footer""></div>
            </div>
          </div>
          <!-- ./col -->
          <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""WAvgDieselCycle""></><sup style=""font-size: 20px""></sup></h3>

                <p>AVG Diesel Cycle Time</p>
              </div>
              <div class=""icon"">
                <i class=""ion ion-clock""></i>
              </div>
");
            WriteLiteral(@"              <div class=""small-box-footer""></div>
            </div>
          </div>
          <!-- ./col -->
          <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""WAvgGas95Cycle""></><sup style=""font-size: 20px""></sup></h3>

                <p>AVG GAS95 Cycle Time</p>
              </div>
              <div class=""icon"">
                <i class=""ion ion-clock""></i>
              </div>
");
            WriteLiteral("              <div class=\"small-box-footer\"></div>\r\n            </div>\r\n          </div>\r\n          <!-- ./col -->\r\n        </div>\r\n\r\n");
            WriteLiteral(@"        <div class=""row"">
        <!-- BAR CHART -->
            <div class=""card card-secondary col-md-6"">
              <div class=""card-header"">
                <h3 class=""card-title"">Average waiting time at each station</h3>

              </div>
              <div class=""card-body"">
                <div class=""chart"">
                  <canvas id=""barChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 491px;"" width=""491"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->

        <!-- BAR CHART 2-->
            <div class=""card card-secondary col-md-6"">
              <div class=""card-header"">
                <h3 class=""card-title"">Number of failed time at each station</h3>

              </div>
              <div class=""card-body"">
                <div class=""chart"">
                  <canvas id=""bar");
            WriteLiteral(@"Chart2"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 491px;"" width=""491"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
            </div>

            <!-- BAR CHART 3-->
            <div class=""card card-secondary"">
              <div class=""card-header"">
                <h3 class=""card-title"">Schedule Utilization</h3>

              </div>
              <div class=""card-body"">
                <div class=""chart"">
                  <canvas id=""barChart3"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%; display: block; width: 491px;"" width=""491"" height=""250"" class=""chartjs-render-monitor""></canvas>
                </div>
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
            </div>

");
            WriteLiteral(@"
        <div class=""row"">
          <div class=""col-md-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""Wtruckin""></><sup style=""font-size: 20px""></sup></h3>

                <p>Truck in</p>
              </div>
              <div class=""icon"">
                <i class=""ion ion-stats-bars""></i>
              </div>
");
            WriteLiteral(@"              <div class=""small-box-footer""></div>
            </div>
          </div>
          <!-- ./col -->
          <div class=""col-md-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""Wtruckout""></><sup style=""font-size: 20px""></sup></h3>

                <p>Truck out</p>
              </div>
              <div class=""icon"">
                <i class=""ion ion-stats-bars""></i>
              </div>
");
            WriteLiteral(@"              <div class=""small-box-footer""></div>
            </div>
          </div>
        </div>

<script type=""text/javascript"">

  var WSW = 1.2345;
  var WIW = 1.2345;
  var WDW = 1.2345;
  var WGW = 1.2345;
  var WOW = 1.2345;
  let showDataW = [];

  var failDieselW = 0;
  var failGas95W = 0;
  let showData2W = [];

  var SCHSalesW = 1.2345;
  var SCHInwbW = 1.2345;
  var SCHDieselW = 1.2345;
  var SCHGas95W = 1.2345;
  var SCHOutwbW = 1.2345;
  let showData3W = [];

async function myFunction(){

  var x = document.getElementById(""selDate"").value;

  fetch(`https://localhost:5001/api/pi/weeklyDieselFilling/${x}`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""WDieselVolDaily"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/weeklyGas95Filling/${x}`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""WGas95VolDaily"").innerHTML = data.result[0].values;
  });

  fe");
            WriteLiteral(@"tch(`https://localhost:5001/api/pi/weeklyDieselAvgCycle/${x}`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""WAvgDieselCycle"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/weeklyGas95AvgCycle/${x}`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""WAvgGas95Cycle"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/weeklyTruckIn/${x}`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""Wtruckin"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/weeklyTruckOut/${x}`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""Wtruckout"").innerHTML = data.result[0].values;
  });

  // GRAPH 1

  await fetch(`https://localhost:5001/api/pi/weeklySalesWait/${x}`)
  .then(response => response.json())
  .then(data => WSW = data.result[0].values)
  .then(() => showDataW = [");
            WriteLiteral(@"])
  .then(() => showDataW.push(WSW))
  .then(() => console.log(WSW));

  await fetch(`https://localhost:5001/api/pi/weeklyInwbWait/${x}`)
  .then(response => response.json())
  .then(data => WIW = data.result[0].values)
  .then(() => showDataW.push(WIW))
  .then(() => console.log(WIW));

  await fetch(`https://localhost:5001/api/pi/weeklyDieselWait/${x}`)
  .then(response => response.json())
  .then(data => WDW = data.result[0].values)
  .then(() => showDataW.push(WDW))
  .then(() => console.log(WDW));

  await fetch(`https://localhost:5001/api/pi/weeklyGas95Wait/${x}`)
  .then(response => response.json())
  .then(data => WGW = data.result[0].values)
  .then(() => showDataW.push(WGW))
  .then(() => console.log(WGW));

  await fetch(`https://localhost:5001/api/pi/weeklyOutwbWait/${x}`)
  .then(response => response.json())
  .then(data => WOW = data.result[0].values)
  .then(() => showDataW.push(WOW))
  .then(() => console.log(WOW));

  // GRAPH 2
  await fetch(`https://localhost:5");
            WriteLiteral(@"001/api/pi/weeklyFailedDiesel/${x}`)
  .then(response => response.json())
  .then(data => failDieselW = data.result[0].values)
  .then(() => showData2W = [])
  .then(() => showData2W.push(failDieselW))
  .then(() => console.log(failDieselW));

  await fetch(`https://localhost:5001/api/pi/weeklyFailedGas95/${x}`)
  .then(response => response.json())
  .then(data => failGas95W = data.result[0].values)
  .then(() => showData2W.push(failGas95W))
  .then(() => console.log(failGas95W));

  // GRAPH 3

  // GRAPH 3
  await fetch(`https://localhost:5001/api/pi/weeklyAvgSCHSales/${x}`)
  .then(response => response.json())
  .then(data => SCHSalesW = data.result[0].values)
  .then(() => showData3W = [])
  .then(() => showData3W.push(SCHSalesW))
  .then(() => console.log(SCHSalesW));

  await fetch(`https://localhost:5001/api/pi/weeklyAvgSCHInwb/${x}`)
  .then(response => response.json())
  .then(data => SCHInwbW = data.result[0].values)
  .then(() => showData3W.push(SCHInwbW))
  .then(() => c");
            WriteLiteral(@"onsole.log(SCHInwbW));

  await fetch(`https://localhost:5001/api/pi/weeklyAvgSCHDiesel/${x}`)
  .then(response => response.json())
  .then(data => SCHDieselW = data.result[0].values)
  .then(() => showData3W.push(SCHDieselW))
  .then(() => console.log(SCHDieselW));

  await fetch(`https://localhost:5001/api/pi/weeklyAvgSCHGas95/${x}`)
  .then(response => response.json())
  .then(data => SCHGas95W = data.result[0].values)
  .then(() => showData3W.push(SCHGas95W))
  .then(() => console.log(SCHGas95W));

  await fetch(`https://localhost:5001/api/pi/weeklyAvgSCHOutwb/${x}`)
  .then(response => response.json())
  .then(data => SCHOutwbW = data.result[0].values)
  .then(() => showData3W.push(SCHOutwbW))
  .then(() => console.log(SCHOutwbW));


  var data1 = {
    labels  : ['Sales Office', 'Inbound WB', 'Diesel Bay', 'Gasohol95 Bay', 'Outbound WB'],
    datasets : [
    {
      label               : 'Minutes',
      backgroundColor     : 'rgba(60,141,188,0.9)',
      borderColor         ");
            WriteLiteral(@": 'rgba(60,141,188,0.8)',
      pointRadius         : false,
      pointColor          : '#3b8bba',
      pointStrokeColor    : 'rgba(60,141,188,1)',
      pointHighlightFill  : '#fff',
      pointHighlightStroke: 'rgba(60,141,188,1)',
      data :  Object.values(showDataW)
    }
    ]
  }

  var data2 = {
    labels : ['DIESEL Bay', 'GASOHOL95 Bay'],
    datasets : [
    {
      label               : 'Time',
      backgroundColor     : 'rgba(60,141,188,0.9)',
      borderColor         : 'rgba(60,141,188,0.8)',
      pointRadius         : false,
      pointColor          : '#3b8bba',
      pointStrokeColor    : 'rgba(60,141,188,1)',
      pointHighlightFill  : '#fff',
      pointHighlightStroke: 'rgba(60,141,188,1)',
      data :  Object.values(showData2W)
    }
    ]
  }

  var data3 = {
    labels : ['Sales Office', 'Inbound WB', 'Diesel Bay', 'Gasohol95 Bay', 'Outbound WB'],
    datasets : [
    {
      label               : 'Unit Interval',
      backgroundColor     : 'rgb");
            WriteLiteral(@"a(60,141,188,0.9)',
      borderColor         : 'rgba(60,141,188,0.8)',
      pointRadius         : false,
      pointColor          : '#3b8bba',
      pointStrokeColor    : 'rgba(60,141,188,1)',
      pointHighlightFill  : '#fff',
      pointHighlightStroke: 'rgba(60,141,188,1)',
      data :  Object.values(showData3W)
    }
    ]
  }


  //-------------
  //- BAR CHART -
  //-------------

  var barChartCanvas = document.getElementById('barChart').getContext('2d');
    var barChartData = $.extend(true, {}, data1)
    var temp0 = data1.datasets
    barChartData.datasets = temp0

    var barChartOptions = {
      responsive              : true,
      maintainAspectRatio     : false,
      datasetFill             : false
    }

    new Chart(barChartCanvas, {
      type: 'bar',
      data: barChartData,
      options: barChartOptions
    })

  // BAR CHART 2

  var barChartCanvas2 = document.getElementById('barChart2').getContext('2d');
    var barChartData2 = $.extend(true");
            WriteLiteral(@", {}, data2)
    var temp1 = data2.datasets
    barChartData2.datasets = temp1

    var barChartOptions2 = {
      responsive              : true,
      maintainAspectRatio     : false,
      datasetFill             : false,
      scales: {
        yAxes: [{
            display: true,
            ticks: {
                min: 0, // minimum value
                max: 10 // maximum value
            }
        }]
    }
    }

    new Chart(barChartCanvas2, {
      type: 'bar',
      data: barChartData2,
      options: barChartOptions2
    })

    // BAR CHART 3

    var barChartCanvas3 = document.getElementById('barChart3').getContext('2d');
    var barChartData3 = $.extend(true, {}, data3)
    var temp2 = data3.datasets
    barChartData3.datasets = temp2

    var barChartOptions3 = {
      responsive              : true,
      maintainAspectRatio     : false,
      datasetFill             : false
    }

    new Chart(barChartCanvas3, {
      type: 'bar',
      data: barCh");
            WriteLiteral("artData3,\r\n      options: barChartOptions3\r\n    })\r\n\r\n\r\n}\r\n\r\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
