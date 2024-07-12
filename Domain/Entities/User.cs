using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder los 50 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<DateTime> LogIngresos { get; set; }

        public User()
        {
            LogIngresos = new List<DateTime>();
            CreatedDate = DateTime.Now;
        }

        public void AddLogIngreso(DateTime ingreso)
        {
            LogIngresos.Add(ingreso);
        }
    }
}