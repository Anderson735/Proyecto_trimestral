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
    public class CategoriesController : Controller
    {
        public IEnumerable<Categories> Index()
        {
            string sql = "SELECT nombre FROM categorias";
            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Categories> listCategories = new List<Categories>();

            listCategories = (from DataRow dr in dt.Rows
                              select new Categories()
                              {
                                  name = dr["nombre"].ToString()
                              }).ToList();

            return listCategories;
        }

        [HttpPost]

        public string Create([FromBody] Categories categories)
        {
            string sql = "INSERT INTO categorias(nombre) VALUES ('"+ categories.name +"') ";

            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);

            return result;
        }

        [HttpPatch]

        public string Update([FromBody] Categories categories, string id)
        {
            string sql = "UPDATE categorias SET nombre = '"+ categories.name +"' WHERE idcategoria = '"+ id +"'";
            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);

            return result;
        }

        [HttpDelete]

        public string Delete([FromBody] Categories categories)
        {
            string sql = "DELETE FROM categorias WHERE idcategoria = '"+ categories.id +"'";
            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);

            return result;
        }
    }
}
