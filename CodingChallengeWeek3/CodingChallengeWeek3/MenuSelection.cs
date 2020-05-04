using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallengeWeek3
{
    class MenuSelection
    {
        /// <summary>
        ///  This method called IsEven() to tell if a user provided number is even.
        ///  and also validate if the users input is even. 
        ///  Print “That number is even.” to the console if the input is an even number. 
        ///  If not an even number, print to the console a message with the input and why it’s not an even number
        /// </summary>
        /// <param name="num"></param>
        public void IsEven()
        {
            Console.WriteLine("Is the Number Even?");
            Console.WriteLine("Please enter a number:");
            string number = Console.ReadLine();

            bool canConvert = int.TryParse(number, out int number1);

            if (canConvert == true)//if the number is a number or string
            {
                //checking if the number is even nuber by using module operator
                if (number1 % 2 == 0)
                {
                    Console.WriteLine("That number is even");
                    MenuSelect();
                }
                else
                {
                    Console.WriteLine($"{number} is not an even number.");
                    MenuSelect();
                }
            }
            else
                Console.WriteLine($"{number} is a string, not a number");
            //going back to the menu
            MenuSelect();

        }
        public void MenuSelect()
        {
            //the method menuselect helps the user to make a choice between various options
            char choice;

            Console.WriteLine("Menu selection: 'E' for Exit, 'M' for Multitable, 'I' for IsEven and 'S' for shuffle");
            Console.WriteLine("Menu: 'E', 'M', 'I' and 'S'");
            string str = "";
            str = Console.ReadLine();
            //check if the user input the right variable 
            while (str.Length > 1)
            {
                Console.WriteLine("Your option is not valid, please make a valid choice");
                Console.WriteLine("Menu selection: 'E' for Exit, 'M' for Multitable, 'I' for IsEven and 'S' for shuffle");
                Console.WriteLine("Menu: 'E', 'M', 'I' and 'S'");
                str = Console.ReadLine();
            }

            //this allows the usee to enter input in lower case
            string ch = str.ToUpper();
            choice = ch[0];
            switch (choice)
            {
                case 'I':
                    IsEven();
                    break;
                case 'E':
                    //this ends the program
                    Console.WriteLine("You have Quit the game");
                    Gameexit();
                    break;
                case 'M':
                    MultiTable();
                    break;

                case 'S':
                    Mshuffle();
                    break;
                default:
                    MenuSelect();
                    break;


            }

        }

        public void MultiTable()
        { 

            Console.WriteLine("Multiplication Table");
            for (int i = 1; i < 13; i++)
            {
                for (int k = 1;
                    k < 13; k++)
                {
                    Console.WriteLine($"{i} X {k} = {i * k}");
                }
            }
            MenuSelect();

        }

        public int Gameexit()
        {
            return 0;
        }

        //This method shuffle two list with 5 element and combine them together
        public void Mshuffle()
        {

            Console.WriteLine("Please enter 2 lists of 5 elements each .e.g [1,”Jonie”,”Chachi”, 4,3,] ");
            //get the first list for the user
            Console.WriteLine("Please enter the first list");
            string firststring = Console.ReadLine();

            //get the second list for the user and storing it
            Console.WriteLine("Please enter the second list");
            _ = Console.ReadLine();

            List<string> shuffleword = new List<string>();
           
            //
            string[] split = firststring.Split(new Char[] { ' ', ',', '.', ':', '\t', '[', ']' });
            List<string> firstlist = new List<string>();
            foreach (string s in split)
            {

                if (s.Trim() != "")
                {
                    //removing empty string and adding to the firstlist variable
                    firstlist.Add(s);
                }
            }
            List<string> secondlist = new List<string>();
            foreach (string s in split)
            {

                if (s.Trim() != "")
                {
                    //removing empty string and adding to the secondlist variable
                    secondlist.Add(s);
                }
            }
            //https://stackoverflow.com/questions/18395943/using-foreach-to-iterate-simultaneously-through-multiple-lists-syntax-sugar
            //using the Enumerator list function
            using (var firstword = firstlist.GetEnumerator())
            using (var secondword = secondlist.GetEnumerator())
            {
                while (firstword.MoveNext() && secondword.MoveNext())
                {

                    //adding both element of the first string and second string
                    var item1 = firstword.Current;
                    shuffleword.Add(item1);
                    var item2 = secondword.Current;
                    shuffleword.Add(item2);

                }
                string combindedString = string.Join(",", shuffleword);
                 Console.WriteLine($"{firstlist} + {secondlist} = {combindedString}");
                
            }
            MenuSelect();
        }

    }
}
