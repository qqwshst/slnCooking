CREATE DATABASE [dbCooking];

USE [dbCooking];

CREATE TABLE [t�|��](
    [f�|��Id] int PRIMARY KEY identity(1,1),
	[f�|���H�c] nvarchar(50) NOT NULL,
	[f�|���K�X] nvarchar(MAX) NOT NULL,
	[f�|���m�W] nvarchar(50),
	[f�|���q��] nvarchar(50),
	[f�ʧO] int,
	[f�ۧڤ���] nvarchar(MAX),
	[f�|���Ӥ�] nvarchar(MAX),
	[f�v��] int,
	[f�|���إߤ��] smalldatetime not null DEFAULT sysdatetime()
);

CREATE TABLE [t�E�|](
    [f�E�|Id] int PRIMARY KEY IDENTITY(1,1),
	[f�D��H] int NOT NULL FOREIGN KEY REFERENCES [t�|��](f�|��Id), 
	[f�E�|�W��] nvarchar(50) NOT NULL,
	[f�E�|���e] nvarchar(50),
	[f�E�|�Ӥ�] nvarchar(MAX),
	[f�E�|���] smalldatetime NOT NULL,
	[f�E�|�}�l�ɶ�] smalldatetime NOT NULL,
	[f�E�|�����ɶ�] smalldatetime,
	[f�W�B] int,
	[f�E�|�n��] nvarchar(50),
	[f�E�|�n��URL] nvarchar(MAX),
	[f�E�|����r] nvarchar(MAX),
	[f�E�|�q�T�n��] nvarchar(50),
	[f�E�|�q�T�n��b��] nvarchar(50),
        [f�D��H�v��URL] nvarchar(MAX),
	[f�E�|���A] int,
	[f�E�|�U����] bit,
	[f�E�|�إߤ��] smalldatetime NOT NULL DEFAULT sysdatetime() 
);

CREATE TABLE [t��ĳ����](
    [f��ĳ����Id] int PRIMARY KEY IDENTITY(1,1),
	[f�E�|Id] int NOT NULL FOREIGN KEY REFERENCES [t�E�|](f�E�|Id),
	[f�����W��] nvarchar(50),
	[f�ƶq] int,
	[f���] nvarchar(50)
);

CREATE TABLE [t�ѥ[��](
    [f�ѥ[��Id] int PRIMARY KEY IDENTITY(1,1),
	[f�|��Id] int NOT NULL FOREIGN KEY REFERENCES [t�|��](f�|��Id),
	[f�E�|Id] int NOT NULL FOREIGN KEY REFERENCES [t�E�|](f�E�|Id),
	[f�f�֪��A] bit NOT NULL DEFAULT 0,
	[f���W] bit NOT NULL DEFAULT 0,
	[f�ѥ[�̫إߤ��] smalldatetime NOT NULL DEFAULT sysdatetime()
);

CREATE TABLE [t����](
    [f����Id] int PRIMARY KEY IDENTITY(1,1),
	[f�E�|Id] int NOT NULL FOREIGN KEY REFERENCES [t�E�|](f�E�|Id),
	[f�ѥ[��Id] int NOT NULL FOREIGN KEY REFERENCES [t�ѥ[��](f�ѥ[��Id),
	[f�d��] nvarchar(MAX),
	[f�Ӥ�] nvarchar(MAX),
	[f�����إߤ��] nvarchar(50)
);

CREATE TABLE [t���|](
    [f���|Id] int PRIMARY KEY IDENTITY(1,1),
	[f���|�HId] int NOT NULL FOREIGN KEY REFERENCES [t�|��](f�|��Id),
	[f�Q���|���E�|Id] int NOT NULL FOREIGN KEY REFERENCES [t�E�|](f�E�|Id),
	[f���|��]] nvarchar(50),
	[f���|�إߤ��] smalldatetime
);

CREATE TABLE [t�d��](
    [f�d��Id] int PRIMARY KEY IDENTITY(1,1),
	[f�d���HId] int NOT NULL FOREIGN KEY REFERENCES [t�|��](f�|��Id),
	[f�d�����E�|Id] int NOT NULL FOREIGN KEY REFERENCES [t�E�|](f�E�|Id),
	[f�d����r] nvarchar(50),
	[f�d���إߤ��] smalldatetime
);