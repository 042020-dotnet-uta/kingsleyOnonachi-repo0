using System;

namespace learningCSharp
{
    class FuncT
    {
         //converting degree celsius to Fahrenheit
         public Func<double, double>degreeToFah = (double degree) => 9/5 * degree + 32;
         //Action<
            float[] deg = {20f, 30.7f, 15.6f,20.8f};
            Predicatecd<float,float>convert  = degreeToFah;
            float[] Fahrenheits = Array.Next(deg,convert); 
            foreach (float num in Fahrenheits)
            {
           
                Console.WriteLine("lambda function: {0}", num);
            }
    }
}
