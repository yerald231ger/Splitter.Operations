using Splitter.Extensions.Interface.Abstractions;
using Splitter.BCMenu.Constants;
using Splitter.BCMenu.Infrastructure;
using Splitter.BCMenu.Interface;
using Splitter.BCMenu.Models;
using Splitter.Extensions;

namespace Splitter.BCMenu;

public class MenuService(IMenuUnitOfWork unitOfWork, ISptInterface sptInterface)
{
    private readonly IMenuUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISptInterface _sptInterface = sptInterface;

    public async Task<SptResult> GetMenu(GetMenuCommand query)
    {
        var menu = await _unitOfWork.GetCompleteMenu(query.MenuId);

        if (menu == null)
            return _sptInterface.Reject(query.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        return _sptInterface.CompleteGet(query.CommandId, menu);
    }

    public async Task<SptResult> CreateMenu(CreateMenuCommand command)
    {
        if (command.MenuId == Guid.Empty)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuIdRequired, MenuRejectCodes.MenuIdRequired.GetDescription());

        var menu = Menu.Create(command.MenuId, command.EstablishmentId, command.MenuName, true);

        if (string.IsNullOrEmpty(command.MenuName))
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNameRequired, MenuRejectCodes.MenuNameRequired.GetDescription());

        await _unitOfWork.MenuRepository.AddAsync(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteCreate(command.CommandId, menu);
    }

    public async Task<SptResult> AddOrCreateProduct(AddOrCreateProductCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        if (command.ProductId == Guid.Empty)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.ProductIdRequired, MenuRejectCodes.MenuNotFound.GetDescription());

        menu.AddOrCreateProduct(command.ProductId, command.EstablishmentId, command.ProductName, command.ProductPrice);
        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteCreate(command.CommandId, menu.GetFirstProduct(command.ProductId)!);
    }

    public async Task<SptResult> RemoveProduct(DeleteProductCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        var product = menu.GetFirstProduct(command.ProductId);

        if (product == null)
            return _sptInterface.CompleteUpdate<Product>(command.CommandId);
        
        menu.RemoveProduct(product);
        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteUpdate(command.CommandId, product);
    }

    public async Task<SptResult> AddOrCreateCategory(CreateCategoryCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        if (command.CategoryId == Guid.Empty)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.CategoryIdRequired, MenuRejectCodes.CategoryIdRequired.GetDescription());

        if (string.IsNullOrEmpty(command.CategoryName))
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.CategoryNameRequired, MenuRejectCodes.CategoryNameRequired.GetDescription());

        menu.AddOrCreateCategory(command.CategoryId, command.EstablishmentId, command.CategoryName);

        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteCreate(command.CommandId, menu);
    }

    public async Task<SptResult> RemoveCategory(DeleteCategoryCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        var category = menu.Categories.FirstOrDefault();

        if (category == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.CategoryNotFound, MenuRejectCodes.CategoryNotFound.GetDescription());

        menu.RemoveCategory(category);
        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteUpdate(command.CommandId, category);
    }

    public async Task<SptResult> CreateLayout(CreateLayoutCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        var layout = Menu.CreateLayout(command.MenuId, command.LayoutId, command.Layout, command.LayoutName);
        menu.AddLayout(layout);
        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteCreate(command.CommandId, menu);
    }

    public async Task<SptResult> UpdateProduct(UpdateProductCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        if (command.ProductId == Guid.Empty)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.ProductIdRequired, MenuRejectCodes.ProductIdRequired.GetDescription());

        if (menu.HasProduct(command.ProductId))
            menu.UpdateProduct(command.ProductId, command.ProductName, command.ProductPrice, command.ProductDescription);
        else
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.ProductNotFound, MenuRejectCodes.ProductNotFound.GetDescription());

        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteUpdate(command.CommandId, menu);
    }

    public async Task<SptResult> UpdateCategory(UpdateCategoryCommand command)
    {
        var menu = await _unitOfWork.GetCompleteMenu(command.MenuId);

        if (menu == null)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());

        if (command.CategoryId == Guid.Empty)
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.CategoryIdRequired, MenuRejectCodes.CategoryIdRequired.GetDescription());

        if (menu.HasCategory(command.CategoryId))
            menu.UpdateCategory(command.CategoryId, command.CategoryName);
        else
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.CategoryNotFound, MenuRejectCodes.CategoryNotFound.GetDescription());

        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteUpdate(command.CommandId, menu);
    }

}
