using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCSHOP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Controllers
{
    public class Klient : Controller
    {
        string StringsqlConn = "Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;";
        // GET: Klient
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from klient";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.Fill(dataTable);
            }
            return View(dataTable);
        }

        // GET: Klient/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from klient p inner join adres a on a.id_adres=p.id_adres inner join siteUser s on p.id_siteUser=s.id_siteUser where p.id_klient=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }

            return View(dataTable);
        }

        // GET: Klient/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klient/Create
        [Authorize(Roles = "admin")]
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
                    sqlQuery.Parameters.AddWithValue("@UserRole", "klient");
                    sqlQuery.ExecuteNonQuery();

                    query = "SELECT TOP 1 id_siteUser FROM siteUser ORDER BY id_siteUser DESC;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    int id_siteUser = Convert.ToInt32(sqlQuery.ExecuteScalar());

                    DateTime data = DateTime.Today;

                    query = "INSERT INTO klient VALUES(@IdAdres,@IdSiteUser,@Imie, @Nazwisko,@Email,@Telefon,@DataZostaniaKlientem);";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@IdAdres", id_adres);
                    sqlQuery.Parameters.AddWithValue("@IdSiteUser", id_siteUser);
                    sqlQuery.Parameters.AddWithValue("@Imie", collection.Imie);
                    sqlQuery.Parameters.AddWithValue("@Nazwisko", collection.Nazwisko);
                    sqlQuery.Parameters.AddWithValue("@DataZostaniaKlientem", data.ToString());
                    sqlQuery.Parameters.AddWithValue("@Email", collection.Email);
                    sqlQuery.Parameters.AddWithValue("@Telefon", collection.Telefon);
                    sqlQuery.ExecuteNonQuery();

                    query = "SELECT TOP 1 id_klient FROM klient ORDER BY id_klient DESC;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    int klient = Convert.ToInt32(sqlQuery.ExecuteScalar());

                    query = "INSERT INTO koszyk VALUES(@Klient);";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@Klient", klient);
                    sqlQuery.ExecuteNonQuery();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Klient/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from klient p inner join adres a on a.id_adres=p.id_adres inner join siteUser s on p.id_siteUser=s.id_siteUser where p.id_klient=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }

            ViewData["Imie"] = dataTable.Rows[0][3].ToString();
            ViewData["Nazwisko"] = dataTable.Rows[0][4].ToString();
            ViewData["Email"] = dataTable.Rows[0][5].ToString();
            ViewData["telefon"] = dataTable.Rows[0][6].ToString();
            ViewData["DataZostaniaKlientem"] = dataTable.Rows[0][7].ToString();

            ViewData["Ulica"] = dataTable.Rows[0][9].ToString();
            ViewData["Lokal"] = dataTable.Rows[0][10].ToString();
            ViewData["Numer lokalu"] = dataTable.Rows[0][11].ToString();
            ViewData["Kod pocztowy"] = dataTable.Rows[0][12].ToString();
            ViewData["Miasto"] = dataTable.Rows[0][13].ToString();

            ViewData["Login"] = dataTable.Rows[0][16].ToString();
            ViewData["Haslo"] = dataTable.Rows[0][15].ToString();
            ViewData["Rola"] = dataTable.Rows[0][17].ToString();

            return View();
        }

        // POST: Klient/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KlientAdresUser collection)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();

                    string query = "select id_adres from klient where id_klient=@ID;";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    int id_adres = Convert.ToInt32(sqlQuery.ExecuteScalar());

                    query = "select id_siteUser from klient where id_klient=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    int id_user = Convert.ToInt32(sqlQuery.ExecuteScalar());

                    query = "update adres set ulica=@Ulica, lokal=@Lokal, numer_lokal=@NumerLokal,kod_pocztowy=@KodPocztowy, miasto=@Miasto where id_adres=@ID";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id_adres);
                    sqlQuery.Parameters.AddWithValue("@Ulica", collection.Ulica);
                    sqlQuery.Parameters.AddWithValue("@Lokal", collection.Lokal);
                    sqlQuery.Parameters.AddWithValue("@NumerLokal", collection.NumerLokal);
                    sqlQuery.Parameters.AddWithValue("@KodPocztowy", collection.KodPocztowy);
                    sqlQuery.Parameters.AddWithValue("@Miasto", collection.Miasto);
                    sqlQuery.ExecuteNonQuery();

                    query = "update siteUser set user_password=@UserPassword, user_login=@UserLogin, user_role=@UserRole where id_siteUser=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id_user);
                    sqlQuery.Parameters.AddWithValue("@UserPassword", collection.UserPassword);
                    sqlQuery.Parameters.AddWithValue("@UserLogin", collection.UserLogin);
                    sqlQuery.Parameters.AddWithValue("@UserRole", collection.UserRole);
                    sqlQuery.ExecuteNonQuery();

                    query = "update klient set imie=@Imie, nazwisko=@Nazwisko,email=@Email,telefon=@Telefon,data_zostania_klientem=@DataZostaniaKlientem where id_klient=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@Imie", collection.Imie);
                    sqlQuery.Parameters.AddWithValue("@Nazwisko", collection.Nazwisko);
                    sqlQuery.Parameters.AddWithValue("@DataZostaniaKlientem", collection.DataZostaniaKlientem);
                    sqlQuery.Parameters.AddWithValue("@Email", collection.Email);
                    sqlQuery.Parameters.AddWithValue("@Telefon", collection.Telefon);
                    sqlQuery.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: Klient/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();

                string query = "select id_adres from klient where id_klient=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                int id_adres = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "select id_siteUser from klient where id_klient=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                int id_user = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "delete from koszyk where id_klient=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                sqlQuery.ExecuteNonQuery();

                query = "delete from klient where id_klient=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                sqlQuery.ExecuteNonQuery();

                query = "delete from adres where id_adres=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id_adres);
                sqlQuery.ExecuteNonQuery();

                query = "delete from siteUser where id_siteUser=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id_user);
                sqlQuery.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }

     
    }
}
