namespace BankApp
{
    public class Greetings
    {
        public static string GetGreeting(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour));

            if (hour >= 5 && hour < 12)
                return "Good Morning";

            if (hour >= 12 && hour < 17)
                return "Good Afternoon";

            if (hour >= 17 && hour < 21)
                return "Good Evening";

            return "Good Night";
        }

        // Optional wrapper for real usage
        public static string GetGreeting()
        {
            return GetGreeting(DateTime.Now.Hour);
        }
    }

}
