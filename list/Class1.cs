using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface IFileReader
{
	public string currentPageText;

	public int currentPageNumber;

	public int pagesCount;

	public IFileReader();

	public void SetFileByPath(string path);

	public string GetCurrentPageText();

	public 
}
