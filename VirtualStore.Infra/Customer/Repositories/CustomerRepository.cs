
using Microsoft.EntityFrameworkCore;
using VirtualStore.Domain.Customer.Queries;
using VirtualStore.Domain.Customer.Repositories;
using VirtualStore.Infra.Customer.Contexts;

namespace VirtualStore.Infra.Customer.Repositories;

public class CustomerRepository : ICustomerRepository
{

    private readonly MyContext _context;

    public CustomerRepository(MyContext context)
    {
        _context = context;
    }
    public void Create(Domain.Customer.Entities.Customer customer)
    {
       _context.Customers.Add(customer);
       _context.SaveChanges();
    }

     public void Update(Domain.Customer.Entities.Customer customer)
    {
        _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
    }

    public IEnumerable<Domain.Customer.Entities.Customer> GetAllActives()
    {
        //Se for retornar dados na tela usar ASNoTRacking (Não servira para Update ou Delete) 
        return _context.Customers.AsNoTracking().Where(CustomerQueries.GetAllActives());
    }

    public IEnumerable<Domain.Customer.Entities.Customer> GetAllInactives()
    {
       //Se for retornar dados na tela usar ASNoTRacking (Não servira para Update ou Delete) 
        return _context.Customers.AsNoTracking().Where(CustomerQueries.GetAllInactives());
    }

    public Domain.Customer.Entities.Customer GetById(Guid id)
    {
        return _context.Customers.FirstOrDefault(x => x.Id == id);
    }

   
}