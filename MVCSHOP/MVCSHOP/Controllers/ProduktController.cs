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
    }
}
