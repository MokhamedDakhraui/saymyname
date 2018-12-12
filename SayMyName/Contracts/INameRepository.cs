using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayMyName.Contracts
{
    public interface INameRepository
    {
        void SetName(string name);
        string GetName();
    }
}
