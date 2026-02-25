using HouseholdExpenses.Application.Interfaces;
using HouseholdExpenses.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesAPI.Controllers
{
    /// <summary>
    /// Endpoint para gestão de categorias de despesas e receitas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service) => _service = service;

        /// <summary> Retorna todas as categorias disponíveis no sistema. </summary>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        /// <summary> Cadastra uma nova categoria. </summary>
        [HttpPost]
        public async Task<IActionResult> Create(Category category) => Ok(await _service.CreateAsync(category));
    }
}
