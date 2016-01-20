namespace Sasha_Hub
{
    using System;
    using Sasha_Hub;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    internal static class Sasha
    {
        private const string SaidNothing = "Scared to say something meaningfull?";
        private const string NullError = "String passed to Sasha.Command() can\'t be null!";
        internal const string InternalErrorString = "error";
        private const string ErrorMessage = "Something went wrong. Brace yourself.";
        private const string IForGotHow = "I think something just broke inside of me. I'm sure I\'ll be fine! *dies*";
        private enum Mood
        {
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
        private static Mood CurrentMood = Mood.Excited;
        private static readonly commandData CommandData = (commandData)new XmlSerializer(typeof(commandData)).Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("Sasha_Hub.commandData.xml")); //Best line of code 2016
        internal static string Interpret(string message)
        {
            if (message != null)
            {
                message = message.Trim();
                if (message != "")
                {
                    string commandReturn = ProcessCommand(message);
                    if (commandReturn != "")
                    {
                        return commandReturn;
                    }
                }
                else
                {
                    return SaidNothing;
                }
            }
            else
            {
                throw new Exception(NullError);
            }
            return ProcessChat(message);
        }
        private static string ProcessChat(string message)
        {
            /* SPAAAAAAAAAAAAAAAACEEEEEEEEEE MAGGGGGGGGGICCCCCCCCCCCCCC
            If you want me to do the steps I sent you in the really long text message let me know but I'll leave it up to you.
            I want to set this entire part of the system up in xml (if you can wait a day)
            That way there's no internal enums or switch statements. I think you can see the other benefits of this. I mean just
            Look what it did for the command system. Made me slightly more broken inside and inside so you can make commands even
            faster xD*/
            switch (CurrentMood)
            {
                case Mood.Confused:
                    break;
                case Mood.Excited:
                    break;
            }
            return "me no smart yet";
        }
        private static string ProcessCommand(string message)
        {
            string[] submessages = message.Split(' ');
            if (submessages.Length <= 127)
            {
                sbyte[] submessageTokens = new sbyte[submessages.Length];
                for (int i = 0; i < submessageTokens.Length; i += 1)
                {
                    submessageTokens[i] = -1;
                }
                List<byte> parameterIndexes = new List<byte>();
                for (byte i = 0; i < submessages.Length; i += 1)
                {
                    string currentString = Regex.Replace(submessages[i].ToLowerInvariant(), "\\p{P}+", "");
                    for (byte e = 0; e < CommandData.Tokens.Length; e += 1)
                    {
                        if (currentString == CommandData.Tokens[e].Value.ToLowerInvariant())
                        {
                            submessageTokens[i] = (sbyte)(e + 1);
                            break;
                        }
                    }
                    if (submessageTokens[i] == -1)
                    {
                        submessageTokens[i] = 0;
                        parameterIndexes.Add(i);
                    }
                }
                string submessageTokenString = "";
                foreach (int tokenId in submessageTokens)
                {
                    submessageTokenString += $"{tokenId} ";
                }
                submessageTokenString = submessageTokenString.TrimEnd(); //I spent 15 minutes before I forgot to have "submessageTokens = "................ Dammit JavaScript.
                for (byte i = 0; i < CommandData.Commands.Length; i += 1)
                {
                    if (submessageTokenString == CommandData.Commands[i].scheme.Trim())
                    {
                        try
                        {
                            Type type = typeof(Commands);
                            MethodInfo method = type.GetMethod(CommandData.Commands[i].action.Trim());
                            List<string> parameters = new List<string>();
                            foreach (byte index in parameterIndexes)
                            {
                                parameters.Add(submessages[index]);
                            }
                            var result = method.Invoke(new Commands(), parameters.ToArray()); //Var is NOT being used because "it can be", or because "it's easier".
                            if (result == null)
                            {
                                return null;
                            }
                            else
                            {
                                return (string)result;
                            }
                        }
                        catch
                        {
                            return IForGotHow;
                        }
                        break;
                    }
                }
            }
            return "";
        }
    }
}