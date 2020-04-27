create database project0;

create table Customers(
	customerId int(8),
    firstName varchar(20),
    lastName varchar(20),
    address varchar(130),
    userName varchar(10),
    pass_word varchar(15),
    defaultStoreId int(8),
    primary key(customerId),
    FOREIGN KEY (defaultStoreId) REFERENCES Store(storeId),
    regDate timestamp
);

create table Store(
	storeId int(8),
    address varchar(130),
    productId int(8),
    primary key(storeId),
    foreign key(productId) references Inventory(productId)
);

