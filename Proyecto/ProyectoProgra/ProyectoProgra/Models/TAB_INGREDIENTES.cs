//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoProgra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAB_INGREDIENTES
    {
        public int ID_INGREDIENTES { get; set; }
        public Nullable<int> COD_RECETA { get; set; }
        public string INGREDIENTES { get; set; }
    
        public virtual TAB_RECETAS TAB_RECETAS { get; set; }
    }
}
