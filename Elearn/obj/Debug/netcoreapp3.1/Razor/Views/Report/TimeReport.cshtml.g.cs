#pragma checksum "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c5e1f2805273921bbe0a0ae8f62a2a8ea991abd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_TimeReport), @"mvc.1.0.view", @"/Views/Report/TimeReport.cshtml")]
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
#line 1 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\_ViewImports.cshtml"
using Elearn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\_ViewImports.cshtml"
using Elearn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c5e1f2805273921bbe0a0ae8f62a2a8ea991abd", @"/Views/Report/TimeReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd51a6fe1f0aff8695cda020bdd558fe8d512ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_TimeReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Elearn.Models.Asign>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
  
    Layout = "~/Views/Report/Shared/_Layout.cshtml";
    ViewData["Title"] = "Mano testai";
    int completedTests = 0;
    int pendingTests = 0;
    double markSum = 0;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 11 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
Write(ViewBag.begin);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 11 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                Write(ViewBag.end);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" laikotarpio ataskaita</h2>
<table class=""table table-hover"">
  <thead>
    <tr>
      <th scope=""col"">Uždavimo data</th>
      <th scope=""col"">Skirta naudotojui</th>
      <th scope=""col"">Testo pavadinimas</th>
      <th scope=""col"">Balas</th>
    </tr>
  </thead>
  <tbody>
");
#nullable restore
#line 22 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
 for(int i=0;i < Model.Count; i++)
{
    string Mark = Model[i].Result.SingleOrDefault() != null ?
    Model[i].Result.SingleOrDefault().Mark.ToString() : "-1" ;

    if(int.Parse(Mark)>=0)
    {
        completedTests++;
        markSum+= int.Parse(Mark);
    }
       
    if(int.Parse(Mark)==-2)
        pendingTests++;
    string Date = Model[i].Result.SingleOrDefault() != null && Model[i].Result.SingleOrDefault().CompleteTime!= null ?
      Model[i].Result.SingleOrDefault().CompleteTime.ToString() : "Nespręsta" ;
    if(Date == "1/1/2000 12:00:00 AM")
      Date = "Nespręsta";
    string MarkPercent = Mark + "%";

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            WriteLiteral("\r\n    <tr>\r\n    <th scope=\"row\">");
#nullable restore
#line 42 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
               Write(Model[i].InsertTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    <td>");
#nullable restore
#line 43 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
   Write(Model[i].Applicant.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 44 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
   Write(Model[i].Test.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n");
#nullable restore
#line 46 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
       if(Mark == "-2")
      {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("Laukiama rezultato");
#nullable restore
#line 48 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                       
      }
      else if (Mark == "-1")
      {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("Testas nespręstas");
#nullable restore
#line 52 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                      
      }
      else
      {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"progress\"> \r\n            <div class=\"progress-bar progress-bar-striped progress-bar-animated\" role=\"progressbar\"");
            BeginWriteAttribute("aria-valuenow", " aria-valuenow=\"", 1663, "\"", 1684, 1);
#nullable restore
#line 57 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
WriteAttributeValue("", 1679, Mark, 1679, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\" aria-valuemax=\"100\"");
            BeginWriteAttribute("style", " style=\"", 1723, "\"", 1750, 2);
            WriteAttributeValue("", 1731, "width:", 1731, 6, true);
#nullable restore
#line 57 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
WriteAttributeValue(" ", 1737, MarkPercent, 1738, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><strong>");
#nullable restore
#line 57 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                                                                                                                                                                               Write(MarkPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n        </div>\r\n");
#nullable restore
#line 59 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </td>\r\n    </tr>\r\n");
#nullable restore
#line 63 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"

} 

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>\r\n</br>\r\n</br>\r\n  <div class=\"row\">\r\n    <div class=\"col\">\r\n        <text> Priskirta testų: <strong> ");
#nullable restore
#line 71 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                    Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></text></br>\r\n        <text> Išspręsta testų: <strong> ");
#nullable restore
#line 72 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                    Write(completedTests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></text></br>\r\n        <text> Laukiama vertinimo: <strong> ");
#nullable restore
#line 73 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                       Write(pendingTests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></text></br>\r\n    </div>\r\n    <div class=\"col\">\r\n        <h3>Laikotarpio pažymių vidurkis: ");
#nullable restore
#line 76 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\TimeReport.cshtml"
                                      Write(markSum/completedTests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n  </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Elearn.Models.Asign>> Html { get; private set; }
    }
}
#pragma warning restore 1591