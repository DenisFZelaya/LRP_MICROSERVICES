﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Agencies.Infraestructura.Data.Entities
{
    [Table("agencias")]
    [Index("IdHash", Name = "UQ__agencias__03D9DF17BD1FE8BA", IsUnique = true)]
    public class Agencias
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idHash")]
        [StringLength(255)]
        [Unicode(false)]
        public string IdHash { get; set; }
        [Column("nombre")]
        [StringLength(255)]
        [Unicode(false)]
        public string Nombre { get; set; }
        [Column("direccion")]
        [StringLength(255)]
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