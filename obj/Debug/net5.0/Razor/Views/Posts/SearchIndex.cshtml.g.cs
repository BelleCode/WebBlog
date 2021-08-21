#pragma checksum "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19adcb1ae81fcde9ca2f497fe18b646c70a9744c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Posts_SearchIndex), @"mvc.1.0.view", @"/Views/Posts/SearchIndex.cshtml")]
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
#line 1 "C:\Users\xbell\source\repos\WebBlog\Views\_ViewImports.cshtml"
using WebBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using WebBlog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using WebBlog.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using WebBlog.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
using WebBlog.Services.Iterfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19adcb1ae81fcde9ca2f497fe18b646c70a9744c", @"/Views/Posts/SearchIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c675b91844008e30f0ead8eec7f2c1927e150ec9", @"/Views/_ViewImports.cshtml")]
    public class Views_Posts_SearchIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<Post>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark btn-sm btn-block mb-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PostDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Posts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"row\">\r\n");
#nullable restore
#line 16 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
     foreach (var post in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-sm-2 col-lg-4 mt-3"">
            <div class=""card border-dark"">
                <div class=""card-body text-center"">
                    <div class=""bg-warning"">
                        <hr class=""card-hr"" />
                        <h5 class=""card-title"">");
#nullable restore
#line 23 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
                                          Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <hr class=\"card-hr\" />\r\n                    </div>\r\n                    <div>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 27 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
                                        Write(post.Abstract);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n\r\n                    <br />\r\n                    <div class=\"text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19adcb1ae81fcde9ca2f497fe18b646c70a9744c6670", async() => {
                WriteLiteral("Read More");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
                                                                                                                          WriteLiteral(post.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <img class=\"card-img-bottom\"");
            BeginWriteAttribute("src", " src=\"", 1226, "\"", 1288, 1);
#nullable restore
#line 35 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
WriteAttributeValue("", 1232, imageService.DecodeImage(post.ImageData,  post.Content), 1232, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 38 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<hr />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col h3\">\r\n        Page ");
#nullable restore
#line 45 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
         Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" of ");
#nullable restore
#line 45 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
                                                                        Write(Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 50 "C:\Users\xbell\source\repos\WebBlog\Views\Posts\SearchIndex.cshtml"
   Write(Html.PagedListPager(Model, page => Url.Action("SearchIndex", new { page = page, searchTerm = ViewData["SearchTerm"] }),
            new PagedListRenderOptions
            {
                LiElementClasses = new string[] { "page-item" },
                PageClasses = new string[] { "page-link" }
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<BlogUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IImageService imageService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
