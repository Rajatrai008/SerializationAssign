using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SerializationAssign
{
    [Serializable]
    class BinarySerial
    {
         public int dateOfBirth;
        // int dateOfBirth = int.Parse(dateOfBirth.ToString("yyyymmdd"));
         int today = int.Parse(DateTime.Now.ToString("yyyy"));
      //  public int today;

        public int AgeOfStud()
        {
            return ( today-dateOfBirth);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinarySerial b = new BinarySerial();
            b.dateOfBirth = 1997;
           
            FileStream fs = new FileStream(@"Year.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, b);
            fs.Seek(0, SeekOrigin.Begin);
            BinarySerial result = (BinarySerial)bf.Deserialize(fs);
            Console.WriteLine($"Current Age is : {result.AgeOfStud()}");
        }
    }
}
