using System;
using System.Collections.Generic;
using System.Linq;
//写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户、订单金额等进行查询）功能。并对各个Public方法编写测试用例。

//提示：主要的类有Order（订单）、OrderDetails（订单明细），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。

//要求：
//（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
//（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
//（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
//（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
//（5） OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。



// 订单明细类
public class OrderDetails
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is OrderDetails other)
        {
            return this.Id == other.Id && this.ProductName == other.ProductName;
        }
        return false;
    }

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

    public double TotalAmount => Details.Sum(detail => detail.Price * detail.Quantity);

    public override bool Equals(object obj)
    {
        if (obj is Order other)
        {
            return this.OrderId == other.OrderId;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {Customer}, Total Amount: {TotalAmount}";
    }
}

// 订单服务类
public class OrderService
{
    private List<Order> orders;

    public OrderService()
    {
        orders = new List<Order>();
    }

    // 添加订单
    public void AddOrder(Order order)
    {
        if (!orders.Contains(order))
        {
            orders.Add(order);
        }
        else
        {
            throw new ArgumentException("Order already exists.");
        }
    }

    // 删除订单
    public void RemoveOrder(int orderId)
    {
        Order orderToRemove = orders.FirstOrDefault(order => order.OrderId == orderId);
        if (orderToRemove != null)
        {
            orders.Remove(orderToRemove);
        }
        else
        {
            throw new ArgumentException("Order not found.");
        }
    }

    // 修改订单（只修改客户名称）
    public void ModifyOrder(int orderId, string newCustomer)
    {
        Order orderToModify = orders.FirstOrDefault(order => order.OrderId == orderId);
        if (orderToModify != null)
        {
            orderToModify.Customer = newCustomer;
        }
        else
        {
            throw new ArgumentException("Order not found.");
        }
    }

    // 按订单号查询订单
    public Order QueryOrderByOrderId(int orderId)
    {
        return orders.FirstOrDefault(order => order.OrderId == orderId);
    }

    // 按商品名称查询订单
    public List<Order> QueryOrdersByProductName(string productName)
    {
        return orders.Where(order => order.Details.Any(detail => detail.ProductName == productName))
                     .ToList();
    }

    // 按客户查询订单
    public List<Order> QueryOrdersByCustomer(string customer)
    {
        return orders.Where(order => order.Customer == customer)
                     .ToList();
    }

    // 按订单金额查询订单
    public List<Order> QueryOrdersByAmount(double amount)
    {
        return orders.Where(order => order.TotalAmount == amount)
                     .OrderBy(order => order.TotalAmount)
                     .ToList();
    }

    // 排序订单
    public void SortOrders(Func<Order, object> keySelector)
    {
        orders = orders.OrderBy(keySelector).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderService orderService = new OrderService();

        // 添加订单示例
        Order order1 = new Order
        {
            OrderId = 1,
            Customer = "Alice",
            Details = new List<OrderDetails>
            {
                new OrderDetails { Id = 1, ProductName = "Product A", Price = 10.0, Quantity = 2 },
                new OrderDetails { Id = 2, ProductName = "Product B", Price = 15.0, Quantity = 1 }
            }
        };
        orderService.AddOrder(order1);

       

        // 测试删除订单
        try
        {
            orderService.RemoveOrder(1);
            Console.WriteLine("Order removed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing order: {ex.Message}");
        }
        Order order2 = new Order
        {
            OrderId = 2,
            Customer = "Jackk",
            Details = new List<OrderDetails>
            {
                new OrderDetails { Id = 1, ProductName = "Product A", Price = 10.0, Quantity = 2 },
                new OrderDetails { Id = 2, ProductName = "Product B", Price = 15.0, Quantity = 1 }
            }
        };
        orderService.AddOrder(order2);
        // 测试修改订单
        try
        {
            orderService.ModifyOrder(2, "Bob");
            Console.WriteLine("Order modified successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error modifying order: {ex.Message}");
        }

        // 测试查询订单功能
        var queriedOrder = orderService.QueryOrderByOrderId(2);
        Console.WriteLine("Queried Order:");
        Console.WriteLine(queriedOrder);

        var queriedOrdersByProduct = orderService.QueryOrdersByProductName("Product A");
        Console.WriteLine("Queried Orders By Product:");
        foreach (var order in queriedOrdersByProduct)
        {
            Console.WriteLine(order);
        }

        // 测试排序订单
        orderService.SortOrders(order => order.TotalAmount);
        Console.WriteLine("Sorted Orders:");
        foreach (var order in orderService.QueryOrdersByAmount(order1.TotalAmount))
        {
            Console.WriteLine(order);
        }

        Console.ReadLine(); // 保持控制台窗口打开
    }
}
