using System;
using System.Collections.Generic;
using System.Linq;

// 订单明细类
public class OrderDetails
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Product: {ProductName}, Price: {Price}, Quantity: {Quantity}";
    }
}

// 订单类
public class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetails> Details { get; set; }
    public Order()
    {
        Details = new List<OrderDetails>();
    }
    public double TotalAmount =>Details.Sum(detail => detail.Price * detail.Quantity);

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {Customer}, Total Amount: {TotalAmount}";
    }

    // 重写Equals方法以确保订单不重复
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Order otherOrder = (Order)obj;
        return OrderId == otherOrder.OrderId;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }
}

// 订单服务类
public class OrderService
{
    private List<Order> orders = new List<Order>();

    // 添加订单
    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
            throw new InvalidOperationException("Order already exists.");

        orders.Add(order);
    }

    // 删除订单
    public void RemoveOrder(int orderId)
    {
        Order orderToRemove = orders.FirstOrDefault(order => order.OrderId == orderId);
        if (orderToRemove == null)
            throw new InvalidOperationException("Order not found.");

        orders.Remove(orderToRemove);
    }

    // 修改订单
    public void ModifyOrder(int orderId, string newCustomer)
    {
        Order orderToModify = orders.FirstOrDefault(order => order.OrderId == orderId);
        if (orderToModify == null)
            throw new InvalidOperationException("Order not found.");

        orderToModify.Customer = newCustomer;
    }

    // 按照订单号查询订单
    public Order QueryOrderByOrderId(int orderId)
    {
        return orders.FirstOrDefault(order => order.OrderId == orderId);
    }

    // 按照商品名称查询订单
    public List<Order> QueryOrderByProductName(string productName)
    {
        return orders.Where(order =>
            order.Details.Any(detail => detail.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    // 按照客户查询订单
    public List<Order> QueryOrderByCustomer(string customer)
    {
        return orders.Where(order => order.Customer.Equals(customer, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // 按照订单金额查询订单
    public List<Order> QueryOrderByAmount(double amount)
    {
        return orders.Where(order => order.TotalAmount == amount).ToList();
    }

    // 按照订单总金额排序返回
    public List<Order> SortOrdersByAmount()
    {
        return orders.OrderBy(order => order.TotalAmount).ToList();
    }

    // 自定义排序方法
    public List<Order> CustomSortOrders(Func<Order, object> keySelector)
    {
        return orders.OrderBy(keySelector).ToList();
    }
}

public class Program
{
    public static void Main()
    {
        // 创建订单服务
        OrderService orderService = new OrderService();

        // 添加测试订单
        Order order1 = new Order { OrderId = 1, Customer = "Alice" };
        Order order2 = new Order { OrderId = 2, Customer = "Bob" };
        Order order3 = new Order { OrderId = 3, Customer = "Alice" };

        // 添加订单到订单服务
        orderService.AddOrder(order1);
        orderService.AddOrder(order2);

        // 测试查询订单
        Console.WriteLine("Query order by order ID:");
        Console.WriteLine(orderService.QueryOrderByOrderId(1));
        Console.WriteLine(orderService.QueryOrderByOrderId(3));

        Console.WriteLine("\nQuery order by customer:");
        Console.WriteLine(string.Join(", ", orderService.QueryOrderByCustomer("Alice")));

        Console.WriteLine("\nQuery order by product name:");
        order1.Details = new List<OrderDetails>
        {
            new OrderDetails { ProductName = "Product A", Price = 10, Quantity = 2 },
            new OrderDetails { ProductName = "Product B", Price = 20, Quantity = 1 }
        };
        order2.Details = new List<OrderDetails>
        {
            new OrderDetails { ProductName = "Product C", Price = 15, Quantity = 3 }
        };
        orderService.AddOrder(order3); // Add order with no details for testing query by product name
        Console.WriteLine(string.Join(", ", orderService.QueryOrderByProductName("Product B")));

        // 测试排序订单
        Console.WriteLine("\nSorted orders by amount:");
        foreach (var order in orderService.SortOrdersByAmount())
        {
            Console.WriteLine(order);
        }

        // 测试自定义排序
        Console.WriteLine("\nCustom sorted orders by customer:");
        foreach (var order in orderService.CustomSortOrders(order => order.Customer))
        {
            Console.WriteLine(order);
        }
    }
}
