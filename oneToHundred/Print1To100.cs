using System;

namespace oneToHundred
{
    class Print1To100
    {
        //         /*Print all the numbers starting from 1 to 100.  
        // When the number is multiple of three, print “sweet” instead of a number on the console.  
        // If the number if a multiple of five then print “salty” on the console.  
        // For numbers which are multiples of three and five, print “sweet’nSalty” on the console.  
        // At the end, tell how many sweet’s, how many salty’s, and how many sweet’nSalty’s 
        // Comment enough to tell me what each line is doing, and site your sources.*/
        public void printOneToHundred()
        {   
            int multiThree = 0;
            int multiFive = 0;
            int sweetAndSalty = 0;
            
            for(int i=1; i<101; i++){
                ///check if the number is a multiple of three
                if((i % 3) == 0){
                    Console.WriteLine("sweet ");
                    multiThree++;
                }
                if((i % 5) == 0)
                {
                    Console.WriteLine("salty");
                    multiFive++;
                }
                if ((i % 3) == 0 && (i % 5 )== 0 )//checking if the number is both multiple of three and five
                {
                    Console.WriteLine("sweet'nSalty");
                    sweetAndSalty++;
                }
            }
            ///printing how many sweet’s, how many salty’s, and how many sweet’nSalty’s 
            Console.WriteLine($"The total number of multiple of three in hundred are: {multiThree}");
            Console.WriteLine($"The total number of multiple of five in hundred are: {multiFive}");
            Console.WriteLine($"The total number of multiple of three and five in hundred are: {sweetAndSalty}");
        }
    }
}