using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebApplication3.Pages.Shared
{
    public class IndexModel : PageModel
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public string Solution { get; set; }

        public void OnGet()
        {
            double.TryParse(TempData["a"]?.ToString(), out double val);
            A = val;
            double.TryParse(TempData["b"]?.ToString(), out val);
            B = val;
            double.TryParse(TempData["c"]?.ToString(), out val);
            C = val;
            Solution = TempData["sol"]?.ToString();
        }
        public IActionResult OnPost([FromForm] double a, [FromForm] double b, [FromForm] double c)
        {
            double d = b * b - 4 * a * c;
            double x1, x2;
            if (d > 0)
            {
                x1 = -b - Math.Sqrt(d) / 2 / a;
                x2 = -b + Math.Sqrt(d) / 2 / a;
                Solution = $"x<sub>1</sub> = {x1:f2}<br />x<sub>2</sub> = {x2:f2}";
            }
            else if (d == 0)
            {
                x1 = -b / 2 / a;
                Solution = $"x = {x1:f2}";
            }
            else
            {
                Solution = "нет корней";
            }
            TempData["a"] = a.ToString();
            TempData["b"] = b.ToString();
            TempData["c"] = c.ToString();
            TempData["sol"] = Solution;
            return RedirectToPage("SqEq");
        }

    }
}
