using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencies.API.Dtos.Request
{
    public class CreateUpdateAgencyRequest
    {
    
        [Column("nombre")]
        [StringLength(255)]
        [MinLength(3)]
        [Unicode(false)]
        public string Nombre { get; set; }

        [Column("direccion")]
        [StringLength(255)]
        [MinLength(3)]
        [Unicode(false)]
        public string Direccion { get; set; }

        [Column("idCiudad")]
        public int? IdCiudad { get; set; }

        [Column("idDepartamento")]
        public int? IdDepartamento { get; set; }

        [Column("idPais")]
        public int? IdPais { get; set; }
        [Column("longitud")]
        [StringLength(255)]
        [Unicode(false)]
        public string Longitud { get; set; }
        [Column("latitud")]
        [StringLength(255)]
        [Unicode(false)]
        public string Latitud { get; set; }

    }
}
