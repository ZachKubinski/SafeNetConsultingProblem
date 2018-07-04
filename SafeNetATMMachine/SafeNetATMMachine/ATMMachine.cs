using System;
using System.Collections.Generic;
using System.Text;

namespace SafeNetATMMachine
{
    class ATMMachine
    {
        private const int RESTOCK = 10;
        private int[] machine = new int[6];
        private int[] machineBackup = new int[6];
        //private int one;     0
        //private int five;    1
        //private int ten;     2
        //private int twenty;  3
        //private int fifty;   4
        //private int hundred; 5

        public ATMMachine()
        {
            machine[0] = RESTOCK;
            machine[1] = RESTOCK;
            machine[2] = RESTOCK;
            machine[3] = RESTOCK;
            machine[4] = RESTOCK;
            machine[5] = RESTOCK;
        }

        public void Restock()
        {
            machine[0] = RESTOCK;
            machine[1] = RESTOCK;
            machine[2] = RESTOCK;
            machine[3] = RESTOCK;
            machine[4] = RESTOCK;
            machine[5] = RESTOCK;
            Inquiry();
        }

        public void Withdrawl(int value)
        {
            if (value > NumericBalance())
            {
                Console.WriteLine("Failure: Insufficient Funds");
            }
            else if (value < 0)
            {
                Console.WriteLine("Cannot Withdraw: -$" + Math.Abs(value));
            }
            else
            {
                int origValue = value;
                machineBackup[0] = machine[0];
                machineBackup[1] = machine[1];
                machineBackup[2] = machine[2];
                machineBackup[3] = machine[3];
                machineBackup[4] = machine[4];
                machineBackup[5] = machine[5];
                bool withdrawl = WithdrawlHelp(value);

                if (withdrawl)
                {
                    Console.WriteLine("Success: Dispensed $" + origValue);
                    Inquiry();
                }
                else
                {
                    Console.WriteLine("Failure: Insufficient Funds");
                    Restore(machineBackup);
                }
            }

        }


        private bool WithdrawlHelp(int value)
        {
            //Recursive Case:
            //Finds largest denomination that can be removed at each step
            if (value > 0)
            {
                // Checks if value is greater than the denomination and 
                // there is greater than 0 bills of that denomination
                if (value >= 100 && machine[5] > 0)
                {
                    value -= 100;
                    machine[5] = machine[5] - 1;
                }
                else if (value >= 50 && machine[4] > 0)
                {
                    value -= 50;
                    machine[4] = machine[4] - 1;
                }
                else if (value >= 20 && machine[3] > 0)
                {
                    value -= 20;
                    machine[3] = machine[3] - 1;
                }
                else if (value >= 10 && machine[2] > 0)
                {
                    value -= 10;
                    machine[2] = machine[2] - 1;
                }
                else if (value >= 5 && machine[1] > 0)
                {
                    value -= 5;
                    machine[1] = machine[1] - 1;
                }
                else if (value >= 1 && machine[0] > 0)
                {
                    value -= 1;
                    machine[0] = machine[0] - 1;
                }
                // Not enough bills to remove value
                else
                    return false;
                // Recursive Case:
                return WithdrawlHelp(value);
            }
            // Base Case: 
            if (value == 0 && machine[5] >= 0 && machine[4] >= 0 && machine[3] >= 0 &&
                        machine[2] >= 0 && machine[1] >= 0 && machine[0] >= 0)
            {
                //Value is 0 and no negative bill amounts
                return true;
            }
            else
            {
                //Not enought bills to withdraw value or negative bill amounts
                return false;
            }
        }

        public void Inquiry(String denomination, int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("$" + denomination + " - " + machine[0] + "");
                    break;
                case 5:
                    Console.WriteLine("$" + denomination + " - " + machine[1] + "");
                    break;
                case 10:
                    Console.WriteLine("$" + denomination + " - " + machine[2] + "");
                    break;
                case 20:
                    Console.WriteLine("$" + denomination + " - " + machine[3] + "");
                    break;
                case 50:
                    Console.WriteLine("$" + denomination + " - " + machine[4] + "");
                    break;
                case 100:
                    Console.WriteLine("$" + denomination + " - " + machine[5] + "");
                    break;
            }

        }

        private void Restore(int[] originalValues)
        {
            machine[0] = originalValues[0];
            machine[1] = originalValues[1];
            machine[2] = originalValues[2];
            machine[3] = originalValues[3];
            machine[4] = originalValues[4];
            machine[5] = originalValues[5];
        }

        private int NumericBalance()
        {
            int balance = 0;
            balance += (machine[0]);
            balance += (machine[1] * 5);
            balance += (machine[2] * 10);
            balance += (machine[3] * 20);
            balance += (machine[4] * 50);
            balance += (machine[5] * 100);
            return balance;
        }
        
        private void Inquiry()
        {
            Console.WriteLine("Machine balance: ");
            Console.WriteLine("$100 - " + machine[5] + "");
            Console.WriteLine("$50 - " + machine[4] + "");
            Console.WriteLine("$20 - " + machine[3] + "");
            Console.WriteLine("$10 - " + machine[2] + "");
            Console.WriteLine("$5 - " + machine[1] + "");
            Console.WriteLine("$1 - " + machine[0] + "");
        }

    }
}
