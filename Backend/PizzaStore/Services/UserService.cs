using AutoMapper;
using FluentValidation;
using PizzaStore.DTOs;
using PizzaStore.Entities;
using PizzaStore.Repositories.IRepositories;
using PizzaStore.Services.IServices;

namespace PizzaStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDto> _validator;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerator<UserDto>> GetAllUsesAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerator<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            await ValidateAsync(userDto);

            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            await ValidateAsync(userDto);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(userDto.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            
            _mapper.Map(userDto, user);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _unitOfWork.UserRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task ValidateAsync(UserDto dto)
        {
            var result = await _validator.ValidateAsync(dto);

            if (!result.IsValid)
                throw new ValidationException(string.Join("; ", result.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
