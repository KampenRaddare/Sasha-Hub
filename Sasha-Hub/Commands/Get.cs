namespace Sasha_Hub.Commands {
    internal static class Get {
        internal static string Weather() {
            //ip location->web service->weather service->xml->process | Me can do it later I guess
            return "27. This is the weather right now. Impressed?";
        }
        internal static string Stocks() {
            return "The US stock market is down more than 2.3 trillion dollars this year.";
            // ^ Sounds like a joke but it's true xD Gg economy
        }
        internal static string Stocks(string stock) {
            return $"{stock} looks like its doing good. Kinda looks like a mountain!";
        }
    }
}