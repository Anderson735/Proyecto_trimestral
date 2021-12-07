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
    public class ProductsController : Controller
    {
        public IEnumerable<Products> Index(int id)
        {
            string sql = "SELECT nombre, precio FROM productos WHERE negocio = '" + id + "'";
            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Products> listProducts = new List<Products>();

            listProducts = (from DataRow dr in dt.Rows
                              select new Products()
                              {
                                  name = dr["nombre"].ToString(),
                                  price = Convert.ToDecimal(dr["precio"])
                              }).ToList();

            return listProducts;
        }

        

        [HttpPatch]

        public string Update([FromBody] Products products, int idproduct, int idbusiness)
        {
            string sql = "UPDATE productos SET nombre = '" + products.name + "', precio = '"+ products.price +"' WHERE identificacion = '" + idproduct + "' AND negocio = '"+ idbusiness +"'";
            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);

            return result;
        }

        [HttpDelete]

        public string Delete([FromBody] Products products, int idbusiness)
        {
            string sql = "DELETE FROM productos WHERE idproductos = '" + products.idproducts + "' AND negocio = '" + idbusiness + "'";
            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);

            return result;
        }
    }
}
