using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonSerialization
{
    [Serializable]
    class Person : IDeserializationCallback, ISerializable
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [NonSerialized]
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public Person()
        {
        }

        public Person(string name, DateTime dateOfBirth, int age)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = age;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name");
            DateOfBirth = info.GetDateTime("birthDate");
            Age = CalculateAge();
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Date of birth: {1}, Age: {2}", Name, DateOfBirth, Age);
        }

        public void OnDeserialization(object sender)
        {
            Age = CalculateAge();
        }

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            return age;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
            info.AddValue("birthDate", DateOfBirth);
        }
    }
}
