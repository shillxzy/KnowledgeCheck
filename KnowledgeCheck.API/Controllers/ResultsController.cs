using KnowledgeCheck.BLL.DTOs.Result;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities.HelpModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeCheck.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultsController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _resultService.GetAllAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "Сталася внутрішня помилка при отриманні результатів.",
                    details = ex.Message
                });
            }
        }

        [HttpGet("paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaginated([FromQuery] ResultParameters parameters, CancellationToken cancellationToken)
        {
            var paginatedResults = await _resultService.GetPaginatedAsync(parameters, cancellationToken);
            return Ok(paginatedResults);
        }


        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _resultService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Create([FromBody] ResultCreateDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _resultService.CreateResultAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Update(int id, [FromBody] ResultUpdateDto dto)
        {
            await _resultService.UpdateResultAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string userID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var role = User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

                if (string.IsNullOrEmpty(userID))
                {
                    return Unauthorized("Не знайдено ідентифікатор користувача.");
                }

                var result = await _resultService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound($"Результат з id = {id} не знайдено.");
                }

                await _resultService.DeleteResultAsync(id);
                return NoContent();
            }
            catch (ResultNotFoundException)
            {
                return NotFound($"Результат з id = {id} не існує.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Внутрішня помилка сервера при видаленні результату.",
                    details = ex.Message
                });
            }
        }

    }
}
