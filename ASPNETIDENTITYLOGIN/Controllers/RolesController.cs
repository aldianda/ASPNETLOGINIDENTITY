using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using ASPNETIDENTITYLOGIN.Models;
using System.Threading.Tasks;

namespace ASPNETIDENTITYLOGIN.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }
        public async Task<ActionResult> GetDataRoles()
        {
            var result = await sqlConnection.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_InsertRole @Name", new { Name = roleVM.Name });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Remove(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_DeleteRole @Id", new { Id = roleVM.Id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Update(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_UpdateRole @Name, @Id", new { Name = roleVM.Name, Id = roleVM.Id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }

    }
}