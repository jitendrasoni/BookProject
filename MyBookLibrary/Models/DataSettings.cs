namespace MyBookLibrary.Models
{
    public class DataSettings
    {
        public string? FilePath { get; set; }
        public virtual string? GetFilePath()
        {
            return FilePath; 
        }
    }
}
