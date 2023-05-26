using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitati
{
    interface ICriteriu<O, C>
    {
        bool isFulfilled(O operatie, C criteriu);
    }
}
