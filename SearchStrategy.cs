using System.Collections.Generic;
using System.IO;

namespace Jcvegan.Com.ContentSearch {
    public abstract class SearchStrategy {
        private const string CsvDelimiter = ",";

        protected string folderPath = string.Empty;
        protected string content = string.Empty;
        protected string outputFile = string.Empty;

        protected SearchStrategy(string folderPath, string content, string outputFile) {
            this.folderPath = folderPath;
            this.content = content;
            this.outputFile = outputFile;
        }

        protected void WriteResults(string path, IEnumerable<FileLookUpInfo> result) {
            TextWriter textWriter = new StreamWriter(path, false);
            textWriter.Write("File Path");
            textWriter.Write(CsvDelimiter);
            textWriter.WriteLine("Line");
            foreach (FileLookUpInfo info in result) {
                textWriter.WriteLine($"{info.FilePath}{CsvDelimiter}{info.Line.ToString()}");
            }
            textWriter.Close();
        }

        public abstract void SearchContent();
    }
}