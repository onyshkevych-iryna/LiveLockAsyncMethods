using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecondTaskFirstPart
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var syncObject1 = new object();
            var syncObject2 = new object();

            var a = new A();
            var b = new B();
            var c = new C();

            Task.Run(() => a.PerformOperation(c));
            Task.Run(() => b.PerformOperation(c));     

            Console.ReadLine();
        }
    }

   
    class A
    {
        public void PerformOperation(C e)
        {
            while (true)
            {
                Console.WriteLine("Class A, before can procceed 1");
                if (e.CanProcceed1)
                {
                    Console.WriteLine("Class A, can procceed 1");

                    e.CanProcceed1 = false;

                    Thread.Sleep(1000);

                    while (true)
                    {
                        Thread.Sleep(1000);

                        Console.WriteLine("Class A, before can procceed 2");
                        if (e.CanProcceed2)
                        {
                            e.CanProcceed2 = false;
                            Console.WriteLine("Class A, can procceed 2");

                            break;
                        }
                        Console.WriteLine("Class A, after can procceed 2");
                    }

                    e.CanProcceed2 = true;
                }
                Console.WriteLine("Class A, after can procceed 1");

                if (e.CanProcceed2)
                {
                    e.CanProcceed1 = true;
                    break;
                }
            }
            Console.WriteLine("Class A, end");
        }
    }

    class B
    {
        public void PerformOperation(C e)
        {
            while (true)
            {
                Console.WriteLine("Class B, before can procceed 2");
                if (e.CanProcceed2)
                {
                    Console.WriteLine("Class B, can procceed 2");

                    e.CanProcceed2 = false;

                    Thread.Sleep(1000);

                    while (true)
                    {
                        Thread.Sleep(1000);

                        Console.WriteLine("Class B, before can procceed 1");
                        if (e.CanProcceed1)
                        {
                            e.CanProcceed1 = false;
                            Console.WriteLine("Class B, can procceed 1");

                            break;
                        }
                        Console.WriteLine("Class B, after can procceed 1");
                    }

                    e.CanProcceed1 = true;
                }
                Console.WriteLine("Class B, after can procceed 2");

                if (e.CanProcceed1)
                {
                    e.CanProcceed2 = true;
                    break;
                }
            }
            Console.WriteLine("Class B, end");
        }
    }

    class C
    {
        public bool CanProcceed1 { get; set; } = true;
        public bool CanProcceed2 { get; set; } = true;
    }

}
