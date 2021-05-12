// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneBlackjackCards
{
    public class InputOutput
    {
        public InputOutput() { } // constructor 

        public String obtainInputFromTheUser(String theMessage)
        {
            Console.Write(theMessage + " \n");

            return Console.ReadLine();
        }

        public void dislpayOutputToTheUser(String theMessage)
        {
            Console.WriteLine(theMessage);
        }
    }
}