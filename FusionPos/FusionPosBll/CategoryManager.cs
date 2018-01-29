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
    public class CategoryManager : BaseManager<Category>
    {
        public CategoryRepository _categoryRepository {
            get
            {
                return _categoryRepository as CategoryRepository;
                ;
            }
        }

        public CategoryManager():base (new CategoryRepository())
        {
            
        }

        public CategoryManager(CategoryRepository repository):base(repository)
        {
            
        }
    }
}
