namespace Ordering.Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("020986f4-1606-473b-ab7d-ba9fd4f8100f")),"mehmet", "mehmet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("34786e81-2941-40bc-9069-dae126065736")),"john", "john@gmail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("b1c8f0d2-3e4f-4c5a-8b6d-7e8f9a0b1c2d")), "Product 1", 500m),
            Product.Create(ProductId.Of(new Guid("c2d3e4f5-6a7b-8c9d-a0b1-c2d3e4f5a6b7")), "Product 2", 400m),
            Product.Create(ProductId.Of(new Guid("f360cc7f-aea4-4310-9b47-7f2ac55aec57")), "Product 3", 650m),
            Product.Create(ProductId.Of(new Guid("04b0e7a6-ead3-436d-8f7c-098e71308708")), "Product 4", 450m)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8888885555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("020986f4-1606-473b-ab7d-ba9fd4f8100f")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("b1c8f0d2-3e4f-4c5a-8b6d-7e8f9a0b1c2d")), 2, 500m);
            order1.Add(ProductId.Of(new Guid("c2d3e4f5-6a7b-8c9d-a0b1-c2d3e4f5a6b7")), 1, 400m);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("34786e81-2941-40bc-9069-dae126065736")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);

            order2.Add(ProductId.Of(new Guid("f360cc7f-aea4-4310-9b47-7f2ac55aec57")), 1, 650m);
            order2.Add(ProductId.Of(new Guid("04b0e7a6-ead3-436d-8f7c-098e71308708")), 3, 450m);

            return new List<Order> { order1, order2 };
        }
    }
}
