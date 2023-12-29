using System.ComponentModel.DataAnnotations;
using Devon4Net.Application.WebAPI.Business.EmployeeManagement.Service;
using Devon4Net.Infrastructure.Common;
using Devon4Net.Infrastructure.Cache.Repository;
using Devon4Net.Application.WebAPI.Business.EmployeeManagement.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Application.WebAPI.Business.EmployeeManagement.Controllers
{
    /// <summary>
    /// Employees controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICacheRepository _cache;
        private const string _cacheKey = "Employee";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeeController(IEmployeeService employeeService, ICacheRepository cache)
        {
            _employeeService = employeeService;
            _cache = cache;
        }

        /// <summary>
        /// Gets the entire list of employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployee()
        {
            Devon4NetLogger.Debug("Executing GetEmployee from controller EmployeeController");

            var cacheData = await _cache.GetData<List<EmployeeDto>>(_cacheKey).ConfigureAwait(false);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            var employees = await _employeeService.GetEmployee().ConfigureAwait(false);
            await _cache.SetData(_cacheKey, employees);

            return Ok(employees);
        }

        /// <summary>
        /// Creates an employee
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(EmployeeDto employeeDto)
        {
            Devon4NetLogger.Debug("Executing GetEmployee from controller EmployeeController");
            var result = await _employeeService.CreateEmployee(employeeDto.Name, employeeDto.Surname, employeeDto.Mail).ConfigureAwait(false);

            await _cache.RemoveData(_cacheKey);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Deletes the employee provided the id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([Required]long employeeId)
        {
            Devon4NetLogger.Debug("Executing GetEmployee from controller EmployeeController");

            await _cache.RemoveData(_cacheKey);

            return Ok(await _employeeService.DeleteEmployeeById(employeeId).ConfigureAwait(false));
        }

        /// <summary>
        /// Modifies the done status of the employee provided the data of the employee
        /// In this sample, all the data fields are mandatory
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ModifyEmployee(EmployeeDto employeeDto)
        {
            Devon4NetLogger.Debug("Executing ModifyEmployee from controller EmployeeController");
            if (employeeDto == null || employeeDto.Id == 0)
            {
                return BadRequest("The id of the employee must be provided");
            }

            await _cache.RemoveData(_cacheKey);

            return Ok(await _employeeService.ModifyEmployeeById(employeeDto.Id, employeeDto.Name, employeeDto.Surname, employeeDto.Mail).ConfigureAwait(false));
        }
    }
}
