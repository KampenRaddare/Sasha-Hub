//I havn't done the formatting the way you do.
//Sorry, you should be able to do control-a, control-x, then control-v and visual studio will
//auto format based on your text editing auto format settings
//unless you have format on paste off
//these commands also have spelling and grammar errors and should
//be removed anyways when you;re done
//also loll because these are all single lines comments
//instead of one multiline comment xD
//this shall forever exist if you come back and few this commit sometime in the future..
namespace Sasha_Hub {
    using System;
    using System.Linq;
    using Sasha_Hub.Commands;
    internal sealed class IntCmd { //Internal Command - Only used by Sasha
        internal IntCmd(Sasha.Token[] tokens,Sasha.Callback callback) {
            Callback = callback;
            Tokens = tokens;
        }
        internal Sasha.Token[] Tokens;
        internal Sasha.Callback Callback;
    }
    internal static class Sasha {
        private const string knowHowDo = "I can't do that. Fuck you buddy.";
        private const string somethingNotGood = "Something went wrong. Brace yourself.";
        internal delegate string Callback(sbyte[] n, string[] t);
        internal enum Token {paramater = 0, help, define, find, get, make, calculate, stocks, joke, weather}; //FOR THE LOVE OF GOD DO NOT SET THE FIRST NUMBER TO 0 LEAVE IT AT 1
        internal static readonly string[] ignoreWords = new string[] {"and","fucking","do","ayy","lmao"};
        private static readonly IntCmd[] Commands = new IntCmd[]{
            new IntCmd(new Token[]{Token.help},delegate(sbyte[] n, string[] t) {
                Help.OpenWindow();
                return null;
            }),
            new IntCmd(new Token[]{Token.help,Token.paramater},delegate(sbyte[] n, string[] t) {
                Help.OpenWindow(t[-n[1]]);
                return null;
            }),
            new IntCmd(new Token[]{Token.define,Token.paramater},delegate(sbyte[] n, string[] t) {
                return Define.Word(t[-n[1]]);
            }),
            new IntCmd(new Token[]{Token.find,Token.paramater},delegate(sbyte[] n, string[] t) {
                return Define.Word(t[-n[1]]);
            }),
            new IntCmd(new Token[]{Token.get,Token.weather},delegate(sbyte[] n, string[] t) {
                return Get.Weather();
            }),
            new IntCmd(new Token[]{Token.get,Token.stocks},delegate(sbyte[] n, string[] t) {
                return Get.Stocks();
            }),
            new IntCmd(new Token[]{Token.get,Token.stocks,Token.paramater},delegate(sbyte[] n, string[] t) {
                return Get.Stocks(t[-n[1]]);
            }),
            new IntCmd(new Token[]{Token.make,Token.joke},delegate(sbyte[] n, string[] t) {
                return Make.Joke();
            }),
            new IntCmd(new Token[]{Token.calculate,Token.paramater,Token.paramater},delegate(sbyte[] n, string[] t) {
                return Calculate.AllOperations(t[-n[1]],t[-n[2]]);
            }),
            new IntCmd(new Token[]{Token.calculate,Token.paramater,Token.paramater,Token.paramater},delegate(sbyte[] n, string[] t) {
                return Calculate.OperatorSupplied(t[-n[1]],t[-n[2]],t[-n[3]]);
            })
            /*
            Basically everytime you wanna have a new command add a new IntCmd to this array
            An int array consists of a token array and a delegate
            Tokens are the strings that make up commands
            To make a command with sasha if will process the string into tokens
            and then it will match it with one of the token arrays inside of a IntCmd
            To use the paramaters (which are always strings) in your delegates logic use t[-n[<your number here>]]
            It's a little complicated but I won't go into detail. You can figure it out.
            Inside the delegate have whatever you want. Just as long as it returns a string or null;
            Returning null implies something like a web page opening or a new window popping up
            Return "ERROR" (without the quotes) will make Sasha say the default error message (somethingNotGood)
            Returning the string will make Interpret return the message and then you can process that from the window
            Adding entirely new commands should be done under Sasha_Hub.Commands and should also be static. But that's up to you.
            It's all up to the logic in each delegate and the command classes themselves. This will save you a lot of time I hope.
            A horrible way this could have been done is multiple layer switch statements. Hint: You don't want that oh god.
            While that wouldn't be very computationally taxing, this way is as efficient, or even more efficient.
            */
        };
        internal static string Interpret(string command) {
            if(command != null) {
                command = command.ToLowerInvariant().Trim();
                foreach(string replaceWord in ignoreWords) {
                    command.Replace(replaceWord,"");
                }
                if(command != "") {
                    string[] tokens = command.Split(' ');
                    sbyte[] numericalTokens = new sbyte[tokens.Length];
                    Token[] finalTokens = new Token[tokens.Length];
                    for(byte i = 0;i<tokens.Length;i+=1) {
                        try {
                            if(!tokens[i].All(char.IsDigit)) {
                                numericalTokens[i] = (sbyte)(Token)Enum.Parse(typeof(Token), tokens[i],true);
                                finalTokens[i] = (Token)numericalTokens[i];
                            } else {
                                numericalTokens[i] = (sbyte)-i;
                                finalTokens[i] = 0;
                            }
                        } catch {
                            numericalTokens[i] = (sbyte)-i;
                            finalTokens[i] = 0;
                        }
                    }
                    foreach(IntCmd intcmd in Commands) {
                        if(Enumerable.SequenceEqual(intcmd.Tokens,finalTokens)) {
                            string returnValue = intcmd.Callback(numericalTokens,tokens);
                            switch(returnValue) {
                                case "ERROR":
                                    return somethingNotGood;
                                case null:
                                    return null;
                                default:
                                    return returnValue;
                            }
                        }
                    }
                }
            }
            return knowHowDo;
        }
    }
}