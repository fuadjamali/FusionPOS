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
    public class ItemRepository : BaseRepository<Item>
    {
        public FusionDbContext Context {
            get
            {
                return _db as FusionDbContext;
            }
        }

        public ItemRepository(DbContext db) : base(db)
        {
        }

        public ItemRepository():base(new FusionDbContext())
        {
            
        }
    }
}
