using Imc.Models.Enums;

namespace Imc.Models
{
    public class Person
    {
/*        public Person(float height, float weight, ESex sex, bool isElderly)
        {
            Height = height;
            Weight = weight;
            Sex = sex;
            IsElderly = isElderly;
        }*/
        public decimal? Height { get;  set; }
        public decimal? Weight { get;  set; }
        public ESex? Sex { get;  set; }
        public bool IsElderly { get;  set; }
    }
}
