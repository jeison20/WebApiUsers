using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApiUsers.Application.Ports.Primary;

namespace WebApiUsers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckInformationController : ControllerBase
    {
        readonly ICheckInformationPrimaryPort PrimaryPort;
        public CheckInformationController(ICheckInformationPrimaryPort checkInformationPrimaryPort)
        {
            PrimaryPort = checkInformationPrimaryPort;
        }

        /// <summary>
        /// Query a city's weather from a free API
        /// </summary>
        /// <remarks>       
        /// <description>
        /// It queries a service and returns a list of results with specific data such as humidity and others and then stores them in the database.
        /// </description>
        /// <param name="city">Name of the city to search</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Information([Required] string city)
        {
            var message = await PrimaryPort.HandleCheckInformation(city);

            if (message.Response != StatusCodes.Status200OK.ToString())
            {
                return BadRequest(message);
            }


            return this.StatusCode(StatusCodes.Status200OK, message);
        }


        /// <summary>
        /// View the history of searches made
        /// </summary>
        /// <response code="200">Returns Retrieve a list of all Searchs.</response>
        /// <returns>Retrieve a list of all users.</returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRecrodsInformation()
        {
            var message = await PrimaryPort.HandleCheckRecordsInformation();

            if (message.Response != StatusCodes.Status200OK.ToString())
            {
                return BadRequest(message);
            }

            return this.StatusCode(StatusCodes.Status200OK, message);
        }
    }
}
