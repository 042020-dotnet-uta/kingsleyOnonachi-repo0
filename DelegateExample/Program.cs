using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));//get a random 0-9 number
            c.ThresholdReached += c_ThresholdReached;
            c.ThresholdReached += c_ExampleSubscriber;

            Console.WriteLine("press 'a' key to increase total"); // get user unput
            while (Console.ReadKey(true).KeyChar == 'a')    //as user presses'a', 1 is added
            {
                Console.WriteLine("adding one");//advise user that one was added
                c.Add(1);//add 1 to the clas C ADD method
            }
        }

        //this method is assigned to teh C class ThresholdReached EventHandler
        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            //tell what the threshhold was and at what time it was reached
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            //Environment.Exit(0);
        }


        static void c_ExampleSubscriber(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("Here in the second subscribed event.");
        }
    }

    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;//assign the random number to threshhold.. it's starting value
        }

        //adds input int to the total
        public void Add(int x)
        {
            total += x;
            if (total >= threshold)//check is total is at threshhold
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();//create a class instance
                args.Threshold = threshold;     //assign the number to the instance variable
                args.TimeReached = DateTime.Now;//give a time for reaching hte threshhold
                OnThresholdReached(args);       //send the instance to the event handler method
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;//assign delegate to instanc of the delegate.
            if (handler != null)
            {
                handler(this, e);//fire the event.
            }
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;//event handler delegate
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}