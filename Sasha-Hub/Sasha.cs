namespace Sasha_Hub
{
    using System;
    using Sasha_Hub;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    internal static class Sasha
    {
        private const string SaidNothing = "Scared to say something meaningful?";
        private const string NullError = "Overloaded string on Sasha.Interpret() can't be null!";
        internal const string InternalErrorString = "error";
        private const string ErrorMessage = "Something went wrong. Brace yourself.";
        private const string deadInside = "I think something just broke inside of me. I'm sure I'll be fine! *dies*";
        private const string meh = "Meh. If you say so.";
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
        private static Mood CurrentMood = Mood.Excited; // Why do this? Why not just pick from the enum?
        private static commandData getCommandData()
        {
            try
            {
                return (commandData)new XmlSerializer(typeof(commandData)).Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("Sasha_Hub.commandData.xml"));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        private static readonly commandData CommandData = getCommandData();
        internal static string Interpret(string message)
        {
            try
            {
                if (message != null)
                {
                    if (CommandData != null)
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
                }
                else
                {
                    throw new Exception(NullError);
                }
                return ProcessChat(message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return deadInside;
            }
        }
        private static string ProcessChat(string message)
        {
            char splitCharacter = Resources.chatdata.Substring(0, 1)[0];
            string[] fullArray = Resources.chatdata.Remove(0, 1).Split(splitCharacter);
            List<string[]> splitFullArray = new List<string[]>();
            for (int i = 0; i < fullArray.Length - 1; i += 2)
            {
                splitFullArray.Add(new string[] { fullArray[i], fullArray[i + 1] });
            }
            // TODO: Sort splitFullArray by the string length of the first value of the contained string arrays
            foreach (string[] chatsubarray in splitFullArray)
            {
                if (message.Trim().ToLowerInvariant().IndexOf(chatsubarray[0].Trim().ToLowerInvariant()) != -1)
                {
                    string returnMessage = chatsubarray[1];
                    switch (CurrentMood)
                    {
                        // TODO: Setup system for replacing things like "{happyInsult}" or '{sadVerb}" depending on current mood. You get the idea
                        case Mood.Happy:
                            break;
                        case Mood.Confused:
                            break;
                        case Mood.Excited:
                            break;
                        case Mood.Flirty:
                            break;
                        case Mood.Sad:
                            break;
                        case Mood.Loving:
                            break;
                        case Mood.Sick:
                            break;
                        case Mood.Silly:
                            break;
                        case Mood.Sleepy:
                            break;
                        case Mood.Smug:
                            break;
                        case Mood.Tipsy:
                            break;
                        default:
                            return deadInside;
                            break;

                    }
                    // TODO: Setup returnMessage metaData tags for changing moods
                    // For instance, having {beAngry} at the end of a message in chatdata.txt could change the mood to angry

                    return returnMessage;
                }
            }
            return meh;
        }
        private static string ProcessCommand(string message)
        {
            string[] submessages = message.Split(' ');
            if (submessages.Length <= 126)
            {
                sbyte[] submessageTokens = new sbyte[submessages.Length];
                for (byte i = 0; i < submessageTokens.Length; i += 1)
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
                for (int i = 0; i < CommandData.Commands.Length; i += 1)
                {
                    if (submessageTokenString == CommandData.Commands[i].scheme.Trim())
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
                            string methodResult = (string)result;
                            if (methodResult != InternalErrorString)
                            {
                                return methodResult;
                            }
                            else
                            {
                                return ErrorMessage;
                            }
                        }
                        break;
                    }
                }
            }
            return "";
        }
    }
}