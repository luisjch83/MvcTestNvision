using MvcTestNvision.Models.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MvcTestNvision.Utilities
{
    public class Utilities
    {
        public void ExportJson(Person person)
        {
            string fileName = person.Nombre;
            string jsonStr = JsonConvert.SerializeObject(person);
            string path = @"C:\" +fileName+ ".json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(jsonStr.ToString());
                tw.Close();
            }
        }

        public void ExportXML(Person person)
        {
            string fileName = person.Nombre;
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            TextWriter txtWriter = new StreamWriter(@"C:\" +fileName+ ".xml");
            xs.Serialize(txtWriter, person);

            txtWriter.Close();
        }

    }
}
