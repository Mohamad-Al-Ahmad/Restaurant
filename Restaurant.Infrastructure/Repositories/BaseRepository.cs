using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Infrastructure.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}