﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Users.API.Infraestructure.DBModels
{
    [Table("permisos")]
    [Index("Nombre", Name = "UQ__permisos__75E3EFCFAC2986A0", IsUnique = true)]
    public partial class Permisos
    {
        public Permisos()
        {
            RolesPermisos = new HashSet<RolesPermisos>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string IdHash { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Descripcion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreadoEn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActualizadoEn { get; set; }

        [InverseProperty("IdPermisoNavigation")]
        public virtual ICollection<RolesPermisos> RolesPermisos { get; set; }
    }
}