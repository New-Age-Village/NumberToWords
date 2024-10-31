using System;
using System.Collections.Generic;

class NumberToWords
{
    // Dictionary for Units
    private static readonly Dictionary<int, string> Units = new Dictionary<int, string>
    {
        { 0, "" },
        { 1, "One" },
        { 2, "Two" },
        { 3, "Three" },
        { 4, "Four" },
        { 5, "Five" },
        { 6, "Six" },
        { 7, "Seven" },
        { 8, "Eight" },
        { 9, "Nine" }
    };

    //Dictionary for Teens
    private static readonly Dictionary<int, string> Teens = new Dictionary<int, string>
    {
        { 10, "Ten" },
        { 11, "Eleven" },
        { 12, "Twelve" },
        { 13, "Thirteen" },
        { 14, "Fourteen" },
        { 15, "Fifteen" },
        { 16, "Sixteen" },
        { 17, "Seventeen" },
        { 18, "Eighteen" },
        { 19, "Nineteen" }
    };

    //Dictionary for Tens
    private static readonly Dictionary<int, string> Tens = new Dictionary<int, string>
    {
        { 2, "Twenty" },
        { 3, "Thirty" },
        { 4, "Forty" },
        { 5, "Fifty" },
        { 6, "Sixty" },
        { 7, "Seventy" },
        { 8, "Eighty" },
        { 9, "Ninety" }
    };

    public static string ConvertToWords(int number)
    {
        // Check if the number is in the thousands range (4-Digits)
        if (number == 0)
            return "Zero";
        if (number > 9999)
            return "Input exceeds four digits.";

        string numStr = number.ToString();
        int length = numStr.Length;
        string words = "";

        if (length == 4)
        {
            int thousands = int.Parse(numStr[0].ToString());
            words += Units[thousands] + " Thousand ";
            numStr = numStr.Substring(1); // Remove the thousands digit
            length--;
        }

        if (length == 3)
        {
            int hundreds = int.Parse(numStr[0].ToString());
            if (hundreds > 0)
                words += Units[hundreds] + " Hundred ";
            numStr = numStr.Substring(1); // Remove the hundreds digit
            length--;
        }

        if (length == 2)
        {
            int tens = int.Parse(numStr);
            if (tens >= 10 && tens < 20)
            {
                words += Teens[tens] + "";
                numStr = ""; // Clear numStr since we processed the last two digits as teens
            }
            else
            {
                int tensPlace = int.Parse(numStr[0].ToString());
                if (tensPlace > 1)
                    words += Tens[tensPlace] + "";
                numStr = numStr.Substring(1); // Remove the tens digit
                length--;

                if (tens%10 > 0 )
                {
                    words += "-";
                }
            }
        }

        if (length == 1 && numStr != "")
        {
            int units = int.Parse(numStr[0].ToString());
            words += Units[units] + " ";
        }

        return words.Trim();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number (up to four digits):");

        if (int.TryParse(Console.ReadLine(), out int number) && number <= 9999 && number >= 0)
        {
            string result = ConvertToWords(number);
            Console.WriteLine("In words: " + result);
        }
        else
        {
            Console.WriteLine("Please enter a valid number up to four digits.");
        }
    }
}
