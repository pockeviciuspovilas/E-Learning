#pragma checksum "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4bdb9192a4aaeda07d33c04c783b96c19d7606c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_MyTests), @"mvc.1.0.view", @"/Views/Test/MyTests.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4bdb9192a4aaeda07d33c04c783b96c19d7606c", @"/Views/Test/MyTests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd51a6fe1f0aff8695cda020bdd558fe8d512ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_MyTests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Elearn.Models.Asign>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
  
    ViewData["Title"] = "Mano testai";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-hover\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">Data</th>\r\n      <th scope=\"col\">Testo pavadinimas</th>\r\n      <th scope=\"col\">Balas</th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
 for(int i=0;i < Model.Count; i++)
{
    string Mark = Model[i].Result.SingleOrDefault() != null ?
    Model[i].Result.SingleOrDefault().Mark.ToString() : "-1" ;
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
#line 27 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
               Write(Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    <td>");
#nullable restore
#line 28 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
   Write(Model[i].Test.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n");
#nullable restore
#line 30 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
       if(Mark == "-2")
      {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("Laukiama rezultato");
#nullable restore
#line 32 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
                                       
      }
      else if (Mark == "-1")
      {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("Testas nespręstas");
#nullable restore
#line 36 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
                                      
      }
      else
      {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"progress\" style=\"height: 30px;\"> \r\n            <div class=\"progress-bar progress-bar-striped progress-bar-animated\" role=\"progressbar\"");
            BeginWriteAttribute("aria-valuenow", " aria-valuenow=\"", 1201, "\"", 1222, 1);
#nullable restore
#line 41 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
WriteAttributeValue("", 1217, Mark, 1217, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\" aria-valuemax=\"100\"");
            BeginWriteAttribute("style", " style=\"", 1261, "\"", 1288, 2);
            WriteAttributeValue("", 1269, "width:", 1269, 6, true);
#nullable restore
#line 41 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
WriteAttributeValue(" ", 1275, MarkPercent, 1276, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 41 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
                                                                                                                                                                                       Write(MarkPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n");
#nullable restore
#line 43 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </td>\r\n    </tr>\r\n");
#nullable restore
#line 47 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Test\MyTests.cshtml"

} 

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>");
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
