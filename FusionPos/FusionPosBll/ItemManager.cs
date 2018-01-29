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
    public class ItemManager : BaseManager<Item>
    {
        public ItemRepository ItemRepository {
            get
            {
                return _Repository as ItemRepository;
            }
        }
        public ItemManager(ItemRepository repository) : base(repository)
        {
        }

        public ItemManager():base(new ItemRepository())
        {
            
        }

    }
}
