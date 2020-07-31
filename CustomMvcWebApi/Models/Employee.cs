using CustomMvcWebApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMvcWebApi.Models
{
    public class Employee : IHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public int Age { get; set; }
    }
}
