using System.Collections.Generic;
using System.Linq;
using DALEntetyFW.Abstract;
using DALEntetyFW.DataModels;

namespace DALEntetyFW.Concrete
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.FirstOrDefault(_ => _.CategoryID  == categoryId);
        }

        public IEnumerable<Order> GetOrdersByCategory(Category category) => _context.Orders
                .Where(_ => _.Order_Details
                    .All(d => d.Product.Category.CategoryID == category.CategoryID));

        public IEnumerable<Order> GetOrdersByCategoryId(int categoryId) => _context.Orders
                .Where(_ => _.Order_Details
                    .All(d => d.Product.Category.CategoryID == categoryId));
    }
}
