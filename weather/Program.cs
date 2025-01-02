namespace weather
{
    class Weather
    {
        // Create properties for temperature, condition, and cloudiness
        public int Temperature { get; set; }
        public string Condition { get; set; }
        public int Cloudiness { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Random seed
            Random random = new Random();

            // Generate Weather
            Weather todayWeather = new Weather();
            todayWeather.Temperature = random.Next(-10, 41); // Temperature between -10°C and 40°C
            todayWeather.Condition = GetValidCondition(random, todayWeather.Temperature);
            todayWeather.Cloudiness = GetValidCloudiness(random, todayWeather.Condition);

            // Display Weather
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("       🌦️  Today's Weather Report 🌦️      ");
            Console.WriteLine("========================================");
            Console.WriteLine($"🌡️  Temperature: {todayWeather.Temperature}°C");
            Console.WriteLine($"☁️  Condition: {todayWeather.Condition}");
            Console.WriteLine($"🌫️  Cloudiness: {todayWeather.Cloudiness}%");
            Console.WriteLine("========================================");

            // Extreme Weather Warning
            if (todayWeather.Condition == "Snow" && todayWeather.Temperature < -10)
            {
                Console.WriteLine("\n⚠️  Warning: It's extremely cold and snowy. Do not go outside! ⚠️");
            }

        }

        // Generate a valid weather condition based on temperature
        static string GetValidCondition(Random random, int temperature)
        {
            string[] conditions = { "Clear", "Rain", "Snow" };
            string condition;

            do
            {
                condition = conditions[random.Next(conditions.Length)];
            } 
            while ((condition == "Snow" && temperature > 0) || // Snow only if temp <= 0
                   (condition == "Rain" && temperature < 0));  // Rain only if temp >= 0

            return condition;
        }

        // Generate cloudiness based on my realistic conditions
        static int GetValidCloudiness(Random random, string condition)
        {
            int cloudiness; // 0 to 100 in steps of 10 because it looks better imo

            if (condition == "Clear")
            {
                // Cloudiness must be less than 20 (0 or 10)
                cloudiness = random.Next(0, 2) * 10; // Generates either 0 or 10
            }
            else if (condition == "Rain" || condition == "Snow")
            {
                // Cloudiness must be over 30 (40, 50, ..., 100)
                cloudiness = random.Next(4, 11) * 10; // Generates 40, 50, ..., 100
            }
            else
            {
                // Default cloudiness (0 to 100 in steps of 10)
                cloudiness = random.Next(0, 11) * 10; // Generates 0, 10, 20, ..., 100
            }

            return cloudiness;
        }
    }
}
