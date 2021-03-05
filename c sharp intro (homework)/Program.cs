using System;

namespace Intro_class
{
    public class CreditCard
    {
        public CreditCard(int pinCode)
        {
            setPin(pinCode);
        }
        int pinCode = 4444;
        public int GetPin()
        {
            return pinCode;
        }
        void setPin(int pin) {
            if (pin.ToString().Length != 4)
            {
                Console.WriteLine("Pin is incorrect");
                return;
            }
            this.pinCode = pin;
        }
    }
    class ATM
    {
        CreditCard creditCard = new CreditCard(4444);
        int id = 0;
        int idCount = 0;

        decimal money = 0;
        public ATM(int money)
        {
            this.money = money;
            this.idCount++;
            this.id = idCount;
        }
        public bool CheckPin(string enteredPIN)
        {
            if (enteredPIN == creditCard.GetPin().ToString())
                return true;
            return false;
        }
        public override string ToString()
        {
            return $"Money on account : ${money}";
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Money on account : ${money}");
        }
        public void AddMoney(decimal addedMoney)
        {
            this.money += addedMoney;
            Console.WriteLine($"Account successfully filled with ${addedMoney}\n" +
                $"Money on account : ${money}\n");
        }
        public void WithDraw(decimal takenMoney)
        {
            if (this.money >= takenMoney)
            {
                this.money -= takenMoney;
                Console.WriteLine($"Take cash ${takenMoney} from the ATM in lower slot \n");
            }
            else
                Console.WriteLine($"Not enough money on account\n");
        }
    }
    class Program
    {
        static void EnterAccount(ATM account)
        {
            string enterPIN = string.Empty;
            do
            {
                if (enterPIN != string.Empty)
                    Console.WriteLine("Wrong PIN!");
                Console.WriteLine("  Enter Credit Card PIN:\n");
                enterPIN = Console.ReadLine();
            } while (!account.CheckPin(enterPIN.ToString()));
            Console.WriteLine("Entering account...");
        }
        static void Main(string[] args)
        {
            ATM account = new ATM(1000);
            decimal insertedMoney = 0;
            decimal withdrawedMoney = 0;
            try
            {
                EnterAccount(account);
                char operation = ' ';
                do
                {
                    Console.WriteLine("  Chose operation:\n");
                    Console.WriteLine("[b]. Show account balance.\n");
                    Console.WriteLine("[+]. Add cash to the account.\n");
                    Console.WriteLine("[-]. Withdraw money.\n");
                    Console.WriteLine("[q]. Quit\n");
                    operation = char.Parse(Console.ReadLine());
                    switch (operation)
                    {
                        case 'b':
                        case 'B':
                            account.ShowBalance();
                            break;
                        case '+':
                            Console.WriteLine("Incert cash to money acceptor :");
                            insertedMoney = Convert.ToDecimal(Console.ReadLine());
                            account.AddMoney(insertedMoney);
                            break;
                        case '-':
                            EnterAccount(account);
                            Console.WriteLine("What money amount you want to withdraw? ");
                            withdrawedMoney = Convert.ToDecimal(Console.ReadLine());
                            account.WithDraw(withdrawedMoney);
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                } while (char.ToLower(operation) != 'q');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
    }
}