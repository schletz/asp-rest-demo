using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace AspRestDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DemoContext _db;

        public IndexModel(DemoContext db)
        {
            _db = db;
        }

        public List<Vehicle> Vehicles { get; set; } = new();
        public void OnGet()
        {
            Vehicles = _db.Vehicles.OrderBy(v => v.Id).ToList();
        }
    }
}
