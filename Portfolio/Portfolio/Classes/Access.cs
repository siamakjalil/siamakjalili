namespace Portfolio.Classes
{
    public static class Access
    {
        public static bool Edit()
        {
            var env = Environment.GetEnvironmentVariable("Siamak_Jalili",EnvironmentVariableTarget.Machine);
            return env!= null;
        }
    }
}
