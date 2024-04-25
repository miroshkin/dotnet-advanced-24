using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Carting.Service
{
    public class Cart
    {
        public int Id { get; set; }

        IEnumerable<Item> Items { get; set; }
    }
}