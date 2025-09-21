-- Insert Employee data
INSERT INTO Employees (Id, EmployeeId, Name, NameEnglish, Position, PositionEnglish, Rank, Department, DepartmentEnglish, Email, PhoneNumber, CreatedAt, IsActive)
VALUES 
(1, 'EMP001', 'محمد عبدالله أحمد', 'Mohammed Abdullah Ahmed', 'مدير وحدة التصوير', 'Director of Photography Unit', 8, 'إدارة الإعلام والاتصال المؤسسي', 'Media and Corporate Communication Department', 'mohammed.ahmed@riyadh.gov.sa', '+966501234567', GETUTCDATE(), 1),
(2, 'EMP002', 'فاطمة محمد السعيد', 'Fatima Mohammed Al-Saeed', 'أخصائية علاقات عامة', 'Public Relations Specialist', 6, 'إدارة الإعلام والاتصال المؤسسي', 'Media and Corporate Communication Department', 'fatima.alsaeed@riyadh.gov.sa', '+966501234568', GETUTCDATE(), 1),
(3, 'EMP003', 'أحمد خالد المطيري', 'Ahmed Khalid Al-Mutairi', 'مطور تطبيقات', 'Application Developer', 7, 'إدارة تقنية المعلومات', 'Information Technology Department', 'ahmed.almutairi@riyadh.gov.sa', '+966501234569', GETUTCDATE(), 1),
(4, 'EMP004', 'نورا عبدالرحمن القحطاني', 'Nora Abdulrahman Al-Qahtani', 'محاسبة', 'Accountant', 5, 'إدارة المالية', 'Finance Department', 'nora.alqahtani@riyadh.gov.sa', '+966501234570', GETUTCDATE(), 1),
(5, 'EMP005', 'سعد محمد الغامدي', 'Saad Mohammed Al-Ghamdi', 'مدير الموارد البشرية', 'Human Resources Manager', 9, 'إدارة الموارد البشرية', 'Human Resources Department', 'saad.alghamdi@riyadh.gov.sa', '+966501234571', GETUTCDATE(), 1);

-- Insert SavedOffers data
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
(10, 10, 'user202', DATEADD(day, -22, GETUTCDATE()), NULL, 1, DATEADD(day, -5, GETUTCDATE()), DATEADD(day, -22, GETUTCDATE()), 1),
(11, 11, 'user123', DATEADD(day, -3, GETUTCDATE()), 'ملاحظة للمستخدم user123', 0, NULL, DATEADD(day, -3, GETUTCDATE()), 1),
(12, 12, 'user456', DATEADD(day, -8, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -8, GETUTCDATE()), 1),
(13, 13, 'user789', DATEADD(day, -13, GETUTCDATE()), 'ملاحظة للمستخدم user789', 1, DATEADD(day, -2, GETUTCDATE()), DATEADD(day, -13, GETUTCDATE()), 1),
(14, 14, 'user101', DATEADD(day, -19, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -19, GETUTCDATE()), 1),
(15, 15, 'user202', DATEADD(day, -24, GETUTCDATE()), 'ملاحظة للمستخدم user202', 0, NULL, DATEADD(day, -24, GETUTCDATE()), 1),
(16, 16, 'user123', DATEADD(day, -1, GETUTCDATE()), NULL, 1, GETUTCDATE(), DATEADD(day, -1, GETUTCDATE()), 1),
(17, 17, 'user456', DATEADD(day, -6, GETUTCDATE()), 'ملاحظة للمستخدم user456', 0, NULL, DATEADD(day, -6, GETUTCDATE()), 1),
(18, 18, 'user789', DATEADD(day, -11, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -11, GETUTCDATE()), 1),
(19, 19, 'user101', DATEADD(day, -17, GETUTCDATE()), 'ملاحظة للمستخدم user101', 1, DATEADD(day, -4, GETUTCDATE()), DATEADD(day, -17, GETUTCDATE()), 1),
(20, 20, 'user202', DATEADD(day, -21, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -21, GETUTCDATE()), 1),
(21, 21, 'user123', DATEADD(day, -4, GETUTCDATE()), 'ملاحظة للمستخدم user123', 0, NULL, DATEADD(day, -4, GETUTCDATE()), 1),
(22, 22, 'user456', DATEADD(day, -9, GETUTCDATE()), NULL, 1, DATEADD(day, -6, GETUTCDATE()), DATEADD(day, -9, GETUTCDATE()), 1),
(23, 23, 'user789', DATEADD(day, -14, GETUTCDATE()), 'ملاحظة للمستخدم user789', 0, NULL, DATEADD(day, -14, GETUTCDATE()), 1),
(24, 24, 'user101', DATEADD(day, -16, GETUTCDATE()), NULL, 0, NULL, DATEADD(day, -16, GETUTCDATE()), 1),
(25, 25, 'user202', DATEADD(day, -23, GETUTCDATE()), 'ملاحظة للمستخدم user202', 1, DATEADD(day, -7, GETUTCDATE()), DATEADD(day, -23, GETUTCDATE()), 1);

-- Verify the data
SELECT 'Employees' as TableName, COUNT(*) as RecordCount FROM Employees
UNION ALL
SELECT 'SavedOffers' as TableName, COUNT(*) as RecordCount FROM SavedOffers;
