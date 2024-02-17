using Imc.Models.Enums;
using System.Net.NetworkInformation;

namespace Imc.Models
{
    public class IMC
    {
        public IMC(Person person)
        {
            Registered = DateTime.Now;

            Calculate(person);
            Check(person.IsElderly);
        }
        public DateTime Registered { get; private set; }
        public double Value { get; private set; }
        public EStatus Status { get; private set; }

        private void Calculate(Person person)
        {
            var _value = person.Weight / (person.Height * person.Height);
            Value = (double)_value;
        }
        private void Check(bool isElderly)
        {
            if(isElderly)
            {
                if (Value <= 18.5)
                    Status = EStatus.Magro;
                if (Value <= 24.9)
                    Status = EStatus.Normal;
                if (Value <= 29)
                    Status = EStatus.Obesidade;
                if (Value <= 39.9)
                    Status = EStatus.Obesidade_Grave;
                else
                    Status = EStatus.Sobrepeso;
            }
            else
            {
                if (Value <= 18.5)
                    Status = EStatus.Magro;
                if (Value < 25)
                    Status = EStatus.Normal;
                else
                    Status = EStatus.Sobrepeso;
            }
        }
    }
}
