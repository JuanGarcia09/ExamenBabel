using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PlanCoberturaM
    {
        public int IdPlanCobertura { get; set; }
        public BL.PlanM Plan { get; set; }
        public BL.CoberturaM Cobertura { get; set; }
        public List<Object> PlanCoberturas { get; set; }
    }
}
