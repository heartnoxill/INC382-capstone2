#pragma checksum "C:\Users\computer\Desktop\Capstonetest1\Views\ManagerDashboard\Monthly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9323ba18d525bf9fbac423aca26304ef49242fce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerDashboard_Monthly), @"mvc.1.0.view", @"/Views/ManagerDashboard/Monthly.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9323ba18d525bf9fbac423aca26304ef49242fce", @"/Views/ManagerDashboard/Monthly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4bf2ce06d2348b1b31570fc36637b69493ab809", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ManagerDashboard_Monthly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\computer\Desktop\Capstonetest1\Views\ManagerDashboard\Monthly.cshtml"
  
    ViewData["Title"] = "Monthly";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9323ba18d525bf9fbac423aca26304ef49242fce4329", async() => {
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
            WriteLiteral("\r\n</div>\r\n\r\n<h1>Monthly Manager Dashboard</h1>\r\n\r\n");
            WriteLiteral(@"<button onclick=""myFunction()"">Show Data</button>

        <!-- Small boxes (Stat box) -->
        <div class=""row"">
          <div class=""col-lg-3 col-6"">
            <!-- small box -->
            <div class=""small-box bg-secondary"">
              <div class=""inner"">
                <h3 id=""DieselVolMonthly""></><sup style=""font-size: 20px""></sup></h3>

                <p>Monthly Diesel Volume</p>
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
                <h3 id=""Gas95VolMonthly""></><sup style=""font-size: 20px""></sup></h3>

                <p>Monthly Gas95 Volume</p>
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
                <h3 id=""AvgDieselCycleMonthly""></><sup style=""font-size: 20px""></sup></h3>

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
                <h3 id=""AvgGas95CycleMonthly""></><sup style=""font-size: 20px""></sup></h3>

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
                <h3 id=""TruckInM""></><sup style=""font-size: 20px""></sup></h3>

                <p>Monthly Truck in</p>
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
                <h3 id=""TruckOutM""></><sup style=""font-size: 20px""></sup></h3>

                <p>Monthly Truck out</p>
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
  var MSW = 1.2345;
  var MIW = 1.2345;
  var MDW = 1.2345;
  var MGW = 1.2345;
  var MOW = 1.2345;
  let showDataM = [];

  var failDieselM = 0;
  var failGas95M = 0;
  let showData2M = [];

  var SCHSalesM = 1.2345;
  var SCHInwbM = 1.2345;
  var SCHDieselM = 1.2345;
  var SCHGas95M = 1.2345;
  var SCHOutwbM = 1.2345;
  let showData3M = [];

async function myFunction(){
");
            WriteLiteral(@"
  fetch(`https://localhost:5001/api/pi/monthlyDieselFilling/`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""DieselVolMonthly"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/monthlyGas95Filling/`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""Gas95VolMonthly"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/monthlyDieselAvgCycle/`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""AvgDieselCycleMonthly"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/monthlyGas95AvgCycle/`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""AvgGas95CycleMonthly"").innerHTML = data.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/monthlyTruckIn/`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""TruckInM"").innerHTML = d");
            WriteLiteral(@"ata.result[0].values;
  });

  fetch(`https://localhost:5001/api/pi/monthlyTruckOut/`)
  .then(response => response.json())
  .then(data => {
  document.getElementById(""TruckOutM"").innerHTML = data.result[0].values;
  });

  // GRAPH 1

  await fetch(`https://localhost:5001/api/pi/monthlySalesWait/`)
  .then(response => response.json())
  .then(data => MSW = data.result[0].values)
  .then(() => showDataM = [])
  .then(() => showDataM.push(MSW))
  .then(() => console.log(MSW));

  await fetch(`https://localhost:5001/api/pi/monthlyInwbWait/`)
  .then(response => response.json())
  .then(data => MIW = data.result[0].values)
  .then(() => showDataM.push(MIW))
  .then(() => console.log(MIW));

  await fetch(`https://localhost:5001/api/pi/monthlyDieselWait/`)
  .then(response => response.json())
  .then(data => MDW = data.result[0].values)
  .then(() => showDataM.push(MDW))
  .then(() => console.log(MDW));

  await fetch(`https://localhost:5001/api/pi/monthlyGas95Wait/`)
  .then(respo");
            WriteLiteral(@"nse => response.json())
  .then(data => MGW = data.result[0].values)
  .then(() => showDataM.push(MGW))
  .then(() => console.log(MGW));

  await fetch(`https://localhost:5001/api/pi/monthlyOutwbWait/`)
  .then(response => response.json())
  .then(data => MOW = data.result[0].values)
  .then(() => showDataM.push(MOW))
  .then(() => console.log(MOW));

  // GRAPH 2
  await fetch(`https://localhost:5001/api/pi/monthlyFailedDiesel/`)
  .then(response => response.json())
  .then(data => failDieselM = data.result[0].values)
  .then(() => showData2M = [])
  .then(() => showData2M.push(failDieselM))
  .then(() => console.log(failDieselM));

  await fetch(`https://localhost:5001/api/pi/monthlyFailedGas95/`)
  .then(response => response.json())
  .then(data => failGas95M = data.result[0].values)
  .then(() => showData2M.push(failGas95M))
  .then(() => console.log(failGas95M));

  // GRAPH 3
  await fetch(`https://localhost:5001/api/pi/monthlyAvgSCHSales/`)
  .then(response => response.json()");
            WriteLiteral(@")
  .then(data => SCHSalesM = data.result[0].values)
  .then(() => showData3M = [])
  .then(() => showData3M.push(SCHSalesM))
  .then(() => console.log(SCHSalesM));

  await fetch(`https://localhost:5001/api/pi/monthlyAvgSCHInwb/`)
  .then(response => response.json())
  .then(data => SCHInwbM = data.result[0].values)
  .then(() => showData3M.push(SCHInwbM))
  .then(() => console.log(SCHInwbM));

  await fetch(`https://localhost:5001/api/pi/monthlyAvgSCHDiesel/`)
  .then(response => response.json())
  .then(data => SCHDieselM = data.result[0].values)
  .then(() => showData3M.push(SCHDieselM))
  .then(() => console.log(SCHDieselM));

  await fetch(`https://localhost:5001/api/pi/monthlyAvgSCHGas95/`)
  .then(response => response.json())
  .then(data => SCHGas95M = data.result[0].values)
  .then(() => showData3M.push(SCHGas95M))
  .then(() => console.log(SCHGas95M));

  await fetch(`https://localhost:5001/api/pi/monthlyAvgSCHOutwb/`)
  .then(response => response.json())
  .then(data => S");
            WriteLiteral(@"CHOutwbM = data.result[0].values)
  .then(() => showData3M.push(SCHOutwbM))
  .then(() => console.log(SCHOutwbM));



  var data1 = {
    labels  : ['Sales Office', 'Inbound WB', 'Diesel Bay', 'Gasohol95 Bay', 'Outbound WB'],
    datasets : [
    {
      label               : 'Minutes',
      backgroundColor     : 'rgba(60,141,188,0.9)',
      borderColor         : 'rgba(60,141,188,0.8)',
      pointRadius         : false,
      pointColor          : '#3b8bba',
      pointStrokeColor    : 'rgba(60,141,188,1)',
      pointHighlightFill  : '#fff',
      pointHighlightStroke: 'rgba(60,141,188,1)',
      data :  Object.values(showDataM)
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
      pointStrokeColor    : 'rgba(6");
            WriteLiteral(@"0,141,188,1)',
      pointHighlightFill  : '#fff',
      pointHighlightStroke: 'rgba(60,141,188,1)',
      data :  Object.values(showData2M)
    }
    ]
  }

  var data3 = {
    labels : ['Sales Office', 'Inbound WB', 'Diesel Bay', 'Gasohol95 Bay', 'Outbound WB'],
    datasets : [
    {
      label               : 'Unit Interval',
      backgroundColor     : 'rgba(60,141,188,0.9)',
      borderColor         : 'rgba(60,141,188,0.8)',
      pointRadius         : false,
      pointColor          : '#3b8bba',
      pointStrokeColor    : 'rgba(60,141,188,1)',
      pointHighlightFill  : '#fff',
      pointHighlightStroke: 'rgba(60,141,188,1)',
      data :  Object.values(showData3M)
    }
    ]
  }

  // BAR CHART 1

  var barChartCanvas = document.getElementById('barChart').getContext('2d');
    var barChartData = $.extend(true, {}, data1)
    var temp0 = data1.datasets
    barChartData.datasets = temp0

    var barChartOptions = {
      responsive              : true,
      main");
            WriteLiteral(@"tainAspectRatio     : false,
      datasetFill             : false
    }

    new Chart(barChartCanvas, {
      type: 'bar',
      data: barChartData,
      options: barChartOptions
    })

  // BAR CHART 2

  var barChartCanvas2 = document.getElementById('barChart2').getContext('2d');
    var barChartData2 = $.extend(true, {}, data2)
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
    var barCha");
            WriteLiteral(@"rtData3 = $.extend(true, {}, data3)
    var temp2 = data3.datasets
    barChartData3.datasets = temp2

    var barChartOptions3 = {
      responsive              : true,
      maintainAspectRatio     : false,
      datasetFill             : false
    }

    new Chart(barChartCanvas3, {
      type: 'bar',
      data: barChartData3,
      options: barChartOptions3
    })

}

</script>");
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
