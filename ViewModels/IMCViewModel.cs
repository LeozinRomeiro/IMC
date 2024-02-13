using Imc.Models.Enums;

namespace Imc.ViewModels
{
    public class IMCViewModel
    {
        public DateTime Registered {  get; set; }
        public string FormattedRegistered
        {
            get
            {
                TimeSpan timeSinceRegistered = DateTime.Now - Registered;

                if (timeSinceRegistered.TotalSeconds < 60)
                    return $"{(int)timeSinceRegistered.TotalSeconds} segundos atrás";
                if (timeSinceRegistered.TotalMinutes < 60)
                    return $"{(int)timeSinceRegistered.TotalMinutes} minutos atrás";
                if (timeSinceRegistered.TotalHours < 24)
                    return $"{(int)timeSinceRegistered.TotalHours} horas atrás";

                return Registered.ToString("dd/MM/yyyy");
            }
        }
        public double? Value { get; set; }
        public EStatus Status { get; set; }

        public string Title {
            get
            {
                if (Status == EStatus.Sobrepeso || Status == EStatus.Obesidade || Status == EStatus.Obesidade_Grave)
                    return "Sobrepeso ⛔️";
                if (Status == EStatus.Magro || Status == EStatus.Normal)
                    return "Peso ideal ✅";
                else return "";
            }
        }
        public string Description
        {
            get
            {
                if (Status == EStatus.Sobrepeso || Status == EStatus.Obesidade || Status == EStatus.Obesidade_Grave)
                    return "Estamos quase lá! Faça alguns ajustes para ficar no peso ideal";
                if (Status == EStatus.Magro || Status == EStatus.Normal)
                    return "Parabéns, você está no seu peso ideal, continue mantendo este estilo!";
                else return "";
            }
        }
    }
}
