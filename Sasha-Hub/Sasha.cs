namespace Sasha_Hub { //Sorry about the formatting my visual studio did this, plus it's a lot easier for me to work in familiar formatting.
    using System;
    using Sasha_Hub;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    internal static class Sasha {
        private const string saidNothing = "Scared to say something meaningfull?";
        private const string somethingNotGood = "Something went wrong. Brace yourself.";
        private const string nullError = "String passed to Sasha.Command() can't be null!";
        private const string errorString = "error";
        private enum Mood {
            Happy,
            Sad,
            Tipsy,
            Flirty,
            Sick,
            Silly,
            Smug,
            Sleepy,
            Loving,
            Confused,
            Excited
        };
        private static Mood currentMood = Mood.Excited;
        private static readonly commandData CommandData = (commandData)new XmlSerializer(typeof(commandData)).Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("Sasha_Hub.commandData.xml")); //Best line of code 2016
        internal static string Interpret(string message) {
            if(message != null) {
                message = message.Trim();
                if(message != "") {
                    string commandReturn = ProcessCommand(message);
                    if(commandReturn != "") {
                        return commandReturn;
                    }
                } else {
                    return saidNothing;
                }
            } else {
                throw new Exception(nullError);
            }
            return ProcessChat(message);
        }
        private static string ProcessChat(string message) {
            /* SPAAAAAAAAAAAAAAAACEEEEEEEEEE MAGGGGGGGGGICCCCCCCCCCCCCC
            If you want me to do the steps I sent you in the really long text message let me know but I'll leave it up to you.
            I want to set this entire part of the system up in xml (if you can wait a day)
            That way there's no internal enums or switch statements. I think you can see the other benefits of this. I mean just
            Look what it did for the command system. Made me slightly more broken inside and inside so you can make commands even
            faster xD*/
            switch(currentMood) {
                case Mood.Confused:
                    break;
                case Mood.Excited:
                    break;
            }
            return "me no smart yet";
        }
        private static string ProcessCommand(string message) {
            string[] submessages = message.Split(' ');
            string submessageTokens = "";
            List<byte> paramaterIndexes = new List<byte>();
            for(byte i = 0;i < submessages.Length;i += 1) {
                string currentString = Regex.Replace(submessages[i].ToLowerInvariant(),"\\p{P}+","");
                for(byte e = 0; e < CommandData.Tokens.Length;e+=1) {
                    if(currentString == CommandData.Tokens[e].Value.ToLowerInvariant()) {
                        submessageTokens += $"{e+1} ";
                        break;
                    }
                }
                if(submessages[i] == null) {
                    submessageTokens += "0 ";
                    paramaterIndexes.Add(i);
                }
            }
            submessageTokens = submessageTokens.Trim(); //I spent 15 minutes before I forgot to have "submessageTokens = "................ Dammit JavaScript.
            for(byte i = 0;i < CommandData.Commands.Length;i += 1) {
                if(submessageTokens == CommandData.Commands[i].scheme.Trim()) {
                    Type type = typeof(Commands);
                    MethodInfo method = type.GetMethod(CommandData.Commands[i].action.Trim());
                    List<string> parameters = new List<string>();
                    foreach(byte index in paramaterIndexes) {
                        parameters.Add(submessages[index]);
                    }
                    var result = method.Invoke(new Commands(),parameters.ToArray()); //Var is NOT being used because "it can be", or because "it's easier".
                    if(result == null) {
                        return null;
                    } else {
                        return (string)result;
                    }
                    break;
                }
            }
            return "";
        }
    }
}