using System;

class PalindromeFinder
{
    static bool CheckNumberIsPalindrome(int numberToCheck)
    {
        if (numberToCheck < 0) return false;
        
        int originalNumber = numberToCheck;
        int reversedNumber = 0;
        
        while (numberToCheck > 0)
        {
            reversedNumber = reversedNumber * 10 + numberToCheck % 10;
            numberToCheck /= 10;
        }
        
        return reversedNumber == originalNumber;
    }

    static void Main()
    {
        int[] numbersToCheck = { 1, 555, 566, 121, 1221, 23 };
        
        Console.WriteLine("Palindrome numbers:");
        foreach (int currentNumber in numbersToCheck)
        {
            if (CheckNumberIsPalindrome(currentNumber))
            {
                Console.WriteLine(currentNumber);
            }
        }
    }
}
