using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuasionPoRepository;
using FuasionPoRepository.Base;
using FusionPosBll.Base;
using FusionPosModels.EntityModels;

namespace FusionPosBll
{
    public class OutletManager : BaseManager<Outlet>
    {
        public OutletReporsitory OutletReporsitory
        {
            get
            {
                return _Repository as OutletReporsitory;
            }

        }
        public OutletManager(BaseRepository<Outlet> repository) : base(repository)
        {
        }

        public OutletManager():base(new OutletReporsitory())
        {
            
        }
    }
}
