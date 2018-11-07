using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// The class includes utility functions concerning the file system
    /// </summary>
    public static class Filesystem
    {

        /// <summary>
        /// The function merges the current path with a file name
        /// </summary>
        /// <param name="fileName">Contains the path or a file name. It is best to use the prefix @ "path\file.txt" to avoid escape errors</param>
        /// <example> This sample shows how to call the SaveData 
        /// method from a wireless device.
        /// <code>
        /// 
        /// string path = Utility.Filesystem.concatenatedPathWithFile(@"path/file.txt");
        ///
        ///</code>
        /// <returns>A string of the current path and the filename</returns>
        public static string ConcatenatedPathWithFile(string fileName) => Path.Combine(Directory.GetCurrentDirectory(), fileName);

        /// <summary>
        /// Checks if the file is locked by another process
        /// </summary>
        /// <code>
        /// 
        /// Boolean fileLocked = IsFileLocked(new Fileinfo("path\file.txt");
        ///
        ///</code>
        /// <param name="file">Contains the path to the file</param>
        /// <returns>Returns the status of whether the file is locked or not</returns>
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
