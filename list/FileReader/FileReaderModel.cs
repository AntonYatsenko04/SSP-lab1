using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;

namespace list
{
    public class FileReaderModel
    {
        private const string FileName = "lib.json";
        private readonly CurrentUserSecurity _currentUserSecurity = new CurrentUserSecurity();

        public FileStream OpenFile(string path)
        {
            try
            {
                if (_currentUserSecurity.HasAccess(new FileInfo(path), FileSystemRights.Read))
                {
                    if (_readFromEndUntilDot(path) == "txt")
                    {
                        FileStream fileStream = File.OpenRead(path);
                        return fileStream; 
                    }
                    else
                    {
                        throw new AppException();
                    }
                    
                }
                else
                {
                    throw new NoAccessPermission();
                }
            }
            catch (NoAccessPermission e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new UnableOpenFileException();
            }
        }

        public List<LibraryItemEntity> ReadLibraryJson()
        {
            try
            {
                string json = File.ReadAllText(FileName);
                List<LibraryItemEntity> libraryItemEntities = JsonSerializer.Deserialize<List<LibraryItemEntity>>(json);
                return libraryItemEntities;
            }
            catch (Exception exception)
            {
                throw new LibraryException();
            }
        }

        public void WriteLibraryJson(List<LibraryItemEntity> libraryItemEntities)
        {
            try
            {
                string json = JsonSerializer.Serialize(libraryItemEntities);

                File.WriteAllText(FileName, json);
            }
            catch (Exception exception)
            {
                throw new LibraryException();
            }
        }
        
        private  string _readFromEndUntilDot(string input)
        {
            var dotIndex = input.LastIndexOf('.');
            if (dotIndex != -1)
            {
                var result = input.Substring(dotIndex + 1);
                return result;
            }

            return string.Empty;
        }
    }
}