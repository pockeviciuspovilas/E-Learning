#pragma checksum "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3d8be1c7dc1ae212bd5845f7f1abdd0a8662c16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_CategoryReport), @"mvc.1.0.view", @"/Views/Report/CategoryReport.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\_ViewImports.cshtml"
using Elearn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\_ViewImports.cshtml"
using Elearn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3d8be1c7dc1ae212bd5845f7f1abdd0a8662c16", @"/Views/Report/CategoryReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd51a6fe1f0aff8695cda020bdd558fe8d512ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_CategoryReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Elearn.Models.Test>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"
  
    Layout = "~/Views/Report/Shared/_Layout.cshtml";
    ViewData["Title"] = "My tests";
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2> Category report</h2>
<table class=""table table-hover"">
  <thead>
    <tr>
      <th scope=""col"">Test name</th>
      <th scope=""col"">Assignees count</th>
      <th scope=""col"">Solved count</th>
      <th scope=""col"">Mark average</th>
    </tr>
  </thead>
  <tbody>
");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"
 for(int i=0;i < Model.Count; i++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            WriteLiteral("\r\n    <tr>\r\n    <th scope=\"row\">");
#nullable restore
#line 23 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"
               Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    <td>");
#nullable restore
#line 24 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"
   Write(ViewBag.participantCountList[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 25 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"
   Write(ViewBag.completedCount[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 26 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"
   Write(ViewBag.averageList[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n");
#nullable restore
#line 28 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\CategoryReport.cshtml"

} 

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Elearn.Models.Test>> Html { get; private set; }
    }
}
#pragma warning restore 1591
