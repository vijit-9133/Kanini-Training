namespace Day8
{
    class Program
    {
        
            static int Add(int a, int b)
            {
                return a + b;
            }
            static void PrintMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
        static void Main(string[] args)
        {
                Func<int, int, int> addFunc = Add;

                Func<int, int, int> multiplyFunc = (x, y) => x * y;

                int sum = addFunc(5, 10);
                int product = multiplyFunc(5, 10);

                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"Product: {product}");
                //Action<string> printAction = PrintMessage;

                //Action<string> lambdaAction = (msg) => Console.WriteLine($"Lambda Message: {msg}");

                //printAction("Hello from Action!");
                //lambdaAction("Hello from Lambda!");
            }
        }
        //var downloader = new FileDownloader();
        //downloader.ProgressChanged += progress => Console.WriteLine($"Downloaded: {progress}%");
        //downloader.Download();
        //        Button myButton = new Button();
        //        myButton.OnClick += PlaySound;
        //        myButton.OnClick += ShowMessage;

        //        myButton.Click();
        //    }

        //    static void PlaySound()
        //    {
        //        Console.WriteLine("  --> Playing a click sound.");
        //    }

        //    static void ShowMessage()
        //    {
        //        Console.WriteLine("  --> Showing a 'Button Clicked!' message.");
        //    }
    }
    

