using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_factory
{
   
    public interface ILaptop
    {
        void Describe();
    }

    public interface INetbook
    {
        void Describe();
    }

    public interface IEBook
    {
        void Describe();
    }

    public interface ISmartphone
    {
        void Describe();
    }

    public interface IDeviceFactory
    {
        ILaptop CreateLaptop();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartphone CreateSmartphone();
    }

    public class IProneLaptop : ILaptop
    {
        public void Describe() => Console.WriteLine("IProne Laptop");
    }
    public class IProneNetbook : INetbook
    {
        public void Describe() => Console.WriteLine("IProne Netbook");
    }
    public class IProneEBook : IEBook
    {
        public void Describe() => Console.WriteLine("IProne EBook");
    }
    public class IProneSmartphone : ISmartphone
    {
        public void Describe() => Console.WriteLine("IProne Smartphone");
    }

    public class KiaomiLaptop : ILaptop
    {
        public void Describe() => Console.WriteLine("Kiaomi Laptop");
    }
    public class KiaomiNetbook : INetbook
    {
        public void Describe() => Console.WriteLine("Kiaomi Netbook");
    }
    public class KiaomiEBook : IEBook
    {
        public void Describe() => Console.WriteLine("Kiaomi EBook");
    }
    public class KiaomiSmartphone : ISmartphone
    {
        public void Describe() => Console.WriteLine("Kiaomi Smartphone");
    }

    public class BalaxyLaptop : ILaptop
    {
        public void Describe() => Console.WriteLine("Balaxy Laptop");
    }
    public class BalaxyNetbook : INetbook
    {
        public void Describe() => Console.WriteLine("Balaxy Netbook");
    }
    public class BalaxyEBook : IEBook
    {
        public void Describe() => Console.WriteLine("Balaxy EBook");
    }
    public class BalaxySmartphone : ISmartphone
    {
        public void Describe() => Console.WriteLine("Balaxy Smartphone");
    }

    public class IProneFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public INetbook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();
        public ISmartphone CreateSmartphone() => new IProneSmartphone();
    }

    public class KiaomiFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public INetbook CreateNetbook() => new KiaomiNetbook();
        public IEBook CreateEBook() => new KiaomiEBook();
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
    }

    public class BalaxyFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public INetbook CreateNetbook() => new BalaxyNetbook();
        public IEBook CreateEBook() => new BalaxyEBook();
        public ISmartphone CreateSmartphone() => new BalaxySmartphone();
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("== IProne Devices ==");
            IDeviceFactory iproneFactory = new IProneFactory();
            iproneFactory.CreateLaptop().Describe();
            iproneFactory.CreateNetbook().Describe();
            iproneFactory.CreateEBook().Describe();
            iproneFactory.CreateSmartphone().Describe();

            Console.WriteLine("\n== Kiaomi Devices ==");
            IDeviceFactory kiaomiFactory = new KiaomiFactory();
            kiaomiFactory.CreateLaptop().Describe();
            kiaomiFactory.CreateNetbook().Describe();
            kiaomiFactory.CreateEBook().Describe();
            kiaomiFactory.CreateSmartphone().Describe();

            Console.WriteLine("\n== Balaxy Devices ==");
            IDeviceFactory balaxyFactory = new BalaxyFactory();
            balaxyFactory.CreateLaptop().Describe();
            balaxyFactory.CreateNetbook().Describe();
            balaxyFactory.CreateEBook().Describe();
            balaxyFactory.CreateSmartphone().Describe();
        }
    }

}
