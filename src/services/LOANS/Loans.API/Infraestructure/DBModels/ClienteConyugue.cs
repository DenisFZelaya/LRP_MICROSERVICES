﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Loans.API.Infraestructure.DBModels
{
    [Table("cliente_conyugue")]
    public partial class ClienteConyugue
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idHash")]
        [StringLength(255)]
        [Unicode(false)]
        public string IdHash { get; set; }
        [Required]
        [Column("cedulaCliente")]
        [StringLength(20)]
        [Unicode(false)]
        public string CedulaCliente { get; set; }
        [Required]
        [Column("cedula")]
        [StringLength(20)]
        [Unicode(false)]
        public string Cedula { get; set; }
        [Required]
        [Column("nombreCompleto")]
        [StringLength(100)]
        [Unicode(false)]
        public string NombreCompleto { get; set; }
        [Column("fchNacim", TypeName = "datetime")]
        public DateTime FchNacim { get; set; }
        [Required]
        [Column("sexo")]
        [StringLength(20)]
        [Unicode(false)]
        public string Sexo { get; set; }
        [Required]
        [Column("telefonoMovil")]
        [StringLength(20)]
        [Unicode(false)]
        public string TelefonoMovil { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; }
        [Column("pais")]
        public int Pais { get; set; }
        [Column("nivEdu")]
        public int NivEdu { get; set; }
        [Column("tieneTrabRemu")]
        public int TieneTrabRemu { get; set; }
        [Required]
        [Column("empresaTrab")]
        [StringLength(100)]
        [Unicode(false)]
        public string EmpresaTrab { get; set; }
        [Required]
        [Column("direccionoTrab")]
        [StringLength(100)]
        [Unicode(false)]
        public string DireccionoTrab { get; set; }
        [Column("fchIniTrab", TypeName = "datetime")]
        public DateTime FchIniTrab { get; set; }
        [Required]
        [Column("dependientes")]
        [StringLength(20)]
        [Unicode(false)]
        public string Dependientes { get; set; }
        [Column("sueldo")]
        public double Sueldo { get; set; }
        [Required]
        [Column("cargo")]
        [StringLength(50)]
        [Unicode(false)]
        public string Cargo { get; set; }
        [Column("codOcupacion")]
        public int CodOcupacion { get; set; }
    }
}