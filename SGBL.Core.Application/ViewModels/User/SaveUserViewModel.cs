using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGBL.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {   
        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe colocar el apellido del usuario")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre de usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }       

        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar un telefono")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }

        // Nuevos campos para rol
        [Required(ErrorMessage = "Debe seleccionar un rol")]
        public string RoleId { get; set; }

        public List<SelectListItem> Roles { get; set; } = new();
    }
}
