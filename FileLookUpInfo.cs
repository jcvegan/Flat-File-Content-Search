namespace Jcvegan.Com.ContentSearch {
    public sealed class FileLookUpInfo {
        public string FilePath { get; set; }
        public int Line { get; set; }

        public FileLookUpInfo(string path, int line) {
            FilePath = path;
            Line = line;
        }
    }
}