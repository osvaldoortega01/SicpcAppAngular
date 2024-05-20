namespace SicpcAPI.Helpers
{
    public class SicpcException: Exception
    {
        public SicpcException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage 
        { 
            get; set;
        }
    }
}
