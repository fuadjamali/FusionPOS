using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuasionPoRepository.Base;
using FuasionPoRepository.DatabaseContexts;
using FusionPosModels.EntityModels;

namespace FuasionPoRepository
{
    public class OutletReporsitory : BaseRepository<Outlet>
    {
        public FusionDbContext Context {
            get
            {
                return _db as FusionDbContext;
            }
        }
        public OutletReporsitory(DbContext db) : base(db)
        {
        }

        public OutletReporsitory():base(new FusionDbContext())
        {
            
        }
    }
}
