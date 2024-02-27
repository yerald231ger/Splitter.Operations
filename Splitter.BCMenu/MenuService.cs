using Splitter.Extentions.Interface.Abstractions;
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

    public async Task<SptResult> CreateProduct(CreateProductCommand command)
    {
        var menu = await _unitOfWork.MenuRepository.GetByIdAsync(command.MenuId);

        if (menu == null)
        {
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.MenuNotFound, MenuRejectCodes.MenuNotFound.GetDescription());
        }

        if(command.ProductId == Guid.Empty)
        {
            return _sptInterface.Reject(command.CommandId, MenuRejectCodes.ProductIdRequired, MenuRejectCodes.MenuNotFound.GetDescription());
        }

        var product = Menu.CreateProduct(command.ProductId, command.ProductName, command.ProductPrice);

        menu.AddProduct(product);
        await _unitOfWork.UpdateMenu(menu);
        await _unitOfWork.SaveChangesAsync();
        return _sptInterface.CompleteCreate(command.CommandId, product);
    }
}
