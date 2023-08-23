using System.Collections.Generic;

namespace BusinessLayer.Dtos
{
    public class PagesTitleDTO
    {
        public string ControllerName { get; set; }
        public List<PageDTO> ChildPages { get; set; }
    }
}
