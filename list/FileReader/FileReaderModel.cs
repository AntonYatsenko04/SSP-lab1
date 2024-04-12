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

        public List<LibraryItemEntity> UpdateLibrary(LibraryItemEntity newLibraryItemEntity)
        {
            List<LibraryItemEntity> libraryEntities;
            try
            {
                libraryEntities = ReadLibraryJson();
            }
            catch (LibraryException e)
            {
                libraryEntities = new List<LibraryItemEntity>();
            }

            try
            {
                for (var index = 0; index < libraryEntities.Count; index++)
                {
                    var entity = libraryEntities[index];
                    if (entity.FilePath == newLibraryItemEntity.FilePath)
                    {
                        libraryEntities.RemoveAt(index);
                        libraryEntities.Insert(index, newLibraryItemEntity);
                        WriteLibraryJson(libraryEntities);
                        return libraryEntities;
                    }
                }

                libraryEntities.Add(newLibraryItemEntity);
                WriteLibraryJson(libraryEntities);
                return libraryEntities;
            }
            catch (Exception e)
            {
                throw new LibraryException();
            }
        }

        public void DeleteLibraryEntity(String filepath)
        {
            List<LibraryItemEntity> libraryEntities;
            try
            {
                libraryEntities = ReadLibraryJson();
            }
            catch (LibraryException e)
            {
                libraryEntities = new List<LibraryItemEntity>();
            }

            try
            {
                for (var index = 0; index < libraryEntities.Count; index++)
                {
                    var entity = libraryEntities[index];
                    if (entity.FilePath == filepath)
                    {
                        libraryEntities.RemoveAt(index);
                        WriteLibraryJson(libraryEntities);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                throw new LibraryException();
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

        private void WriteLibraryJson(List<LibraryItemEntity> libraryItemEntities)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize<List<LibraryItemEntity>>(libraryItemEntities, options);
                File.WriteAllText(FileName, json);
            }
            catch (Exception exception)
            {
                throw new LibraryException();
            }
        }

        private string _readFromEndUntilDot(string input)
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