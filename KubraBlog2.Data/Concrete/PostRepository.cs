using KubraBlog2.Data.Abstract;
using KubraBlog2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubraBlog2.Data.Concrete
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DatabaseContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Post>> GetAllPostbyCategoriesAsync()
        {
           return await context.Posts.Include(c=>c.Category).ToListAsync();
        }
    }
}
