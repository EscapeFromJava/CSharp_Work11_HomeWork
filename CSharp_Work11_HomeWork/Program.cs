using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Math = System.Math;

namespace CSharp_Work11_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ifigure> listFigure = new List<Ifigure>();

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

            for (int i = 0; i < listFigure.Count; i++)
                listFigure[i].Print();

            Console.WriteLine("==== после сортировки ====");

            listFigure.Sort();

            for (int i = 0; i < listFigure.Count; i++)
                listFigure[i].Print();

            Console.ReadKey();
        }
    }

    interface Ifigure
    {
        double Edge { set; }
        double Diagonal { get; }
        void Print();
    }

    struct Cube : Ifigure, IComparable
    {
        private string name;
        public Cube(double x)
        {
            Edge = x;
            name = "Cube";
        }
        public double Edge { get; set; }
        public double Diagonal
        {
            get { return Math.Sqrt(Edge * Edge + Edge * Edge); }
        }
        public void Print()
        {
            Console.WriteLine("{0} Диагональ = {1:f2}, Площадь = {2:f2}, Объем = {3:f2}", name, Diagonal, 6 * Edge * Edge, Edge * Edge * Edge);
        }

        public int CompareTo(object obj)
        {
            Ifigure c = (Ifigure)obj;
            if (Diagonal > c.Diagonal)
                return 1;
            else
                return -1;
        }
    }

    struct Square : Ifigure, IComparable
    {
        private string name;
        public Square(double x)
        {
            Edge = x;
            name = "Square";
        }
        public double Edge { get; set; }
        public double Diagonal
        {
            get { return Math.Sqrt(Edge * Edge + Edge * Edge); }
        }
        public void Print()
        {
            Console.WriteLine("{0} Диагональ = {1:f2}, Площадь = {2:f2}", name, Diagonal, Edge * Edge);
        }

        public int CompareTo(object obj)
        {
            Ifigure s = (Ifigure) obj;
            if (Diagonal > s.Diagonal)
                return 1;
            else
                return -1;
        }
    }
}
