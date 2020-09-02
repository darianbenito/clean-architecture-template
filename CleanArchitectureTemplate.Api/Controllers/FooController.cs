using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Api.Dtos;
using CleanArchitectureTemplate.Api.OutputPorts;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.EntityCrudUseCases.Create;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Create;
using CleanArchitectureTemplate.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FooController : ControllerBase
    {
        private readonly ICreateFooUseCase _createFooUseCase;

        public FooController(ICreateFooUseCase createFooUseCase)
        {
            _createFooUseCase = createFooUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFooDto createFooDto)
        {
            var createFooOutputPort = new CreateFooOutputPort();

            var newFoo = new Foo
            {
                Name = createFooDto.Name
            };

            var createFooUseCaseRequest = new CreateEntityUseCaseRequest<Foo>(newFoo);

            _createFooUseCase.Execute(createFooUseCaseRequest, createFooOutputPort);

            return createFooOutputPort.ActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateFooDto createFooDto)
        {
            var createFooOutputPort = new CreateFooOutputPort();

            var newFoo = new Foo
            {
                Name = createFooDto.Name
            };

            var createFooUseCaseRequest = new CreateEntityUseCaseRequest<Foo>(newFoo);

            await _createFooUseCase.ExecuteAsync(createFooUseCaseRequest, createFooOutputPort);

            return createFooOutputPort.ActionResult;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Foo> foos = new List<Foo> { new Foo { Id = 1, Name = "Hello" } };

            return new OkObjectResult(foos);
        }
    }
}
