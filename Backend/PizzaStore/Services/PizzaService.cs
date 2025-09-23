using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using PizzaStore.DTOs;
using PizzaStore.Entities;
using PizzaStore.Enums;
using PizzaStore.Repositories.IRepositories;
using PizzaStore.Services.IServices;
using PizzaStore.Validators;
using System.Collections.Generic;

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
            await ValidateAsync(pizzaDto);
            
            var pizza = _mapper.Map<Pizza>(pizzaDto);
            await _unitOfWork.PizzaRepository.AddAsync(pizza);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePizzaAsync(PizzaDto pizzaDto)
        {
            await ValidateAsync(pizzaDto);

            var pizza = await _unitOfWork.PizzaRepository.GetByIdAsync(pizzaDto.Id);
            if (pizza is null)
                throw new KeyNotFoundException("Pizza not found");

            _unitOfWork.PizzaRepository.Update(pizza);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePizzaAsync(Guid id)
        {
            var pizza = await _unitOfWork.PizzaRepository.GetByIdAsync(id);

            if (pizza is null)
                throw new KeyNotFoundException("Pizza not found");
            else
            {
                _unitOfWork.PizzaRepository.Remove(pizza);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task ValidateAsync(PizzaDto dto)
        {
            var result = await _validator.ValidateAsync(dto);
            
            if (!result.IsValid)
                throw new ValidationException(string.Join("; ", result.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
