namespace TranscribeMe.API.Data
{
    public enum MessageTypes
    {
        Info = 1,

        Warning = 2
    }

    public enum MessageCodes
    {
        GoingToMainenance = 10001,
    }

    public class MessageModel
    {
        public MessageCodes Code { get; set; }

        public MessageTypes Type { get; set; }

        public string Text { get; set; }

    }
}