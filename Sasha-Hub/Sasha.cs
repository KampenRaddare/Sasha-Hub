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
        private const string NullError = "String passed to Sasha.Command() can't be null!";
        internal const string InternalErrorString = "error";
        private const string ErrorMessage = "Something went wrong. Brace yourself.";
        private const string IForGotHow = "I think something just broke inside of me. I'm sure I'll be fine! *dies*";
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
        private static readonly commandData CommandData = (commandData)new XmlSerializer(typeof(commandData)).Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("Sasha_Hub.commandData.xml")); // Fuck your formating of comments bitch
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
            // I got sick of seeing that long ass comment XD
            switch (CurrentMood)
            {
                case Mood.Confused:
                    break;
                case Mood.Excited:
                    break;
            }
            return "I don't no how to smart just yet. Sorry.";
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
                submessageTokenString = submessageTokenString.TrimEnd();
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
                            var result = method.Invoke(new Commands(), parameters.ToArray());
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