using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryNewWebProj.Application.Words.Command.CreateCommand;
using TryNewWebProj.Application.Words.Command.DeleteCommand;
using TryNewWebProj.Application.Words.Command.UpdateCommand;
using TryNewWebProj.Application.Words.Queries.GetWordDetails;
using TryNewWebProj.Application.Words.Queries.GetWordList;
using TryNewWebProj.WebAopi.Models.Word;

namespace TryNewWebProj.WebAopi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class WordController : BaseController
    {
        private readonly IMapper mapper;

        public WordController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets Word by language id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Word/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="languageId"></param>
        /// <returns>Returns WordListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("bylanguage/{languageId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<WordListVm>> GetAll(Guid languageId)
        {
            var dict = new GetWordListQuery()
            {
                LanguageId = languageId
            };
            var vm = await Mediator.Send(dict);
            return Ok(vm);
        }

        /// <summary>
        /// Gets Word by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Word/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Returns WordListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Get(Guid id)
        {
            var query = new GetWordDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        ///  Creates the Word
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /Word
        /// {
        ///     title: "Word title"
        /// }
        /// </remarks>
        /// <param name="createWordDto"></param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateWordDto createWordDto)
        {
            var command = mapper.Map<CreateWordCommand>(createWordDto);
            var dictId = await Mediator.Send(command);
            return Ok(dictId);
        }

        /// <summary>
        /// Update the word
        /// </summary>
        /// <remarks>
        /// PUT /Word
        /// {
        ///     title: "updated word title"
        /// }
        /// </remarks>
        /// <param name="updateWordDto"></param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateWordDto updateWordDto)
        {
            var command = mapper.Map<UpdateWordCommand>(updateWordDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the Word by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /Word/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the Word (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteWordCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
