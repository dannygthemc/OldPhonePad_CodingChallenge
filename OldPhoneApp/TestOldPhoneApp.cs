// Created by: Dan Gilber
// On 07/28/2024
//Purpose: To test processing of OldPhonePad text strings

using System;
using System.Net;

namespace OldPhoneApp
{
    class TestOldPhoneApp
    {
        private OldPhoneProcessor myOPP;
        public int anyFails;
        public static void Main(string[] args)
        {
            
            TestOldPhoneApp tester = new TestOldPhoneApp();
            tester.TestAllCharacters();
            tester.TestHandleInvalidChars();
            tester.TestHandleExtraPresses();
            tester.TestEmptyString();
            tester.TestSingleChar();
            tester.TestPauses();
            tester.TestHandleStars();
            tester.TestMiddleHashtag();
            tester.TestMultiplePauses();

            if(tester.anyFails > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There were " + tester.anyFails + " FAILED tests.");
                Console.WriteLine("Looke above for details");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All Tests PASSED!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public TestOldPhoneApp()
        {
            myOPP = new OldPhoneProcessor();
            anyFails = 0;
        }

        public void TestMultiplePauses()
        {
            Console.WriteLine("Testing handling of multiple pauses in a row");
            String expectedAnswer = "cadghg";
            String testString = "222  2    34    44    4444 #";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestMiddleHashtag()
        {
            Console.WriteLine("Testing handling of the # being in the middle of the string");
            String expectedAnswer = "hello";
            String testString = "4433555 555666#04466690277733099966688#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestHandleStars()
        {
            Console.WriteLine("Testing handling of the *");
            String expectedAnswer = "turio*ng";
            String testString = "8 88777444666*664#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestPauses()
        {
            Console.WriteLine("Testing handling of pauses between same button press");
            String expectedAnswer = "abc cba aaca";
            String testString = "2 22 2220222 22 202222 2 222 2#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestSingleChar()
        {
            Console.WriteLine("Testing handling single char");
            String expectedAnswer = "a";
            String testString = "2#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestEmptyString()
        {
            Console.WriteLine("Testing handling of String that contains nothing but the #");
            String expectedAnswer = "";
            String testString = "#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestHandleExtraPresses()
        {
            Console.WriteLine("Testing handling of presses greater than max options for a given button");
            String expectedAnswer = "hello how are you";
            String testString = "4444433555 5556660446669027777777330999999966688#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestHandleInvalidChars()
        {
            Console.WriteLine("Testing Handling of invalid input");
            String expectedAnswer = "invalid string";
            String testString = "hello";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);
            myOPP.ClearFinalAnswer();
            String testString2 = null;
            String answer2 = myOPP.OldPhonePad(testString2);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer2);
            myOPP.ClearFinalAnswer();
            String testString3 = "44dd33555 555666#";
            String answer3 = myOPP.OldPhonePad(testString3);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer3);
            myOPP.ClearFinalAnswer();
            String testString4 = "44!@33555 555666#";
            String answer4 = myOPP.OldPhonePad(testString4);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer4);
            myOPP.ClearFinalAnswer();
            String testString5 = "4433555 555666d#";
            String answer5 = myOPP.OldPhonePad(testString5);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer5);

            if(answer.Equals(expectedAnswer) && answer2.Equals(expectedAnswer) 
            && answer3.Equals(expectedAnswer) && answer4.Equals(expectedAnswer)
            && answer5.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
        public void TestAllCharacters()
        {
            Console.WriteLine("Testing Output of all possible characters");
            String expectedAnswer = "& ' ( a b c d e f g h i j k l m n o p q r s t u v w x y z *";
            String testString = "1011011102022022203033033304044044405055055506066066607077077707777080880888090990999099990*#";
            String answer = myOPP.OldPhonePad(testString);
            Console.WriteLine("The returned value was: ");
            Console.WriteLine(answer);

            if(answer.Equals(expectedAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed!");
                anyFails++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------- \n");
            myOPP.ClearFinalAnswer();
        }
    }
}
