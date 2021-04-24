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
    public class ProduktController : Controller
    {
        string StringsqlConn = "Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;";
        // GET: ProduktController
        public ActionResult Index()
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

        // GET: ProduktController/Details/5
        public ActionResult Details(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from plyta where id_plyta=@ID";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }

            return View(dataTable);
        }

        // GET: ProduktController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduktController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plyta collection)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();

                    string query = "INSERT INTO plyta VALUES(@Tytul, @Autor, @Gatunek,@Zdjecie1, @Zdjecie2, @Cena,@Ilosc,@Opis,@DataWydania);";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@Tytul", collection.Tytul);
                    sqlQuery.Parameters.AddWithValue("@Autor", collection.Autor);
                    sqlQuery.Parameters.AddWithValue("@Gatunek", collection.Gatunek);
                    sqlQuery.Parameters.AddWithValue("@Zdjecie1", collection.Zdjecie1);
                    sqlQuery.Parameters.AddWithValue("@Zdjecie2", collection.Zdjecie2);
                    sqlQuery.Parameters.AddWithValue("@Cena", collection.Cena);
                    sqlQuery.Parameters.AddWithValue("@Ilosc", collection.Ilosc);
                    sqlQuery.Parameters.AddWithValue("@Opis", collection.Opis);
                    sqlQuery.Parameters.AddWithValue("@DataWydania", collection.DataWydania);
                    sqlQuery.ExecuteNonQuery();            
                }
                    return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ProduktController/Edit/5
        public ActionResult Edit(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from plyta where id_plyta=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }

            ViewData["Tytul"] = dataTable.Rows[0][1].ToString();
            ViewData["Autor"] = dataTable.Rows[0][2].ToString();
            ViewData["Gatunek"] = dataTable.Rows[0][3].ToString();
            ViewData["Zdjecie1"] = dataTable.Rows[0][4].ToString();
            ViewData["Zdjecie2"] = dataTable.Rows[0][5].ToString();
            ViewData["Cena"] = dataTable.Rows[0][6].ToString(); 
            ViewData["Ilosc"] = dataTable.Rows[0][7].ToString(); 
            ViewData["Opis"] = dataTable.Rows[0][8].ToString();
            ViewData["DataWydania"] = dataTable.Rows[0][9].ToString();
           

            return View();
        }

        // POST: ProduktController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Plyta collection)
        {

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();
                    string query = "update plyta set tytul=@Tytul, autor=@Autor,gatunek=@Gatunek,zdjecie1=@Zdjecie1,zdjecie2=@Zdjecie2,cena=@Cena,ilosc=@Ilosc,opis=@Opis,data_wydania=@DataWydania where id_plyta=@ID;";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@Tytul", collection.Tytul);
                    sqlQuery.Parameters.AddWithValue("@Autor", collection.Autor);
                    sqlQuery.Parameters.AddWithValue("@Gatunek", collection.Gatunek);
                    sqlQuery.Parameters.AddWithValue("@Zdjecie1", collection.Zdjecie1);
                    sqlQuery.Parameters.AddWithValue("@Zdjecie2", collection.Zdjecie2);
                    sqlQuery.Parameters.AddWithValue("@Cena", collection.Cena);
                    sqlQuery.Parameters.AddWithValue("@Ilosc", collection.Ilosc);
                    sqlQuery.Parameters.AddWithValue("@Opis", collection.Opis);
                    sqlQuery.Parameters.AddWithValue("@DataWydania", collection.DataWydania);
                    sqlQuery.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ProduktController/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "delete from plyta where id_plyta=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                sqlQuery.ExecuteNonQuery();         
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProduktController/Opinia/5
        public ActionResult Opinia(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select o.id_opinia,o.tresc,k.imie,o.id_plyta from opinia o inner join klient k  on o.id_klient=k.id_klient where o.id_plyta=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }

            return View(dataTable);
        }

        // GET: ProduktController/Opinia_edit/5
        public ActionResult Opinia_edit(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from opinia where id_opinia=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }
            ViewData["TrescOpini"] = dataTable.Rows[0][3].ToString();
            return View();
        }

        // POST: ProduktController/Opinia_edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Opinia_edit(int id,Opinia collection)
        {

            if (ModelState.IsValid)
            {
                int id_plyta;
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();
                    string query = "update opinia set tresc=@Tresc where id_opinia=@ID;";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@Tresc", collection.Tresc);
                    sqlQuery.ExecuteNonQuery();

                    query = "SELECT id_plyta from opinia where id_opinia=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    id_plyta = Convert.ToInt32(sqlQuery.ExecuteScalar());
                }
                return RedirectToAction("Opinia", "Produkt", new { @id = id_plyta });

            }
            else
            {
                return View();
            }
        }

        // GET: ProduktController/Opinia_delete/5
        public ActionResult Opinia_delete(int id)
        {
            int id_plyta;
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "SELECT id_plyta from opinia where id_opinia=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                id_plyta = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "delete from opinia where id_opinia=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                sqlQuery.ExecuteNonQuery();

               
            }
            return RedirectToAction("Opinia", "Produkt", new { @id = id_plyta });
        }

        // GET: ProduktController/OpinionsForClient/5
        public ActionResult OpinionsForClient(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select o.id_opinia,o.tresc,k.imie,o.id_plyta,p.autor,p.tytul,k.id_klient from opinia o inner join klient k  on o.id_klient=k.id_klient  inner join plyta p on p.id_plyta=o.id_plyta where o.id_plyta=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }

            return View(dataTable);
        }

        // GET: ProduktController/OpinionAddClient/5
        public ActionResult OpinionAddClient(int id)
        {
            return View();
        }


        // POST: ProduktController/OpinionAddClient/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpinionAddClient(int id, Opinia collection)
        {

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();
                    string query = "INSERT INTO opinia VALUES(@ID_KLIENT, @ID_PLYTA, @TRESC);";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID_PLYTA", id);
                    sqlQuery.Parameters.AddWithValue("@ID_KLIENT", @User.FindFirst("id").Value);
                    sqlQuery.Parameters.AddWithValue("@Tresc", collection.Tresc);
                    sqlQuery.ExecuteNonQuery();
                }
                return RedirectToAction("OpinionsForClient", "Produkt", new { @id = id });            }
            else
            {
                return View();
            }
        }

        // GET: ProduktController/ClientDeleteOpinia/5
        public ActionResult ClientDeleteOpinia(int id)
        {
            int id_plyta;
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "SELECT id_plyta from opinia where id_opinia=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                id_plyta = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "delete from opinia where id_opinia=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                sqlQuery.ExecuteNonQuery();


            }
            return RedirectToAction("OpinionsForClient", "Produkt", new { @id = id_plyta });
        }

        // GET: ProduktController/ClientEditOpinia/5
        public ActionResult ClientEditOpinia(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from opinia where id_opinia=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }
            ViewData["TrescOpini"] = dataTable.Rows[0][3].ToString();
            return View();
        }

        // POST: ProduktController/ClientEditOpinia/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientEditOpinia(int id, Opinia collection)
        {

            if (ModelState.IsValid)
            {
                int id_plyta;
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();
                    string query = "update opinia set tresc=@Tresc where id_opinia=@ID;";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@Tresc", collection.Tresc);
                    sqlQuery.ExecuteNonQuery();

                    query = "SELECT id_plyta from opinia where id_opinia=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    id_plyta = Convert.ToInt32(sqlQuery.ExecuteScalar());
                }
                return RedirectToAction("OpinionsForClient", "Produkt", new { @id = id_plyta });

            }
            else
            {
                return View();
            }
        }

    }
}
