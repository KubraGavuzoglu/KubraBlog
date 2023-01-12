using KubraBlog2.Data.Concrete;
using KubraBlog2.Data;
using KubraBlog2.Entities;
using KubraBlog2.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubraBlog2.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {
        }
    }
}
