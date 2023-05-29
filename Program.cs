using System.Net.WebSockets;

namespace theradcalisma
{
    internal class Program
    {
        static int[] a = new int[100000];
        static int sayac = 0;
        static int kont = 0;
        static Mutex m = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;   
            }

            Thread th1 = new Thread(B1);
            Thread th2 = new Thread(B2);
            Thread th3 = new Thread(B3);
            Thread th4 = new Thread(B4);

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();

            while (kont < 4 )
            {

            }
            Console.WriteLine(sayac) ;

        }
        static void B1()
        {
            m.WaitOne();
            for (int i = 0; i < 25001; i++)
            {
                if (a[i] == 0 )
                {
                    sayac++;
                }
            }
            kont++;
            m.ReleaseMutex();
        }
        static void B2()
        {
            m.WaitOne();
            for (int i = 25001; i < 50001; i++)
            {
                if (a[i] == 0)
                {
                    sayac++;
                }
            }
            kont++;
            m.ReleaseMutex();
        }
        static void B3()
        {
            m.WaitOne();
            for (int i = 50001; i < 75001; i++)
            {
                if (a[i] == 0)
                {
                    sayac++;
                }
            }
            kont++;
            m.ReleaseMutex();
        }
        static void B4()
        {
            m.WaitOne();
            for (int i = 75001; i < 100000; i++)
            {
                if (a[i] == 0)
                {
                    sayac++;
                }
            }
            kont++;
            m.ReleaseMutex();
        }

    }
}