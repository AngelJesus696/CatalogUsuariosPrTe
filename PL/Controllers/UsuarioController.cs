using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);

            }
            return View(usuario);
        }
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.Delete(IdUsuario);
            return RedirectToAction("GetAll");
        }
        [HttpPost]
        public JsonResult Add(ML.Usuario usuario)
        {
            ML.Result result= BL.Usuario.Add(usuario);
            return Json(result);
        }
        public JsonResult Update(ML.Usuario usuario)
        {
            ML.Result result= BL.Usuario.Update(usuario);
            return Json(result);
        }
        public JsonResult GetbyID(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetById(IdUsuario);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}