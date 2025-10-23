namespace UnitConverterWeb.Services
{
    public class LengthConverter : IConverter
    {
        private readonly Dictionary<string, double> _toMeter = new()
        {
            { "millimeter", 0.001 },
            { "centimeter", 0.01 },
            { "meter", 1 },
            { "kilometer", 1000 },
            { "inch", 0.0254 },
            { "foot", 0.3048 },
            { "yard", 0.9144 },
            { "mile", 1609.34 }
        };

        public double Convert(double value, string fromUnit, string toUnit)
        {
            var meters = value * _toMeter[fromUnit];
            return meters / _toMeter[toUnit];
        }

        public IEnumerable<string> GetUnits() => _toMeter.Keys;
    }
}
