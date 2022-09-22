namespace Antaram_game.Extensions
{
    public class Extension
    {
        public static void MapSecretsToEnvVariables()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            foreach (var child in config.GetChildren())
            {
                Environment.SetEnvironmentVariable(child.Key, child.Value);
            }
        }
    }
}
