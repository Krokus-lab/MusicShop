using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCSHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Controllers
{
    public class RegisterController : Controller
    {
        string StringsqlConn = "Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;";
        // GET: RegisterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KlientAdresUser collection)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();

                    string query = "INSERT INTO adres VALUES(@Ulica, @Lokal, @NumerLokal,@KodPocztowy, @Miasto);";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@Ulica", collection.Ulica);
                    sqlQuery.Parameters.AddWithValue("@Lokal", collection.Lokal);
                    sqlQuery.Parameters.AddWithValue("@NumerLokal", collection.NumerLokal);
                    sqlQuery.Parameters.AddWithValue("@KodPocztowy", collection.KodPocztowy);
                    sqlQuery.Parameters.AddWithValue("@Miasto", collection.Miasto);
                    sqlQuery.ExecuteNonQuery();

                    query = "SELECT TOP 1 id_adres FROM adres ORDER BY id_adres DESC;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    int id_adres = Convert.ToInt32(sqlQuery.ExecuteScalar());

                    query = "INSERT INTO siteUser VALUES(@UserPassword, @UserLogin, @UserRole);";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@UserPassword", collection.UserPassword);
                    sqlQuery.Parameters.AddWithValue("@UserLogin", collection.UserLogin);
                    sqlQuery.Parameters.AddWithValue("@UserRole", collection.UserRole);
                    sqlQuery.ExecuteNonQuery();

                    query = "SELECT TOP 1 id_siteUser FROM siteUser ORDER BY id_siteUser DESC;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    int id_siteUser = Convert.ToInt32(sqlQuery.ExecuteScalar());

                    query = "INSERT INTO klient VALUES(@IdAdres,@IdSiteUser,@Imie, @Nazwisko,@Email,@Telefon,@DataZostaniaKlientem);";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@IdAdres", id_adres);
                    sqlQuery.Parameters.AddWithValue("@IdSiteUser", id_siteUser);
                    sqlQuery.Parameters.AddWithValue("@Imie", collection.Imie);
                    sqlQuery.Parameters.AddWithValue("@Nazwisko", collection.Nazwisko);
                    sqlQuery.Parameters.AddWithValue("@DataZostaniaKlientem", collection.DataZostaniaKlientem);
                    sqlQuery.Parameters.AddWithValue("@Email", collection.Email);
                    sqlQuery.Parameters.AddWithValue("@Telefon", collection.Telefon);
                    sqlQuery.ExecuteNonQuery();
                }
                TempData["Msg"] = "Account created,now u can log in!";
                return RedirectToAction("Login", "Home", null);
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
