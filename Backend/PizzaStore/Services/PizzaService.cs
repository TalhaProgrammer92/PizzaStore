using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using PizzaStore.DTOs;
using PizzaStore.Entities;
using PizzaStore.Enums;
using PizzaStore.Repositories.IRepositories;
using PizzaStore.Services.IServices;
using PizzaStore.Validators;

namespace PizzaStore.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PizzaDto> _validator;

        public PizzaService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<PizzaDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<PizzaDto>> GetAllPizzasAsync()
        {
            var pizzas = await _unitOfWork.PizzaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PizzaDto>>(pizzas);
        }

        public async Task<PizzaDto?> GetPizzaByIdAsync(Guid id)
        {
            var pizza = await _unitOfWork.PizzaRepository.GetByIdAsync(id);
            return pizza is null ? null : _mapper.Map<PizzaDto>(pizza);
        }

        public async Task AddPizzaAsync(PizzaDto pizzaDto)
        {
            var result = _validator.Validate(pizzaDto);

            if (result.IsValid)
            {
                var pizza = _mapper.Map<Pizza>(pizzaDto);
                await _unitOfWork.PizzaRepository.AddAsync(pizza);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdatePizzaAsync(PizzaDto pizzaDto)
        {
            var result = _validator.Validate(pizzaDto);

            if (result.IsValid)
            {
                var pizza = await _unitOfWork.PizzaRepository.GetByIdAsync(pizzaDto.Id);
                if (pizza is null)
                    throw new KeyNotFoundException("Pizza not found");

                //_mapper.Map<Pizza>(PizzaDto);
                _unitOfWork.PizzaRepository.Update(pizza);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeletePizzaAsync(Guid id);
        public async Task<PizzaDto?> GetPizzaBySizeAsync(PizzaSize size);
        public async Task<PizzaDto?> GetPizzaByPriceAsync(decimal price);
        public async Task<PizzaDto?> GetPizzaByPriceRangeAsync(decimal priceStart, decimal priceEnd);
    }
}
