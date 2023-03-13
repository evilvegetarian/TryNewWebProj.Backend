using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryNewWebProj.Application.Settings.Command.UpdateCommand;
using TryNewWebProj.Application.Settings.Queries.GetSettingDetails;
using TryNewWebProj.Application.Settings.Queries.GetSettingDetailsByWordId;
using TryNewWebProj.WebAopi.Models.Setting;

namespace TryNewWebProj.WebAopi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class SettingController : BaseController
    {
        private readonly IMapper mapper;

        public SettingController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets setting by wordId
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /Word/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="wordId"></param>
        /// <returns>Returns SettingDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{wordId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SettingDetailsVM>> Get(Guid wordId)
        {
            var sett = new GetSettingDetailsByWordIdQuery
            {
                WordId = wordId
            };
            var vm =await Mediator.Send(sett);
            return Ok(vm);
        }

        /// <summary>
        /// update the setting the quiz compleate
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Put /Setting
        /// {
        ///     wordId:"D34D349E-43B8-429E-BCA4-793C932FD580",
        ///     learn:"true"
        /// }
        /// </remarks>
        /// <param name="updateSetting"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLearn( UpdateSettingLearnDto updateSetting)
        {
            var command = mapper.Map<UpdateSettingLearnCommand>(updateSetting);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// update the  all settings
        /// </summary>
        /// <returns>Returns NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpPut("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateAll()
        {
            var sett = new UpdateAllSettingCommand
            {
                UserId = UserId
            };

            await Mediator.Send(sett);
            return NoContent();
        }
    }
}
