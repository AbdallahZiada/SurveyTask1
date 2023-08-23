using BusinessLayer.Common.Enums;

namespace BusinessLayer.Dtos
{
    public class JTableSearchDTO<T>
    {
        public int jTableStartIndex { get; set; }
        public int jTablePageSize { get; set; }
        public SortDirectionEnum sortDirection { get; set; }
        public string sortingField { get; set; }
        public T SearchObj { get; set; }
    }
}
