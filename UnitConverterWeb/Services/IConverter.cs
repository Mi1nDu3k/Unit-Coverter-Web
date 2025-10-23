namespace UnitConverterWeb.Services
{
    public interface IConverter
    {
        double Convert(double value, string fromUnit, string toUnit);
        IEnumerable<string> GetUnits();
    }
}
