namespace Shopping.Web.Pages;

public class OrderListModel
    (IOrderingService orderingService, ILogger<OrderListModel> logger)
    : PageModel
{
    public IEnumerable<OrderModel> Orders { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        var customerId = new Guid("020986f4-1606-473b-ab7d-ba9fd4f8100f");

        var response = await orderingService.GetOrdersByCustomer(customerId);
        Orders = response.Orders;

        return Page();
    }
}
