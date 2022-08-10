using AutoMapper;
using DepartmentsRefbook.DataAccess.Repositories;
using DepartmentsRefbook.Domain.Entities;
using DepartmentsRefbook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace DepartmentsRefbook.Controllers
{
    /// <summary>
    /// Контроллер для операций с компаниями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список всех компаний
        /// </summary>
        [HttpGet]
        public async Task<List<CompanyViewModel>> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();
            var model = new List<CompanyViewModel>();
            _mapper.Map(companies, model);

            return model;
        }

        /// <summary>
        /// Импорт справочника подразделений из XML-файла
        /// </summary>
        [HttpPost("import")]
        public async Task<IActionResult> Import([FromForm] ImportFormModel model)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var serializer = new XmlSerializer(typeof(CompanyListModel));
            using (var stream = model.File!.OpenReadStream())
            {
                var companiesData = (CompanyListModel?)serializer.Deserialize(stream);
                if (companiesData == null)
                    return BadRequest(ApiResult.Fail("Неудалось извлечь данные из файла. Проверьте данные и повторите попытку позже."));

                var companyList = new List<Company>();
                _mapper.Map(companiesData.Companies, companyList);

                await _companyRepository.AddCompaniesAsync(companyList);
            }

            return Ok(ApiResult.Ok($"Данные из файла успешно импортированы."));
        }

        /// <summary>
        /// Экспорт справочника подразделений в XML-файл
        /// </summary>
        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            var companies = await _companyRepository.GetCompaniesAsync();
            var model = new CompanyListModel();
            _mapper.Map(companies, model.Companies);

            var serializer = new XmlSerializer(typeof(CompanyListModel));
            using var stream = new MemoryStream();
            using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(writer, model);
            }

            return File(stream.ToArray(), "text/xml", "Справочник подразделений.xml");
        }
    }
}
