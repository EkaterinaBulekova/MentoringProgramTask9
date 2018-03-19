using System.Collections.Generic;
using DALEntetyFW.DataModels;

namespace DALEntetyFW.Abstract
{
    public interface IRepository
    {
        IEnumerable<Order> GetOrdersByCategory(Category category);

        IEnumerable<Order> GetOrdersByCategoryId(int categoryId);

        Category GetCategoryById(int categoryId);
    }
}
