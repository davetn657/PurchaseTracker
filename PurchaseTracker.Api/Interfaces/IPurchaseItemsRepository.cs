using PurchaseTracker.Api.Dtos;
using PurchaseTracker.Api.Models;

namespace PurchaseTracker.Api.Interfaces;

public interface IPurchaseItemsRepository
{
    public Task<PurchaseItemDto?> GetItemById(int id);
    public Task<List<PurchaseItemDto>> GetAllItems();
    public Task<PurchaseItem> CreateItem(PurchaseItemDto itemDto);
    public Task<PurchaseItemDto?> UpdateItem(int id, PurchaseItemDto updatedItemDto);
    public Task<PurchaseItemDto?> DeleteItem(int id);
}