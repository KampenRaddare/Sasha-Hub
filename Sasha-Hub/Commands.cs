namespace Sasha_Hub
{
    using System;
    using System.Windows;
    using System.Diagnostics;
    using System.Xml;

    public sealed class Commands
    {
        /*this is where commands live now. Since I just pasted all the methods here MAJOR reorganizing needs to be done.. My 'job' is just to make things work efficiently lol
        All methods must have a return type of string or void
        All method overloads must be strings
        All methods must be public and not static
        METHODS MUST NOT SHARE A NAME
        *****Even if they have seperate overloads*****
        To make Sasha say that something bad happened/whatever when a generic error happens in a method return/use Sasha.InternalErrorString*/
        public string CalculateNoOperator(string number1, string number2)
        {
            // Since no operator is supplied
            // returns every possible solution
            int num1 = Convert.ToInt32(number1);
            int num2 = Convert.ToInt32(number2);
            return "Multiplied = " + (num1 * num2).ToString() + "\n" +
                "Divided = " + (num1 / num2) + "\n" +
                "Added = " + (num1 + num2) + "\n" +
                "Subtracted = " + (num1 - num2); //DO YOU EVEN FUCKING C# 6 BRUH!?
        }
        public string CalculateOperator(string number1, string numberOperator, string number2)
        {
            // Since operator is supplied
            // returns specific solution
            int num1 = Convert.ToInt32(number1);
            int num2 = Convert.ToInt32(number2);
            switch (numberOperator)
            {
                case "plus":
                    return (num1 + num2).ToString();
                case "divide":
                    return (num1 / num2).ToString();
                case "subtract":
                    return (num1 - num2).ToString();
                case "times":
                    return (num1 * num2).ToString();
                default:
                    return "Fuck you. You broke me. D;";
            }
        }
        public void Suicide()
        {
            MessageBox.Show("Sasha killed herself!", "Suicide!");
            Environment.Exit(1);
        }

        public void Sudoku()
        {
            MessageBox.Show("Sasha committed Sudoku!", "Sudoku!");
            Environment.Exit(1);
        }
        public string Define(string word)
        {
            return "I don't feel like defining a word right now you little bitch!";
        }
        public string Weather(string location)
        {
            // IP location->web service->weather service->xml->process | Me can do it later I guess
            string day = DateTime.Now.DayOfWeek.ToString();
            string temp = null;
            string high = null;
            string low = null;

            XmlDocument weather = new XmlDocument();
            weather.Load(string.Format("http://www.google.com/ig/api?weather={0}", "Chicago"));

            temp = weather.SelectSingleNode("/xml_api_reply/weather/current_conditions/temp_f").Attributes["data"].InnerText;
            high = weather.SelectSingleNode("high").Attributes["data"].InnerText;
            low = weather.SelectSingleNode("low").Attributes["data"].InnerText;

            Debug.WriteLine(temp);
            Debug.WriteLine(high);
            Debug.WriteLine(low);

            return "It is " + temp + "F in your city. With a high of " + high + " and a low of " + low;
        }

        public string Stocks()
        {
            return "The US stock market is down more than 2.3 trillion dollars this year.";
            // ^ Sounds like a joke but it's true xD Gg economy
        }

        public string StocksSpecific(string stock)
        {
            return $"{stock} looks like its doing good. Kinda looks like a mountain!";
        }
        public void Help()
        {
            // Open the help window to no specific command section
            HelpWindow HALP = new HelpWindow();
            HALP.Show();
        }

        public void OpenWindow(string command)
        {
            // Open the help window to specific command section
            MessageBox.Show("No help for you, you little bitch.");
        }
        public string Joke()
        {
            Random r = new Random();
            string[] jokes =
            {
                "A husband and wife are trying to set up a new password for their computer. The husband puts, 'Mypenis,' and the wife falls on the ground laughing because on the screen it says, 'Error. Not long enough.'",
                "The teacher asked Jimmy, 'Why is your cat at school today Jimmy?' Jimmy replied crying, 'Because I heard my daddy tell my mommy, 'I am going to eat that p*ssy once Jimmy leaves for school today!'",
                "A mother is in the kitchen making dinner for her family when her daughter walks in. “Mother, where do babies come from?” The mother thinks for a few seconds and says, “Well dear, Mommy and Daddy fall in love and get married. One night they go into their bedroom, they kiss and hug, and have sex.” The daughter looks puzzled so the mother continues, “That means the daddy puts his penis in the mommy’s vagina. That’s how you get a baby, honey.” The child seems to comprehend. “Oh, I see, but the other night when I came into your room you had daddy’s penis in your mouth. What do you get when you do that?” “Jewelry, my dear. Jewelry.”",
                "A family is at the dinner table. The son asks the father, “Dad, how many kinds of boobs are there?” The father, surprised, answers, “Well, son, a woman goes through three phases. In her 20s, a woman’s breasts are like melons, round and firm. In her 30s and 40s, they are like pears, still nice, hanging a bit. After 50, they are like onions.” “Onions?” the son asks. “Yes. You see them and they make you cry.” This infuriated his wife and daughter. The daughter asks, “Mom, how many different kinds of willies are there?” The mother smiles and says, “Well, dear, a man goes through three phases also. In his 20s, his willy is like an oak tree, mighty and hard. In his 30s and 40s, it’s like a birch, flexible but reliable. After his 50s, it’s like a Christmas tree.” “A Christmas tree?” the daughter asks. “Yes, dead from the root up and the balls are just for decoration.”",
                "A teacher is teaching a class and she sees that Johnny isn't paying attention, so she asks him, 'If there are three ducks sitting on a fence, and you shoot one, how many are left?' Johnny says, 'None.' The teacher asks, 'Why?' Johnny says, 'Because the shot scared them all off.' The teacher says, 'No, two, but I like how you're thinking.' Johnny asks the teacher, 'If you see three women walking out of an ice cream parlor, one is licking her ice cream, one is sucking her ice cream, and one is biting her ice cream, which one is married?' The teacher says, 'The one sucking her ice cream.' Johnny says, 'No, the one with the wedding ring, but I like how youre thinking!'",
                ""
            };
            int index = 0;

            index = r.Next(index, jokes.Length);

            return jokes[index];
        }
        public string OffensiveJoke()
        {
            Random r = new Random();
            string[] offensiveJokes =
            {
                "911 was an inside job.",
                "Donald Trump was an inside job.",
                "What's red, covered in boils and scratching at the window? A baby in the microwave.",
                "How do you fit 3 dead babies in a bucket? Use a blender. How do you get them out of the bucket? Tortilla chips.",
                "What's the difference between an onion and a baby? I don't cry when I chop up babies.",
                "What's harder than nailing a dead baby to a tree? My dick-while I'm doing it.",
                "Are there many successful places to pick up kids? Well, it's swings and roundabouts really."
            };
            int index = 0;

            index = r.Next(index, offensiveJokes.Length);

            return offensiveJokes[index];
        }
    }
}
