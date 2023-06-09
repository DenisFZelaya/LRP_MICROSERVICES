﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Loans.API.Infraestructure.DBModels
{
    [Table("referencias_personales")]
    public partial class ReferenciasPersonales
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
        [Column("familiar")]
        public bool? Familiar { get; set; }
        [Column("telefono")]
        [StringLength(20)]
        [Unicode(false)]
        public string Telefono { get; set; }
        [Column("direccion")]
        [StringLength(255)]
        [Unicode(false)]
        public string Direccion { get; set; }
        [Column("tpReferencia")]
        public int? TpReferencia { get; set; }
        [Column("cuenta")]
        [StringLength(255)]
        [Unicode(false)]
        public string Cuenta { get; set; }
        [Column("lugar")]
        [StringLength(255)]
        [Unicode(false)]
        public string Lugar { get; set; }
        [Column("relacion")]
        [StringLength(255)]
        [Unicode(false)]
        public string Relacion { get; set; }
        [Column("sldoDep", TypeName = "decimal(18, 2)")]
        public decimal? SldoDep { get; set; }
        [Column("sldoAdeuda", TypeName = "decimal(18, 2)")]
        public decimal? SldoAdeuda { get; set; }
        [Column("cuotaMes", TypeName = "decimal(18, 2)")]
        public decimal? CuotaMes { get; set; }
        [Column("celular")]
        [StringLength(20)]
        [Unicode(false)]
        public string Celular { get; set; }
        [Column("email")]
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; }
        [Column("tpResidencia")]
        [StringLength(255)]
        [Unicode(false)]
        public string TpResidencia { get; set; }
        [Column("tiempoResidir")]
        public int? TiempoResidir { get; set; }
        [Column("telTrabajo")]
        [StringLength(20)]
        [Unicode(false)]
        public string TelTrabajo { get; set; }
        [Column("confirmada")]
        public bool? Confirmada { get; set; }
        [Column("observacion")]
        [StringLength(255)]
        [Unicode(false)]
        public string Observacion { get; set; }
        [Column("codSolicitud")]
        [StringLength(255)]
        [Unicode(false)]
        public string CodSolicitud { get; set; }
        [Column("indice")]
        public int? Indice { get; set; }
    }
}