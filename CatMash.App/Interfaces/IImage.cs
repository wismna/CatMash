namespace CatMash.App.Interfaces
{
    public interface IImage
    {
        string Url { get; set; }
        string Id { get; set; }
        int Votes { get; set; }
    }
}