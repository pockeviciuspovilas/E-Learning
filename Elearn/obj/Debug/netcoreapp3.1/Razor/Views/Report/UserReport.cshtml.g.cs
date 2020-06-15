#pragma checksum "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77fec542e4320f93b23622806568becb0aada253"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_UserReport), @"mvc.1.0.view", @"/Views/Report/UserReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77fec542e4320f93b23622806568becb0aada253", @"/Views/Report/UserReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd51a6fe1f0aff8695cda020bdd558fe8d512ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_UserReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Elearn.Models.Asign>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
  
    Layout = "~/Views/Report/Shared/_Layout.cshtml";
    ViewData["Title"] = "My tests";
    int completedTests = 0;
    int pendingTests = 0;
    double markSum = 0;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 11 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
Write(ViewBag.User);

#line default
#line hidden
#nullable disable
            WriteLiteral(" user report</h2>\r\n<table class=\"table table-hover\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">Date</th>\r\n      <th scope=\"col\">Test name</th>\r\n      <th scope=\"col\">Mark</th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n");
#nullable restore
#line 21 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
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
      Date = "Unsolved";
    string MarkPercent = Mark + "%";

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            WriteLiteral("\r\n    <tr>\r\n    <th scope=\"row\">");
#nullable restore
#line 41 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
               Write(Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    <td>");
#nullable restore
#line 42 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
   Write(Model[i].Test.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n");
#nullable restore
#line 44 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
         if (Mark == "-2")
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("Waiting for result");
#nullable restore
#line 46 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
                                           
        }
        else if (Mark == "-1")
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("Test not solved");
#nullable restore
#line 50 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
                                        
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"progress\">\r\n                <div class=\"progress-bar progress-bar-striped progress-bar-animated\" role=\"progressbar\"");
            BeginWriteAttribute("aria-valuenow", " aria-valuenow=\"", 1541, "\"", 1562, 1);
#nullable restore
#line 55 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
WriteAttributeValue("", 1557, Mark, 1557, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\" aria-valuemax=\"100\"");
            BeginWriteAttribute("style", " style=\"", 1601, "\"", 1628, 2);
            WriteAttributeValue("", 1609, "width:", 1609, 6, true);
#nullable restore
#line 55 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
WriteAttributeValue(" ", 1615, MarkPercent, 1616, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><strong>");
#nullable restore
#line 55 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
                                                                                                                                                                                                   Write(MarkPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n            </div>\r\n");
#nullable restore
#line 57 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    </tr>\r\n");
#nullable restore
#line 61 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"

} 

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>\r\n<br/>\r\n<br/>\r\n  <div class=\"row\">\r\n    <div class=\"col\">\r\n        <text> User assigned tests: <strong> ");
#nullable restore
#line 69 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
                                        Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></text><br/>\r\n        <text> User solved tests: <strong> ");
#nullable restore
#line 70 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
                                      Write(completedTests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></text><br/>\r\n        <text> Waiting for result: <strong> ");
#nullable restore
#line 71 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
                                       Write(pendingTests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></text><br/>\r\n    </div>\r\n    <div class=\"col\">\r\n        <h3>User average mark: ");
#nullable restore
#line 74 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Report\UserReport.cshtml"
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
