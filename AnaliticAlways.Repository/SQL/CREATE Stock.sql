﻿CREATE TABLE Stock(
Id INT IDENTITY(1,1) PRIMARY KEY,
PointOfSale VARCHAR(50) NOT NULL,
Product VARCHAR(50) NOT NULL,
Date Date NOT NULL,
Count INT NOT NULL)