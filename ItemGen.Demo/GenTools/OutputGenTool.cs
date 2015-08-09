using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemGen.Interfaces;

namespace ItemGen.Demo.GenTools
{
    public class OutputGenTool<T> : IGenTool<T, bool>
    {
        private readonly Action<string> outputMethod;

        public OutputGenTool(Action<string> outputMethod) 
        {
            this.outputMethod = outputMethod;
        }

        public bool Apply(T item)
        {
            this.outputMethod(item.GetType().Name.ToString() + ":" );

            this.OutputProperties(item, 1);

            return true;
        }


        private void OutputProperties (object item, int offset = 0) 
        {
            if (item != null) 
            {
                item.GetType().GetProperties().ToList().ForEach(p =>
                {
                    if (p.PropertyType.IsArray)
                    {
                        Array arr = (Array)p.GetValue(item);

                        for (int i = 0; i < arr.Length; i++)
                        {
                            this.outputMethod(Tabs(offset) + p.Name + "[" + i.ToString() + "]: ");
                            this.OutputProperties(arr.GetValue(i), offset + 1);
                        }
                    }
                    else
                    {
                        object value = p.GetValue(item);
                        this.outputMethod(Tabs(offset) + p.Name + ": " + (value != null ? p.GetValue(item).ToString() : "null"));
                    }
                    
                });
            }
        }

        private static Func<int,string> Tabs = n => new String('\t', n);
    }
}
