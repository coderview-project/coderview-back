using API.IServices;
using Data;
using Entities;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly ServiceContext _serviceContext;
        public FileService(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public void DeleteFile(int id)
        {
            _serviceContext.Files.Remove(_serviceContext.Set<FileItem>().Where(i => i.Id == id).First());
            _serviceContext.SaveChanges();
        }

        public List<FileItem> GetAllFilesList()
        {
            return _serviceContext.Set<FileItem>().ToList();
        }

        public FileItem GetFileById(int id)
        {
            var file = _serviceContext.Set<FileItem>().Where(f => f.Id == id).FirstOrDefault();
            if (file != null)
            {
                return file;
            }
            else
            {
                throw new Exception("No se encontró el archivo.");
            }
        }

        public int PostFile(FileItem fileItem)
        {
            try
            {
                _serviceContext.Files.Add(fileItem);
                _serviceContext.SaveChanges();
                return fileItem.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
