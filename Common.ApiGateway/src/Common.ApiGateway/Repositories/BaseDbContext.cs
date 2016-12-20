using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Common.ApiGateway.Repositories
{
    public class BaseDbContext<T> : DbContext where T : DbContext
    {
        public BaseDbContext(DbContextOptions<T> options)
            : base(options)
        {
        }
    }
}
