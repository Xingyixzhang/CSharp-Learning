using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap; // To make this library visible/usable, go to reference and add reference soap.
using System.Runtime.Serialization.Json;            // Add reference for System.Runtime.Serialization.
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteLocalData
{
    [Serializable]
    class Student: ISerializable
    {
        public string  Name { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context) // method from ISerializable interface.
        {
            info.AddValue("Name", Name);
            info.AddValue("Major", Major);
            info.AddValue("GPA", GPA);
        }
        public Student(string name, string major, double gpa)
        {
            Name = name;
            Major = major;
            GPA = gpa;
        }
        public Student(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetValue("Name", typeof(string)).ToString();    // object.ToString().
            Major = info.GetValue("Major", typeof(string)).ToString();
            GPA = Convert.ToDouble(info.GetValue("GPA", typeof(string)).ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Alice = new Student("Alice Boemer", "Math", 4.0);
            Student Bob = new Student("Bob Chandler", "Chinese", 3.7);
            Student Dan = new Student("Dan Lindsey", "Geology", 3.98);

            // Save it into Binary:
            // Binary Formatter:
            // ----- Save to File ------- SERIALIZE
            FileStream AliceFile = File.Create("Alice_in_binary.txt");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(AliceFile, Alice);
            AliceFile.Close();                      // Best Practice: Always close the file.
            // ----- Read from file ----- DESERIALIZE
            FileStream AliceFile1 = File.OpenRead("Alice_in_binary.txt");
            BinaryFormatter formatter1 = new BinaryFormatter();
            Student Alice1 = formatter1.Deserialize(AliceFile1) as Student;
            Console.WriteLine(Alice1.Name);
            AliceFile1.Close();


            // Save it into XML:
            // Soap Formatter:
            // ----- Save to File ------- SERIALIZE
            FileStream BobFile = File.Create("Bob_in_xml.xml");
            SoapFormatter formatter2 = new SoapFormatter();
            formatter2.Serialize(BobFile, Bob);
            BobFile.Close();
            // ----- Read from file ----- DESERIALIZE
            FileStream BobFile1 = File.OpenRead("Bob_in_xml.xml");
            SoapFormatter formatter3 = new SoapFormatter();
            Student Bob1 = formatter3.Deserialize(BobFile1) as Student;
            Console.WriteLine(Bob1.Name);
            BobFile1.Close();


            // Save it into JSON:
            // ----- Save to File ------- SERIALIZE
            FileStream DanFile = File.Create("Dan_in_json.json");
            DataContractJsonSerializer formatter4 = new DataContractJsonSerializer(typeof(Student));
            formatter4.WriteObject(DanFile, Dan);
            DanFile.Close();
            // ----- Read from file ----- DESERIALIZE
            FileStream DanFile1 = File.OpenRead("Dan_in_json.json");
            DataContractJsonSerializer formatter5 = new DataContractJsonSerializer(typeof(Student));
            Student Dan1 = formatter5.ReadObject(DanFile1) as Student;
            Console.WriteLine(Dan1.Name);
            DanFile1.Close();


            // Read Data from input file:
            //string[] lines = File.ReadAllLines(@"inputs\inputSchools.txt"); // double'\\' or put @ in front.
            //string str = File.ReadAllText(@"inputs\inputSchools.txt");
            //byte[] bytes = File.ReadAllBytes(@"inputs\inputSchools.txt");

            //Console.WriteLine();

            try
            {
                File.ReadAllLines(@"inputs\inputSchools.txt");
            }
            catch (FileNotFoundException e)
            {
                Directory.CreateDirectory("inputs");
                File.Create(e.FileName);
            }

            // Write:
            File.Copy(@"inputs\inputSchools.txt", @"inputs\inputSchools_copy.txt", true);   //true: destination file can be overwritten.
            File.Delete(@"inputs\inputSchools_copy.txt");

            FileInfo myFile1 = new FileInfo(@"inputs\inputSchools.txt");

            Directory.Delete("inputs", true);

        }
    }
}
