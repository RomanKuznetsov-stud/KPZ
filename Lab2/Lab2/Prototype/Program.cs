using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Virus 
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }

        public List<Virus> Children { get; set; } = new List<Virus>();

        public Virus(string name, string type, double weight, int age)
        {
            Name = name;
            Type = type;
            Weight = weight;
            Age = age;
        }

        public object Clone()
        {

            Virus clone = new Virus(Name, Type, Weight, Age);

            foreach (var child in Children)
            {
                clone.Children.Add((Virus)child.Clone());
            }

            return clone;
        }

        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}Вірус: {Name}, Вид: {Type}, Вага: {Weight}, Вік: {Age}");
            foreach (var child in Children)
            {
                child.Print(indent + "  ");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Virus grandParent = new Virus("SARS-CoV-1", "Coronavirus", 1.5, 10);

            Virus covid19  = new Virus("SARS-CoV-2", "Coronavirus", 1.2, 8);
            Virus mers = new Virus("MERS-CoV", "Coronavirus", 1.1, 7);

            grandParent.Children.Add(covid19);
            grandParent.Children.Add(mers);

            Virus delta = new Virus("Delta", "Variant of SARS-CoV-2", 0.11, 4);
            Virus omicron = new Virus("Omicron", "Variant of SARS-CoV-2", 0.8, 3);
            Virus lambda = new Virus("Lambda", "Variant of SARS-CoV-2", 0.61, 2);

            covid19.Children.Add(delta);
            mers.Children.Add(omicron);
            mers.Children.Add(lambda);

            Console.WriteLine("Оригінальне сімейство вірусів:");
            grandParent.Print();

            Virus clonedFamily = (Virus)grandParent.Clone();

            Console.WriteLine("\nКлоноване сімейство вірусів:");
            clonedFamily.Print();
        }
    }
}
