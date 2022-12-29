namespace CustomConfigProvider.Providers
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEntityConfiguration(
            this IConfigurationBuilder builder)
        {
            var tempConfig = builder.Build();
            var connectionString =
                //tempConfig.GetConnectionString("WidgetConnectionString");
                //tempConfig.GetValue<string>("ConnectionStrings:WidgetConnectionString");
                "Server=HOANLE\\HOANLE;Initial Catalog=TestConfigDb;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;";

            Console.WriteLine(connectionString);
            return builder.Add(new EntityConfigurationSource(connectionString));
        }
    }
}
