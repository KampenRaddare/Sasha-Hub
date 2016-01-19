namespace Sasha_Hub.Commands
{
    internal static class Calculate
    {
        internal static string AllOperations(string number1, string number2)
        {
            // Since no operator is supplied
            // returns every possible solution

            int num1 = System.Convert.ToInt32(number1);
            int num2 = System.Convert.ToInt32(number2);

            return "Multiplied = " + (num1 * num2).ToString() + "\n" + 
                "Divided = " + (num1 / num2) + "\n" +
                "Added = " + (num1 + num2) + "\n" + 
                "Subtracted = " + (num1 - num2);
        }

        internal static string OperatorSupplied(string number1, string number2, string numberOperator)
        {
            // Since operator is supplied
            // returns specific solution

            int num1 = System.Convert.ToInt32(number1);
            int num2 = System.Convert.ToInt32(number2);

            switch (numberOperator)
            {
                case "+":
                    return (num1 + num2).ToString();
                case "/":
                    return (num1 / num2).ToString();
                case "-":
                    return (num1 - num2).ToString();
                case "*":
                    return (num1 * num2).ToString();
                default:
                    return "Fuck you. You broke me. D;";
            }
        }
    }
}