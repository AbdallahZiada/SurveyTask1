using BusinessLayer.Dtos.Enums;

namespace BusinessLayer.Dtos
{
    public class ResponseViewModel
    {
        public ResponseStatusEnum Status { get; set; }
        public string Message { get; set; }

    }
}
