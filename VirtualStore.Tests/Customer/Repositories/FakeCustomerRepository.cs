
using System;
using System.Collections.Generic;
using VirtualStore.Domain.Customer.Repositories;

namespace VirtualStore.Domain.Customer.Tests.Repositories;

public class FakeCustomerRepository : ICustomerRepository
{
    public void Create(Entities.Customer customer)
    {
        
    }

    public IEnumerable<Entities.Customer> GetAllActives()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Entities.Customer> GetAllInactives()
    {
        throw new NotImplementedException();
    }

    public Entities.Customer GetById(Guid id)
    {
        return new Entities.Customer("Mario", "Augusto", DateTime.Now,
        "0869473115", "01333009518", "Bahia", "Salvador", "Massaranduba", "40435-070", "Rua Carlos Lopes, Número 49");
    }

    public void Update(Entities.Customer customer)
    {
       
    }
}