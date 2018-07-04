using System;

namespace SafeNetATMMachine
{
    class Test
    {
        //Cant withdraw from >1810 at 1860
        //Cant withdraw from >40 at 60
        static void Main(string[] args)
        {
            string input = " ";
            char firstChar = ' ';
            ATMMachine atm = new ATMMachine();

            while (firstChar != 'Q')
            {
                Console.WriteLine("Enter R to Restock, I to Inquire, W to Withdraw, Q to Quit");
                input = Console.ReadLine();
                firstChar = Char.ToUpper(input.ToCharArray()[0]);
                input = input.Substring(1, input.Length-1).Trim();
                
                switch (firstChar) {
                    case 'R':
                        atm.Restock();
                        break;
                    case 'I':
                        String inquiryS = input;
                        inquiryS = inquiryS.Replace("$", "");
                        String[] inquiryA = inquiryS.Split(" ");
                        // Inquire for all given denominations
                        for (int i = 0; i < inquiryA.Length; i++)
                        {
                            atm.Inquiry(inquiryA[i], Int32.Parse(inquiryA[i]));
                        }
                        break;
                    case 'W':
                        //Filter out inputs with no value
                        if(input.Length < 1)
                        {
                            Console.WriteLine("Failure Invalid Command");
                            break;
                        }
                        input = input.Replace("$", "");
                        atm.Withdrawl(Int32.Parse(input));
                        break;
                    case 'Q':
                        Console.WriteLine("Program Ended");
                        break;
                    default:
                        Console.WriteLine("Failure: Invalid Command");
                        break;
                }
            }
        }
    }
}
