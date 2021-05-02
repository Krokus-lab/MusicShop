using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Controllers
{
    public class KoszykController : Controller
    {
        string StringsqlConn = "Server=PIOTR-PC\\BRACSQL;Database=shopMVC;Trusted_Connection=True;";
        // GET: KoszykController
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from koszyk k inner join pozycjaKoszyka p on k.id_koszyk=p.id_koszyk inner join plyta pl on pl.id_plyta=p.id_plyta where k.id_klient=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", User.FindFirst("id").Value);
                sqlData.Fill(dataTable);
            }
            double full_cart_price=0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                full_cart_price += Convert.ToDouble(dataTable.Rows[i][12])*Convert.ToDouble(dataTable.Rows[i][5]);
            }
            ViewData["full_cart_price"] = full_cart_price.ToString() + " zł";

            return View(dataTable);
        }

        public ActionResult DodajZamowienie()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select * from koszyk k inner join pozycjaKoszyka p on k.id_koszyk=p.id_koszyk inner join plyta pl on pl.id_plyta=p.id_plyta where k.id_klient=@ID;";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConn);
                sqlData.SelectCommand.Parameters.AddWithValue("@ID", User.FindFirst("id").Value);
                sqlData.Fill(dataTable);
            }
            double full_cart_price = 0;
            DateTime data = DateTime.Today;
            int zamowienieID;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                full_cart_price += Convert.ToDouble(dataTable.Rows[i][12]) * Convert.ToDouble(dataTable.Rows[i][5]);
            }
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();        
                string query = "INSERT INTO zamowienie VALUES(@ID_KLIENT, @DATA, @Stan,@Cena);";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID_KLIENT", @User.FindFirst("id").Value);
                sqlQuery.Parameters.AddWithValue("@DATA", data.ToString());
                sqlQuery.Parameters.AddWithValue("@Stan", "Przetwarzanie");
                sqlQuery.Parameters.AddWithValue("@Cena", full_cart_price);
                sqlQuery.ExecuteNonQuery();

                query = "SELECT TOP 1 id_zamowienie FROM zamowienie ORDER BY id_zamowienie DESC;";
                sqlQuery = new SqlCommand(query, sqlConn);
                zamowienieID = Convert.ToInt32(sqlQuery.ExecuteScalar());

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    query = "insert into pozycjaZamowienia values (@IDPLYTA,@IDZAMOWIENIE,@ILOSC);";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@IDPLYTA", Convert.ToInt32(dataTable.Rows[i][4]));
                    sqlQuery.Parameters.AddWithValue("@IDZAMOWIENIE", zamowienieID);
                    sqlQuery.Parameters.AddWithValue("@ILOSC", Convert.ToInt32(dataTable.Rows[i][5]));       
                    sqlQuery.ExecuteNonQuery();

                    query = "delete from pozycjaKoszyka where id_pozycjaKoszyka=@ID;;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", Convert.ToInt32(dataTable.Rows[i][2]));
                    sqlQuery.ExecuteNonQuery();

                    query = "select ilosc from plyta where id_plyta=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", Convert.ToInt32(dataTable.Rows[i][4]));
                    int ilosc = Convert.ToInt32(sqlQuery.ExecuteScalar());
                    ilosc -= Convert.ToInt32(dataTable.Rows[i][5]);

                    query = "update plyta set ilosc=@Ilosc where id_plyta=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", Convert.ToInt32(dataTable.Rows[i][4]));
                    sqlQuery.Parameters.AddWithValue("@Ilosc", ilosc);
                    sqlQuery.ExecuteNonQuery();
                }
            }
            TempData["Msg"] = "Dodano zamówienie";
            return RedirectToAction(nameof(Index));
        }



        [Authorize]
        public ActionResult AddToCartFromMainPage(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select id_koszyk from koszyk where id_klient=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", User.FindFirst("id").Value);
                int cartID = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "select id_pozycjaKoszyka from pozycjaKoszyka where id_plyta=@ID and id_koszyk=@IDKOSZYK;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                sqlQuery.Parameters.AddWithValue("@IDKOSZYK", cartID);
                int cartElement = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "select ilosc from plyta where id_plyta=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                int dostepnaIlosc = Convert.ToInt32(sqlQuery.ExecuteScalar());
                int ilosc;

                if (cartElement == 0)
                {
                    ilosc = 1;

                    if (ilosc > dostepnaIlosc)
                    {
                        TempData["Error"] = "Wybrana płyta nie jest aktualnie dostępna na naszym magazynie w tej ilości";
                    }
                    else
                    {
                        TempData["Msg"] = "Dodano do koszyka";
                        query = "insert into pozycjaKoszyka(id_koszyk,id_plyta,ilosc) values (@IDKOSZYK,@IDPLYTA,@ILOSC);";
                        sqlQuery = new SqlCommand(query, sqlConn);
                        sqlQuery.Parameters.AddWithValue("@IDKOSZYK", cartID);
                        sqlQuery.Parameters.AddWithValue("@IDPLYTA", id);
                        sqlQuery.Parameters.AddWithValue("@ILOSC", ilosc);
                        sqlQuery.ExecuteNonQuery();
                    }
                }
                else
                {
                    query = "select ilosc from pozycjaKoszyka where id_pozycjaKoszyka=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", cartElement);
                    ilosc = Convert.ToInt32(sqlQuery.ExecuteScalar());
                    ilosc++;

                    if (ilosc > dostepnaIlosc)
                    {
                        TempData["Error"] = "Wybrana płyta nie jest aktualnie dostępna na naszym magazynie w tej ilości";
                    }
                    else
                    {
                        TempData["Msg"] = "Dodano do koszyka";
                        query = "update pozycjaKoszyka set ilosc=@ILOSC where id_pozycjaKoszyka=@ID;";
                        sqlQuery = new SqlCommand(query, sqlConn);
                        sqlQuery.Parameters.AddWithValue("@ID", cartElement);
                        sqlQuery.Parameters.AddWithValue("@ILOSC", ilosc);
                        sqlQuery.ExecuteNonQuery();
                    }
                }

                
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult PlytaAdd(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();

                string query = "select ilosc from pozycjaKoszyka where id_pozycjaKoszyka=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                int ilosc = Convert.ToInt32(sqlQuery.ExecuteScalar());
                ilosc++;

                query = "select id_plyta from pozycjaKoszyka where id_pozycjaKoszyka=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                int id_plyta = Convert.ToInt32(sqlQuery.ExecuteScalar());

                query = "select ilosc from plyta where id_plyta=@ID;";
                sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id_plyta);
                int dostepnaIlosc = Convert.ToInt32(sqlQuery.ExecuteScalar());

                if (ilosc > dostepnaIlosc)
                {
                    TempData["Error"] = "Wybrana płyta nie jest aktualnie dostępna na naszym magazynie w tej ilości";
                }
                else
                {
                    query = "update pozycjaKoszyka set ilosc=@ILOSC where id_pozycjaKoszyka=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@ILOSC", ilosc);
                    sqlQuery.ExecuteNonQuery();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public ActionResult PlytaRemove(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(StringsqlConn))
            {
                sqlConn.Open();
                string query = "select ilosc from pozycjaKoszyka where id_pozycjaKoszyka=@ID;";
                SqlCommand sqlQuery = new SqlCommand(query, sqlConn);
                sqlQuery.Parameters.AddWithValue("@ID", id);
                int ilosc = Convert.ToInt32(sqlQuery.ExecuteScalar());
                ilosc--;
                if (ilosc > 0)
                {
                    query = "update pozycjaKoszyka set ilosc=@ILOSC where id_pozycjaKoszyka=@ID;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.Parameters.AddWithValue("@ILOSC", ilosc);
                    sqlQuery.ExecuteNonQuery();
                }
                else
                {
                    query = "delete from pozycjaKoszyka where id_pozycjaKoszyka=@ID;;";
                    sqlQuery = new SqlCommand(query, sqlConn);
                    sqlQuery.Parameters.AddWithValue("@ID", id);
                    sqlQuery.ExecuteNonQuery();
                }
            }
            return RedirectToAction(nameof(Index));
        }     
        
    }
}
