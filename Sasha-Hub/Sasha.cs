//Prototype - Not final version
namespace Sasha_Hub {
    using System;
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
        internal enum Token {help = 1, define, find, get, make, calculate, stocks, joke, weather};
        private static readonly IntCmd[] Commands = new IntCmd[]{
            new IntCmd(new Token[]{Token.help},delegate(sbyte[] n, string[] t) {
                Help.OpenWindow();
                return null;
            }),
            new IntCmd(new Token[]{Token.help,0},delegate(sbyte[] n, string[] t) {
                Help.OpenWindow(t[-n[1]]);
                return null;
            }),
            new IntCmd(new Token[]{Token.define,0},delegate(sbyte[] n, string[] t) {
                
            }),
            new IntCmd(new Token[]{Token.find,0},delegate(sbyte[] n, string[] t) {
                
            }),
            new IntCmd(new Token[]{Token.get,Token.weather},delegate(sbyte[] n, string[] t) {
                
            }),
            new IntCmd(new Token[]{Token.get,Token.stocks},delegate(sbyte[] n, string[] t) {
                
            }),
            new IntCmd(new Token[]{Token.make,Token.joke},delegate(sbyte[] n, string[] t) {
                
            }),
            new IntCmd(new Token[]{Token.calculate,0,0,0},delegate(sbyte[] n, string[] t) {
                
            })
        };
        internal static string Interpret(string command) {
            string[] tokens = command.Trim().Split(' ');
            sbyte[] numericalTokens = new sbyte[tokens.Length];
            Token[] finalTokens = new Token[tokens.Length];
            for(byte i = 0;i<tokens.Length;i+=1) {
                try {
                    numericalTokens[i] = (sbyte)(Token)Enum.Parse(typeof(Token), tokens[i],true);
                    finalTokens[i] = (Token)numericalTokens[i];
                } catch {
                    numericalTokens[i] = (sbyte)-i;
                    finalTokens[i] = 0;
                }
            }
            foreach(IntCmd variableNameIWantedWasAlreadyTakenByThisMethodsOverload in Commands) {
                if(variableNameIWantedWasAlreadyTakenByThisMethodsOverload.Tokens == finalTokens) {
                    string returnValue = variableNameIWantedWasAlreadyTakenByThisMethodsOverload.Callback(numericalTokens,tokens);
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
            return knowHowDo;
        }
    }
}