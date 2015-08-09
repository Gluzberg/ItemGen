using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemGen.Generators;


namespace ItemGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator<TemplatesCollection, Template, string>.Execute(@"c:\users\manya\documents\visual studio 2013\Projects\ItemGen\ItemGen\Samples\Sample.xml", new TemplateGenTool());

            Console.ReadKey();
        }
    }
}
