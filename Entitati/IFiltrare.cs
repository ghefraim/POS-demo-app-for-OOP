using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitati
{
    interface IFiltrare<O, C>
    {
        public IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> elemente, O operatie,C criteriu);
    }
}
