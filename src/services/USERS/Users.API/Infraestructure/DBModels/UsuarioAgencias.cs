﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Users.API.Infraestructure.DBModels
{
    [Table("usuario_agencias")]
    public partial class UsuarioAgencias
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idHash")]
        [StringLength(250)]
        [Unicode(false)]
        public string IdHash { get; set; }
        [Column("Id_UsuarioHash")]
        public int? IdUsuarioHash { get; set; }
        [Column("Id_AgenciaHash")]
        public int? IdAgenciaHash { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Identificador { get; set; }
    }
}