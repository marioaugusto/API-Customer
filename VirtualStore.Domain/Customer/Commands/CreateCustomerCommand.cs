using Flunt.Notifications;
using Flunt.Validations;
using VirtualStore.Shared.Commands.Contracts;

namespace VirtualStore.Domain.Customer.Commands.Contracts;

public class CreateCustomerCommand : Notifiable, ICommand
{

    public CreateCustomerCommand(){}

    public CreateCustomerCommand(
            string name,
            string lastName,
            DateTime birthDate,
            string rg,
            string cpf,
            string state,
            string city,
            string neighborhood,
            string cep,
            string publicPlace)
        {
        

            Name = name;
            LastName= lastName;
            BirthDate = birthDate;
            RG = rg;
            CPF = cpf;
            State = state;
            City =  city;
            Neighborhood = neighborhood;
            CEP = cep;
            PublicPlace = publicPlace;
            Active = true;
            DateRegister = DateTime.UtcNow;

        }

    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DateRegister { get; set; }
    public string RG { get; set; } 
    public string CPF { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string PublicPlace { get; set; }
    public string CEP { get; set; }
    public bool Active { get; set; }

    public void Validate()
    {
        AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "Por favor, informe um nome com mais de 2 caracteres!")
                    .HasMinLen(LastName, 3, "LastName", "Por favor, informe um sobrenome com mais de 2 caracteres!")
            );
    }
}
