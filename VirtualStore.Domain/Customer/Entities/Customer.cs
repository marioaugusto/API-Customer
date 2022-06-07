using VirtualStore.Shared.Entities;

namespace VirtualStore.Domain.Customer.Entities;

public class Customer : Entity
{
        public Customer(
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
            PublicPlace = publicPlace;
            CEP = cep;
            Active = true;
            DateRegister = DateTime.UtcNow;

        }

    public Customer()
    {
    }

    public string Name { get; private set; }

        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }

        public DateTime DateRegister { get; private set; }

        public string RG { get; private set; } 

        public string CPF { get; private set; }

        public string State { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string PublicPlace { get; private set; }
        public string CEP { get; private set; }
        public bool Active { get; private set; }

        public void Activate()
        {
            Active = true;
        }

        public void Inactivate()
        {
            Active = false;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;

        } 

        public string CompleteName() => Name + LastName;


}