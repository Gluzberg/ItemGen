using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemGen.Demo.GenTools;
using Data.Schemas;
using ItemGen.Generators;
using ItemGen.Interfaces;

namespace ItemGen.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\Manya\Documents\Visual Studio 2013\Projects\ItemGen\ItemGen.Demo\Data\Templates.xml";

            IGenTool<Template, bool> genTool = new OutputGenTool<Template>(System.Console.WriteLine);

            Generator<TemplatesCollection, Template, bool>.Execute(filename, genTool);

            Console.ReadKey();
        }
    }
}
