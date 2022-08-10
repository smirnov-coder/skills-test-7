using DepartmentsRefbook.DataAccess.Repositories;
using DepartmentsRefbook.Domain.Entities;
using DepartmentsRefbook.General;
using DepartmentsRefbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsRefbook.Controllers
{
    /// <summary>
    /// Контроллер для операций с отделами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public BranchesController(IBranchRepository branchRepository, IDepartmentRepository departmentRepository)
        {
            _branchRepository = branchRepository;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Переместить отдел в другой департамент
        /// </summary>
        [HttpPost("move")]
        public async Task<IActionResult> MoveBranch([FromBody] MoveBranchRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var branch = await _branchRepository.GetBranchByIdAsync(request.BranchId);
            if (branch == null)
                return NotFound(ApiResult.Fail($"Отдел с Id={request.BranchId} не найден."));

            var department = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);
            if (department == null)
                return NotFound(ApiResult.Fail($"Департамент с Id={request.DepartmentId} не найден."));

            try
            {
                var rowVersion = RowVersionHelper.Decode(request.BranchRowVersion!);
                await _branchRepository.MoveBranchToDepartmentAsync(branch, department, rowVersion);
            }
            catch (DbUpdateConcurrencyException)
            {
                var message = $"Не удалось переместить отдел '{branch.Name}' в департамент '{department.Name}', т.к. данные устарели. " +
                    "Обновите страницу и повторите попытку.";
                return BadRequest(ApiResult.Fail(message));
            }

            return Ok(ApiResult.Ok($"Отдел '{branch.Name}' успешно перемещён в департамент '{department.Name}'."));
        }

        /// <summary>
        /// Удалить отдел
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeteleBranch(int id)
        {
            var branch = await _branchRepository.GetBranchByIdAsync(id);
            if (branch == null)
                return NotFound(ApiResult.Fail($"Отдел с Id={id} не найден."));

            await _branchRepository.DeleteBranchAsync(branch);

            return Ok(ApiResult.Ok($"Отдел '{branch.Name}' успешно удалён."));
        }

        /// <summary>
        /// Создать новый отдел в департамента
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var department = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);
            if (department == null)
                return NotFound(ApiResult.Fail($"Департамент с Id={request.DepartmentId} не найден."));

            var branch = new Branch
            {
                Name = request.BranchName,
                DepartmentId = department.Id,
            };
            await _branchRepository.AddBranchAsync(branch);

            return Ok(ApiResult.Ok($"Отдел '{branch.Name}' успешно добавлен в департамент '{department.Name}'."));
        }
    }
}
