using Entities;

namespace API.IServices
{
    public interface IFileService
    {
        int PostFile(FileItem fileItem);
        void DeleteFile(int id);
        FileItem GetFileById(int id);
        List<FileItem> GetAllFilesList(); 
        
    }
}
