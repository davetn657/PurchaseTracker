using Microsoft.EntityFrameworkCore;
using PurchaseTracker.Api.Data;
using PurchaseTracker.Api.Dtos;
using PurchaseTracker.Api.Interfaces;
using PurchaseTracker.Api.Mappers;

namespace PurchaseTracker.Api.Repository;

public class PurchaseItemRepository : IPurchaseItemsRepository
{
    private readonly ApplicationDbContext _context;
    public PurchaseItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PurchaseItemDto> CreateItem(PurchaseItemDto itemDto)
    {
        var item = itemDto.ToPurchaseItem();

        await _context.Purchases.AddAsync(item);
        await _context.SaveChangesAsync();

        return itemDto;
    }

    public async Task<PurchaseItemDto?> DeleteItem(int id)
    {
        var item = await _context.Purchases.FirstOrDefaultAsync(p => p.Id == id);

        if (item == null) return null;

        _context.Purchases.Remove(item);
        await _context.SaveChangesAsync();

        return item.ToPurchaseDto();
    }

    public async Task<List<PurchaseItemDto>> GetAllItems()
    {
        var items = await _context.Purchases.Select(p => p.ToPurchaseDto()).ToListAsync();

        return items;
    }

    public async Task<PurchaseItemDto?> GetItemById(int id)
    {
        var item = await _context.Purchases.FirstOrDefaultAsync(p => p.Id == id);

        if (item == null) return null;

        return item.ToPurchaseDto();
    }

    public async Task<PurchaseItemDto?> UpdateItem(int id, PurchaseItemDto updatedItemDto)
    {
        var item = await _context.Purchases.FirstOrDefaultAsync(p => p.Id == id);

        if (item == null) return null;

        item.ItemName = updatedItemDto.ItemName;
        item.Price = updatedItemDto.Price;
        item.Quantity = updatedItemDto.Quantity;
        item.PurchaseDate = updatedItemDto.PurchaseDate;
        item.PaymentStatus = updatedItemDto.PaymentStatus;
        item.PaymentPrice = updatedItemDto.PaymentPrice;

        await _context.SaveChangesAsync();

        return item.ToPurchaseDto();
    }
}