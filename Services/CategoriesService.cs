using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CategoriesService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoriesService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;

        public async Task<CategoryResponse> Add(Guid userId, CategoryAddRequest categoryAddRequest)
        {
            if (string.IsNullOrEmpty(categoryAddRequest.Name) || string.IsNullOrWhiteSpace(categoryAddRequest.Name))
            {
                throw new ArgumentException("Invalid name.");
            }

            var existingCategory = await unitOfWork.Categories.GetByNameAsync(userId, categoryAddRequest.Name);

            if (existingCategory != null)
            {
                throw new ArgumentException("Category with given name already exists.");
            }

            var categoryEntity = mapper.Map<CategoryEntity>(categoryAddRequest);
            categoryEntity.Id = Guid.NewGuid();
            categoryEntity.UserId = userId;

            unitOfWork.Categories.Add(categoryEntity);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<CategoryResponse>(categoryEntity);
        }

        public async Task Delete(Guid userId, Guid id)
        {
            var entity = await CheckIfCategoryExists(userId, id);

            unitOfWork.Categories.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<CategoryResponse>> GetAll(Guid userId)
        {
            var resultEntity = await unitOfWork.Categories.GetAllAsync(userId);
            var result = mapper.Map<List<CategoryResponse>>(resultEntity);
            return result;
        }

        public async Task<CategoryResponse> GetById(Guid userId, Guid id)
        {
            var resultEntity = await CheckIfCategoryExists(userId, id);
            var result = mapper.Map<CategoryResponse>(resultEntity);
            return result;
        }

        public async Task<CategoryResponse> Update(Guid userId, CategoryUpdateRequest categoryUpdateRequest)
        {
            var existingEntity = await CheckIfCategoryExists(userId, categoryUpdateRequest.Id);

            if (string.IsNullOrEmpty(categoryUpdateRequest.Name) || string.IsNullOrWhiteSpace(categoryUpdateRequest.Name))
            {
                throw new ArgumentException("Invalid name.");
            }

            if (existingEntity.Name != categoryUpdateRequest.Name)
            {
                var duplicate = await unitOfWork.Categories.GetByNameAsync(userId, categoryUpdateRequest.Name);
                if (duplicate != null) throw new ArgumentException("Category with provided name already exists.");
            }

            mapper.Map(categoryUpdateRequest, existingEntity);

            unitOfWork.Categories.Update(existingEntity);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<CategoryResponse>(existingEntity);
        }

        private async Task<CategoryEntity> CheckIfCategoryExists(Guid userId, Guid id)
        {
            var resultEntity = await unitOfWork.Categories.GetByIdAsync(id);
            if (resultEntity == null || userId != resultEntity.UserId)
            {
                throw new KeyNotFoundException("Category not found.");
            }
            return resultEntity;
        }
    }
}
