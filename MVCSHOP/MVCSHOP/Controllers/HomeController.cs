using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MVCSHOP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCSHOP.Controllers
{
    public class HomeController : Controller
    {
        string StringsqlConn = "Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from plyta";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.Fill(dataTable);
            }
            return View(dataTable);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string name, string password, string returnUrl)
        {
            if (string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "Nie podałeś loginu";
                return View("login");
            }
            if (string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Nie podałeś hasła";
                return View("login");
            }
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from siteUser where user_login=@name and user_password=@password;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@name", name);
                sqlData.SelectCommand.Parameters.AddWithValue("@password", password);
                sqlData.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    query = "select * from pracownik where id_siteUser=@ID;";
                    sqlData = new SqlDataAdapter(query, sqlConn);
                    sqlData.SelectCommand.Parameters.AddWithValue("@ID", @dataTable.Rows[0][0]);
                    sqlData.Fill(dataTable2);

                    if (dataTable2.Rows.Count == 0)
                    {
                        query = "select * from klient where id_siteUser=@ID;";
                        sqlData = new SqlDataAdapter(query, sqlConn);
                        sqlData.SelectCommand.Parameters.AddWithValue("@ID", @dataTable.Rows[0][0]);
                        sqlData.Fill(dataTable2);
                    }
                }
            }
                ViewData["ReturnUrl"] = returnUrl;

                if (dataTable.Rows.Count != 0)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim("id", @dataTable2.Rows[0][0].ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, @dataTable2.Rows[0][3].ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, @dataTable2.Rows[0][3].ToString()));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction(nameof(Index));
                }
                TempData["Error"] = "Błędne hasło lub login";
                return View("login");
            }
            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        
    }
}
