
using System.Linq.Expressions;

namespace VirtualStore.Domain.Customer.Queries;

public static class CustomerQueries
{

    public static Expression<Func<VirtualStore.Domain.Customer.Entities.Customer, bool>> GetAllActives()
    {
        return x => x.Active == true;
    }

    public static Expression<Func<VirtualStore.Domain.Customer.Entities.Customer, bool>> GetAllInactives()
    {
        return x => x.Active == false;

    }




}