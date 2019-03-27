﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm01
{
    // Declare a delegate type.
    delegate string StrMod(string str);

    class FirstDelegate
    {
        // Replaces spaces with hyphens.
        static string ReplaceSpaces(string s)
        {
            Console.WriteLine("Replacing spaces with hyphens.");
            return s.Replace(' ', '-');
        }
        // Remove spaces.
        static string RemoveSpaces(string s)
        {
            string temp = "";
            int i;
            Console.WriteLine("Removing spaces.");
            for (i = 0; i < s.Length; i++)
                if (s[i] != ' ') temp += s[i];
            return temp;
        }
        // Reverse a string.
        static string Reverse(string s)
        {
            string temp = "";
            int i, j;
            Console.WriteLine("Reversing string.");
            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                temp += s[i];
            return temp;
        }
        public static void Start()
        {
            // Construct a delegate.
            StrMod strOp = new StrMod(ReplaceSpaces);
            string str;

            // Call methods through the delegate.
            str = strOp("This is a test.");
            Console.WriteLine("Resulting string: " + str);
            Console.WriteLine();

            strOp = new StrMod(RemoveSpaces);
            str = strOp("This is a test.");
            Console.WriteLine("Resulting string: " + str);
            Console.WriteLine();

            strOp = new StrMod(Reverse);
            str = strOp("This is a test.");
            Console.WriteLine("Resulting string: " + str);
        }

        public static void Start2()
        {
            // Construct a delegate using method group conversion.
            StrMod strOp = ReplaceSpaces; // use method group conversion
            string str;

            // Call methods through the delegate.
            str = strOp("This is a test.");
            Console.WriteLine("Resulting string: " + str);
            Console.WriteLine();

            strOp = RemoveSpaces; // use method group conversion
            str = strOp("This is a test.");
            Console.WriteLine("Resulting string: " + str);
            Console.WriteLine();

            strOp = Reverse; // use method group conversion
            str = strOp("This is a test.");
            Console.WriteLine("Resulting string: " + str);

        }       
    }
}