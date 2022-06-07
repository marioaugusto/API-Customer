
namespace VirtualStore.Domain.Customer.Repositories;

public interface ICustomerRepository
{
    void Create(VirtualStore.Domain.Customer.Entities.Customer customer);

    void Update (VirtualStore.Domain.Customer.Entities.Customer customer);

    VirtualStore.Domain.Customer.Entities.Customer GetById(Guid id);

    IEnumerable<Domain.Customer.Entities.Customer> GetAllActives();

    IEnumerable<Domain.Customer.Entities.Customer> GetAllInactives();

}