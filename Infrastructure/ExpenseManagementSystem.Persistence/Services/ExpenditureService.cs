using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Application.Helpers;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ExpenditureService(IUnitOfWork unitOfWork, IExpenditureRepository expenditureRepository, IMapper mapper, IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Expenditure> CreateAsync(ExpenditureRequestDto model)
        {

            var isReceiptUsed = await _expenditureRepository.AnyAsync(x =>
                x.ReceiptNumber == model.ReceiptNumber && x.IsActive);
            if (isReceiptUsed)
                throw new ConflictException("Bu fiş numarası daha önce kullanılmış.");

            var isCategoryValid = await _categoryRepository.AnyAsync(x =>
                x.Id == model.CategoryId && x.IsActive);
            if (!isCategoryValid)
                throw new ConflictException("Geçerli bir kategori seçiniz.");

            var isExpenseValid = await _expenseRepository.AnyAsync(x =>
                x.Id == model.ExpenseId && x.IsActive);
            if (!isExpenseValid)
                throw new ConflictException("Geçerli bir harcama başvurusu bulunamadı.");

            var entity = _mapper.Map<Expenditure>(model);
            entity.ReceiptFilePath = await FileHelper.SaveFileAsync(model.ReceiptFile);
            entity.IsActive = true;

            await _expenditureRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }


        public async Task<Expenditure> UpdateAsync(long id, ExpenditureRequestDto model)
        {
            var entity = await _expenditureRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Harcama kaydı bulunamadı.");

            var isReceiptUsed = await _expenditureRepository.AnyAsync(x =>
                x.ReceiptNumber == model.ReceiptNumber && x.Id != id && x.IsActive);
            if (isReceiptUsed)
                throw new ConflictException("Bu fiş numarası başka bir kayıtla eşleşiyor.");

            var isCategoryValid = await _categoryRepository.AnyAsync(x =>
                x.Id == model.CategoryId && x.IsActive);
            if (!isCategoryValid)
                throw new ConflictException("Geçerli bir kategori seçiniz.");

            var isExpenseValid = await _expenseRepository.AnyAsync(x =>
                x.Id == model.ExpenseId && x.IsActive);
            if (!isExpenseValid)
                throw new ConflictException("Geçerli bir harcama başvurusu bulunamadı.");

            _mapper.Map(model, entity);
            _expenditureRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> SoftDeleteAsync(long id)
        {
            var entity = await _expenditureRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Harcama kaydı bulunamadı.");

            if (!entity.IsActive)
                throw new ConflictException("Bu harcama zaten silinmiş.");

            entity.IsActive = false;
            _expenditureRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
