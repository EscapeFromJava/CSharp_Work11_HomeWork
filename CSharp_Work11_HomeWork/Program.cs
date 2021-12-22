using System;
using System.Collections.Generic;
using Math = System.Math;

namespace CSharp_Work11_HomeWork
{
    class Program
    {
        static void Main()
        {
            List<IFigure> listFigure = new List<IFigure>();

            Cube c1 = new Cube(30);
            Cube c2 = new Cube(15);
            Cube c3 = new Cube(4);
            Cube c4 = new Cube(59);
            Cube c5 = new Cube(32);

            Square s1 = new Square(13);
            Square s2 = new Square(25);
            Square s3 = new Square(3);
            Square s4 = new Square(5);
            Square s5 = new Square(14);

            listFigure.Add(c1);
            listFigure.Add(s1);
            listFigure.Add(c2);
            listFigure.Add(s2);
            listFigure.Add(c3);
            listFigure.Add(s3);
            listFigure.Add(c4);
            listFigure.Add(s4);
            listFigure.Add(c5);
            listFigure.Add(s5);

            Console.WriteLine("==== до сортировки ====");

            foreach (var el in listFigure)
                el.Print();

            Console.WriteLine("==== после сортировки ====");

            listFigure.Sort();

            foreach (var el in listFigure)
                el.Print();

            Console.ReadKey();
        }
    }

    interface IFigure
    {
        //double Edge { set; }
        double Diagonal { get; }
        void Print();
    }

    struct Cube : IFigure, IComparable
    {
        private readonly string _name;
        public Cube(double x)
        {
            Edge = x;
            _name = "Cube";
        }
        public double Edge { get; set; }
        public double Diagonal => Math.Sqrt(Edge * Edge + Edge * Edge);

        public void Print()
        {
            Console.WriteLine("{0} Диагональ = {1:f2}, Площадь = {2:f2}, Объем = {3:f2}", _name, Diagonal, 6 * Edge * Edge, Edge * Edge * Edge);
        }

        public int CompareTo(object obj)
        {
            IFigure c = (IFigure)obj;
            if (Diagonal > c.Diagonal)
                return 1;
            else
                return -1;
        }
    }

    struct Square : IFigure, IComparable
    {
        private readonly string _name;
        public Square(double x)
        {
            Edge = x;
            _name = "Square";
        }
        public double Edge { get; set; }
        public double Diagonal => Math.Sqrt(Edge * Edge + Edge * Edge);

        public void Print()
        {
            Console.WriteLine("{0} Диагональ = {1:f2}, Площадь = {2:f2}", _name, Diagonal, Edge * Edge);
        }

        public int CompareTo(object obj)
        {
            IFigure s = (IFigure) obj;
            if (Diagonal > s.Diagonal)
                return 1;
            else
                return -1;
        }
    }
}
