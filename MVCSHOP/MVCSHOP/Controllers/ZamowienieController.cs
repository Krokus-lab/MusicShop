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
    public class ZamowienieController : Controller
    {
        string StringsqlConn = "Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;";
        // GET: ProduktController
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from zamowienie";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.Fill(dataTable);
            }
            return View(dataTable);
        }

        // GET: ProduktController/StatusEdit/5
        public ActionResult StatusEdit(int id)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from zamowienie where id_zamowienie=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlData.Fill(dataTable);
            }
            ViewData["Status"] = dataTable.Rows[0][3].ToString();
            return View();
        }

        // POST: ProduktController/StatusEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StatusEdit(int id, Zamowienia collection)
        {

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
                {
                    sqlConn.Open();
                    string query = "update zamowienie set stan_zamowienia=@Stan where id_zamowienie=@ID;";
                    SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@Stan", collection.StanZamowienia);
                    sqlQuery.ExecuteNonQuery();

                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
