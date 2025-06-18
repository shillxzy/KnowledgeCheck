using KnowledgeCheck.BLL.DTOs.Test;
using KnowledgeCheck.BLL.Services;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities.HelpModels;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _testService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _testService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(TestCreateDto dto)
        {
            var result = await _testService.CreateTestAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TestUpdateDto dto)
        {
            await _testService.UpdateTestAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _testService.DeleteTestAsync(id);
            return NoContent();
        }


        [HttpGet("paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaginated([FromQuery] TestParameters parameters, CancellationToken cancellationToken)
        {
            var paginatedResults = await _testService.GetPaginatedAsync(parameters, cancellationToken);
            return Ok(paginatedResults);
        }
    }
}
