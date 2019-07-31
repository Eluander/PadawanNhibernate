namespace Padawan.Shared.Commands
{
    public interface ICommandSearch
    {
        string Filter { get; set; }
        string Order { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
