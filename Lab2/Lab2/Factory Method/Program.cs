using System;
using System.Collections.Generic;

namespace Factory_Method
{
    abstract class Subscription
    {
        public abstract string Name { get; }
        public abstract decimal Monthly_Fee { get; }
        public abstract int MinPeriodInMonths { get; }
        public abstract List<string> Channels { get; }
        public abstract List<string> Features { get; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Підписка: {Name}");
            Console.WriteLine($"Місячна плата: {Monthly_Fee} грн");
            string count_month = (MinPeriodInMonths % 10 == 1 && MinPeriodInMonths % 100 != 11) ? "місяць" : "місяців";
            Console.WriteLine($"Мінімальний період: {MinPeriodInMonths} {count_month}");
            Console.WriteLine("Канали: " + string.Join(", ", Channels));
            Console.WriteLine("Можливості: " + string.Join(", ", Features));
            Console.WriteLine();
        }
    }

    class DomesticSubscription : Subscription
    {
        public override string Name => "Домашня";
        public override decimal Monthly_Fee => 150;
        public override int MinPeriodInMonths => 3;
        public override List<string> Channels => new List<string> { "Новини", "Фільми", "Серіали" };
        public override List<string> Features => new List<string> { "HD якість", "1 пристрій" };
    }

    class EducationalSubscription : Subscription
    {
        public override string Name => "Освітня";
        public override decimal Monthly_Fee => 100;
        public override int MinPeriodInMonths => 6;
        public override List<string> Channels => new List<string> { "Наука", "Історія", "Новини" };
        public override List<string> Features => new List<string> { "HD якість", "2 пристрої" };
    }

    class PremiumSubscription : Subscription
    {
        public override string Name => "Преміум";
        public override decimal Monthly_Fee => 300;
        public override int MinPeriodInMonths => 1;
        public override List<string> Channels => new List<string> { "Усе включено" };
        public override List<string> Features => new List<string> { "4K якість", "Без реклами", "до 6 пристроїв" };
    }

    abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription(string type);
    }

    class WebSite : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine("Оформлення через WebSite...");
            return type switch
            {
                "Domestic" => new DomesticSubscription(),
                "Educational" => new EducationalSubscription(),
                "Premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки"),
            };
        }
    }

    class MobileApp : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine("Оформлення через MobileApp...");
            return type switch
            {
                "Domestic" => new DomesticSubscription(),
                "Educational" => new EducationalSubscription(),
                "Premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки"),
            };
        }
    }

    class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine("Оформлення через дзвінок менеджеру...");
            return type switch
            {
                "Domestic" => new DomesticSubscription(),
                "Educational" => new EducationalSubscription(),
                "Premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки"),
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            List<SubscriptionCreator> creators = new List<SubscriptionCreator>
            {
            new WebSite(),
            new MobileApp(),
            new ManagerCall()
            };
 
            string[] types = { "Domestic", "Educational", "Premium" };

            foreach (var creator in creators)
            {
                foreach (var type in types)
                {
                    Subscription subscription = creator.CreateSubscription(type);
                    subscription.ShowInfo();
                }
            }

            Console.ReadLine();
        }
    }
}