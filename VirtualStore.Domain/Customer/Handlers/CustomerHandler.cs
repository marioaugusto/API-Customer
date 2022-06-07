using Flunt.Notifications;
using VirtualStore.Domain.Customer.Commands;
using VirtualStore.Domain.Customer.Commands.Contracts;
using VirtualStore.Domain.Customer.Repositories;
using VirtualStore.Shared;
using VirtualStore.Shared.Commands.Contracts;
using VirtualStore.Shared.Handlers.Contracts;

namespace VirtualStore.Domain.Customer.Handlers;


public class CustomerHandler : Notifiable, 
                                IHandler<CreateCustomerCommand>, 
                                IHandler<UpdateCustomerCommand>,
                                IHandler<MarkCustomerAsActiveCommand>,
                                IHandler<MarkCustomerAsInactiveCommand>
{

    private readonly ICustomerRepository _repository;

    public CustomerHandler(ICustomerRepository repository)
    {

        _repository = repository;

    }
    public ICommandResult Handle(CreateCustomerCommand command)
    {
        //Fail Fast Validation - Falhe rapido a validação, irá validar rapidamente, evitando a detecção do erro 
        //em camadas mais profundas
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que o cliente está invalido!", command.Notifications);

        //Gera o cliente
        var customer = new VirtualStore.Domain.Customer.Entities.Customer
                                    (command.Name, command.LastName, command.BirthDate, command.CEP,
                                    command.CPF, command.RG, command.City, command.Neighborhood,
                                    command.PublicPlace, command.State);
        //salva no banco
        _repository.Create(customer);

        // Retorna o resultado, se chegou até aqui é por que o Command já foi validado
        return new GenericCommandResult(true, "Cliente salvo", customer);

    }

    public ICommandResult Handle(UpdateCustomerCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que o cliente está invalido!", command.Notifications);

        // Recupera o TodoItem (Rehidratação)
        var customer = _repository.GetById(command.Id);

        // Altera o título
        customer.UpdateBirthDate(command.BirthDate);

        // Salva no banco
        _repository.Update(customer);

        // Retorna o resultado
        return new GenericCommandResult(true, "Cliente salvo", customer);
    }

     public ICommandResult Handle(MarkCustomerAsActiveCommand command)
     {
         // Fail Fast Validation
         command.Validate();
         if (command.Invalid)
             return new GenericCommandResult(false, "Ops, parece que o cliente está invalido!", command.Notifications);

         // Recupera o TodoItem
         var customer = _repository.GetById(command.Id);

         // Altera o estado
         customer.Activate();

         // Salva no banco
         _repository.Update(customer);

         // Retorna o resultado
         return new GenericCommandResult(true, "Cliente salvo", customer);
     }

     public ICommandResult Handle(MarkCustomerAsInactiveCommand command)
     {
         // Fail Fast Validation
         command.Validate();
         if (command.Invalid)
             return new GenericCommandResult(false, "Ops, parece que o cliente está invalido!", command.Notifications);

         // Recupera o TodoItem
         var customer = _repository.GetById(command.Id);

         // Altera o estado
         customer.Inactivate();

         // Salva no banco
         _repository.Update(customer);

         // Retorna o resultado
         return new GenericCommandResult(true, "Cliente salvo", customer);
     }

}
