using ItemGen.Interfaces;
using ItemGen.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGen
{
    public class TemplateGenTool : IGenTool<Template, string>
    {
        public string Apply(Template item)
        {
            TemplateGenTool.WriteLine("Start creating Template");

            TemplateGenTool.WriteLine("Name" + item.Name);

            TemplateGenTool.WriteLine("Path" + item.Name);

            item.TemplateFields.ToList().ForEach(x => TemplateGenTool.WriteLine("Field: " + x.Name + "\tType: " + x.Type));

            return ("ok");
        }

        private static readonly Action<string> WriteLine = System.Console.WriteLine;
    }
}
