using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitati
{
    public interface IPackageable
    {
        bool canAddToPackage(List<IPackageable> elementePachet, ProdusAbstract produsAbstract);
    }
}
