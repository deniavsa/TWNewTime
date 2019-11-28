
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TW.Models;
using TW.Repositorios;

namespace TW.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClassificadoController : ControllerBase
    {
        ClassificadoRepositorio repositorio = new ClassificadoRepositorio();

        // /api/Classificado?busca=tela17&marca=dell&categoria=notebook
        /// <summary>
        /// Método para buscar a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="marca">Envia uma marca.</param>
        /// <param name="categoria">Envia uma categoria.</param>
        /// <param name="ordenacao">Envia um estado true para ordenar Crescente e false para ordenar decrescente.</param>
        /// <returns>Retorna a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.</returns>
        [HttpGet]
        [Authorize(Roles="Comum")]
        public async Task<IActionResult> GetHome(string busca, string marca, string categoria, bool ordenacao)
        {
            return Ok(await repositorio.Get(busca, marca, categoria, ordenacao));
        }


        // [HttpGet]
        // public async Task<ActionResult<List<Classificado>>> Get() //definição do tipo de retorno
        // {
        //     try
        //     {
        //         return await repositorio.Get();
        //         //await vai esperar traser a lista para armazenar em Categoria
        //     }
        //     catch (System.Exception)
        //     {
        //         throw;
        //     } 
            
        // }

    /// <summary>
    /// Método para buscar um classificado específico com todas as informações (Equipamento,Imagens).
    /// </summary>
    /// <param name="id">Envia um id.</param>
    /// <returns>Retorna um classificado específico com todas as informações (Equipamento,Imagens).</returns>
    [Authorize(Roles="Comum")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Classificado>> GetProductClassificado(int id)
    {
        Classificado classificadoRetornado = await repositorio.GetPageProduct(id);
        if(classificadoRetornado == null)
        {
            return NotFound();
        }
        return classificadoRetornado;
    }
    
     

    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<Classificado>> GetAction(int id)
    //     {
    //         Classificado classificadoRetornado = await repositorio.Get(id);
    //         if(classificadoRetornado == null)
    //         {
    //             return NotFound();
    //         }
    //         return classificadoRetornado;
    //     }

        
        // [HttpPost]
        // public async Task<ActionResult<Classificado>> Post(Classificado classificado)
        // {
        //     try
        //     {
        //         await repositorio.Post(classificado);
        //     }
        //     catch (System.Exception)
        //     {
        //         throw;
        //     }
        //     return classificado;
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Classificado>> Put(int id, Classificado classificado)
        // {
        //     if(id != classificado.IdClassificado)
        //     {
        //         return BadRequest();
        //     }
        //     try
        //     {
        //        return await repositorio.Put(classificado);
                
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         var classificadoValida = await repositorio.Get(id);
        //         if(classificadoValida == null)
        //         {
        //             return NotFound();
        //         }else{
        //             throw;
        //         }
        //     }
        // }
    }
}