# Offers API Database

This project implements a comprehensive offers management system with Entity Framework Core and SQL Server.

## 🏗️ Project Structure

```
Offersapi/
├── Domain/                 # Domain entities and business logic
│   ├── Entities/          # Core business entities
│   │   ├── Offer.cs       # Main offer entity
│   │   ├── OfferCategory.cs
│   │   ├── OfferLocation.cs
│   │   ├── OfferPlatform.cs
│   │   ├── OfferSharingMethod.cs
│   │   ├── Dependent.cs
│   │   └── SavedOffer.cs
├── Persistence/           # Data access layer
│   ├── Context/           # Database context and configuration
│   ├── Repositories/      # Data access repositories
│   └── Services/          # Business logic services
└── DatabaseTest/          # Console application to test the database
```

## 🗄️ Database Schema

### Entity Relationships

```
OfferCategory (1) ←→ (Many) Offer
OfferLocation (1) ←→ (Many) Offer
OfferPlatform (Many) ←→ (Many) Offer
OfferSharingMethod (Many) ←→ (Many) Offer
Dependent (1) ←→ (Many) Offer
Offer (1) ←→ (Many) SavedOffer
```

### Core Entities

#### Offer
- **Id**: Primary key
- **Title**: Offer title (max 200 chars)
- **Description**: Detailed description (max 1000 chars)
- **DiscountPercentage**: Discount percentage (0-100%)
- **CreatedAt**: When the offer was created
- **ValidFrom**: When the offer becomes valid (start time)
- **ValidUntil**: When the offer expires (end time)
- **IsActive**: Whether the offer is currently active
- **CategoryId**: Reference to offer category (one category can have many offers)
- **LocationId**: Reference to offer location
- **DependentId**: Reference to dependent type (optional)
- **ImageUrl**: Optional image URL
- **Name**: Service/Company name
- **MaxUses**: Maximum number of times offer can be used
- **CurrentUses**: Current usage count
- **CouponCode**: Optional coupon code
- **MinimumPurchase**: Minimum purchase amount to use offer
- **IsStackable**: Whether offer can be combined with others
- **TermsAndConditions**: Terms and conditions for the offer

#### OfferCategory
- **Id**: Primary key
- **Name**: Category name (max 100 chars)
- **Description**: Category description (max 500 chars)
- **Icon**: Emoji or icon representation
- **IsActive**: Whether category is active
- **Offers**: Collection of offers in this category (one category can have many offers)

#### OfferLocation
- **Id**: Primary key
- **Name**: Location name (max 200 chars)
- **Address**: Full address (max 500 chars)
- **City**: City name (max 100 chars)
- **State**: State/province (max 100 chars)
- **PostalCode**: ZIP/postal code (max 20 chars)
- **Country**: Country name (max 100 chars)
- **Latitude/Longitude**: GPS coordinates
- **IsActive**: Whether location is active

#### OfferPlatform
- **Id**: Primary key
- **Name**: Platform name (max 100 chars)
- **Description**: Platform description (max 500 chars)
- **Icon**: Emoji or icon representation
- **IsActive**: Whether platform is active

#### OfferSharingMethod
- **Id**: Primary key
- **Name**: Sharing method name (max 100 chars)
- **Description**: Sharing method description (max 500 chars)
- **Icon**: Emoji or icon representation
- **IsActive**: Whether sharing method is active

#### Dependent
- **Id**: Primary key
- **Relationship**: Relationship type in Arabic (max 50 chars)
- **RelationshipEnglish**: Relationship type in English (max 50 chars)
- **IsActive**: Whether dependent type is active

#### SavedOffer
- **Id**: Primary key
- **OfferId**: Reference to offer
- **UserId**: User identifier
- **SavedAt**: When offer was saved
- **Notes**: Optional user notes (max 500 chars)

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB recommended for development)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Offersapi
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

### Database Setup

1. **Run the database test application**
   ```bash
   cd DatabaseTest
   dotnet run
   ```

   This will:
   - Create the database automatically
   - Seed initial data (categories, locations, usage methods)
   - Add sample offers
   - Display all data for verification

2. **Verify database creation**
   - Check SQL Server Object Explorer in Visual Studio
   - Database name: `OffersDb`
   - Tables: `Offers`, `OfferCategories`, `OfferLocations`, `OfferPlatforms`, `OfferSharingMethods`, `Dependents`, `SavedOffers`, `OfferPlatforms`, `OfferSharingMethods`

## 📊 Sample Data

The system comes pre-populated with:

