using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Domain.Customer.Commands;
using VirtualStore.Domain.Customer.Commands.Contracts;
using VirtualStore.Domain.Customer.Handlers;
using VirtualStore.Domain.Customer.Repositories;
using VirtualStore.Shared;

namespace VirtualStore.API.Customer.Controllers;

[ApiController]
[Route("V1/customers")]
[Authorize]
public class CustomerController : ControllerBase
{

    [Route("actives")]
    [HttpGet]
    public IEnumerable<VirtualStore.Domain.Customer.Entities.Customer> GetAllActives(
            [FromServices] ICustomerRepository repository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        
        return repository.GetAllActives();
    }

    [Route("inactives")]
    [HttpGet]
    public IEnumerable<VirtualStore.Domain.Customer.Entities.Customer> GetAllInactives(
        [FromServices] ICustomerRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        return repository.GetAllInactives();
    }

    [Route("Create")]
    [HttpPost]
    public GenericCommandResult Create(
            [FromBody] CreateCustomerCommand command,
            [FromServices] CustomerHandler handler
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("Update")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateCustomerCommand command,
        [FromServices] CustomerHandler handler
    )
    {
        //command.User = "Mario"; Verificar a utilização de usuario vindo do google para autenticação
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-active")]
    [HttpPut]
    public GenericCommandResult MarkAsActive(
            [FromBody] MarkCustomerAsActiveCommand command,
            [FromServices] CustomerHandler handler
        )
    {
        //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-inactive")]
    [HttpPut]
    public GenericCommandResult MarkAsInactive(
        [FromBody] MarkCustomerAsInactiveCommand command,
        [FromServices] CustomerHandler handler
    )
    {
        //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }




}