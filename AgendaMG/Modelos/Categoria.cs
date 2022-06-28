﻿using System.ComponentModel.DataAnnotations;

namespace AgendaMG.Modelos
{
    public class Categoria
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]

        public DateTime FechaCreacion { get; set; }
        public bool Eliminado { get; internal set; }
    }
}
