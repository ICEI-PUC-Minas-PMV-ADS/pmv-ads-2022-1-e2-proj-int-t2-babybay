#pragma checksum "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fb084e862044c6036af16b3973d65429380c1a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\_ViewImports.cshtml"
using app_babybay;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\_ViewImports.cshtml"
using app_babybay.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fb084e862044c6036af16b3973d65429380c1a4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2c07a4573f2b3d4e39208d40f0608652029373d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<app_babybay.Models.Anuncio>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/template-page-index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Usuarios", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("input__botao--cadastro"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
  
	ViewData["Title"] = "Início";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1fb084e862044c6036af16b3973d65429380c1a45337", async() => {
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
            WriteLiteral(@"
<div class=""container"">
	<section>
		<article class=""article-busca"">
			<div class=""article__busca--contorno"">
				<div class=""menu-busca"">
					<input class=""input__busca"" type=""search"" name=""input-buscar"" id=""input-buscar""
						   placeholder=""Busque uma roupa"">

");
#nullable restore
#line 17 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
                     using (Html.BeginForm("Busca", "Anuncios", FormMethod.Post))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<h2>Nome do produto</h2>\r\n");
#nullable restore
#line 20 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
                   Write(Html.TextBox("nomeProduto"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<h2>Idade</h2>\r\n");
#nullable restore
#line 23 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
                   Write(Html.TextBox("idadeProduto"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<h2>Categoria</h2>\r\n");
#nullable restore
#line 26 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
                   Write(Html.DropDownList("Categoria",
							new SelectList(Enum.GetValues(typeof(Categoria))),
							"Selecione",
							new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<input class=\"input__busca--botao\" type=\"submit\" value=\"Buscar\"/>\r\n");
#nullable restore
#line 32 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div> <!-- .menu__busca -->\r\n\t\t\t</div> <!-- .article__busca--contorno-->\r\n\t\t</article> <!-- .article-busca -->\r\n\t</section>\r\n\t<h3>");
#nullable restore
#line 37 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
   Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n\t<main>\r\n");
#nullable restore
#line 40 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
         if (!User.Identity.IsAuthenticated) // Se user autenticado, então não mostrar
		{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"			<div class=""conteudo-principal"">
				<div class=""conteudo__h1"">
					<h1 class=""conteudo__h1--padding"">1. Poste suas roupas</h1>
					<h1 class=""conteudo__h1--padding"">2. Ganhe BabyCoins</h1>
					<h1 class=""conteudo__h1--padding"">3. Troque por outras roupas</h1>
				</div> <!-- .conteudo__h1 -->
			</div> <!-- .conteudo-principal -->
			<div class=""conteudo__botao__cadastro"">
				");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fb084e862044c6036af16b3973d65429380c1a49524", async() => {
                WriteLiteral("CADASTRE-SE");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("\t\t\t</div> <!-- .conteudo__cadastre__botao-->\r\n");
#nullable restore
#line 53 "C:\Users\user\Source\Repos\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t</main>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<app_babybay.Models.Anuncio> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
