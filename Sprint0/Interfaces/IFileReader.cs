using System;

public interface IFileReader
{
    public bool LoadFile(string filePath);
    public void ParseXml();

}
