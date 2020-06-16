#pragma checksum "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0677b02fded1a1cd9266b93f01df9b4ad28f18b"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0677b02fded1a1cd9266b93f01df9b4ad28f18b", @"/Views/Assign/AssignNew.cshtml")]
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
  
    ViewData["Title"] = "Assign new tests";
    if(ViewData["msg"]!= null && ViewData["msg"]!="")
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n        alert(");
#nullable restore
#line 9 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
          Write((string)ViewData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        </script>\r\n");
#nullable restore
#line 11 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0677b02fded1a1cd9266b93f01df9b4ad28f18b4324", async() => {
                WriteLiteral("\r\n    <h3>Chosen test:</h3>\r\n    ");
#nullable restore
#line 16 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
Write(Html.DropDownList("Test", ViewBag.TestId, "Choose test", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <h3>Due:</h3>\r\n    <input type=\"datetime-local\" name =\"ExprDate\"/>\r\n    <h3>Choose unit category:</h3>\r\n    ");
#nullable restore
#line 20 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
Write(Html.DropDownList("Category", ViewBag.CategoryId, "Choose category", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    </br>
    <input type=""submit"" value=""Assign to category"" class=""btn btn-primary"" name =""assignCat""/>
    </br>
    </br>
    <h3>Or choose users from the list:</h3>
    <table class=""table table-hover"">
    <thead>
        <tr>
        <th scope=""col"">User</th>
        <th scope=""col"">Assign test</th>
        </tr>
    </thead>
        <tbody>
");
#nullable restore
#line 34 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
         for(int i=0;i< @Model.Count; i++)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                WriteLiteral("\r\n            <tr>\r\n                <th scope = \"row\">\r\n                    ");
#nullable restore
#line 39 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
               Write(Model[i].UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <td>\r\n                    <input type=\"checkbox\"");
                BeginWriteAttribute("name", " name=\"", 1242, "\"", 1261, 1);
#nullable restore
#line 42 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
WriteAttributeValue("", 1249, Model[i].Id, 1249, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                </td>\r\n            </tr>      \r\n");
#nullable restore
#line 45 "C:\Users\MyPC\Documents\GitHub\E-Learning\Elearn\Views\Assign\AssignNew.cshtml"
        } 

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n     <div class=\"form-group\">\r\n        <input type=\"submit\" value=\"Assign test to users\" class=\"btn btn-primary\" name=\"assignusers\" />\r\n    </div>\r\n");
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
