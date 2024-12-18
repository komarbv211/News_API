﻿using Core.DTOs;
using Core.DTOs.DtoSpec;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); 
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); 
        Task DeleteCategoryAsync(int id);
        Task<CategoryWithNewsDto> GetCategorySpecsByIdAsync(int id);
    }
}
