#pragma checksum "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb291cd072717ff710565ab722fdcb9694213dde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Anuncios_Busca), @"mvc.1.0.view", @"/Views/Anuncios/Busca.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb291cd072717ff710565ab722fdcb9694213dde", @"/Views/Anuncios/Busca.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"470da59ae7bc7837616f866b5995ad4ea39df1df", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Anuncios_Busca : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<app_babybay.Models.Anuncio>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/template-page-index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
  
	ViewData["Title"] = "Busca";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--Ver uma forma de renderizar-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cb291cd072717ff710565ab722fdcb9694213dde4329", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"	<!--Cod copiado de home/index -->
<div class=""container"">
	<section>
		<article class=""article-busca"">
			<div class=""article__busca--contorno"">
				<div class=""menu-busca"">
					<input class=""input__busca"" type=""search"" name=""input-buscar"" id=""input-buscar""
						   placeholder=""Busque uma roupa""> <!-- .input__busca-->
");
#nullable restore
#line 16 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
                     using (Html.BeginForm("Busca", "Anuncios", FormMethod.Post))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<h2>Nome do produto</h2>\r\n");
#nullable restore
#line 19 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
                   Write(Html.TextBox("nomeProduto"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<h2>Idade</h2>\r\n");
#nullable restore
#line 22 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
                   Write(Html.TextBox("idadeProduto"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<h2>Categoria</h2>\r\n");
#nullable restore
#line 25 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
                   Write(Html.DropDownList("Categoria",
					new SelectList(Enum.GetValues(typeof(Categoria))),
					"Selecione",
					new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<input class=\"input__busca--botao\" type=\"submit\" value=\"Buscar\"/>\t\t\t\t\t\t\r\n");
#nullable restore
#line 30 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
					}		

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div> <!-- .menu__busca -->\r\n\t\t\t</div> <!-- .article__busca--contorno-->\r\n\t\t</article> <!-- .article-busca -->\r\n\t</section>\r\n</div><!--Cod copiado de home/index -->\r\n\r\n<section>\r\n\t<table class=\"table\">\r\n\t\t<tbody>\r\n");
#nullable restore
#line 40 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
             foreach (var item in Model)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 44 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AnuncioId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 47 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 50 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Anuncios\Busca.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</tbody>\r\n\t</table>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<app_babybay.Models.Anuncio>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
