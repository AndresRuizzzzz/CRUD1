using CRUD1.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD1.Data
{
    public class ContactoData
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();
            var cn = new Conexion();

            using(var conexion = new SqlConnection(cn.GetSQLString()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            idContacto = Convert.ToInt32(reader["idContacto"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }


        public  ContactoModel Obtener(int idContacto)
        {
            var oContacto= new ContactoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetSQLString()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conexion);
                cmd.Parameters.AddWithValue("@idContacto", idContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oContacto.idContacto = Convert.ToInt32(reader["idContacto"]);
                        oContacto.Nombre = reader["Nombre"].ToString();
                        oContacto.Telefono = reader["Telefono"].ToString();
                        oContacto.Correo = reader["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Crear(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetSQLString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_crear", conexion);
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetSQLString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar", conexion);
                    cmd.Parameters.AddWithValue("@idContacto", oContacto.idContacto);
                    cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }



        public bool Eliminar(int idContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetSQLString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar", conexion);
                    cmd.Parameters.AddWithValue("@idContacto", idContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }
    }
}
