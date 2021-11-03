Create Database Materials

Create Table Buildings (
      PKBuilding Int IDENTITY (1,1) NOT NULL, 
	  Building Varchar(4000) 
	  CONSTRAINT Buildings_PKBuilding PRIMARY KEY CLUSTERED (PKBuilding)
   );

   Create Table Customers (
      PKCustomer Integer IDENTITY (1,1) NOT NULL, 
	  Customer Varchar(4000),
	  Prefix Varchar(5),
	  FKBuilding Int,
	  CONSTRAINT Customers_PKCustomer PRIMARY KEY CLUSTERED (PKCustomer),
	  CONSTRAINT FKBuilding FOREIGN KEY (FKBuilding) REFERENCES  Buildings (PKBuilding)
   );

     Create Table PartNumbers (
      PKPartNumber Integer IDENTITY (1,1) NOT NULL, 
	  PartNumber Varchar(50),
	  Available Bit NOT NULL,
	  FKCustomer Int,
	  CONSTRAINT PartNumbers_PKPartNumber PRIMARY KEY CLUSTERED (PKPartNumber),
	  CONSTRAINT FKCustomer FOREIGN KEY (FKCustomer) REFERENCES  Customers (PKCustomer)
   );

