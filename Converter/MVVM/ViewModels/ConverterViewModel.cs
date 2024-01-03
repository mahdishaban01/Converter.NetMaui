using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UnitsNet;

namespace Converter.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }
        public double FromValue { get; set; } = 1;
        public double ToValue { get; set; }
        public ICommand ReturnCommand =>
             new Command(() =>
             {
                 Convert();
             });

        public ConverterViewModel(string quantityName)
        {
            QuantityName = quantityName;
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();
            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
            Convert();
        }

        public void Convert()
        {
            var result =
                 UnitConverter
                 .ConvertByName(FromValue, QuantityName,
                 CurrentFromMeasure,
                 CurrentToMeasure);
            ToValue = result;
        }

        private ObservableCollection<string> LoadMeasures()
        {
            var types =
                 Quantity.Infos
                 .FirstOrDefault(x => x.Name == QuantityName)
                 .UnitInfos
                 .Select(u => u.Name)
                 .ToList();
            return new ObservableCollection<string>(types);
        }
    }
}
