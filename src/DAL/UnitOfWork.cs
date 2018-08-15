// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



      



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
