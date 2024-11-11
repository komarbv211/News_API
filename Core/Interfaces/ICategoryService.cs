using Core.DTOs;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); 
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); 
        //Task DeleteCategoryAsync(int id);
        //Task<CategoryDto> GetCategorySpecsByIdAsync(int id);
    }
}
