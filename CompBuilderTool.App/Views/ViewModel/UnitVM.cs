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

        private List<Unit> _units { get; set; } = [];

        public async Task Load()
        {
            var units = await _unitDataProvider.GetAll();
            if (units is not null)
            {
                foreach (var unit in units)
                {
                    _units.Add(unit);
                }

                UpdateObservableUnits(units);
            }
        }

        public void FilteredLoad(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return;
            }

            var chars = param.ToLower().ToCharArray();
            var units = _units.Where(x => chars.All(x.Name.ToLower().Contains)).ToList();

            if (units is not null)
            {
                UpdateObservableUnits(units);
            }

        }

        public void StandardLoad()
        {
            Units.Clear();
            foreach (var unit in _units)
            {
                Units.Add(unit);
            }

            Units.OrderBy(x => x.Name);
        }

        private void UpdateObservableUnits(IEnumerable<Unit> units) 
        {
            Units.Clear();
            foreach (var unit in units) 
            {
                Units.Add(unit);
            }

            Units.OrderBy(x => x.Name);
        }
    }
}
