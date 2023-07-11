using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        DataResult<List<Category>> GetAll();
        Category GetById(int categoryId);
    }
}