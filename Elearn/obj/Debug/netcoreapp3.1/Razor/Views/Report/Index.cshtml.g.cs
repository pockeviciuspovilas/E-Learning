#pragma checksum "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b678a9e014d72604aeb61d5e77abd24a4ac4cb2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Index), @"mvc.1.0.view", @"/Views/Report/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b678a9e014d72604aeb61d5e77abd24a4ac4cb2b", @"/Views/Report/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd51a6fe1f0aff8695cda020bdd558fe8d512ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Elearn.Models.AspNetUsers>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CategoryReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TimeReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
  <div class=""row"">
    <div class=""col-sm"">
      <h2>Ataskaitos pagal vartotoj</h2>
        <table class=""table table-hover"">
    <thead>
        <tr>
        <th scope=""col"">Vartotojas</th>
        <th scope=""col"">Peržiūrėti ataskaitą</th>
        <th scope=""col"">Atsisiusti ataskaitą</th>
        </tr>
    </thead>
        <tbody>
");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
         for(int i=0;i< 1; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            WriteLiteral("\r\n            <tr>\r\n                <th scope = \"row\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
               Write(Model[i].UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <td>\r\n                    <input type=\"button\" value=\"Peržiūrėti ataskaitą\"");
            BeginWriteAttribute("onclick", " onclick=\"", 724, "\"", 805, 5);
            WriteAttributeValue("", 734, "location.href=\'", 734, 15, true);
#nullable restore
#line 27 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
WriteAttributeValue("", 749, Url.Action("UserReport", "Report"), 749, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 784, "?userId=", 784, 8, true);
#nullable restore
#line 27 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
WriteAttributeValue("", 792, Model[i].Id, 792, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 804, "\'", 804, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    <input type=\"button\" value=\"Atsisiusti ataskaitą\"");
            BeginWriteAttribute("onclick", " onclick=\"", 925, "\"", 1015, 5);
            WriteAttributeValue("", 935, "location.href=\'", 935, 15, true);
#nullable restore
#line 30 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
WriteAttributeValue("", 950, Url.Action("SaveAsPdfUserReport", "Report"), 950, 44, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 994, "?userId=", 994, 8, true);
#nullable restore
#line 30 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
WriteAttributeValue("", 1002, Model[i].Id, 1002, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1014, "\'", 1014, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </tr>      \r\n");
#nullable restore
#line 32 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
        } 

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    </div>\r\n    <div class=\"col-sm\">\r\n      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b678a9e014d72604aeb61d5e77abd24a4ac4cb2b7142", async() => {
                WriteLiteral("\r\n      <h2>Ataskaitos pagal testų kategoriją</h2>\r\n      <text>Pasirinkita kategorija:</text>\r\n      ");
#nullable restore
#line 40 "C:\Users\Lenovo\source\repos\Elearn\Elearn\Views\Report\Index.cshtml"
 Write(Html.DropDownList("TestCategory", ViewBag.TestCategory, "Pasirinkite kategoriją", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n      <input type=\"submit\" name=\"showReport\" value=\"Rodyti ataskaitą\" class=\"btn btn-primary\" />\r\n      <input type=\"submit\" name=\"downloadReport\" value=\"Atsisiusti ataskaitą\" class=\"btn btn-primary\" />\r\n      ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n    </div>\r\n    <div class=\"col-sm\">\r\n      <h2>Ataskaitos pagal laiką</h2>\r\n      ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b678a9e014d72604aeb61d5e77abd24a4ac4cb2b9320", async() => {
                WriteLiteral(@"
        <text>Pasirinkite praždios datą</text>
        <input type=""date"" name =""Begin""/></br>
        <text>Pasirinkite pabaigos datą</text>
        <input type=""date"" name =""End""/>
        <input type=""submit"" name=""showReport"" value=""Rodyti ataskaitą"" class=""btn btn-primary"" />
        <input type=""submit"" name=""downloadReport"" value=""Atsisiusti ataskaitą"" class=""btn btn-primary"" />
      ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n  </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Elearn.Models.AspNetUsers>> Html { get; private set; }
    }
}
#pragma warning restore 1591
