using CompBuilderTool.App.Data;
using CompBuilderTool.App.Models;
using System.Collections.ObjectModel;

namespace CompBuilderTool.App.Views.ViewModel
{
    public class UnitVM
    {
        private IUnitDataProvider _unitDataProvider { get; }

        public UnitVM(IUnitDataProvider unitDataProvider)
        {
            _unitDataProvider = unitDataProvider;
        }

        public ObservableCollection<Unit> Units { get; } = [];

        public async Task Load()
        {
            var units = await _unitDataProvider.GetAll();
            if (units is not null)
            {
                Units.Clear();
                foreach (var unit in units)
                {
                    Units.Add(unit);
                }
            }
            Units.OrderBy(x => x.Name).ToList();
        }

        public async Task FilteredLoad(string param)
        {
            var units = await _unitDataProvider.GetBySearch(param);
            if (units is not null)
            {
                Units.Clear();
                foreach (var unit in units)
                {
                    Units.Add(unit);
                }
            }
            else
            {
                await _unitDataProvider.GetAll();
            }

            Units.OrderBy(x => x.Name).ToList();
        }
    }
}
