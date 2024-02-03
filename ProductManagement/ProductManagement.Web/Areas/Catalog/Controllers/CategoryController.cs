using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Features.Categories.Commands.Create;
using ProductManagement.Application.Features.Categories.Commands.Delete;
using ProductManagement.Application.Features.Categories.Commands.Update;
using ProductManagement.Application.Features.Categories.Queries.GetAllCached;
using ProductManagement.Application.Features.Categories.Queries.GetById;
using ProductManagement.Web.Abstractions;
using ProductManagement.Web.Areas.Catalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Web.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class CategoryController : BaseController<CategoryController>
    {
        public IActionResult Index()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllCategoriesCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<CategoryViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            var CategoriesResponse = await _mediator.Send(new GetAllCategoriesCachedQuery());

            if (id == 0)
            {
                var CategoryViewModel = new CategoryViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", CategoryViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetCategoryByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var CategoryViewModel = _mapper.Map<CategoryViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", CategoryViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, CategoryViewModel Category)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createCategoryCommand = _mapper.Map<CreateCategoryCommand>(Category);
                    var result = await _mediator.Send(createCategoryCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Category with ID {result.Data} Created.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(Category);
                    var result = await _mediator.Send(updateCategoryCommand);
                    if (result.Succeeded) _notify.Information($"Category with ID {result.Data} Updated.");
                }
                var response = await _mediator.Send(new GetAllCategoriesCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CategoryViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", Category);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteCategoryCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Category with Id {id} Deleted.");
                var response = await _mediator.Send(new GetAllCategoriesCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CategoryViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }
    }
}