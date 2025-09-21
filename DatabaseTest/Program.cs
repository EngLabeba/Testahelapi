using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Microsoft.Data.SqlClient;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing database seeding...");
            
            var connectionString = "Data Source=.;Initial Catalog=OffersDb;Integrated Security=True;TrustServerCertificate=True";
            
            // First, try to insert the seed data using raw SQL
            try
            {
                Console.WriteLine("Inserting seed data...");
                InsertSeedData(connectionString);
                Console.WriteLine("Seed data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting seed data: {ex.Message}");
            }
            
            // Then verify using Entity Framework
            var optionsBuilder = new DbContextOptionsBuilder<OffersDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            using var context = new OffersDbContext(optionsBuilder.Options);
            
            try
            {
                // Test Employee data
                var employeeCount = context.Employees.Count();
                Console.WriteLine($"Employees in database: {employeeCount}");
                
                if (employeeCount > 0)
                {
                    var firstEmployee = context.Employees.First();
                    Console.WriteLine($"First employee: {firstEmployee.Name} ({firstEmployee.EmployeeId})");
                }
                
                // Test SavedOffers data
                var savedOffersCount = context.SavedOffers.Count();
                Console.WriteLine($"Saved offers in database: {savedOffersCount}");
                
                if (savedOffersCount > 0)
                {
                    var firstSavedOffer = context.SavedOffers.First();
                    Console.WriteLine($"First saved offer: User {firstSavedOffer.UserId}, Offer {firstSavedOffer.OfferId}");
                }
                
                // Test Offers data
                var offersCount = context.Offers.Count();
                Console.WriteLine($"Offers in database: {offersCount}");
                
                Console.WriteLine("Database seeding verification completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        static void InsertSeedData(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            
            // Insert Employee data
            var employeeSql = @"
                IF NOT EXISTS (SELECT 1 FROM Employees WHERE Id = 1)
                BEGIN
                    INSERT INTO Employees (Id, EmployeeId, Name, NameEnglish, Position, PositionEnglish, Rank, Department, DepartmentEnglish, Email, PhoneNumber, CreatedAt, IsActive)
                    VALUES 
                    (1, 'EMP001', 'محمد عبدالله أحمد', 'Mohammed Abdullah Ahmed', 'مدير وحدة التصوير', 'Director of Photography Unit', 8, 'إدارة الإعلام والاتصال المؤسسي', 'Media and Corporate Communication Department', 'mohammed.ahmed@riyadh.gov.sa', '+966501234567', GETUTCDATE(), 1),
                    (2, 'EMP002', 'فاطمة محمد السعيد', 'Fatima Mohammed Al-Saeed', 'أخصائية علاقات عامة', 'Public Relations Specialist', 6, 'إدارة الإعلام والاتصال المؤسسي', 'Media and Corporate Communication Department', 'fatima.alsaeed@riyadh.gov.sa', '+966501234568', GETUTCDATE(), 1),
                    (3, 'EMP003', 'أحمد خالد المطيري', 'Ahmed Khalid Al-Mutairi', 'مطور تطبيقات', 'Application Developer', 7, 'إدارة تقنية المعلومات', 'Information Technology Department', 'ahmed.almutairi@riyadh.gov.sa', '+966501234569', GETUTCDATE(), 1),
                    (4, 'EMP004', 'نورا عبدالرحمن القحطاني', 'Nora Abdulrahman Al-Qahtani', 'محاسبة', 'Accountant', 5, 'إدارة المالية', 'Finance Department', 'nora.alqahtani@riyadh.gov.sa', '+966501234570', GETUTCDATE(), 1),
                    (5, 'EMP005', 'سعد محمد الغامدي', 'Saad Mohammed Al-Ghamdi', 'مدير الموارد البشرية', 'Human Resources Manager', 9, 'إدارة الموارد البشرية', 'Human Resources Department', 'saad.alghamdi@riyadh.gov.sa', '+966501234571', GETUTCDATE(), 1);
                END";
            
            using var employeeCommand = new SqlCommand(employeeSql, connection);
            employeeCommand.ExecuteNonQuery();
            
            // Insert SavedOffers data (only if offers exist)
            var savedOffersSql = @"
                IF EXISTS (SELECT 1 FROM Offers WHERE Id = 1) AND NOT EXISTS (SELECT 1 FROM SavedOffers WHERE Id = 1)
                BEGIN
                    INSERT INTO SavedOffers (Id, OfferId, UserId, SavedAt, Notes, IsUsed, UsedAt, CreatedAt, IsActive)
                    VALUES 
                    (1, 1, 'user123', DATEADD(day, -5, GETUTCDATE()), 'ملاحظة للمستخدم user123', 0, NULL, DATEADD(day, -5, GETUTCDATE()), 1),
                    (2, 2, 'user456', DATEADD(day, -10, GETUTCDATE()), NULL, 1, DATEADD(day, -3, GETUTCDATE()), DATEADD(day, -10, GETUTCDATE()), 1),
                    (3, 3, 'user789', DATEADD(day, -15, GETUTCDATE()), 'ملاحظة للمستخدم user789', 0, NULL, DATEADD(day, -15, GETUTCDATE()), 1),
                    (4, 4, 'user101', DATEADD(day, -20, GETUTCDATE()), NULL, 1, DATEADD(day, -8, GETUTCDATE()), DATEADD(day, -20, GETUTCDATE()), 1),
                    (5, 5, 'user202', DATEADD(day, -25, GETUTCDATE()), 'ملاحظة للمستخدم user202', 0, NULL, DATEADD(day, -25, GETUTCDATE()), 1);
                END";
            
            using var savedOffersCommand = new SqlCommand(savedOffersSql, connection);
            savedOffersCommand.ExecuteNonQuery();
        }
    }
}