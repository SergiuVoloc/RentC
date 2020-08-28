-- tables

CREATE TABLE Cars (
    CarID int  NOT NULL IDENTITY(1, 1),
    Plate varchar(10)  NOT NULL,
    Manufacturer varchar(30)  NOT NULL,
    Model varchar(50)  NOT NULL,
	Location varchar(50) NOT NULL,
    PricePerDay money  NOT NULL,
    CONSTRAINT Cars_pk PRIMARY KEY  (CarID)
);


-- Table: Coupons
CREATE TABLE Coupons (
    CouponCode varchar(10)  NOT NULL,
    Description varchar(100)  NOT NULL,
    Discount decimal(4,2)  NOT NULL,
    CONSTRAINT Coupons_pk PRIMARY KEY  (CouponCode)
);


-- Table: Customers
CREATE TABLE Customers (
    CustomerID int  NOT NULL IDENTITY(1, 1),
    Name varchar(50)  NOT NULL,
    BirthDate date  NOT NULL
    CONSTRAINT Customers_pk PRIMARY KEY  (CustomerID)
);

-- Table: Permissions
CREATE TABLE Permissions (
    PermissionID int  NOT NULL IDENTITY(1, 1),
    Name varchar(10)  NOT NULL,
    Description varchar(100)  NOT NULL,
    CONSTRAINT Permissions_pk PRIMARY KEY  (PermissionID)
);

-- Table: ReservationStatuses
CREATE TABLE ReservationStatuses (
    ReservStatsID tinyint  NOT NULL IDENTITY(1, 1),
    Name varchar(20)  NOT NULL,
    Description varchar(100)  NOT NULL,
    CONSTRAINT ReservationStatuses_pk PRIMARY KEY  (ReservStatsID)
);

-- Table: Reservations
CREATE TABLE Reservations (
    ReservationID int  NOT NULL IDENTITY(1, 1),
    CarID int  NOT NULL,
    CustomerID int  NOT NULL,
    ReservStatsID tinyint  NOT NULL,
    StartDate date  NOT NULL,
    EndDate date  NOT NULL,
    Location varchar(50)  NOT NULL,
    CouponCode varchar(10)  NULL,
    CONSTRAINT Reservations_pk PRIMARY KEY  (ReservationID)
);

-- Table: Roles
CREATE TABLE Roles (
    RoleID int  NOT NULL IDENTITY(1, 1),
    Name varchar(50)  NOT NULL,
    Description varchar(200)  NOT NULL,
    CONSTRAINT Roles_pk PRIMARY KEY  (RoleID)
);

-- Table: RolesPermissions
CREATE TABLE RolesPermissions (
	RolesPermissionID int  NOT NULL IDENTITY(1, 1),
    RoleID int  NOT NULL,
    PermissionID int  NOT NULL,
    CONSTRAINT RolesPermissions_pk PRIMARY KEY  (RolesPermissionID)
);

-- Table: Users
CREATE TABLE Users (
    UserID int  NOT NULL IDENTITY(1, 1),
    Password varchar(100)  NOT NULL,
    Enabled bit  NOT NULL,
    RoleID int  NOT NULL,
    CONSTRAINT Users_pk PRIMARY KEY  (UserID)
);




-- foreign keys
-- Reference: Reservations_Cars (table: Reservations)
ALTER TABLE Reservations ADD CONSTRAINT Reservations_Cars
    FOREIGN KEY (CarID)
    REFERENCES Cars (CarID);

-- Reference: Reservations_Coupons (table: Reservations)
ALTER TABLE Reservations ADD CONSTRAINT Reservations_Coupons
    FOREIGN KEY (CouponCode)
    REFERENCES Coupons (CouponCode);

-- Reference: Reservations_Customers (table: Reservations)
ALTER TABLE Reservations ADD CONSTRAINT Reservations_Customers
    FOREIGN KEY (CustomerID)
    REFERENCES Customers (CustomerID);

-- Reference: Reservations_ReservationStatuses (table: Reservations)
ALTER TABLE Reservations ADD CONSTRAINT Reservations_ReservationStatuses
    FOREIGN KEY (ReservStatsID)
    REFERENCES ReservationStatuses (ReservStatsID);

-- Reference: RolesPermissions_Permissions (table: RolesPermissions)
ALTER TABLE RolesPermissions ADD CONSTRAINT RolesPermissions_Permissions
    FOREIGN KEY (PermissionID)
    REFERENCES Permissions (PermissionID);

-- Reference: ScreenPermissions_Roles (table: RolesPermissions)
ALTER TABLE RolesPermissions ADD CONSTRAINT ScreenPermissions_Roles
    FOREIGN KEY (RoleID)
    REFERENCES Roles (RoleID);

-- Reference: Users_Roles (table: Users)
ALTER TABLE Users ADD CONSTRAINT Users_Roles
    FOREIGN KEY (RoleID)
    REFERENCES Roles (RoleID);

-- End of file.






         ----------------- DROP ------------------

-- foreign keys
ALTER TABLE Reservations DROP CONSTRAINT Reservations_Cars;

ALTER TABLE Reservations DROP CONSTRAINT Reservations_Coupons;

ALTER TABLE Reservations DROP CONSTRAINT Reservations_Customers;

ALTER TABLE Reservations DROP CONSTRAINT Reservations_ReservationStatuses;

ALTER TABLE RolesPermissions DROP CONSTRAINT RolesPermissions_Permissions;

ALTER TABLE RolesPermissions DROP CONSTRAINT ScreenPermissions_Roles;

ALTER TABLE Users DROP CONSTRAINT Users_Roles;

-- tables
DROP TABLE Cars;

DROP TABLE Coupons;

DROP TABLE Customers;

DROP TABLE Permissions;

DROP TABLE ReservationStatuses;

DROP TABLE Reservations;

DROP TABLE Roles;

DROP TABLE RolesPermissions;

DROP TABLE Users;

-- End of file.


