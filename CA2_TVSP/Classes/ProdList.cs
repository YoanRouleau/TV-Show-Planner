using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class ProdList
    {
        private List<Staff> productionList;

        public ProdList(List<Staff> pPorductionList)
        {
            this.ProductionList = pPorductionList;
        }

        public List<Staff> ProductionList
        {
            get { return productionList; }
            set { productionList = value; }
        }
    }
}
