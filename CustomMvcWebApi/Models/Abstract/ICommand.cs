using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMvcWebApi.Models.Abstract
{
    public class ICommand
    {
        string Line { get; set; }
        string HowTo { get; set; }

        string Platform { get; set; }
    }
}
