namespace Padawan.Shared.Entities
{
    public class Filter
    {
        public Filter() { }

        public string FieldName { get; set; }
        public string OperatorWhere { get; set; }
        public string Value { get; set; }
        public string ExtraFilter { get; set; }
        public string OrderBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
