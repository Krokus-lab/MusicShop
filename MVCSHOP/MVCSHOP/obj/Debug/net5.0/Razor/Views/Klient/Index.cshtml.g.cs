#pragma checksum "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fec89ae835282981bb1aaafe4342bbec5c00bdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Klient_Index), @"mvc.1.0.view", @"/Views/Klient/Index.cshtml")]
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
#line 1 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\_ViewImports.cshtml"
using MVCSHOP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\_ViewImports.cshtml"
using MVCSHOP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fec89ae835282981bb1aaafe4342bbec5c00bdb", @"/Views/Klient/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79462bbe1c6f31d27190616f72c865232e772eee", @"/Views/_ViewImports.cshtml")]
    public class Views_Klient_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Data.DataTable>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Klienci</h1>\r\n\r\n<table class=\"table table-bordered table-striped\">\r\n    <tr>\r\n        <th>Imie</th>\r\n        <th>Nazwisko</th>\r\n        <th>email</th>\r\n        <th>telefon</th>\r\n        <th>Data zostania klientem</th>\r\n        <th></th>\r\n    </tr>\r\n");
#nullable restore
#line 17 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
     for (int i = 0; i < Model.Rows.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
           Write(Model.Rows[i][3]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
           Write(Model.Rows[i][4]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
           Write(Model.Rows[i][5]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
           Write(Model.Rows[i][6]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
           Write(Model.Rows[i][7]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 632, "\"", 701, 1);
#nullable restore
#line 26 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
WriteAttributeValue("", 639, Url.Action("Details", "Klient", new { @id=Model.Rows[i][0] }), 639, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Detale</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 29 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 770, "\"", 808, 1);
#nullable restore
#line 32 "C:\Users\Piotr\Documents\GitHub\MusicShop\MVCSHOP\MVCSHOP\Views\Klient\Index.cshtml"
WriteAttributeValue("", 777, Url.Action("Create", "Klient"), 777, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dodaj nowego klienta</a>");
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
