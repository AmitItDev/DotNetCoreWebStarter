-- Insert data into AspNetUsers
SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] (
    [Id], [DisplayName], [IsActive], [PasswordPlainText], [UserName], [NormalizedUserName], 
    [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], 
    [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
    [LockoutEnd], [LockoutEnabled], [AccessFailedCount]
) VALUES
(1, N'System Admin', 1, NULL, N'admin', N'ADMIN', N'admin@bizsoft.com', N'ADMIN@BIZSOFT.COM', 1,
'AQAAAAIAAYagAAAAENFdGkQODhGwaoRqTkaAulo88K05/1pAO3csLo9zr5ZsSfZvQdJZ3W9zmVjVrI7AyA==',
'C1283527-62E8-4BF2-9E01-877673AEBAB1', '93570AD2-806A-4E29-B25D-421D64D2AF5C', NULL, 0, 0, NULL, 1, 0),
(2, N'Normal User', 1, NULL, N'user', N'USER', N'user@bizsoft.com', N'USER@BIZSOFT.COM', 1,
'AQAAAAIAAYagAAAAECOljcRcEDClFgYn16v48AHnDMxdNSjSxYd/ApcllTom+SydKlNk9SR3mE6QvScG/Q==',
'4EDF54C1-A502-4F93-BAA2-42DF99AE325D', '60451367-4E41-44BB-9BBD-991734EBD8D0', NULL, 0, 0, NULL, 1, 0);
SET IDENTITY_INSERT [AspNetUsers] OFF;
GO
 
-- Insert data into AspNetRoles
SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] (
    [Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]
) VALUES
(1, NULL, N'Admin', N'ADMIN', N'94D3CC4C-23B4-4800-AD02-517B03513B9E'),
(2, NULL, N'User', N'USER', N'78036046-32C3-4942-9581-9934141092C6');
SET IDENTITY_INSERT [AspNetRoles] OFF;
GO
 
-- Insert data into AspNetUserRoles (no identity column, so no IDENTITY_INSERT)
INSERT INTO [AspNetUserRoles] (
    [UserId], [RoleId]
) VALUES
(1, 1),
(2, 2);
GO
 
-- Insert data into MenuItems
SET IDENTITY_INSERT [MenuItems] ON;
INSERT INTO [MenuItems] (
    [MenuId], [Title], [Url], [Icon], [ParentMenuId], [Order], [IsActive]
) VALUES
(1, N'Jobs', N'/Jobs', N'fa fa-briefcase', NULL, 1, 1),
(2, N'Users', N'/Users', N'fa fa-users', NULL, 2, 1),
(3, N'Job Reports', N'/Jobs/Reports', N'fas fa-file-alt', 1, 3, 1);
SET IDENTITY_INSERT [MenuItems] OFF;
GO
 
-- Insert data into RoleMenus
SET IDENTITY_INSERT [RoleMenus] ON;
INSERT INTO [RoleMenus] (
    [RoleMenuId], [RoleId], [MenuId]
) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 1),
(4, 1, 3),
(5, 2, 3);
SET IDENTITY_INSERT [RoleMenus] OFF;
GO