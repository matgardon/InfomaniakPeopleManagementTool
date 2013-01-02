using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using InfomaniakPeopleManagementTool.Model;
using InfomaniakPeopleManagementTool.Model.Interface;

namespace InfomaniakPeopleManagementTool
{
    class Program
    {
        private 

        static void Main()
        {
            IList<Campus> campuses = new List<Campus>();

            Console.Clear();
            Console.WriteLine();

            // Create a new campus
            Campus campus0 = new Campus("city0","region0",4);
            campuses.Add(campus0);
            Console.WriteLine("[New campus created : campus0]");
            Console.WriteLine(campus0.ToString());
            Console.WriteLine();

            // Create a registered (id != 0) student and add it to this campus
            Student student1 = new Student("foo1","bar1",1);
            Console.WriteLine("[New student created : student1]");
            Console.WriteLine(student1.ToString());
            Console.WriteLine();

            Console.WriteLine(campus0.AddStudent(student1)
                                  ? "[student1 added to campus0]"
                                  : "[student1 not added to campus0]");

            Console.WriteLine("[ordered list of students in campus0] - list's size : "+campus0.Students.Count());
            foreach (var student in campus0.Students)
                Console.WriteLine(student.ToString());
            Console.WriteLine();

            // Exporting list of created campuses to xml files
            // You will be able to retrieve thoses files in this application's directory under bin/Debug/ or bin/Release/
            XmlSerializer serializer = new XmlSerializer(typeof(Campus));
            // write
            foreach (var campus in campuses)
                using (var stream = File.Create(campus.City + "_" + campus.Region + ".xml"))
                    serializer.Serialize(stream, campus);


            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            Console.WriteLine("Xml files created under ["+path+"] with the following rule : campusCity_campusRegion.xml for each campuses.");
            Console.WriteLine();

            // Prevent automatic closing of the output window, waiting for the user to press enter ...
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
