using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMvcWebApi.Models.Abstract
{
    public interface IHuman
    {
        string Name { get; set; }
        string Lastname { get; set; }

        int Age { get; set; }

    }
}
