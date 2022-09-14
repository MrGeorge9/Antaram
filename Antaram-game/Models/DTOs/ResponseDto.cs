namespace Antaram_game.Models.DTOs
{
    public class ResponseDto
    {
        public string Message { get; }

        public ResponseDto()
        {
            Message = string.Empty;
        }

        public ResponseDto(string message)
        {
            Message = message;
        }
    }
}
