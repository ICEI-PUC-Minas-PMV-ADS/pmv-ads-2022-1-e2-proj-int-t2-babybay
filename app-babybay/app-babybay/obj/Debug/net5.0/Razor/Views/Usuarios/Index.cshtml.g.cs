#pragma checksum "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "022241da34c5d6777c3118083d81f9aeb5e00091"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Index), @"mvc.1.0.view", @"/Views/Usuarios/Index.cshtml")]
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
#line 1 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\_ViewImports.cshtml"
using app_babybay;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\_ViewImports.cshtml"
using app_babybay.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"022241da34c5d6777c3118083d81f9aeb5e00091", @"/Views/Usuarios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"470da59ae7bc7837616f866b5995ad4ea39df1df", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Usuarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<app_babybay.Models.Usuario>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Index</h1>\n\n<p>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "022241da34c5d6777c3118083d81f9aeb5e000914996", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 16 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 19 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DataNascimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 22 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 25 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 28 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Rua));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 31 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Bairo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 34 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 37 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 40 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 43 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Senha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 46 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ConfirmarSenha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 52 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 55 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 58 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DataNascimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 61 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 64 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 67 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rua));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 70 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Bairo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 73 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 76 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 79 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 82 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Senha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 85 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ConfirmarSenha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "022241da34c5d6777c3118083d81f9aeb5e0009115578", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "022241da34c5d6777c3118083d81f9aeb5e0009117838", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "022241da34c5d6777c3118083d81f9aeb5e0009120104", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 93 "C:\Users\carlos\Desktop\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\pmv-ads-2022-1-e2-proj-int-t2-babybay-mvc-babybay\app-babybay\app-babybay\Views\Usuarios\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<app_babybay.Models.Usuario>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
