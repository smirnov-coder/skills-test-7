using DepartmentsRefbook.DataAccess.Repositories;
using DepartmentsRefbook.Domain.Entities;
using DepartmentsRefbook.General;
using DepartmentsRefbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsRefbook.Controllers
{
    /// <summary>
    /// Контроллер для операций с департаментами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(ICompanyRepository companyRepository, IDepartmentRepository departmentRepository)
        {
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Переместить департамент в другую компанию
        /// </summary>
        [HttpPost("move")]
        public async Task<IActionResult> MoveDepartment([FromBody]MoveDepartmentRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var department = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);
            if (department == null)
                return NotFound(ApiResult.Fail($"Департамент с Id={request.DepartmentId} не найден."));

            var company = await _companyRepository.GetCompanyByIdAsync(request.CompanyId);
            if (company == null)
                return NotFound(ApiResult.Fail($"Компания с Id={request.CompanyId} не найдена."));
            try
            {
                var rowVersion = RowVersionHelper.Decode(request.DepartmentRowVersion!);
                await _departmentRepository.MoveDepartmentToCompanyAsync(department, company, rowVersion);
            }
            catch (DbUpdateConcurrencyException)
            {
                var message = $"Не удалось переместить департамент '{department.Name}' в компанию '{company.Name}', т.к. данные устарели. " +
                    "Обновите страницу и повторите попытку.";
                return BadRequest(ApiResult.Fail(message));
            }

            return Ok(ApiResult.Ok($"Департамент '{department.Name}' успешно перемещён в компанию '{company.Name}'."));
        }

        /// <summary>
        /// Удалить департамент
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeteleDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound(ApiResult.Fail($"Департамент с Id={id} не найден."));

            await _departmentRepository.DeleteDepartmentAsync(department);

            return Ok(ApiResult.Ok($"Департамент '{department.Name}' и все его отделы успешно удалёны."));
        }

        /// <summary>
        /// Создать департамент в компании
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody]CreateDepatmentRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var company = await _companyRepository.GetCompanyByIdAsync(request.CompanyId);
            if (company == null)
                return NotFound(ApiResult.Fail($"Компания с Id={request.CompanyId} не найдена."));

            var department = new Department
            {
                Name = request.DepartmentName,
                CompanyId = company.Id,
            };
            await _departmentRepository.AddDepartmentAsync(department);

            return Ok(ApiResult.Ok($"Департамент '{department.Name}' успешно добавлен в компанию '{company.Name}'."));
        }
    }
}
