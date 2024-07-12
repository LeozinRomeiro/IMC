using Imc.Models.Enums;

namespace Imc.ViewModels
{
    public class PersonViewModel
    {
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public ESex? Sex { get; set; }
        public bool IsElderly { get; set; }

    }
}
