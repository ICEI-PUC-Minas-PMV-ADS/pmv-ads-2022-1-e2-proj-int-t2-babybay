#pragma checksum "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efa112e5b9eff19395c9779b50c50fc9c883a75b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Relatorio), @"mvc.1.0.view", @"/Views/Usuarios/Relatorio.cshtml")]
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
#line 1 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\_ViewImports.cshtml"
using app_babybay;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\_ViewImports.cshtml"
using app_babybay.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efa112e5b9eff19395c9779b50c50fc9c883a75b", @"/Views/Usuarios/Relatorio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"470da59ae7bc7837616f866b5995ad4ea39df1df", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Usuarios_Relatorio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<app_babybay.Models.Usuario>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Trocas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
  
	ViewData["Title"] = "Meu Guarda-Roupas";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Minhas Roupas</h1>

<div>
	<hr />
	<table class=""table"">
		<thead>
			<tr>
				<th>
					Nome
				</th>
				<th>
					Cor
				</th>
				<th>
					Idade
				</th>
				<th>
					Tamanho
				</th>
				<th>
					Tempo de Uso
				</th>
				<th>
					Descrição
				</th>
				<th>
					Categoria
				</th>
			</tr>
		</thead>
		<tbody>
");
#nullable restore
#line 38 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
             foreach (var item in Model.Produtos)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 42 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 45 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 48 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Idade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 51 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Tamanho));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 54 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.TempoUso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 57 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\n\t\t\t\t\t");
#nullable restore
#line 60 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
               Write(Html.DisplayFor(modelItem => item.Categoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t\t<td>\t\t\t\t\t\n\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efa112e5b9eff19395c9779b50c50fc9c883a75b8136", async() => {
                WriteLiteral("Anunciar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
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
            WriteLiteral("\n\t\t\t\t</td>\n\t\t\t</tr>\n");
#nullable restore
#line 66 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</tbody>\n\t</table>\n</div>\n<div>\t\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efa112e5b9eff19395c9779b50c50fc9c883a75b11065", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<app_babybay.Models.Usuario> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
