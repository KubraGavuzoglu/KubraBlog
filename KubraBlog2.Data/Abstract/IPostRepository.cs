using KubraBlog2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubraBlog2.Data.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {

        Task<IEnumerable<Post>> GetAllPostbyCategoriesAsync();
    }
}
