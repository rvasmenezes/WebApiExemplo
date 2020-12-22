using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lider.DPVAT.APIModelo.Application.ViewModel
{
    [DisplayColumn("Parametros de entrada")]
    public class UsuarioViewModel
    {
        [Required]
        public string user_id { get; set; }
        [Required]
        public string user_full_name { get; set; }
        [Required]
        public string user_email { get; set; }
        [Required]
        public string user_password { get; set; }
        [Required]
        public string force_password_change { get; set; }
    }
}
