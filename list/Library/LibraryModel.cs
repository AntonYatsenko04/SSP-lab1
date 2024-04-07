using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace list
{
    public class LibraryModel
    {
        private const string FileName = "lib.json";

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
    }
}