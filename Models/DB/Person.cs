using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MvcTestNvision.Models.DB
{
    public partial class Person
    {
        public int IdPerson { get; set; }
        [Required(ErrorMessage = "This field is required.")]       
        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^.{1,20}$", ErrorMessage = "Nombre should be of  maximum 20 characters")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^.{1,20}$", ErrorMessage = "Apellido should be of  maximum 20 characters")]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^.{1,20}$", ErrorMessage = "Telefono should be of  maximum 20 characters")]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^.{1,100}$", ErrorMessage = "Telefono should be of  maximum 20 characters")]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }
    }
}
