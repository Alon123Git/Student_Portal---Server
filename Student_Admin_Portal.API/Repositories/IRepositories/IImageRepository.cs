namespace Student_Admin_Portal.API.Repositories.IRepositories
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}