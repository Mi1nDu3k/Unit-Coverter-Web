using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverterWeb.Services;

namespace UnitConverterWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Dictionary<string, IConverter> _converters;

        [BindProperty]
        public string Category { get; set; } = "Length";

        [BindProperty]
        public double Value { get; set; }

        [BindProperty]
        public string From { get; set; } = string.Empty;

        [BindProperty]
        public string To { get; set; } = string.Empty;

        public double? Result { get; set; }

        public List<string> Categories { get; } = new() { "Length", "Weight", "Temperature" };

        public IEnumerable<string> Units { get; set; } = Enumerable.Empty<string>();

        public IndexModel()
        {
            _converters = new Dictionary<string, IConverter>
            {
                { "Length", new LengthConverter() },
                { "Weight", new WeightConverter() },
                { "Temperature", new TemperatureConverter() }
            };
        }

        public void OnGet(string? category)
        {
            var selectedCategory = category ?? Category;
            Category = selectedCategory;
            Units = _converters[selectedCategory].GetUnits();
        }

        public IActionResult OnPost()
        {
            var converter = _converters[Category];
            Units = converter.GetUnits();

            Result = converter.Convert(Value, From, To);

            return Page();
        }
    }
}
