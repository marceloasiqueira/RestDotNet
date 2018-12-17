using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestDotNet.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addressd { get; set; }
        public string Gender { get; set; }
    }
}
