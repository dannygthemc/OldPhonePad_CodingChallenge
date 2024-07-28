// Created by: Dan Gilber
// On 07/28/2024
//Purpose: To process OldPhonePad text strings

using System;
using System.Net;

namespace OldPhoneApp
{
    class OldPhoneProcessor
    {
        //2D Array is used to quickly convert input to corresponding values
        private char[][] answerGrid = new char[10][];
        private String finalAnswer;
        
        public static void Main(string[] args)
        {
            
            bool finished = false;
            String userInput = "";
            OldPhoneProcessor myOPP = new OldPhoneProcessor();
            do
            {
                Console.WriteLine("This program processes OldPhonePad strings.");
                Console.WriteLine("All Input should end with a '#'");
                Console.WriteLine("If finished, enter 'q' to quit");
                Console.Write("Enter your string: ");
                userInput = Console.ReadLine();
                if(userInput.Equals("q") || userInput.Equals("Q"))
                {
                    finished = true;
                }
                else
                {
                    String answer = myOPP.OldPhonePad(userInput);
                    Console.WriteLine(answer);
                    myOPP.ClearFinalAnswer();
                }
            }
            while(finished == false);
            
        }

        public OldPhoneProcessor(){
            InitializeAnswerGrid();
            finalAnswer = "";
        }
        
        public String OldPhonePad(string input)
        {
            //handle null values
            if (input == null)
            {
                return "invalid string";
            }
            //if string has only one character, it should be the hashtag
            //end processing
            while(input.Length > 1)
            {
                input = SubString(input);
                //if invalid characters are detected, SubString breaks and
                //returns "invalid string"
                //if this happens, return "invalid string" and end run
                if(input.Equals("invalid string"))
                {
                    finalAnswer = input;
                    break;
                }
            }
            return finalAnswer;
        }

        //breaks off substrings from the current string
        //sends the substrings to be converted
        //returns the rest of the string back
        public String SubString(string input)
        {
            String subString = "";
            //tracks progress through string
            int curChar = 0;
            char lastChar = ' ';
            foreach (char c in input)
            {
                //checks for characters outside expected values
                if ( ( c < '0' || c > '9') && c != '*' && c != '#' && c != ' ')
                {
                    return "invalid string";
                }
                else
                {
                    //if we've reached a break, end traversal and increment by 1
                    if(c == ' ' )
                    {
                        curChar++;
                        break;
                    }
                    //if it's a non consecutive number, break
                    else if(curChar > 0 && c != lastChar)
                    {
                        break;
                    }
                    // if we see the hashtag, consider the string reading complete
                    else if(c == '#')
                    {
                        curChar = input.Length - 1;
                    }
                    else{
                        subString = subString + c;
                        lastChar = c;
                        curChar++;
                    }
                }
            }

            Convert(subString); //calls the conversion method on the current substring
            input = input.Substring(curChar);
            return input;

        }
        //takes in substring and converts them to their corresponding character
        //function appends to class-wide string and thus is void
        public void Convert(String oldPadText)
        {
            //if the string is blank just exit
            if(oldPadText.Equals(""))
            {
                return;
            }
            //if the string is just a star
            //append the star an exit
            else if(oldPadText.Equals("*"))
            {
                finalAnswer += '*';
                return;
            }
            int length = oldPadText.Length;
            //represents the number of options a given digit can represent
            int numOptions;

            char num = oldPadText[0];
            int numInt = num - '0';

            if(num == '7' || num == '9')
            {
                numOptions = 4;
            }
            else if(num == '0')
            {
                numOptions = 1;
            }
            else
            {
                numOptions = 3;
            }
            
            // Any number of presses greater than numOptions, cycles back to the first option
            // account for additional presses by subtracting by numOptions until within range of 1-numOptions
            while(length > numOptions)
            {
                length = length - numOptions;
            }
            length -= 1;
            //gets the corresponding value from the 2D array
            char conversion = answerGrid[numInt][length];
            finalAnswer += conversion;
        }
        //initializes the answer grid which facilitates quick conversion of the data
        public void InitializeAnswerGrid()
        {
            answerGrid[0] = new char[] {' '};
            answerGrid[1] = new char[] {'&','\'','('};
            answerGrid[2] = new char[] {'a','b','c'};
            answerGrid[3] = new char[] {'d','e','f'};
            answerGrid[4] = new char[] {'g','h','i'};
            answerGrid[5] = new char[] {'j','k','l'};
            answerGrid[6] = new char[] {'m','n','o'};
            answerGrid[7] = new char[] {'p','q','r','s'};
            answerGrid[8] = new char[] {'t','u','v'};
            answerGrid[9] = new char[] {'w','x','y','z'};
        }
        //used to reset the string between separate submissions
        public void ClearFinalAnswer()
        {
            finalAnswer = "";
        }

        public String GetFinalAnswer()
        {
            return finalAnswer;
        }
    }
}
