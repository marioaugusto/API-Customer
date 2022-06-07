using Flunt.Notifications;
using Flunt.Validations;
using VirtualStore.Domain.Customer.Commands.Contracts;
using VirtualStore.Shared.Commands.Contracts;

namespace VirtualStore.Domain.Customer.Commands;

public class UpdateCustomerCommand : Notifiable, ICommand
{

    public UpdateCustomerCommand(){}

    public UpdateCustomerCommand(
            Guid  id,
            string name,
            string lastName,
            DateTime birthDate,
            string state,
            string city,
            string neighborhood,
            string cep,
            string publicPlace)
        {
            Id = id;
            Name = name;
            LastName= lastName;
            BirthDate = birthDate;
            State = state;
            City =  city;
            Neighborhood = neighborhood;
            PublicPlace = publicPlace;
            CEP = cep;

        }

    public Guid Id { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DateRegister { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string PublicPlace { get; set; }
    public string CEP { get; set; }
    

    public void Validate()
    {
        AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "Por favor, informe um nome com mais de 2 caracteres!")
                    .HasMinLen(LastName, 3, "LastName", "Por favor, informe um sobrenome com mais de 2 caracteres!")
                    //.HasExactLengthIfNotNullOrEmpty("CPF inválido!",11,"CPF","Por favor, informe um CPF COM 11 caracteres!")
            );
    }
}
