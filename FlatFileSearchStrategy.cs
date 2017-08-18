using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jcvegan.Com.ContentSearch {
    public class FlatFileSearchStrategy : SearchStrategy {
        public FlatFileSearchStrategy(string folderPath, string content, string outputFile) : base(folderPath, content,
            outputFile) {
        }

        public override void SearchContent() {
            List<FileLookUpInfo> files = new List<FileLookUpInfo>();
            SearchInContent(folderPath, content, ref files);
            WriteResults(outputFile, files);
        }

        private void SearchInContent(string folderPath, string content, ref List<FileLookUpInfo> filesResult) {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            Console.WriteLine("Looking into {0}", folderPath);
            IEnumerable<FileInfo> files = directory.EnumerateFiles();
            try {
                foreach (FileInfo file in files) {
                    string filePath = file.FullName;
                    List<string> contentLines = File.ReadAllLines(filePath).ToList();
                    for (int i = 0; i < contentLines.Count; i++) {
                        string line = contentLines[i];
                        if (line.Contains(content)) {
                            filesResult.Add(new FileLookUpInfo(filePath, i + 1));
                        }
                    }
                }
                IEnumerable<DirectoryInfo> subDirectories = directory.GetDirectories();
                if (subDirectories.Any()) {
                    foreach (DirectoryInfo sub in subDirectories) {
                        SearchInContent(sub.FullName, content, ref filesResult);
                    }
                }
            }
            catch (Exception exc) {
                throw exc;
            }
        }
    }
}