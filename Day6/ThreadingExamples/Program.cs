using System.Reflection.Metadata.Ecma335;

namespace ThreadingExamples
{
    internal class Program
    {
        static void Main1()
        {
            //asynchronus and main thread is waiting for other threads to get executed.
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            t1.Start();
            t2.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }

        static void Main7()
        {
            //asynchronous but non waiting
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            t1.IsBackground = true;
            t2.IsBackground = true;

            //t1 and t2 become backgroundthread so after completion of main, it will not wait for other threads to complete;

            t1.Start();
            t2.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }
        static void Main44()
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Start();
            t2.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
            t1.Join();  //waiting call
            Console.WriteLine("code that should run ONLY after first thread is over");
        }

        static void Main558()
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t2.IsBackground=true;
            t1.Start();
            t2.Start();
            Console.WriteLine("t1" + t1.ManagedThreadId);
            Console.WriteLine("t2" + t2.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
            t1.Join();  //waiting call
            Console.WriteLine("code that should run ONLY after first thread is over");
        }
        static void Main856()
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            //if(t1.ThreadState == ThreadState.)

            t1.Start();
           
            t2.Start();


            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Main : " + i);
                //Thread.Sleep(1000);

               // if(i == 10) t2.Abort();
            }
            //t1.Suspend();
            //t1.Resume();
            //t1.Join();  //waiting call
            //Console.WriteLine("code that should run ONLY after first thread is over");
        }
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First : " + i);
               // Thread.Sleep(1000);
            }

        }

        static void Main5()
        {
            AutoResetEvent wh = new AutoResetEvent(false);
            Thread t1 = new Thread(delegate ()
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("f1:" + i);
                    if (i % 50 == 0)
                    {
                        //instead of Suspend, use this
                        Console.WriteLine("waiting");
                        wh.WaitOne();
                    }
                }
            });
            t1.Start();

            Thread.Sleep(5000);
            Console.WriteLine("resuming 1....");
            wh.Set();

            Thread.Sleep(5000);
            Console.WriteLine("resuming 2....");
            wh.Set();

            Thread.Sleep(5000);
            Console.WriteLine("resuming 3....");
            wh.Set();

            Thread.Sleep(5000);
            Console.WriteLine("resuming 4....");
            wh.Set();
        }
        static void Func2()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Second : " + i);
                //Thread.Sleep(1000);

            }

        }
    }
}

namespace ThreadingExamples2
{
    internal class Program
    {
        static void Main6854()
        {
            object[] obj = new object[3];
            obj[0] = 13;
            obj[1] = "Akash";
            obj[2] = true;
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            //Thread t2 = new Thread(new ParameterizedThreadStart(Func2));
            //Thread t2 = new Thread(delegate ()
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("Second : " + i +x+" "+name+" "+flag);

            //    }

            //});

            SampleObj s1 = new SampleObj();
            //t1.Start(s1);
            //t1.Start(10);
            //t1.Start(true);

           // t2.Start(obj);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }

        public class SampleObj
        {
            public int x=13;
            public String name = "Akash";
            public bool flag = true;

            public override string ToString()
            {
                return name+" "+x+" "+flag;
            }
        }

        // TO DO - Pass multiple values to the function
        static void Func1(object o)
        {
            //Class1 obj = (Class1)o;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First : " + i + o.ToString());
            }

        }

      
        static void Func2(object[] o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second : " + i + " , " + o[0]+" " + o[1]+" " + o[2]);
            }

        }
    }
}

//ThreadPool
namespace ThreadingExamples3
{
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }
        static void Main32()
        {

            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), "aaa");
            //ThreadPool.QueueUserWorkItem(PoolFunc1, "aaa");
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc2));
            //ThreadPool.QueueUserWorkItem(PoolFunc2);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            int workerthreads, iothreads;

            ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);
            //ThreadPool.SetMinThreads
            //ThreadPool.SetMaxThreads
            //ThreadPool.GetMinThreads
            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

            Console.ReadLine();
        }
    }
}

//synchronization
namespace ThreadingExamples4
{
    class MainClass
    {
        static object lockObject = new object();
        static int i = 0;
        static void Main()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }
        static void FuncLock()
        {
            lock (lockObject) //Monitor.Enter(lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                //--------------------------
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;


                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
        }

        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
            Monitor.Exit(lockObject);

        }

        static void FuncInterlocked()
        {

            Interlocked.Add(ref i, 10);   //i+=10
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Increment(ref i); //++i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Decrement(ref i); //--i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Exchange(ref i, 100); //i = 100;
            Console.WriteLine("Third Interlocked " + i.ToString());
        }

    }
}