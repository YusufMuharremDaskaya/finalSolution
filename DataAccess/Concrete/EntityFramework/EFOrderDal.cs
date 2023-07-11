using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    class EFOrderDal:EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        
    }
}