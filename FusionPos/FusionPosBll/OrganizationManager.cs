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
    public class OrganizationManager:BaseManager<Organization>
    {
        public OrganizationRepository OrganizationRepository
        {
            get { return _Repository as OrganizationRepository; }
        }
        public OrganizationManager(OrganizationRepository repository) : base(repository)
        {
        }

        public OrganizationManager():base(new OrganizationRepository())
        {
            
        }

        
    }
}
