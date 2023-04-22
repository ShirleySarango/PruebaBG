using Microsoft.AspNetCore.Mvc;
using WsMiStream.Modelo;
using WsMiStream.Datos; 

namespace WsMiStream.Controllers
{
    [ApiController]
    [Route("api/Pelicula")]
    public class PeliculasController
    {
        [HttpGet]
        [Route("MostrarPelicula")]
        public async Task<ActionResult<List<MPelicula>>> GetMostrarPelicula()
        {
            var funtion = new DPelicula();
            var lista = new List<MPelicula>();
            lista = await funtion.MostrarPeliculas();
            return lista;
        }
        [HttpGet]
        [Route("MostrarCategorias")]
        public async Task<ActionResult<List<MCategoria>>> GetMostrarCategorias()
        {
            var funtion = new DPelicula();
            var lista = new List<MCategoria>();
            lista = await funtion.MostrarCategorias();
            return lista;
        }

        [HttpPost]
        [Route("MostrarPeliculasUsuario")]
        public async Task<ActionResult<List<MPelicula>>> MostrarPeliculasUsuario([FromBody] MUsuario parametros)
        {
            var funtion = new DPelicula();
            var lista = new List<MPelicula>();
            lista = await funtion.MostrarPeliculasUsuario(parametros);
            return lista;
        }


        [HttpPost]
        [Route("InsertarUsuarioCategoria")]
        public async Task  PostInsertarUsuarioCategoria([FromBody] MUsuarioCategoria parametros) 
        {
            try
            {
                var funtion = new DPelicula();

                await funtion.InsertarUsuarioCategoria(parametros);
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
          

        }
    }
}
