using Dapper;
using Microsoft.Data.SqlClient;

namespace BlazorDapperCRUD.Data.Service
{
    public class VideoService : IVideoService
    {
        private readonly DBConnectionString _dbConnectionString;
        public VideoService(DBConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }
        public async Task<List<Video>> GetVideos()
        {
            using var connection = new SqlConnection(_dbConnectionString.ConnectionString);
            var videos = await connection.QueryAsync<Video>("SELECT * FROM tblVideo");
            return videos.ToList();
        }
        public async Task<Video> GetVideoById(int videoId)
        {
            using var connection = new SqlConnection(_dbConnectionString.ConnectionString);
            var video = await connection.QueryFirstOrDefaultAsync<Video>("SELECT * FROM tblVideo WHERE VideoId = @VideoId", new { VideoId = videoId });
            return video;
        }
        public async Task AddVideo(Video video)
        {
            using var connection = new SqlConnection(_dbConnectionString.ConnectionString);
            var sql = "INSERT INTO tblVideo (Title, DatePublished, IsActive, CreatedDate, LastUpdatedDate, CreatedBy, LastUpdatedBy) " +
                      "VALUES (@Title, @DatePublished, @IsActive, @CreatedDate, @LastUpdatedDate, @CreatedBy, @LastUpdatedBy)";
            await connection.ExecuteAsync(sql, video);
        }
        public async Task UpdateVideo(Video video)
        {
            using var connection = new SqlConnection(_dbConnectionString.ConnectionString);
            var sql = "UPDATE tblVideo SET Title = @Title, DatePublished = @DatePublished, IsActive = @IsActive, " +
                      "LastUpdatedDate = @LastUpdatedDate, LastUpdatedBy = @LastUpdatedBy WHERE VideoId = @VideoId";
            await connection.ExecuteAsync(sql, video);
        }
        public async Task DeleteVideo(int videoId)
        {
            using var connection = new SqlConnection(_dbConnectionString.ConnectionString);
            await connection.ExecuteAsync("DELETE FROM tblVideo WHERE VideoId = @VideoId", new { VideoId = videoId });
        }
    }
}
