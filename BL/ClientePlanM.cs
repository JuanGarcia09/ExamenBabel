using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClientePlanM
    {
        public int IdClientePlan { get; set; }
        public BL.ClienteM Cliente { get; set; }
        public BL.PlanM Plan { get; set; }
        public List<Object> ClientePlanes { get; set; }        
    }
}
