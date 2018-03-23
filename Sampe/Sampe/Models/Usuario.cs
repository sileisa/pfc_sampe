using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampe
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Column(Order = 2)]
        [Required(ErrorMessage = "Preencha este campo")]
        public string NomeUsuario { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Preencha este campo")]
        public string SobrenomeUsuario { get; set; }

        [Column(Order = 4)]
        public int Login { get; set; }
                
        [Column(Order = 5)]
        public int Senha { get; set; } = 123456;

        [Column(Order = 6)]
        public String Hierarquia { get; set; }

        [Column(Order = 7)]
        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
    }
}
