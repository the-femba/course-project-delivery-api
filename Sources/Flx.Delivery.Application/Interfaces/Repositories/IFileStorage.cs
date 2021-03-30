namespace Flx.Delivery.Application.Interfaces.Repositories
{
    public interface IFileStorage
    {
        public void PutBytes(string container, string fileName, byte[]? data);

        public void PutString(string container, string fileName, string? data);

        public void PutBase64String(string container, string fileName, string? base64);

        public byte[]? GetBytes(string container, string fileName);

        public string? GetString(string container, string fileName);

        public string? GetBase64String(string container, string fileName);

        public void Remove(string container, string fileName);
    }
}
