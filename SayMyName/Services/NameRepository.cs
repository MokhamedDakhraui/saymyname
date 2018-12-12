using SayMyName.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayMyName.Services
{
    public class NameRepository : INameRepository
    {
        protected static string _name;

        public string GetName() => _name;

        public void SetName(string name) => _name = name;
    }
}
