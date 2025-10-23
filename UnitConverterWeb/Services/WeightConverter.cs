namespace UnitConverterWeb.Services
{
    public class WeightConverter : IConverter
    {
        private readonly Dictionary<string, double> _toKg = new()
        {
            { "milligram", 0.000001 },
            { "gram", 0.001 },
            { "kilogram", 1 },
            { "ounce", 0.0283495 },
            { "pound", 0.453592 }
        };

        public double Convert(double value, string fromUnit, string toUnit)
        {
            var kg = value * _toKg[fromUnit];
            return kg / _toKg[toUnit];
        }

        public IEnumerable<string> GetUnits() => _toKg.Keys;
    }
}
