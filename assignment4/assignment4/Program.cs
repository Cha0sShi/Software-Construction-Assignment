using System;
//1、为示例中的泛型链表类添加类似于List<T> 类的ForEach(Action<T> action)方法。
//通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。

//2、使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
//在闹钟走时时或者响铃时，在控制台显示提示信息。

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    private Node<T> head;

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void ForEach(Action<T> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }

    public T Sum(Func<T, T, T> func)
    {
        T sum = default(T);
        Node<T> current = head;
        while (current != null)
        {
            sum = func(sum, current.Data);
            current = current.Next;
        }
        return sum;
    }

    public T Max(Func<T, T, T> comparer)
    {
        if (head == null)
            throw new InvalidOperationException("链表为空");

        T max = head.Data;
        Node<T> current = head.Next;
        while (current != null)
        {
            max = comparer(max, current.Data);
            current = current.Next;
        }
        return max;
    }

    public T Min(Func<T, T, T> comparer)
    {
        if (head == null)
            throw new InvalidOperationException("链表为空");

        T min = head.Data;
        Node<T> current = head.Next;
        while (current != null)
        {
            min = comparer(min, current.Data);
            current = current.Next;
        }
        return min;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(3);
        list.Add(7);
        list.Add(2);
        list.Add(9);

        Console.WriteLine("链表元素：");
        list.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        int sum = list.Sum((x, y) => x + y);
        Console.WriteLine("链表元素求和：{0}", sum);

        int max = list.Max((x, y) => x > y ? x : y);
        Console.WriteLine("链表元素最大值：{0}", max);

        int min = list.Min((x, y) => x < y ? x : y);
        Console.WriteLine("链表元素最小值：{0}", min);

        AlarmClock clock = new AlarmClock();
        clock.Tick += () => Console.WriteLine("嘀嗒...");
        clock.Tick += () => Console.WriteLine("666...");
        clock.Alarm += () => Console.WriteLine("响铃！！！");

        for (int i = 0; i < 10; i++)
        {
            clock.Run();
            Thread.Sleep(1000);
        }
        clock.SetAlarm();
        clock.Run();
    }
}

public class AlarmClock
{
    public event Action Tick;
    public event Action Alarm;

    public void Run()
    {
        Console.WriteLine("时间流逝...");
        OnTick();
    }

    public void SetAlarm()
    {
        Console.WriteLine("设置闹钟...");
        OnAlarm();
    }

    protected virtual void OnTick()
    {
        Tick?.Invoke();
    }

    protected virtual void OnAlarm()
    {
        Alarm?.Invoke();
    }
}
