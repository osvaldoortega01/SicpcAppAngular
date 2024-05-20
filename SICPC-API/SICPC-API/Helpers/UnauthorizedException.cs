namespace SicpcAPI.Helpers
{
    public class UnauthorizedException: Exception
    {
        public UnauthorizedException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage 
        { 
            get; set;
        }
    }
}
