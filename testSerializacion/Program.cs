using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace testSerializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Animales-------");
            ArrayList ob = new ArrayList();
            //byte[] buff1 = LeerBinario("C:/Users/ayrto_e5oa9k8/Downloads/Application.ttf");
            byte[] buff2 = LeerBinario("C:/Users/ayrto_e5oa9k8/Downloads/Application (1).ttf");
            byte[] buff3 = LeerBinario("C:/Users/ayrto_e5oa9k8/Downloads/Application (2).ttf");

           // ob.Add(Obj(buff1));
            ob.Add(Obj(buff2));
            ob.Add(Obj(buff3));

            //Thread t1 = new Thread(new ThreadStart(proceso1));
            Thread t2 = new Thread(new ThreadStart(proceso2));
            Thread t3 = new Thread(new ThreadStart(proceso3));
           // t1.Start();
            t2.Start();
            t3.Start();

        }
        public static Animal Obj(byte[] buff)
        {
            Stream canal = new MemoryStream(buff, true);
            IFormatter formateador = new BinaryFormatter();
            Animal otro = (Animal)formateador.Deserialize(canal);
            canal.Close();
            canal.Dispose();
            Console.WriteLine(otro);
            return otro;
            
        }

        public static byte[] LeerBinario(string nomArch)
        {
            byte[] buff = new byte[256];
            IFormatter formateador = new BinaryFormatter();
            Stream canal = new FileStream(nomArch, FileMode.Open, FileAccess.Read, FileShare.None);
            canal.Read(buff, 0, buff.Length);
            canal.Close();
            canal.Dispose();
            return buff;
        }
        public static void proceso1()
        {
            for (int i=0;i<80;i++)
            {
                Console.Write("T");
                Thread.Sleep(80);                
            }
            Console.WriteLine("La Tortuga ha llegado a la meta, LA TORTUGA HA GANADO LA CARRERA");
        }
        public static void proceso2()
        {
            for (int i = 0; i < 80; i++)
            {
                if(i>=0 && i<40)
                {
                    Console.Write("L");
                    Thread.Sleep(50);
                }
                if(i==40)
                {
                    Console.WriteLine("La liebre se ha dormido");
                }
                if(i==60)
                {
                    Console.WriteLine("La liebre se ha despertado");
                }
            
                if (i >= 40 && i<50)
                {
                    Console.Write("L");
                    Thread.Sleep(500);
                }

                if (i >= 50 && i < 80)
                {
                    Console.Write("L");
                    Thread.Sleep(50);
                }
            }
            Console.WriteLine("La Liebre ha llegado a la meta");
        }
        public static void proceso3()
        {
            for (int i = 0; i < 80; i++)
            {
                if (i >= 0 && i < 40)
                {
                    Console.Write("N");
                    Thread.Sleep(20);
                }
                if (i == 40)
                {
                    Console.WriteLine("La Tortuga Ninja se ha dormido");
                }
                if (i == 60)
                {
                    Console.WriteLine("La Tortuga Ninja se ha despertado");
                }

                if (i >= 40 && i < 50)
                {
                    Console.Write("N");
                    Thread.Sleep(200);
                }

                if (i >= 50 && i < 80)
                {
                    Console.Write("N");
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine("La Tortuga Ninja ha llegado a la meta, LA TORTUGA NINJA ES LA GANADORA");
        }
    }
}
   
