using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByID(id);
            return _mapper.Map<CategoryDto>(category);
        }
/*        public async Task<CategoryDto> GetCategorySpecsByIdAsync(int id)
        {
            var category = await _categoryRepository.GetItemBySpec(new CategorySpecs.ById(id));
            return _mapper.Map<CategoryDto>(category);
        }
*/
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryRepository.Insert(category);
            await _categoryRepository.Save();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _categoryRepository.Update(category);
            await _categoryRepository.Save();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByID(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);
                await _categoryRepository.Save();
            }
        }
    }
}
