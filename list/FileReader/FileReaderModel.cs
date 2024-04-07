using System;
using System.IO;
using System.Security.AccessControl;

namespace list
{
    public class FileReaderModel
    {
        private readonly CurrentUserSecurity _currentUserSecurity = new CurrentUserSecurity();

        public FileStream OpenFile(string path)
        {
            try
            {
                if (_currentUserSecurity.HasAccess(new FileInfo(path), FileSystemRights.Read))
                {
                    FileStream fileStream = File.OpenRead(path);
                    return fileStream;
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
        
        
    }
}