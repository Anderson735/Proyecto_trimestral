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
    public class ServicesController : Controller
    {
        public IEnumerable<Services> Index(int idBusiness)
        {
            string sql = "SELECT nombre FROM servicios WHERE negocio = '"+ idBusiness +"'";
            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Services> listServices = new List<Services>();

            listServices = (from DataRow dr in dt.Rows
                            select new Services()
                            {
                                name = dr["nombre"].ToString(),
                            }).ToList();


            return listServices;         
        }


        [HttpPatch]

        public string Update([FromBody] Services services, int idService, int idBusiness )
        {
            string sql = "UPDATE servicios SET nombre = '"+ services.name +"' WHERE idservicios = '"+ idService +"' AND negocio = '"+ idBusiness +"'";

            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);

            return result;
        }

        [HttpDelete]

        public string Delete([FromBody] Services services, int idBusiness)
        {
            string sql = "DELETE FROM servicio WHERE idservicio = '" + services.idservices + "' AND negocio = '" + idBusiness + "'"; 

            DataBase db = new DataBase();

            string result = db.consultaSQL(sql);

            return result;
        }
    }
}
