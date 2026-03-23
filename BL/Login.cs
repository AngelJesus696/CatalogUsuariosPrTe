using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {
        public static ML.Result ValidateUser(string Username, string Password)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CatalogoUsuariosEntities context = new DL.CatalogoUsuariosEntities())
                {
                    var usuario = context.GetUsuarioByName(Username).SingleOrDefault();
                    if (usuario != null)
                    {
                        if (usuario.PassWord == Password && usuario.Estatus)
                        {
                            result.Correct = true;
                        }
                        else//no hace falta, ya de vuelve false
                        {
                            result.Correct = false;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existe el usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
