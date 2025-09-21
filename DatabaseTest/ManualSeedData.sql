-- Manual Seed Data for Employee and SavedOffers Tables
-- Run this script in SQL Server Management Studio or any SQL client

USE OffersDb;
GO

-- Insert Employee data (only if not exists)
IF NOT EXISTS (SELECT 1 FROM Employees WHERE Id = 1)
BEGIN
    INSERT INTO Employees (Id, EmployeeId, Name, NameEnglish, Position, PositionEnglish, Rank, Department, DepartmentEnglish, Email, PhoneNumber, CreatedAt, IsActive)
    VALUES 
    (1, 'EMP001', 'محمد عبدالله أحمد', 'Mohammed Abdullah Ahmed', 'مدير وحدة التصوير', 'Director of Photography Unit', 8, 'إدارة الإعلام والاتصال المؤسسي', 'Media and Corporate Communication Department', 'mohammed.ahmed@riyadh.gov.sa', '+966501234567', GETUTCDATE(), 1),
    (2, 'EMP002', 'فاطمة محمد السعيد', 'Fatima Mohammed Al-Saeed', 'أخصائية علاقات عامة', 'Public Relations Specialist', 6, 'إدارة الإعلام والاتصال المؤسسي', 'Media and Corporate Communication Department', 'fatima.alsaeed@riyadh.gov.sa', '+966501234568', GETUTCDATE(), 1),
    (3, 'EMP003', 'أحمد خالد المطيري', 'Ahmed Khalid Al-Mutairi', 'مطور تطبيقات', 'Application Developer', 7, 'إدارة تقنية المعلومات', 'Information Technology Department', 'ahmed.almutairi@riyadh.gov.sa', '+966501234569', GETUTCDATE(), 1),
    (4, 'EMP004', 'نورا عبدالرحمن القحطاني', 'Nora Abdulrahman Al-Qahtani', 'محاسبة', 'Accountant', 5, 'إدارة المالية', 'Finance Department', 'nora.alqahtani@riyadh.gov.sa', '+966501234570', GETUTCDATE(), 1),
    (5, 'EMP005', 'سعد محمد الغامدي', 'Saad Mohammed Al-Ghamdi', 'مدير الموارد البشرية', 'Human Resources Manager', 9, 'إدارة الموارد البشرية', 'Human Resources Department', 'saad.alghamdi@riyadh.gov.sa', '+966501234571', GETUTCDATE(), 1);
    
    PRINT 'Employee data inserted successfully!';
END
ELSE
BEGIN
    PRINT 'Employee data already exists.';
END
GO

-- Insert SavedOffers data (only if offers exist and not already inserted)
IF EXISTS (SELECT 1 FROM Offers WHERE Id = 1) AND NOT EXISTS (SELECT 1 FROM SavedOffers WHERE Id = 1)
BEGIN
    INSERT INTO SavedOffers (Id, OfferId, UserId, SavedAt, Notes, IsUsed, UsedAt, CreatedAt, IsActive)
    VALUES 
    (1, 1, 'user123', DATEADD(day, -5, GETUTCDATE()), 'ملاحظة للمستخدم user123', 0, NULL, DATEADD(day, -5, GETUTCDATE()), 1),
    (2, 2, 'user456', DATEADD(day, -10, GETUTCDATE()), NULL, 1, DATEADD(day, -3, GETUTCDATE()), DATEADD(day, -10, GETUTCDATE()), 1),
    (3, 3, 'user789', DATEADD(day, -15, GETUTCDATE()), 'ملاحظة للمستخدم user789', 0, NULL, DATEADD(day, -15, GETUTCDATE()), 1),
    (4, 4, 'user101', DATEADD(day, -20, GETUTCDATE()), NULL, 1, DATEADD(day, -8, GETUTCDATE()), DATEADD(day, -20, GETUTCDATE()), 1),
    (5, 5, 'user202', DATEADD(day, -25, GETUTCDATE()), 'ملاحظة للمستخدم user202', 0, NULL, DATEADD(day, -25, GETUTCDATE()), 1),
    (6, 6, 'user123', DATEADD(day, -2, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -2, GETUTCDATE()), 1),
    (7, 7, 'user456', DATEADD(day, -7, GETUTCDATE()), 'ملاحظة للمستخدم user456', 1, DATEADD(day, -1, GETUTCDATE()), DATEADD(day, -7, GETUTCDATE()), 1),
    (8, 8, 'user789', DATEADD(day, -12, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -12, GETUTCDATE()), 1),
    (9, 9, 'user101', DATEADD(day, -18, GETUTCDATE()), 'ملاحظة للمستخدم user101', 0, NULL, DATEADD(day, -18, GETUTCDATE()), 1),
    (10, 10, 'user202', DATEADD(day, -22, GETUTCDATE()), NULL, 1, DATEADD(day, -5, GETUTCDATE()), DATEADD(day, -22, GETUTCDATE()), 1);
    
    PRINT 'SavedOffers data inserted successfully!';
END
ELSE
BEGIN
    PRINT 'SavedOffers data already exists or no offers found.';
END
GO

-- Verify the data
SELECT 'Employees' as TableName, COUNT(*) as RecordCount FROM Employees
UNION ALL
SELECT 'SavedOffers' as TableName, COUNT(*) as RecordCount FROM SavedOffers
UNION ALL
SELECT 'Offers' as TableName, COUNT(*) as RecordCount FROM Offers;
GO

-- Show sample data
SELECT TOP 3 Id, EmployeeId, Name, Position, Department FROM Employees;
GO

SELECT TOP 3 Id, OfferId, UserId, SavedAt, IsUsed FROM SavedOffers;
GO
