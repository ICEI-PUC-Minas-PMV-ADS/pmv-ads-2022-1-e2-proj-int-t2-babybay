#pragma checksum "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b861e684d196e637ee9da182af07672176c9e240"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b861e684d196e637ee9da182af07672176c9e240", @"/Views/Usuarios/Relatorio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"470da59ae7bc7837616f866b5995ad4ea39df1df", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Usuarios_Relatorio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<app_babybay.Models.Usuario>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style-guarda-roupa.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/template-style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/card-style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Produtos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MenuProduto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Anuncios", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MenuAnuncio", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-cadastrar-produto-guarda-roupa"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
  
	ViewData["Title"] = "Meu Guarda-Roupas";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC\" crossorigin=\"anonymous\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b861e684d196e637ee9da182af07672176c9e2407945", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b861e684d196e637ee9da182af07672176c9e2409143", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b861e684d196e637ee9da182af07672176c9e24010258", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<main>\r\n<div class=\"Container\">\r\n\t<h2>Guarda-Roupa de ");
#nullable restore
#line 12 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                   Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
	<div class=""container-gr"">
		<ul class=""nav nav-tabs justify-content-center"" id=""myTab"" role=""tablist"">
			<li class=""nav-item"" role=""presentation"">
				<button class=""nav-link active"" id=""home-tab"" data-bs-toggle=""tab"" data-bs-target=""#home"" type=""button"" role=""tab"" aria-controls=""home"" aria-selected=""true"">Minhas Roupas</button>
			</li>
			<li class=""nav-item"" role=""presentation"">
				<button class=""nav-link"" id=""profile-tab"" data-bs-toggle=""tab"" data-bs-target=""#profile"" type=""button"" role=""tab"" aria-controls=""profile"" aria-selected=""false"">Meus Anúncios</button>
			</li>
			<li class=""nav-item"" role=""presentation"">
				<button class=""nav-link"" id=""contact-tab"" data-bs-toggle=""tab"" data-bs-target=""#contact"" type=""button"" role=""tab"" aria-controls=""contact"" aria-selected=""false"">Favoritos</button>
			</li>			
			<li class=""nav-item"" role=""presentation"">
				<button class=""nav-link"" id=""cad-tab"" data-bs-toggle=""tab"" data-bs-target=""#cad"" type=""button"" role=""tab"" aria-controls=""cad"" aria-s");
            WriteLiteral("elected=\"false\">Cadastrar Roupa</button>\r\n\t\t\t</li>\r\n\t\t</ul>\r\n\t\t<div class=\"tab-content\" id=\"myTabContent\">\r\n\t\t\t<div class=\"tab-pane fade show active\" id=\"home\" role=\"tabpanel\" aria-labelledby=\"home-tab\">\r\n\t\t\t\t<div class=\"cards\">\r\n");
#nullable restore
#line 31 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                     foreach (var item in Model.Produtos)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"card\">\r\n\t\t\t\t\t\t\t<img class=\"card-image\" src=\"../img/roupa2.jpeg\">\r\n\t\t\t\t\t\t\t<div class=\"card-infos\">\r\n\t\t\t\t\t\t\t\t<div class=\"card-description\">\r\n\t\t\t\t\t\t\t\t\t<h2>");
#nullable restore
#line 37 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 38 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                  Write(Html.DisplayFor(modelItem => item.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 38 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                                                           Write(Html.DisplayFor(modelItem => item.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\r\n\t\t\t\t\t\t\t\t\t<p class=\"idade\">");
#nullable restore
#line 39 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                                Write(Html.DisplayFor(modelItem => item.Idade));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b861e684d196e637ee9da182af07672176c9e24015091", async() => {
                WriteLiteral("Ver Produto");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
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
            WriteLiteral("\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 44 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div><!--.cards-->\r\n\t\t\t</div><!--primeira-tab-->\r\n\t\t\t<div class=\"tab-pane fade\" id=\"profile\" role=\"tabpanel\" aria-labelledby=\"profile-tab\">\r\n\t\t\t\t<div class=\"cards\">\r\n");
#nullable restore
#line 49 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                     foreach (var item in Model.Anuncios)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"card\">\r\n\t\t\t\t\t\t\t<img class=\"card-image\" src=\"../img/roupa2.jpeg\">\r\n\t\t\t\t\t\t\t<div class=\"card-infos\">\r\n\t\t\t\t\t\t\t\t<div class=\"card-description\">\r\n\t\t\t\t\t\t\t\t\t<h2>");
#nullable restore
#line 55 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"card-price\">\r\n\t\t\t\t\t\t\t\t\t<h2> ");
#nullable restore
#line 58 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Babycoin));

#line default
#line hidden
#nullable disable
            WriteLiteral(" BC</h2>\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b861e684d196e637ee9da182af07672176c9e24019412", async() => {
                WriteLiteral("Ver Anúncio");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
                                                                                                           WriteLiteral(item.AnuncioId);

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
            WriteLiteral("\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 63 "C:\Users\carlos\Documents\GitHub\pmv-ads-2022-1-e2-proj-int-t2-babybay\app-babybay\Views\Usuarios\Relatorio.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"				</div><!--.cards-->
			</div><!--segunda-tab-->
			<div class=""tab-pane fade"" id=""contact"" role=""tabpanel"" aria-labelledby=""contact-tab"">
				elementos favoritos
			</div><!--terceira-tab-->
			<div class=""tab-pane fade"" id=""cad"" role=""tabpanel"" aria-labelledby=""cad-tab"">
				<div class=""card-description"">
					Cadastre um novo produto e aumente suas chances de trocas! É simples, só clicar no botão abaixo:

				</div>
				");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b861e684d196e637ee9da182af07672176c9e24022722", async() => {
                WriteLiteral("Cadastrar Produto");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\t\t\t\t\t\r\n\t\t\t</div><!--terceira-tab-->\r\n\t\t</div><!--.container-gr-->\r\n\t</div> <!--.container-->\r\n</div>\r\n</main>\r\n\r\n\r\n");
            WriteLiteral("\r\n<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM\" crossorigin=\"anonymous\"></script>\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n");
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
