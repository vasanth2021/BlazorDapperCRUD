
namespace BlazorDapperCRUD.Data.Service
{
    public interface IVideoService
    {
        Task AddVideo(Video video);
        Task DeleteVideo(int videoId);
        Task<Video> GetVideoById(int videoId);
        Task<List<Video>> GetVideos();
        Task UpdateVideo(Video video);
    }
}