﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PlanM
    {
        public int IdPlan { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaModificacion { get; set; }
        public List<Object> Planes { get; set; }
    }
}