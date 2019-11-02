namespace CatswordsTab.Shell.Model
{
    public class ComputationModel
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public string MD5 { get; set; }
        public string SHA1 { get; set; }
        public string HEAD32 { get; set; }
        public string CRC32 { get; set; }
        public string SHA256 { get; set; }
        public string InfoHash { get; set; }
        public string SystemLocale { get; set; }
        public AssociationModel Association { get; set; }
    }
}