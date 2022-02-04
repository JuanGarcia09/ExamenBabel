using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Result
    {
        public bool Correct { get; set; }
        public Object Object { get; set; }
        public List<Object> Objects { get; set; }
        public String ErrorMessage { get; set; }
        public Exception Ex { get; set; }
    }
}
