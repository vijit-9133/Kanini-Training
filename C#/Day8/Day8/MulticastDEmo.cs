//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Day8
//{
//    internal class MulticastDEmo
//    {
//        public delegate void ProcessStatusHandler(string message);

//        static void Main(string[] args)
//        {
//            ProcessStatusHandler myMulticastDelegate = null;
//            myMulticastDelegate += LogToConsole;
//            myMulticastDelegate += UpdateProgressBar;

//            Console.WriteLine("Invoking the multicast delegate...");
//            myMulticastDelegate?.Invoke("Task complete!");

//            Console.WriteLine("\nRemoving one method...");
//            myMulticastDelegate -= UpdateProgressBar;


//            myMulticastDelegate?.Invoke("Task status updated.");
//        }

//        static void LogToConsole(string message)
//        {
//            Console.WriteLine($"[Log]: {message}");
//        }

//        static void UpdateProgressBar(string message)
//        {
//            Console.WriteLine($"[UI]: Progress bar updated: {message}");
//        }
//    }
//}
