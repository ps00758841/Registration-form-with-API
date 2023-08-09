using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginRegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {

            _configuration = configuration;


        }
        [HttpPost]
        [Route("registration")]

        public string registration(Registration registration)

        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyCon").ToString());
           

            
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(UserName,Password,Email,IsActive) VALUES('" + registration.UserName + "', ' " + registration.Password + "', ' " + registration.Email + "','" + registration.IsActive + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return "Data inserted";

            }
            else
            {

                return "Error";
            }
            return "";

        }
    }



}