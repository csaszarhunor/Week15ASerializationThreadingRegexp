using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PersonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Person person = new Person();
                person.Name = args[0];
                DateTime birthDate = new DateTime(Int32.Parse(args[1]), Int32.Parse(args[2]), Int32.Parse(args[3]));
                person.DateOfBirth = birthDate;

                Serialize(person);
            }

            Person deserializedPerson = Deserialize();
            Console.WriteLine(deserializedPerson);
        }

        private static void Serialize(Person person)
        {
            // Create file to save the data to 
            FileStream fileStream = new FileStream("Person.Dat", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization 
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // Use the BinaryFormatter object to serialize the data to the file 
            binaryFormatter.Serialize(fileStream, person);

            // Close the file
            fileStream.Close();
        }

        private static Person Deserialize()
        {
            Person person = new Person();

            // Open file to read the data from 
            FileStream fileStream = new FileStream("Person.Dat", FileMode.Open);

            // Create a BinaryFormatter object to perform the deserialization 
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // Use the BinaryFormatter object to deserialize the data
            // from the file 
            person = (Person)binaryFormatter.Deserialize(fileStream);

            // Close the file 
            fileStream.Close();

            return person;
        }
    }
}
