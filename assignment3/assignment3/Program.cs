using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Transactions;

namespace homework3
{
    public abstract class Shape
    {
        protected double Area { get; set; }
        public abstract double CalArea();
    }
    interface Judge
    {
        bool JudgeShape();
    }

    public class Rectangle : Shape
    {
        private double len;
        private double wid;
        public Rectangle(double len, double wid)
        {
            this.len = len; this.wid = wid;
        }

        public override double CalArea()
        {
            Area = len * wid;
            return Area;
        }
    }
    public class Square : Rectangle
    {
        private double side;
        public Square(double side) : base(side, side)
        {
        }
    }
    public class Triangle : Shape, Judge
    {
        private double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double CalArea()
        {
            double p = (a + b + c) / 2;
            Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return Area;
        }
        public bool JudgeShape()
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            else return false;
        }
    }
    public class ShapeFactory
    {
        public Shape GetShape(String shapeType, double a, double? b, double? c)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType == "RECTANGLE")
            {
                return new Rectangle(a, (double)b);
            }
            else if (shapeType == "SQUARE")
            {
                return new Square(a);
            }
            else if (shapeType == "TRIANGLE")
            {
                return new Triangle(a, (double)b, (double)c);
            }
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //普通的随机产生
            Rectangle rec1 = new Rectangle(5, 4);
            Rectangle rec2 = new Rectangle(9, 4);
            Rectangle rec3 = new Rectangle(5, 1);
            Rectangle rec4 = new Rectangle(10, 2);
            Square squ1 = new Square(2);
            Square squ2 = new Square(3);
            Square squ3 = new Square(4);
            Square squ4 = new Square(5);
            Triangle tri1 = new Triangle(3, 4, 5);
            Triangle tri2 = new Triangle(6, 8, 10);
            Console.WriteLine(rec1.CalArea() + rec2.CalArea() + rec3.CalArea() + rec4.CalArea() + squ1.CalArea() + squ2.CalArea() + squ3.CalArea() + squ4.CalArea() + tri1.CalArea() + tri2.CalArea());
            //使用工厂
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape shape1 = shapeFactory.GetShape("RECTANGLE", 5, 4, null);
            Shape shape2 = shapeFactory.GetShape("RECTANGLE", 9, 4, null);
            Shape shape3 = shapeFactory.GetShape("RECTANGLE", 5, 1, null);
            Shape shape4 = shapeFactory.GetShape("RECTANGLE", 10, 2, null);
            Shape shape5 = shapeFactory.GetShape("SQUARE", 2, null, null);
            Shape shape6 = shapeFactory.GetShape("SQUARE", 3, null, null);
            Shape shape7 = shapeFactory.GetShape("SQUARE", 4, null, null);
            Shape shape8 = shapeFactory.GetShape("SQUARE", 5, null, null);
            Shape shape9 = shapeFactory.GetShape("TRIANGLE", 3, 4, 5);
            Shape shape10 = shapeFactory.GetShape("TRIANGLE", 6, 8, 10);
            Console.WriteLine(shape1.CalArea() + shape2.CalArea() + shape3.CalArea() + shape4.CalArea() + shape5.CalArea() + shape6.CalArea() + shape7.CalArea() + shape8.CalArea() + shape9.CalArea() + shape10.CalArea());
        }
    }
}
