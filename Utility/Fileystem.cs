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
    public static class Fileystem
    {

        /// <summary>
        /// The main function was just created so that you can compile the project
        /// </summary>
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// The function merges the current path with a file name
        /// </summary>
        /// <param name="fileName">Contains the path or a file name. It is best to use the prefix @ "path\file.txt" to avoid escape errors</param>
        /// <example> This sample shows how to call the SaveData 
        /// method from a wireless device.
        /// <code>
        /// 
        ///string path = concatenatedPathWithFile(@"path/file.txt");
        ///
        ///</code>
        /// <returns>A string of the current path and the filename</returns>
        public static string ConcatenatedPathWithFile(string fileName) => Path.Combine(Directory.GetCurrentDirectory(), fileName);
    }
}
