using Microsoft.EntityFrameworkCore;
using Restaurant.Domain;
using Restaurant.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}