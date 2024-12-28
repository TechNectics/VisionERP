//using DataNexus.Migrations;
using DataNexus.Repositories;
using Domain.Interfaces;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataNexus.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _context; 

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            


        }
       


        //if already that repo intializd > reutnr it otherise creae new and return it back
        //  public IChartOfAccounts IChartOfAccounts { get { return _chartOfAccounts = _chartOfAccounts ?? new ChartOfAccountsRepository(_context); } }

        public void Dispose()
        {
            _context.Dispose();
        }


        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();

        }
    }

}
