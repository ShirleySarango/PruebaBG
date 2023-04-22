using WsMiStream.Modelo;
using WsMiStream.Conexion;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace WsMiStream.Datos
{
    public class DPelicula
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MPelicula>> MostrarPeliculas()
        {
        var lista = new List<MPelicula>();
        using(var sql= new SqlConnection(cn.ConexionSql()))
        {
                using(var cmd= new SqlCommand("consultarPeliculas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item=await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var mpeliculas = new MPelicula()
                            {
                                Id= (Int64)item["id"],
                                Nombre = (string)item["nombre"]
                            };

                            lista.Add(mpeliculas);

                        }

                    }


                }
        }

        return lista;
 
        }
     
        public async Task<List<MPelicula>> InsertarUsuarioCategoria(MUsuarioCategoria uc)
        {
            var lista = new List<MPelicula>();
            using (var sql = new SqlConnection(cn.ConexionSql()))
            {
                using (var cmd = new SqlCommand("insertarUsuarioCategoria", sql))
                {
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario ", uc.IdUsuario);
                    cmd.Parameters.AddWithValue("@idCategoria", uc.IdCategoria);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                   

                }
            }

            return lista;

        }

        public async Task<List<MPelicula>> MostrarPeliculasUsuario(MUsuario usuario)
        {
            var lista = new List<MPelicula>();
            using (var sql = new SqlConnection(cn.ConexionSql()))
            {
                using (var cmd = new SqlCommand("consultarPeliculaUsuario", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mpeliculas = new MPelicula()
                            {
                                Id = (Int64)item["id"],
                                Nombre = (string)item["nombre"]
                            };

                            lista.Add(mpeliculas);

                        }

                    }


                }
            }

            return lista;

        }

        public async Task<List<MPelicula>> InsertarUsuario(MUsuario uc)
        {
            var lista = new List<MPelicula>();
            using (var sql = new SqlConnection(cn.ConexionSql()))
            {
                using (var cmd = new SqlCommand("insertarUsuario", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario ", uc.Nombre);
                    cmd.Parameters.AddWithValue("@alias", uc.Alias);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();



                }
            }

            return lista;

        }

        public async Task<List<MCategoria>> MostrarCategorias()
        {
            var lista = new List<MCategoria>();
            using (var sql = new SqlConnection(cn.ConexionSql()))
            {
                using (var cmd = new SqlCommand("consultarCategoria", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcategorias = new MCategoria()
                            {
                                Id = (int)item["id"],
                                Nombre = (string)item["nombre"]
                            };

                            lista.Add(mcategorias);

                        }

                    }


                }
            }

            return lista;

        }

    }
}
