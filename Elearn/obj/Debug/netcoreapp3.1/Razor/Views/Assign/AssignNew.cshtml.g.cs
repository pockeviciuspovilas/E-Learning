#pragma checksum "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "997cc1c20bdd6dfd677bbd3fb962ca3ae6d19f87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assign_AssignNew), @"mvc.1.0.view", @"/Views/Assign/AssignNew.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"997cc1c20bdd6dfd677bbd3fb962ca3ae6d19f87", @"/Views/Assign/AssignNew.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd51a6fe1f0aff8695cda020bdd558fe8d512ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Assign_AssignNew : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Elearn.Models.AspNetUsers>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewAssigns", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
  
    ViewData["Title"] = "Priskirti testai";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "997cc1c20bdd6dfd677bbd3fb962ca3ae6d19f873758", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 7 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
Write(Html.DropDownList("Test", ViewBag.TestId, "Pasirinkite testą", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <table class=\"table table-hover\">\r\n    <thead>\r\n        <tr>\r\n        <th scope=\"col\">Vartotojas</th>\r\n        <th scope=\"col\">Priskirti testą</th>\r\n        </tr>\r\n    </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
         for(int i=0;i< 1; i++)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                WriteLiteral("\r\n            <tr>\r\n                <th scope = \"row\">\r\n                    ");
#nullable restore
#line 21 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
               Write(Model[i].UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <td>\r\n                    <input type=\"checkbox\"");
                BeginWriteAttribute("name", " name=\"", 667, "\"", 686, 1);
#nullable restore
#line 24 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
WriteAttributeValue("", 674, Model[i].Id, 674, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </td>\r\n            </tr>      \r\n");
#nullable restore
#line 27 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
        } 

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n     <div class=\"form-group\">\r\n        <input type=\"submit\" value=\"Priskirti\" class=\"btn btn-primary\" />\r\n    </div>\r\n");
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