namespace UnitConverterWeb.Services
{
    public class TemperatureConverter : IConverter
    {
        public double Convert(double value, string fromUnit, string toUnit)
        {
            var celsius = fromUnit.ToLower() switch
            {
                "celsius" => value,
                "fahrenheit" => (value - 32) * 5 / 9,
                "kelvin" => value - 273.15,
                _ => throw new ArgumentException("Invalid from unit")
            };

            return toUnit.ToLower() switch
            {
                "celsius" => celsius,
                "fahrenheit" => (celsius * 9 / 5) + 32,
                "kelvin" => celsius + 273.15,
                _ => throw new ArgumentException("Invalid to unit")
            };
        }

        public IEnumerable<string> GetUnits() =>
            new List<string> { "Celsius", "Fahrenheit", "Kelvin" };
    }
}
