namespace Sasha_Hub {
    using System;
    using System.Linq;
    using Sasha_Hub.Commands;
    internal sealed class IntCmd {
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
        private const string errorString = "ERROR";
        internal delegate string Callback(sbyte[] n, string[] t);
        internal enum Token {paramater = 0, help, define, find, get, make, calculate, stocks, joke, weather};
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
        };
        internal static string Interpret(string command) {
            if(command != null) {
                command = command.Trim();
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
                                case errorString:
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