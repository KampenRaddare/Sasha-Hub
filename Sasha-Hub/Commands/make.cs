namespace Sasha_Hub.Commands
{
    internal static class Make
    {
        internal static string Joke()
        {
            System.Random r = new System.Random(); // Don't want to put a using statement for just this :/
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

            r.Next(index);

            return jokes[index];
        }
    }
}