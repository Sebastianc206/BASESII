//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CINEGT2
{
    using System;
    using System.Collections.Generic;
    
    public partial class SesionCSV
    {
        public int ID_CSV { get; set; }
        public System.DateTime Fecha_Hora_Creacion { get; set; }
        public string Estado_Grupo { get; set; }
        public int ID_Usuario { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}