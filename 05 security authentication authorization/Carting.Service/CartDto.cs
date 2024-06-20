namespace Carting.Service
{
    public class CartDto
    {
        public string CartId { get; set; }
        public IEnumerable<ItemDto> Items { get; set; }
    }
}
