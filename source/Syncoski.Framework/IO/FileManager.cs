using System;
using System.IO;
using VGExplorer.Framework.Helpers;

namespace Syncoski.Framework.IO
{
    internal class FileManager
    {

        private const String LocalRepository = "LocalRepository.ski";

        public static String GetAppPath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var finalPath = Path.Combine(basePath, Constants.APP_COMPANY, Constants.APP_NAME);
            if (!Directory.Exists(finalPath))
                Directory.CreateDirectory(finalPath);

            return finalPath;
        }

        public static String GetAppFile()
        {
            return Path.Combine(GetAppPath(), LocalRepository);
        }

        public static String GetAppFileContent()
        {
            var file = GetAppFile();
            if (!File.Exists(file))
            {
                using (var tempStream = File.Create(file))
                {
                    tempStream.Flush();
                    tempStream.Close();
                    tempStream.Dispose();
                }
            }
            return FileHelper.OpenStream(file);
        }


        public static bool IsEqualStructure(string file1, string file2)
        {
            var content1 = FileHelper.OpenStream(file1);
            var nodes1 = JsonHelper.DeserializeNodeStringArray(content1);

            var content2 = FileHelper.OpenStream(file2);
            var nodes2 = JsonHelper.DeserializeNodeStringArray(content2);

            return nodes1.Equals(nodes2);
        }

    }
}
