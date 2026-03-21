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
        [HttpPost]
        public JsonResult Add(ML.Usuario usuario)
        {
            ML.Result result= BL.Usuario.Add(usuario);
            return Json(result);
        }
    }
}