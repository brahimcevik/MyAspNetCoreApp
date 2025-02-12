namespace MyAspNetCoreApp.Wep.Helpers
{
    public class Helper : IHelper
    {
        public string Upper(string text)
        {
            return text.ToUpper();
        }
    }
}
