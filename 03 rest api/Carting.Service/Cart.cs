using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Carting.Service
{
    public class Cart
    {
        public string CartId { get; set; }

        IEnumerable<Item> Items { get; set; }
    }
}