using System;
using System.Linq;
using System.Windows.Forms;
namespace list
{
    public class AppInitializer
    {
        private static readonly FileReaderModel _fileReaderModel = new FileReaderModel();
        
         public static void InitializeApp()
         {
             try
             {
                 var libraryItemEntities = _fileReaderModel.ReadLibraryJson();
                 if (libraryItemEntities.TrueForAll(LibraryValidator.LibraryItemEntityIsValidated)&&libraryItemEntities.Count>0) 
                 {
                     Application.Run(new FileReaderView(libraryItemEntities));
                     return;
                 }
                 else
                 {
                     Application.Run(new FileReaderView());
                 }
             }
             catch (Exception e)
             {
                 Application.Run(new FileReaderView());
             }
             
            
            
        }
    }
}