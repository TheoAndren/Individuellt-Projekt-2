using System;

namespace Individuellt_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            

            User user1 = new User("albin", "1777");
            User user2 = new User("göran", "1888");
            User user3 = new User("kevin", "1555");
            User user4 = new User("sixten", "1666");
            User user5 = new User("perra", "1999");

            User[] bankUsers = { user1, user2, user3, user4, user5 };

            user1.Konton = new Bankkonto[] { new Bankkonto(1300, "sparkonto")};
            user2.Konton = new Bankkonto[] { new Bankkonto(1400, "sparkonto"), new Bankkonto(2400, " lönekonto")};
            user3.Konton = new Bankkonto[] { new Bankkonto(1500, "sparkonto"), new Bankkonto(2500, " lönekonto"), new Bankkonto(3200, " slöskonto")};
            user4.Konton = new Bankkonto[] { new Bankkonto(1600, "sparkonto"), new Bankkonto(2600, " lönekonto"), new Bankkonto(3300, " slöskonto"), new Bankkonto(4200, " akutkonto")};
            user5.Konton = new Bankkonto[] { new Bankkonto(1700, "sparkonto"), new Bankkonto(2700, " lönekonto"), new Bankkonto(3400, " slöskonto"), new Bankkonto(4300, " akutkonto"), new Bankkonto(5200, " aktiekonto") };
            
            Welcome(bankUsers);
            
            string userInput = "";

            
            while (userInput != "4")
            {

                Console.WriteLine("");

                Console.WriteLine("Välj ett av följande alternativ.");
                Console.WriteLine("1. Se dina konton och saldo");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");

                userInput = Console.ReadLine();

                
                switch (userInput)
                {
                    case "1":
                        Accounts();
                        Console.ReadLine();
                        break;

                    case "2":
                        Transfer();
                        break;

                    case "3":
                        Withdrawal();
                        break;

                    case "4":
                        Console.WriteLine("Du kommer nu loggas ut..."); 
                        break;

                    default:
                        Console.WriteLine("Du valde inte ett giltigt alternativ.");
                        break;
                }
            }
        }







        public static User Welcome(User[] bankUsers)
        {
            Console.WriteLine("Welcome to the bank of Sweden! Press enter to get to the loginpage");
            Console.ReadLine();
           
            


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                
                for (int j = 0; j <= bankUsers.GetLength(0) -1; j++)
                {
                    if (username == bankUsers[j].Username && password == bankUsers[j].Password)
                    {
                        return bankUsers[j];
                    }
                    
                    
                }
                
              
                


            }
            Environment.Exit(0);
            return null;
           

            

            
        }

        static void Accounts()
        {
            Console.WriteLine("Method för att kolla konton och saldo");
        }

        static void Transfer()
        {
            Console.WriteLine("Method för att låta användaren överföra pengar mellan konton");
        }

        static void Withdrawal()
        {
            Console.WriteLine("Metod för att ta ut pengar ur specifikt konto");
        }
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Bankkonto[] Konton { get; set; }
        public User(string name, string pin)
        {
            Username = name;
            Password = pin;
        }
    }

    class Bankkonto
    {
        public double Balance { get; set;  }
        public string Kontonamn { get; set; }

        public Bankkonto(double Balance, string Kontonamn)
        {
            this.Balance = Balance;
            this.Kontonamn = Kontonamn;

        }
    }
}
