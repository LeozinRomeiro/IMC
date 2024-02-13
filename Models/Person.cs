using Imc.Models.Enums;

namespace Imc.Models
{
    public class Person
    {
        public Person(float height, float weight, ESex sex, bool isElderly)
        {
            Height = height;
            Weight = weight;
            Sex = sex;
            IsElderly = isElderly;
        }
        public float Height { get; private set; }
        public float Weight { get; private set; }
        public ESex Sex { get; private set; }
        public bool IsElderly { get; private set; }
    }
}
