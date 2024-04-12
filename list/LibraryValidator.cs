namespace list
{
    public class LibraryValidator
    {
        public static bool LibraryItemEntityIsValidated(LibraryItemEntity libraryItemEntity)
        {
            return ValidateBufferSize(libraryItemEntity.BufferSize) && ValidateFontSize(libraryItemEntity.FontSize);
        }

        public static bool ValidateBufferSize(int bufferSize)
        {
            return bufferSize == 4096 || bufferSize == 8192 || bufferSize >= 16384;
        }

        public static bool ValidateFontSize(float fontSize)
        {
            return (!(fontSize >= 50)) && (!(fontSize <= 5));
        }

    }
}