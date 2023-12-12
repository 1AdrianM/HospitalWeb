using Microsoft.AspNetCore.Mvc;
using Proyecto_Hospital.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Proyecto_Hospital.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verify(Usuario acc)
        {
            try
            {
                if (string.IsNullOrEmpty(acc.Username) || string.IsNullOrEmpty(acc.Password))
                {
                    // Manejar el caso de valores vacíos
                    return View("Error");
                }

                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-TITIKER; database=hospitalDb;integrated security=true; TrustServerCertificate=True"))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand com = new SqlCommand())
                        {
                            com.Connection = conn;
                            com.CommandText = "SELECT * FROM usuario WHERE username = @username AND password = @password";
                            com.Parameters.AddWithValue("@username", acc.Username);
                            com.Parameters.AddWithValue("@password", acc.Password);

                            using (SqlDataReader dr = com.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    return RedirectToAction("Index", "Home", new { area = "" });
                                }
                                else
                                {
                                    return View("Error");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"Error: {ex.Message}");
                return View("Error");
            }
            return View("Error");
        }
    }

}
