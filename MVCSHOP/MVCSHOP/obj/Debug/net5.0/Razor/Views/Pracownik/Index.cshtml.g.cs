#pragma checksum "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7559329471b63945b142527e132b8cd3b5b6fe55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pracownik_Index), @"mvc.1.0.view", @"/Views/Pracownik/Index.cshtml")]
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
#line 1 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\_ViewImports.cshtml"
using MVCSHOP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\_ViewImports.cshtml"
using MVCSHOP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7559329471b63945b142527e132b8cd3b5b6fe55", @"/Views/Pracownik/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79462bbe1c6f31d27190616f72c865232e772eee", @"/Views/_ViewImports.cshtml")]
    public class Views_Pracownik_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Data.DataTable>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Pracownicy</h1>\r\n\r\n<table class=\"table table-bordered table-striped\">\r\n    <tr>\r\n        <th>Imie</th>\r\n        <th>Nazwisko</th>\r\n        <th>Data zatrudnienia</th>\r\n        <th>email</th>\r\n        <th>telefon</th>\r\n        <th></th>\r\n    </tr>\r\n");
#nullable restore
#line 17 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
     for (int i = 0; i < Model.Rows.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>");
#nullable restore
#line 20 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
   Write(Model.Rows[i][3]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 21 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
   Write(Model.Rows[i][4]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 22 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
   Write(Model.Rows[i][5]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 23 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
   Write(Model.Rows[i][6]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 24 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
   Write(Model.Rows[i][7]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 566, "\"", 638, 1);
#nullable restore
#line 26 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
WriteAttributeValue("", 573, Url.Action("Details", "Pracownik", new { @id=Model.Rows[i][0] }), 573, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Detale</a> \r\n    </td>\r\n</tr>\r\n");
#nullable restore
#line 29 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 692, "\"", 733, 1);
#nullable restore
#line 32 "C:\Users\Piotr\source\repos\MVCSHOP\MVCSHOP\Views\Pracownik\Index.cshtml"
WriteAttributeValue("", 699, Url.Action("Create", "Pracownik"), 699, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dodaj nowego pracownika</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Data.DataTable> Html { get; private set; }
    }
}
#pragma warning restore 1591
