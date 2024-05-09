using CompBuilderTool.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompBuilderTool.App.Data
{
    public interface IUnitDataProvider 
    {
        Task<IEnumerable<Unit>> GetAll();

    }

    public class UnitDataProvider : IUnitDataProvider
    {
        private List<Unit> _inMemoryList = new List<Unit>()
            {
                new Unit() { Id = 1, Name = "Sivir" },
                new Unit() { Id = 2, Name = "Kobuko" },
                new Unit() { Id = 3, Name = "Caitlyn" }

            };

        public async Task<IEnumerable<Unit>> GetAll()
        {
            await Task.Delay(100); //Simulate Async

            return _inMemoryList;

        }

        //public async Task<IEnumerable<Unit>> GetBySearch(string param)
        //{
        //    await Task.Delay(100); //Simulate Async

        //    var chars = param.ToLower().ToCharArray();
        //    return _inMemoryList.Where(x => chars.All(x.Name.ToLower().Contains));
        //}
    }
}
