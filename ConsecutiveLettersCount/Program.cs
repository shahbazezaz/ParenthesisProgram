using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsecutiveLettersCount
{
    public class program
    {

        public static void check(String mainstring, int index, int pos, int srno)
        {
            int i;

            //if the length of the character is not same or index is invalid or opening para not present

            int strlength; 
            strlength = mainstring.Length;

            
            
            if (mainstring[index] != '(' || pos != strlength)
            {
                Console.Write("#" + srno + " 0\n");
                return;
            }

            Stack st = new Stack();

            for (i = index; i < mainstring.Length; i++)
            {

                // If current character is an opening bracket then push it in the stack. 
                if (mainstring[i] == '(')
                {
                    st.Push((int)mainstring[i]);
                } 
                else if (mainstring[i] == ')')
                {
                    st.Pop();
                    if (st.Count == 0)
                    {
                        int cur = i + 1;
                        Console.Write("#" + srno + " " + cur + "\n");
                        return;
                    }
                }
            }

            // If no matching closing bracket found or invalid string
            Console.Write("#" + srno +" 0\n");
        }

        public static bool IsAllParanthesis(string s)
        {
            foreach (char c in s)
            {
                if (c != '(' && c != ')')
                    return false;
            }
            return true;
        }

        // Main Function
        public static void Main()
        {
            int len = 0, pos = 0;
            string inputStr = "", finalStr="";

            List<parastring> par = new List<parastring>();
            Console.Write("Input (Total 10 Lines.) \n");
            for (int k = 0; k < 10; k++)
            {
                inputStr = Console.ReadLine();
                string[] mainStr; bool isallparan = true;
                if (!string.IsNullOrEmpty(inputStr))
                {
                    if(inputStr.IndexOf(" ") != -1)
                    {
                        mainStr = inputStr.Split(" ");
                        len = Convert.ToInt16(mainStr[0]);
                        pos = Convert.ToInt16(mainStr[1]);
                        finalStr = mainStr[2].ToString();
                        isallparan = IsAllParanthesis(finalStr);
                    }
                    
                }
                    

                //check if the string in between 10 and 10000 and also in pairs
                if (inputStr.Length > 10 && inputStr.Length < 10000 && finalStr.Length %2 != 1)
                {
                    if(isallparan) 
                    {
                        parastring childPar = new parastring();
                        childPar.strlen = len;
                        childPar.startpt = pos;
                        childPar.originalstr = finalStr;
                        par.Add(childPar);
                    }
                    else
                    {
                        //adding blank values for invalid input
                        par.Add(null);
                    }
                    
                }
                else
                {
                    //adding blank values for invalid input
                    par.Add(null);
                }
                

                
            }

            Console.Write("Output \n");
            int l = 0;
            foreach (var str in par)
            {
                l += 1;
                if(str == null)
                {
                    Console.Write("#" + l + " 0\n");
                }
                else
                {
                    check(str.originalstr, str.startpt - 1, str.strlen, l);
                }
               
            }

        }

        

        public class parastring
        {
            public int strlen { get; set; }
            public int startpt { get; set; }
            public string originalstr { get; set; }
        }
    }
}

