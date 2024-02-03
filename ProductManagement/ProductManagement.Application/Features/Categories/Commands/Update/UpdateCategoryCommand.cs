using AspNetCoreHero.Results;
using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICategoryRepository _CategoryRepository;

            public UpdateProductCommandHandler(ICategoryRepository CategoryRepository, IUnitOfWork unitOfWork)
            {
                _CategoryRepository = CategoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
            {
                var Category = await _CategoryRepository.GetByIdAsync(command.Id);

                if (Category == null)
                {
                    return Result<int>.Fail($"Category Not Found.");
                }
                else
                {
                    Category.Name = command.Name ?? Category.Name;
                    Category.Description = command.Description ?? Category.Description;
                    await _CategoryRepository.UpdateAsync(Category);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Category.Id);
                }
            }
        }
    }
}