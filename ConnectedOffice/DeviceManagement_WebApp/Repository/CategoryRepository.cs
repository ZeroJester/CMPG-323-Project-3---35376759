//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    //CategoryRepository inherits from GenericRepository and ICategoryRespository//
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
        }
    }
}
