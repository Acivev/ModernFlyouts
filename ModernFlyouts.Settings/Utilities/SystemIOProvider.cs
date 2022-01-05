﻿using System;
using System.IO.Abstractions;

namespace ModernFlyouts.Settings.Utilities
{
    public class SystemIOProvider : IIOProvider
    {
        private readonly IDirectory _directory;
        private readonly IFile _file;

        public SystemIOProvider()
            : this(new FileSystem())
        {
        }

        public SystemIOProvider(IFileSystem fileSystem)
            : this(fileSystem?.Directory, fileSystem?.File)
        {
        }

        private SystemIOProvider(IDirectory directory, IFile file)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
            _file = file ?? throw new ArgumentNullException(nameof(file));
        }

        public bool CreateDirectory(string path)
        {
            var directoryInfo = _directory.CreateDirectory(path);
            return directoryInfo != null;
        }

        public void DeleteDirectory(string path)
        {
            _directory.Delete(path, recursive: true);
        }

        public bool DirectoryExists(string path)
        {
            return _directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return _file.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return _file.ReadAllText(path);
        }

        public void WriteAllText(string path, string content)
        {
            _file.WriteAllText(path, content);
        }
    }
}
