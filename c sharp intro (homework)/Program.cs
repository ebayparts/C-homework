using System;

namespace Intro_class
{
    public class CreditCard
    {
        public CreditCard(int pinCode, decimal money = 0)
        {
            setPin(pinCode);
            setMoney(money);
        }
        int pinCode = 4444;
        public int GetPin()
        {
            return pinCode;
        }
        void setPin(int pin)
        {
            if (pin.ToString().Length != 4)
            {
                Console.WriteLine("Pin is incorrect");
                return;
            }
            this.pinCode = pin;
        }
        decimal money = 0;
        public decimal getMoney()
        {
            return this.money;
        }
        void setMoney(decimal money)
        {
            this.money = money;
        }
        public void AddMoney(decimal addedMoney)
        {
            this.money += addedMoney;
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
    class ATM
    {
        decimal money = 0;
        CreditCard creditCard = new CreditCard(4444, 0);
        int id = 0;
        int idCount = 0;

        public ATM()
        {
            this.money = creditCard.getMoney();
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
            Console.WriteLine($"Money on account : ${money}\nCredit card money: {creditCard.getMoney()}");
        }
        public void AddMoney(decimal addedMoney)
        {
            creditCard.AddMoney(addedMoney);
            this.money = creditCard.getMoney();
            Console.WriteLine($"Account successfully filled with ${addedMoney}\n " +
                $"Money on account : ${money}\n");
        }
        public void WithDraw(decimal takenMoney)
        {
            _ = money >= takenMoney ? money -= takenMoney : money;
            creditCard.WithDraw(takenMoney);
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
            ATM account = new ATM();
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