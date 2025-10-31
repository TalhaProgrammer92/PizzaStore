using AutoMapper;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;

namespace PizzaStore.Infrastructure.Services
{
    public class GeneralService<TEntity, TDto> : IGeneralService<TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IGeneralRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GeneralService(IGeneralRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var query = await _repository.GetAllAsync();
            return _mapper.ProjectTo<TDto>(query);
        }

        public virtual async Task<TDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(Guid id, TDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return;

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
