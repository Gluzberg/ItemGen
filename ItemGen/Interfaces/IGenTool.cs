using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGen.Interfaces
{
    public interface IGenTool<T,R>
    {
        R Apply(T item);
    }
}
