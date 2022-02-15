using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Blog.Common.Api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediatr;
        public CategoryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
/*
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] Common.Application.Commands.Category.Insert.Command command)
            => Ok(await _mediatr.Send(command));
        
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Blog.Commands.Category.Update.Command command)
            => Ok(await _mediatr.Send(command));
        
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] Blog.Commands.Category.Delete.Command command)
            => Ok(await _mediatr.Send(command));
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] Blog.Queries.Category.GetAll.Query query)
            => Ok(await _mediatr.Send(query));
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Application.Queries.Category.GetById.Query query)
            => Ok(await _mediatr.Send(query));
        
        [HttpGet("get-nested")]
        public async Task<IActionResult> GetNestedAsync([FromRoute] Application.Queries.Category.GetNested.Query query)
            => Ok(await _mediatr.Send(query));*/
    }
}