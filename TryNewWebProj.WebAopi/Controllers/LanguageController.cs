using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryNewWebProj.Application.Languages.Commands.CreateCommand;
using TryNewWebProj.Application.Languages.Commands.DeleteCommand;
using TryNewWebProj.Application.Languages.Commands.UpdateCommand;
using TryNewWebProj.Application.Languages.Queries.GetlanguageDetails;
using TryNewWebProj.Application.Languages.Queries.GetLanguageList;
using TryNewWebProj.WebAopi.Models.Language;

namespace TryNewWebProj.WebAopi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class LanguageController : BaseController
    {
        private readonly IMapper mapper;

        public LanguageController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the list of languages
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /language
        /// </remarks>
        /// <returns>Returns LanguageListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LanguageListVm>> GetAll()
        {
            var query = new GetLanguageListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the language by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /language/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Language id (guid)</param>
        /// <returns>Returns LanguageDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LanguageListVm>> Get(Guid id)
        {
            var query = new GetLanguageDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the language
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /language
        /// {
        ///     title: "language title",
        /// }
        /// </remarks>
        /// <param name="createLanguageDto">CreateLanguageDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateLanguageDto createLanguageDto)
        {
            var command = mapper.Map<CreateLanguageCommand>(createLanguageDto);
            command.UserId = UserId;
            var languageId = await Mediator.Send(command);
            return Ok(languageId);
        }

        /// <summary>
        /// Updates the language
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /language
        /// {
        ///     title: "updated language title"
        /// }
        /// </remarks>
        /// <param name="updateLanguageDto">UpdateLanguageDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageDto updateLanguageDto)
        {
            var command = mapper.Map<UpdateLanguageCommand>(updateLanguageDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the language by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /language/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the language (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLanguageCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
