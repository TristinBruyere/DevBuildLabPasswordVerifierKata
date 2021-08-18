using System;

namespace PasswordVerifierKata
{
    
    public class PasswordVerifier
    {
        public static bool ContainsNumber(string input)
        {
            char[] nums = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            foreach (char i in nums)
            {
                if (input.Contains(i))
                {
                    return true;
                }

            }
            return false;
        }
        public static bool ContainsUpper(string input)
        {
            char[] uppercase = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            foreach (char i in uppercase)
            {
                if (input.Contains(i))
                {
                    return true;
            
                }
            }
            return false;
        }
        public static bool ContainsLower(string input)
        {
        char[] lowercase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (char i in lowercase)
            {
                if (input.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool VerifyLength(string input)
        {
            if (input.Length < 8)
            {
                return false;
            }
            return true;
        }
        public static bool VerifyNull(string input)
        {
            if (input == null)
            {
                return false;
            }
            return true;
        }
        public static int PasswordPoints(string password)
        {
            int passwordStrength = 5;
            if (!VerifyNull(password))
            {
                passwordStrength = 0;
            }
            else
            {
                if (!ContainsNumber(password))
                {
                    passwordStrength--;
                }
                if (!ContainsUpper(password))
                {
                    passwordStrength--;
                }
                if (!ContainsLower(password))
                {
                    passwordStrength--;
                }
                if (!VerifyLength(password))
                {
                    passwordStrength--;
                }
            }
            return passwordStrength;
        }
        public static bool Verify(string password)
        {
            int passwordStrength = 5;
            if (!VerifyNull(password))
            {
                passwordStrength = 0;
            }
            else if(!ContainsLower(password))
            {
                passwordStrength = 0;
            }
            else
            {
                if (!ContainsNumber(password))
                {
                    passwordStrength--;
                }
                if (!ContainsUpper(password))
                {
                    passwordStrength--;
                }
                if (!VerifyLength(password))
                {
                    passwordStrength--;
                }
                if (!VerifyNull(password))
                {
                    passwordStrength = 0;
                }
            }
            if (passwordStrength >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        public static bool KeepGoing()
        {
            while (true)
            {
                Console.Write("Would you like to continue? (Y/N): ");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("That is not valid input.");
                }
            }
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                if (PasswordVerifier.Verify(password))
                {
                    Console.WriteLine("Your password is valid.");
                }
                else
                {
                    Console.WriteLine("That password is not valid.");
                }
            } while (KeepGoing());
            //Console.WriteLine(PasswordVerifier.PasswordPoints("the1"));
            //Console.WriteLine(PasswordVerifier.PasswordPoints("theguys1"));
            //Console.WriteLine(PasswordVerifier.PasswordPoints("THEGUYS1"));
            //Console.WriteLine(PasswordVerifier.PasswordPoints(null));

        }
    }
}
