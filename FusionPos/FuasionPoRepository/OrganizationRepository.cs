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
    public class OrganizationRepository : BaseRepository<Organization>
    {
        public FusionDbContext Context {
            get
            {
                return _db as FusionDbContext;
                
            }
        }
        public OrganizationRepository(DbContext db) : base(db)
        {
        }

        public OrganizationRepository():base(new FusionDbContext())
        {
            
        }
    }
}
