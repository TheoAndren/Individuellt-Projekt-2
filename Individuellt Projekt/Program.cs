using System;

namespace Individuellt_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            
            // Deklarerar nya användare med namn och pin kod genom User classen.
            User user1 = new User("albin", "1777");
            User user2 = new User("göran", "1888");
            User user3 = new User("kevin", "1555");
            User user4 = new User("sixten", "1666");
            User user5 = new User("perra", "1999");

            //Stoppar in dem olika användarna i en array
            User[] bankUsers = { user1, user2, user3, user4, user5 };

            //Använder bankkonto classen för att ge värden till dem olika användarna. 
            user1.Konton = new Bankkonto[] { new Bankkonto(1300, "sparkonto")};
            user2.Konton = new Bankkonto[] { new Bankkonto(1400, "sparkonto"), new Bankkonto(2400, " lönekonto")};
            user3.Konton = new Bankkonto[] { new Bankkonto(1500, "sparkonto"), new Bankkonto(2500, " lönekonto"), new Bankkonto(3200, " slöskonto")};
            user4.Konton = new Bankkonto[] { new Bankkonto(1600, "sparkonto"), new Bankkonto(2600, " lönekonto"), new Bankkonto(3300, " slöskonto"), new Bankkonto(4200, " akutkonto")};
            user5.Konton = new Bankkonto[] { new Bankkonto(1700, "sparkonto"), new Bankkonto(2700, " lönekonto"), new Bankkonto(3400, " slöskonto"), new Bankkonto(4300, " akutkonto"), new Bankkonto(5200, " aktiekonto") };
            
            User user = Welcome(bankUsers);
            
            string userInput = "";

            // While loop för att köra om menyn sålänge inte användaren väljer att logga ut. 
            while (userInput != "4")
            {

                Console.WriteLine("");

                Console.WriteLine("Välj ett av följande alternativ.");
                Console.WriteLine("1. Se dina konton och saldo");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");

                userInput = Console.ReadLine();

                //Switch sats för dem olika menyvalen med metoderna instoppade i varje case. 
                switch (userInput)
                {
                    case "1":
                        Accounts(user);
                        break;

                    case "2":
                        Transfer(user);
                        break;

                    case "3":
                        Withdrawal(user);
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






        // Welcome metod med som kollar så att inlogg stämmer och också bestämmer vilken användare det är som loggar in med hjälp av loop. 
        // Metoden har också ett antal max försök innan applikationen stängs ner. J == numret på usern som loggar in. 
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

        //Denna metod använder infon vi fick från Welcome metod att ta reda på vilken user det är och skriver sedan ut userns kontonamn och saldo.
        static void Accounts(User userx)
        {

            foreach (var bankkonto in userx.Konton)
            {
                Console.WriteLine(bankkonto.Kontonamn +" "+ bankkonto.Balance);
            }
            Console.WriteLine("");
            Console.WriteLine("Tryck enter för att komma tillbaka till menyn");
            Console.ReadLine();
        }
        
        // Denna metoden radar upp alla konton den specifika användaren har och ger varje kontonamn ett nummer.
        // Den tar sedan in info från användaren för att bestämma vilka konton som den tar pengar ifrån och vilket som det lägger till. 
        static void Transfer(User usery)
        {
            
            for (int i = 0; i < usery.Konton.Length; i++)
            {
                Bankkonto bankkonto =(Bankkonto) usery.Konton.GetValue(i);
                
                Console.WriteLine(i + bankkonto.Kontonamn + " " + bankkonto.Balance);

            }
            Console.WriteLine("");
            Console.WriteLine("Välj ett konto att överföra pengar ifrån");
            int userResponse = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Välj ett konto att överföra pengar till");
            int userResponse2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Välj antal kronor du ska överföra");
            double antalKronor = Convert.ToDouble(Console.ReadLine());

            Bankkonto bankkontoFrån = (Bankkonto) usery.Konton.GetValue(userResponse);
            Bankkonto bankkontoTill = (Bankkonto) usery.Konton.GetValue(userResponse2);

            bankkontoFrån.Balance = bankkontoFrån.Balance - antalKronor;
            bankkontoTill.Balance = bankkontoTill.Balance + antalKronor;
            Console.WriteLine(bankkontoFrån.Kontonamn + bankkontoFrån.Balance);
            Console.WriteLine(bankkontoTill.Kontonamn + bankkontoTill.Balance);
            Console.WriteLine("");
            Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
            Console.ReadLine();




        }
        // Ännu en gång så radar vi först upp dem olika kontona med en siffra intill. Sen väljer användaren ett konto utifrån siffra som hen ska - 
        // ta ut pengar ifrån. 
        static void Withdrawal(User userx)
        {

            for (int i = 0; i < userx.Konton.Length; i++)
            {
                Bankkonto bankkonto = (Bankkonto)userx.Konton.GetValue(i);

                Console.WriteLine(i + bankkonto.Kontonamn + " " + bankkonto.Balance);
            }

            Console.WriteLine("");
            Console.WriteLine("Välj ett konto att ta ut pengar ifrån");
            int userResponse3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Välj antal kronor att ta ut");
            double kronorUttag = Convert.ToInt32(Console.ReadLine());

            Bankkonto bankkontoFrån = (Bankkonto)userx.Konton.GetValue(userResponse3);

            bankkontoFrån.Balance = bankkontoFrån.Balance - kronorUttag;
            Console.WriteLine("");
            Console.WriteLine(bankkontoFrån.Kontonamn + bankkontoFrån.Balance);
            Console.WriteLine("");
            Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
            Console.ReadLine();

        }
    } //Skapar en class kallad User så jag har en mall för vad alla användare ska ha för info.
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
    // Skapar en class kallad Bankkonto för att ha en mall med saldo och kontonamn på. 
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
