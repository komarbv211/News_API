using Core.DTOs;

namespace Core.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetCommentsByNewsIdAsync(int newsId);
        Task<CommentDto?> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CommentDto commentDto);
        Task UpdateCommentAsync(int id, CommentDto commentDto);
        Task DeleteCommentAsync(int id);
    }

}
