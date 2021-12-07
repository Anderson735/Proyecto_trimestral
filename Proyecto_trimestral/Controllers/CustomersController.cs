using Microsoft.AspNetCore.Mvc;
using Proyecto_trimestral.Models;
using Proyecto_trimestral.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_trimestral.Controllers
{
    public class CustomersController : Controller
    {
        public IEnumerable<Customers> Index()
        {
            string sql = "SELECT documento, tipodoc, name1, name2, last_name1, last_name2, negocio FROM usuario";
            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Customers> listCustomers = new List<Customers>();

            listCustomers = (from DataRow dr in dt.Rows
                             select new Customers()
                             {
                                 document = dr["documento"].ToString(),
                                 document_type = dr["tipodoc"].ToString(),
                                 name1 = dr["name1"].ToString(),
                                 name2 = dr["name2"].ToString(),
                                 last_name1 = dr["last_name1"].ToString(),
                                 last_name2 = dr["last_name2"].ToString()                            
                             }).ToList();

            return listCustomers;
        }

        [HttpGet]
        public IEnumerable<Customers> showBusinesses()
        {
            string sql = "SELECT documento, tipodoc, name1, name2, last_name1, last_name2, negocio, nombre, nombre FROM usuario, negocio";
            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Customers> listCustomers = new List<Customers>();

            listCustomers = (from DataRow dr in dt.Rows
                             select new Customers()
                             {
                                 document = dr["documento"].ToString(),
                                 document_type = dr["tipodoc"].ToString(),
                                 name1 = dr["name1"].ToString(),
                                 name2 = dr["name2"].ToString(),
                                 last_name1 = dr["last_name1"].ToString(),
                                 last_name2 = dr["last_name2"].ToString(),
                                 Businesses = new List<Business>()
                                 {
                                     new Business
                                     {
                                         name = dr["nombre"].ToString(),
                                     }
                                 }
                             }).ToList();

            return listCustomers;
        }

        [HttpPost]
        public string Create([FromBody] Customers customers)
        {
            string sql = "INSERT INTO usuario(documento ,tipodoc ,name1 ,name2 , last_name1, last_name2)VALUES('" + customers.document + "', '" + customers.document_type + "', '" + customers.name1 + "', '" + customers.name2 + "', '" + customers.last_name1 + "','" + customers.last_name2 + "')";

            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);

            return result;
        }

        [HttpPatch]

        public string Update([FromBody] Customers customers, string id)
        {
            string sql = "UPDATE users SET documento` = '" + customers.document + "',tipodoc = '" + customers.document_type + "'" +
                ", name1  = '" + customers.name1 + "', name2 = '" + customers.name2 + "', last_name1 = '"+ customers.last_name1 + "'" +
                ", last_name2 = '"+ customers.last_name2 +"' WHERE documento = '"+ id +"'";


            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);
            return result;
        }

        [HttpDelete]

        public string Delete([FromBody] Customers customer)
        {
            string sql = "DELETE FROM users WHERE documento = ('"+ customer.document +"')";

            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);

            return result;
        }
    }
}
