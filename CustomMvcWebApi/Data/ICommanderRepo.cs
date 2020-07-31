using CustomMvcWebApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMvcWebApi.Data
{
    /// <summary>
    /// Provides CommanderRepository specification
    /// </summary>
    public interface ICommanderRepo
    {
        IEnumerable<ICommand> GetCommands();
        ICommand GetCommandById(int id);
    }
}
