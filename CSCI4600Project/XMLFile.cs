using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace CSCI4600Project
{
    public static class XMLFile
    {
        /*
        XmlSerializer xmlSerializer;
        FileStream fileStream;
        public String FilePath { get; set; }

        public XMLFile()
        {
            xmlSerializer = new XmlSerializer(typeof(RegistrationClass));

            FilePath = "./Data.xml";
        }

        public void Serialize(RegistrationClass registration)
        {
            FileStream filestream = System.IO.File.Create(FilePath);

            xmlSerializer.Serialize(filestream, registration);

            filestream.Close();
        }

        public void Deserialize(RegistrationClass registration)
        {
            FileStream filestream = new FileStream(FilePath, FileMode.Open);

            registration = (RegistrationClass)xmlSerializer.Deserialize(filestream);

            filestream.Close();
        }
        */

        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }








        // Add user to File


        // Check file for user information


        // Add course to Student


        // Remove selected course from Student, CurrentCourses
    }
}
