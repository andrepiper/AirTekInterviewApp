namespace AirTek.Utils
{
    public interface IJsonFileReader<T>
    {
        Task<T> Read(string filePath);
    }
}