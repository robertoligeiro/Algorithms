using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAmazonOnSiteDesignFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class FileSystemManager
        {
            private Dictionary<char, IFolder> volumes;

            public FileSystemManager()
            {
                // Load the volumes and files
            }
            public IFile Find(char volume, string name)
            {
                IFolder v;
                if (volumes.TryGetValue(volume, out v))
                {
                    return v.Find(name);
                }
                throw new ArgumentException("Invalid Volume");
            }
        }

        public interface IFolder
        {
            string FolderName { get; set; }
            string FolderPath { get; set; }
            IFile Find(string name);
            IFile FindFile(string name);
            bool IsSymbolicLink();
        }

        public class Folder : IFolder
        {
            private List<IFile> files;
            private List<IFolder> folders;
            private string folderName;
            private string folderPath;
            public Folder(string folderName, string folderPath)
            {
                this.FolderName = folderName;
                this.FolderPath = folderPath;
            }
            public IFile Find(string name)
            {
                var foldersVisited = new HashSet<string>();
                return this.Find(name, this, foldersVisited);
            }

            private IFile Find(string name, IFolder folder, HashSet<string> foldersVisited)
            {
                var file = folder.FindFile(name);
                if (file != null) return file;
                foreach (var subFolder in folders)
                {
                    if (foldersVisited.Add(folder.FolderPath))
                    {
                        file = Find(name, subFolder, foldersVisited);
                        if (file != null) return file;
                    }
                }
                return null;
            }

            public IFile FindFile(string name)
            {
                foreach (var f in files)
                {
                    if (f.FileName == name)
                    {
                        return f;
                    }
                }
                return null;
            }
            public virtual bool IsSymbolicLink()
            {
                return false;
            }
            public string FolderName
            {
                get
                {
                    return folderName;
                }

                set
                {
                    folderName = value;
                }
            }

            public string FolderPath
            {
                get
                {
                    return folderPath;
                }

                set
                {
                    folderPath = value;
                }
            }
        }

        public class SymbolicLinkFolder : Folder
        {
            private string symbolicLinkFolderName;
            private string symbolicLinkFolderPath;
            public SymbolicLinkFolder(string symbolicLinkFolderName, string symbolicLinkFolderPath, string targetFolderName, string targetFolderPath) : base(targetFolderName, targetFolderPath)
            {
                this.symbolicLinkFolderName = symbolicLinkFolderName;
                this.symbolicLinkFolderPath = symbolicLinkFolderPath;
            }
        }
        public interface IFile
        {
            string FileName { get; set; }
            string FilePath { get; set; }
            string CreatedDateTime { get; }
            bool IsSymbolicLink();
        }

        public class File : IFile
        {
            private string filename;
            private string filepath;
            private string lastupdateddatetime;
            private string createddatetime;
            public File(string fileName, string filePath)
            {
                this.FileName = filename;
                this.FilePath = filepath;
                createddatetime = DateTime.Now.ToString();
            }
            public string CreatedDateTime
            {
                get
                {
                    return createddatetime;
                }
            }

            public string FileName
            {
                get
                {
                    return filename;
                }

                set
                {
                    filename = value;
                }
            }

            public string FilePath
            {
                get
                {
                    return filepath;
                }

                set
                {
                    filepath = value;
                }
            }

            public virtual bool IsSymbolicLink()
            {
                return false;
            }
        }

        public class SymbolicLinkFile : File
        {
            private string symbolicFileName;
            private string symbolicFilePath;
            public SymbolicLinkFile(string symbolicLinkName, string symbolicLinkPath, string targetFileName, string targetFilePath) : base(targetFileName, targetFilePath)
            {
                this.symbolicFileName = symbolicFileName;
                this.symbolicFilePath = symbolicFilePath;
            }
            public override bool IsSymbolicLink()
            {
                return true;
            }
        }
    }
}
