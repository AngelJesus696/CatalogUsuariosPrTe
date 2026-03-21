using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CatalogoUsuariosEntities context = new DL.CatalogoUsuariosEntities())
                {
                    int filaAfectada = context.UsuarioADD(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, Encoding.ASCII.GetBytes(usuario.Password), usuario.Correo, usuario.Estatus, DateTime.Now);
                    if (filaAfectada > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Fallo en algo";
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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CatalogoUsuariosEntities context = new DL.CatalogoUsuariosEntities())
                {
                    int filaAfectada = context.UsuarioUpdate(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, Encoding.ASCII.GetBytes(usuario.Password), usuario.Correo, usuario.Estatus, DateTime.Now);
                    if (filaAfectada > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CatalogoUsuariosEntities context = new DL.CatalogoUsuariosEntities())
                {
                    var listaUsuarios = context.UsuarioGetAll().ToList();
                    if (listaUsuarios.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var UsuarioBD in listaUsuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = UsuarioBD.IdUsuario;
                            usuario.Nombre = UsuarioBD.Nombre;
                            usuario.ApellidoPaterno = UsuarioBD.ApellidoPaterno;
                            usuario.ApellidoMaterno = UsuarioBD.ApellidoMaterno;
                            usuario.UserName = UsuarioBD.UserName;
                            usuario.Password = Convert.ToString(UsuarioBD.PassWord);
                            usuario.Correo = UsuarioBD.Correo;
                            usuario.Estatus = UsuarioBD.Estatus;
                            usuario.FechaAlta = UsuarioBD.FechaAlta;
                            if (UsuarioBD.FechaModificacion == null)
                            {
                                
                            }
                            else
                            {
                                usuario.FechaModificacion = UsuarioBD.FechaModificacion.Value;
                            }

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
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
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CatalogoUsuariosEntities context = new DL.CatalogoUsuariosEntities())
                {
                    var Usuario = context.UsuarioGetById(IdUsuario).SingleOrDefault();
                    if (Usuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = Usuario.IdUsuario;
                        usuario.Nombre = Usuario.Nombre;
                        usuario.ApellidoPaterno = Usuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = Usuario.ApellidoMaterno;
                        usuario.UserName = Usuario.UserName;
                        usuario.Password = Convert.ToString(Usuario.PassWord);
                        usuario.Correo = Usuario.Correo;
                        usuario.Estatus = Usuario.Estatus;
                        usuario.FechaAlta = Usuario.FechaAlta;
                        usuario.FechaModificacion = Usuario.FechaModificacion.Value;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
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
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CatalogoUsuariosEntities context = new DL.CatalogoUsuariosEntities())
                {
                    var filasAfectas = context.UsuarioDelete(IdUsuario);
                    if (filasAfectas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
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
