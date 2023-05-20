using AwBll.Interfaces.Production;
using Common.Runtime;
using Entities.Production;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAwLayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBll _bll;
        public CategoriesController(ICategoryBll categoryBll)
        {
            _bll = categoryBll;
        }
        /// <summary>
        /// Retorna listado de cateogrías
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ProductCategory>> Get()
        {
            return  await _bll.GetAll();
        }

        /// <summary>
        /// Obtiene una categoría que tiene como id el valor especificado
        /// </summary>
        /// <param name="id">Identificador de la categoría</param>
        /// <returns><see cref="ProductCategory"/></returns>
        [HttpGet("{id}")]
        public async Task<ProductCategory> Get(int id)
        {
            return await _bll.GetById(id);
        }

        /// <summary>
        /// Crear una nueva categorìa
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Post(string categoryName)
        {
            return await _bll.Create(categoryName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        public async Task<ExecutionResult> Save(string categoryName)
        {
            return await _bll.Save(categoryName);
        }
        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
