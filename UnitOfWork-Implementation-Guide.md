# Unit of Work Pattern Implementation Guide

## Overview

This project has been successfully refactored to implement the **Unit of Work** design pattern, which provides a clean way to manage database transactions and coordinate work between multiple repositories.

## Key Components

### 1. IUnitOfWork Interface
- **Location**: `Persistence/UnitOfWork/IUnitOfWork.cs`
- **Purpose**: Defines the contract for the Unit of Work pattern
- **Features**:
  - Repository properties for all entities
  - Transaction management methods
  - ExecuteInTransactionAsync for atomic operations

### 2. UnitOfWork Implementation
- **Location**: `Persistence/UnitOfWork/UnitOfWork.cs`
- **Purpose**: Concrete implementation of the Unit of Work pattern
- **Features**:
  - Lazy initialization of repositories
  - Transaction management with automatic rollback on exceptions
  - Proper disposal of resources

### 3. Generic Repository Pattern
- **Interface**: `Persistence/Repositories/IRepository.cs`
- **Implementation**: `Persistence/Repositories/Repository.cs`
- **Purpose**: Provides common CRUD operations for all entities
- **Features**:
  - Soft delete support (IsActive flag)
  - Include support for related entities
  - Async operations throughout

## Benefits of This Implementation

### 1. Transaction Management
```csharp
// Automatic transaction management
var result = await _unitOfWork.ExecuteInTransactionAsync(async () =>
{
    var offer = await _unitOfWork.Offers.CreateOfferAsync(newOffer);
    await _unitOfWork.Offers.SaveOfferForUserAsync(offer.Id, userId, notes);
    return offer;
});
```

### 2. Manual Transaction Control
```csharp
// Manual transaction management
await _unitOfWork.BeginTransactionAsync();
try
{
    // Multiple operations
    await _unitOfWork.SaveChangesAsync();
    await _unitOfWork.CommitTransactionAsync();
}
catch
{
    await _unitOfWork.RollbackTransactionAsync();
    throw;
}
```

### 3. Repository Access
```csharp
// Access to all repositories through Unit of Work
var offers = await _unitOfWork.Offers.GetAllOffersAsync();
var categories = await _unitOfWork.OfferCategories.FindAsync(c => c.IsActive);
var locations = await _unitOfWork.OfferLocations.GetAllAsync();
```

## Updated Architecture

### Before (Repository Pattern)
```
Controller → Service → Repository → DbContext
```

### After (Unit of Work Pattern)
```
Controller → Service → UnitOfWork → Repositories → DbContext
```

## Key Changes Made

### 1. Services Updated
- **OfferService**: Now uses `IUnitOfWork` instead of individual repositories
- **OfferShareService**: Refactored to use Unit of Work pattern
- All write operations now use transactions for consistency

### 2. Repositories Updated
- Removed `SaveChangesAsync()` calls from repositories
- Transaction management is now handled by Unit of Work
- Repositories focus on data access only

### 3. Dependency Injection Updated
- Added `IUnitOfWork` registration
- Added generic `IRepository<T>` registration
- Maintained backward compatibility with existing repositories

## Usage Examples

### 1. Simple Query Operations
```csharp
public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
{
    return await _unitOfWork.Offers.GetActiveOffersAsync();
}
```

### 2. Complex Operations with Transactions
```csharp
public async Task<Offer> CreateOfferWithDependenciesAsync(Offer offer, List<int> locationIds)
{
    return await _unitOfWork.ExecuteInTransactionAsync(async () =>
    {
        var createdOffer = await _unitOfWork.Offers.CreateOfferAsync(offer);
        
        // Add locations to the offer
        foreach (var locationId in locationIds)
        {
            var location = await _unitOfWork.OfferLocations.GetByIdAsync(locationId);
            if (location != null)
            {
                createdOffer.Locations.Add(location);
            }
        }
        
        await _unitOfWork.SaveChangesAsync();
        return createdOffer;
    });
}
```

### 3. Using Generic Repository
```csharp
public async Task<IEnumerable<OfferCategory>> GetActiveCategoriesAsync()
{
    return await _unitOfWork.OfferCategories.FindAsync(c => c.IsActive);
}

public async Task<int> GetCategoryCountAsync()
{
    return await _unitOfWork.OfferCategories.CountAsync();
}
```

## Best Practices

### 1. Service Layer
- Always use `IUnitOfWork` instead of individual repositories
- Use `ExecuteInTransactionAsync` for operations that modify multiple entities
- Let Unit of Work handle transaction management

### 2. Repository Layer
- Don't call `SaveChangesAsync()` in repositories
- Focus on data access operations only
- Use generic repository for simple CRUD operations

### 3. Controller Layer
- Controllers should only interact with services
- Services handle all business logic and transaction management
- No direct Unit of Work usage in controllers

## Error Handling

The Unit of Work pattern provides automatic rollback on exceptions:

```csharp
try
{
    var result = await _unitOfWork.ExecuteInTransactionAsync(async () =>
    {
        // Multiple operations
        return await SomeComplexOperation();
    });
}
catch (Exception ex)
{
    // Transaction automatically rolled back
    // Handle the error appropriately
}
```

## Performance Considerations

1. **Lazy Loading**: Repositories are created only when accessed
2. **Transaction Scope**: Keep transactions as short as possible
3. **Connection Management**: Unit of Work manages database connections efficiently
4. **Memory Management**: Proper disposal of resources

## Testing

The Unit of Work pattern makes testing easier:

```csharp
// Mock the Unit of Work interface
var mockUnitOfWork = new Mock<IUnitOfWork>();
var mockOfferRepository = new Mock<IOfferRepository>();

mockUnitOfWork.Setup(u => u.Offers).Returns(mockOfferRepository.Object);

// Test your service
var service = new OfferService(mockUnitOfWork.Object);
```

## Migration Notes

- All existing functionality is preserved
- Services now use Unit of Work internally
- Controllers remain unchanged
- Database operations are now more consistent and reliable

## Conclusion

The Unit of Work pattern implementation provides:
- ✅ Better transaction management
- ✅ Improved data consistency
- ✅ Cleaner separation of concerns
- ✅ Easier testing
- ✅ Better error handling
- ✅ Reduced code duplication

This implementation follows industry best practices and makes the codebase more maintainable and robust.
