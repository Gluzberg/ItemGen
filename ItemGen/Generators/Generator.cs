using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ItemGen.Interfaces;
using System.Reflection;

namespace ItemGen.Generators
{
    public class Generator<C, T, R> where C : class where T : class 
    {
        private readonly IGenTool<T, R> genTool;
        
        private readonly T[] models;

        public Generator(string filename, IGenTool<T, R> generator)
        {
            this.genTool = generator;

            try
            {
                object result = new XmlSerializer(typeof(C)).Deserialize(new FileStream(filename, FileMode.Open));
                
                PropertyInfo propertyInfo = result != null ? result.GetType().GetProperties().DefaultIfEmpty(null).FirstOrDefault(p => p.PropertyType == typeof(T[])) : null;
             
                object models = propertyInfo != null ? propertyInfo.GetValue(result) : null;

                this.models = models != null && models is T[] ? (T[])models : null;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void Execute()
        {
            if (this.models != null && this.genTool != null)
            {
                this.models.ToList().ForEach(x => this.genTool.Apply(x));
            }
        }

        public static void Execute(string filename, IGenTool<T, R> genTool) 
        {
            Generator<C, T, R> baseGenerator = new Generator<C, T, R>(filename, genTool);

            baseGenerator.Execute();
        }
    }
}
