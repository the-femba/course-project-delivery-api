using Flx.Delivery.Application.Interfaces.Repositories;
using System;
using System.IO;

namespace Flx.Delivery.Shared.Repositories
{
    public sealed class FileStorage : IFileStorage
    {
        private string GetPath(string container, string fileName)
        {
            return GetPath(container) + $"/{fileName}";
        }

        private string GetPath(string container)
        {
            return $"{Directory.GetCurrentDirectory()}/Cache/Storage/{container}";
        }

        public byte[]? GetBytes(string container, string fileName)
        {
            var globalPath = GetPath(container, fileName);

            if (!File.Exists(globalPath))
            {
                return null;
            }

            return File.ReadAllBytes(globalPath);
        }

        public void PutBytes(string container, string fileName, byte[]? data)
        {
            var globalPath = GetPath(container, fileName);

            Directory.CreateDirectory(GetPath(container));

            File.WriteAllBytes(globalPath, data ?? new byte[] { });
        }

        public void Remove(string container, string fileName)
        {
            var globalPath = GetPath(container, fileName);

            File.Delete(globalPath);
        }

        public void PutString(string container, string fileName, string? data)
        {
            var globalPath = GetPath(container, fileName);

            Directory.CreateDirectory(GetPath(container));

            File.WriteAllText(globalPath, data);
        }

        public void PutBase64String(string container, string fileName, string? base64)
        {
            PutBytes(container, fileName, base64 != null ? Convert.FromBase64String(base64) : null);
        }

        public string? GetString(string container, string fileName)
        {
            var globalPath = GetPath(container, fileName);

            if (!File.Exists(globalPath))
            {
                return null;
            }

            return File.ReadAllText(globalPath);
        }

        public string? GetBase64String(string container, string fileName)
        {
            var globalPath = GetPath(container, fileName);

            if (!File.Exists(globalPath))
            {
                return null;
            }

            return Convert.ToBase64String(File.ReadAllBytes(globalPath));
        }
    }
}