### Categories
- 🎯 عروض متنوعة (Diverse Offers)
- 🏦 خدمات مصرفيه (Banking Services)
- 🏥 صحة وطب (Health & Medicine)
- ✈️ سفر وسياحة (Travel & Tourism)
- 🛍️ تسوق وبيع (Shopping & Retail)

### Locations
- الرياض (Riyadh)
- جدة (Jeddah)
- أونلاين (Online)

### Platforms
- 🌐 موقع (Website)
- 📱 تطبيق (Mobile App)
- 💬 واتساب (WhatsApp)
- 📢 وسائل التواصل (Social Media)
- 📧 بريد إلكتروني (Email)

### Sharing Methods
- 👨‍👩‍👧‍👦 مشاركة مع التابعين (Share with Dependents)
- 👥 مشاركة مع منسوبي الأمانة (Share with Municipality Employees)
- 📱 مشاركة على وسائل التواصل (Share on Social Media)
- 🔗 رابط مباشر (Direct Link)
- 🚫 لا يمكن المشاركة (Cannot be Shared)

### Dependents
- زوجة (Wife)
- ابن (Son)
- أبنة (Daughter)
- أب (Father)
- أم (Mother)

### Sample Offers
- المسافر (Almosafar) - 50% off hotel bookings
- مستشفى المملكة (Kingdom Hospital) - 30% off medical consultations
- بنك الجزيرة (AlJazira Bank) - 25% off banking services
- مطعم اللوفر (Louvre Restaurant) - 40% off meals
- صالون الجمال (Beauty Salon) - 35% off beauty services

## 🔧 Configuration

### Connection Strings

Default connection strings are defined in `Persistence/Context/ConnectionStrings.cs`:

```csharp
public const string DefaultConnection = "Server=(localdb)\\mssqllocaldb;Database=OffersDb;Trusted_Connection=true;MultipleActiveResultSets=true";
public const string DevelopmentConnection = "Server=(localdb)\\mssqllocaldb;Database=OffersDb_Dev;Trusted_Connection=true;MultipleActiveResultSets=true";
public const string TestConnection = "Server=(localdb)\\mssqllocaldb;Database=OffersDb_Test;Trusted_Connection=true;MultipleActiveResultSets=true";
```

### Customizing Connection

To use a different database:

1. **Modify connection string** in `Persistence/DependencyInjection.cs`
2. **Update appsettings.json** in your main application
3. **Run migrations** or use `EnsureCreatedAsync()`

## 🏗️ Architecture

### Repository Pattern
- **IOfferRepository**: Data access interface
- **OfferRepository**: Entity Framework implementation
- **IOfferService**: Business logic interface
- **OfferService**: Business logic implementation

### Dependency Injection
Services are registered in `Persistence/DependencyInjection.cs`:

```csharp
services.AddDbContext<OffersDbContext>();
services.AddScoped<IOfferRepository, OfferRepository>();
services.AddScoped<IOfferService, OfferService>();
```

## 📝 Usage Examples

### Basic CRUD Operations

```csharp
// Get all active offers
var activeOffers = await offerService.GetActiveOffersAsync();

// Search offers
var searchResults = await offerService.SearchOffersAsync("pizza");

// Create new offer
var newOffer = new Offer
{
    Title = "New Offer",
    Description = "Description",
    DiscountPercentage = 25.0m, // 25% off
    CategoryId = 1,
    LocationId = 1,
    DependentId = 1
};
var createdOffer = await offerService.CreateOfferAsync(newOffer);

// Save offer for user
await offerService.SaveOfferForUserAsync(1, "user123", "Great deal!");
```

## 🧪 Testing

### Database Test Application
The `DatabaseTest` console application provides:

- Database creation verification
- Data seeding validation
- Sample data display
- Error handling demonstration

### Running Tests
```bash
cd DatabaseTest
dotnet run
```

## 🔍 Troubleshooting

### Common Issues

1. **Connection String Errors**
   - Verify SQL Server is running
   - Check LocalDB installation
   - Ensure connection string format is correct

2. **Migration Issues**
   - Use `EnsureCreatedAsync()` for development
   - Run `dotnet ef migrations add InitialCreate` for production

3. **Data Not Appearing**
   - Check seed data method execution
   - Verify entity configurations
   - Check foreign key relationships

## 📚 Next Steps

1. **Add API Controllers** for REST endpoints
2. **Implement Authentication** for user management
3. **Add Validation** using FluentValidation
4. **Create Unit Tests** for business logic
5. **Add Logging** with Serilog
6. **Implement Caching** with Redis
7. **Add API Documentation** with Swagger

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.
