//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanCobertura
    {
        public int IdPlanCobertura { get; set; }
        public Nullable<int> IdPlan { get; set; }
        public Nullable<int> IdCobertura { get; set; }
    
        public virtual Coberturas Coberturas { get; set; }
        public virtual Planes Planes { get; set; }
    }
}
