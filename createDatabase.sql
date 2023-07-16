
-- -----------------------------------------------------
-- Schema easyMenu
-- -----------------------------------------------------

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'easyMenu')
  BEGIN
    CREATE DATABASE [easyMenu]
  END
GO

USE [easyMenu]
GO

-- -----------------------------------------------------
-- Table `easyMenu`.`user`
-- -----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='user' and xtype='U')
BEGIN
    CREATE TABLE [user] (
											  id	      UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
											  userName	  varchar(50) NOT NULL,
											  email       varchar(100) NOT NULL,
											  password    varchar(50) NOT NULL,
											  createdDate DateTime NOT NULL DEFAULT GETDATE(),
											  updatedDate Datetime NULL,
    )
END

-- -----------------------------------------------------
-- Table `easyMenu`.`menu`
-- -----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='menu' and xtype='U')
BEGIN
    CREATE TABLE menu (
											  id	      UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
											  title		  varchar(50) NOT NULL,
											  description varchar(200) NULL,
											  createdDate DateTime NOT NULL DEFAULT GETDATE(),
											  updatedDate Datetime NULL,
    )
END


  -- ---------------------------------------------------
-- Table `easyMenu`.`disheType`
-- -----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='disheType' and xtype='U')
BEGIN
    CREATE TABLE disheType (
											  id	      UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
											  title		  varchar(50) NOT NULL,
											  description varchar(200) NULL,
											  createdDate DateTime NOT NULL DEFAULT GETDATE(),
											  updatedDate Datetime NULL,
    )
END

-- -----------------------------------------------------
-- Table `easyMenu`.`dishes`
-- -----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='dishes' and xtype='U')
BEGIN
	CREATE TABLE dishes(
											  id	         UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
											  title		     varchar(50) NOT NULL,
											  description    varchar(200) NULL,
											  price          decimal(10,2) NOT NULL DEFAULT 0,
											  portion        tinyint NOT NULL DEFAULT 1,
											  promotion      bit NULL,
											  promotionPrice decimal(10,2) NULL DEFAULT 0,
											  disheTypeId	 UNIQUEIDENTIFIER NOT NULL,
											  createdDate    DateTime NOT NULL DEFAULT GETDATE(),
											  updatedDate    Datetime NULL,
											  CONSTRAINT fk_disheTypeId FOREIGN KEY (disheTypeId) REFERENCES disheType (id)
	)
 END

    -- ---------------------------------------------------
-- Table `easyMenu`.`menuOption`
-- -----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='menuOption' and xtype='U')
BEGIN
	CREATE TABLE menuOption(
											  id	  UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
											  menuId  UNIQUEIDENTIFIER NOT NULL,
											  disheId UNIQUEIDENTIFIER NOT NULL,
											  CONSTRAINT fk_menuId FOREIGN KEY (menuId) REFERENCES menu (id),
											  CONSTRAINT fk_disheId FOREIGN KEY (disheId) REFERENCES dishes (id)
	)
END

  -- ---------------------------------------------------
-- Table `easyMenu`.`restaurant`
-- -----------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='restaurant' and xtype='U')
BEGIN
	CREATE TABLE restaurant(
											  id	      UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
											  name		  varchar(50) NOT NULL,
											  address     varchar(200) NULL,
											  menuId	  UNIQUEIDENTIFIER NOT NULL,
											  createdDate DateTime NOT NULL DEFAULT GETDATE(),
											  updatedDate Datetime NULL,
											  CONSTRAINT fk_menuId_restaurant FOREIGN KEY (menuId) REFERENCES menu (id),
	)
END