using Imc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Imc.Models
{
    public class ImcModel
    {
        [Required(ErrorMessage = "Informe a altura")]
        [Range(1, 3, ErrorMessage = "Altura inválida")]
        public double? Height { get; set; }

        [Required(ErrorMessage = "Informe o peso")]
        [Range(15, 180, ErrorMessage = "Peso inválido")]
        public double? Weight { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public double Imc => (Weight ?? 1) / ((Height ?? 1) * (Height ?? 1));
        public EStatus Status 
        { 
            get 
            {
                if (Imc <= 18.5)
                    return EStatus.Magro;
                if (Imc <= 24.9)
                    return EStatus.Normal;
                if (Imc <= 29)
                    return EStatus.Obesidade;
                if (Imc <= 39.9)
                    return EStatus.Obesidade_Grave;
                else
                    return EStatus.Sobrepeso;
            } 
        }
    }
}
