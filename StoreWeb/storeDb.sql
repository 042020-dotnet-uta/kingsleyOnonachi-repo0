create database project0;

create table Customers(
	customerId int,
    firstName varchar(20) not null,
    lastName varchar(20),
    address varchar(130) not null,
    userName varchar(10) not null,
    pass_word varchar(15) not null,
    primary key(customerId),
	regDate timestamp
);


create table DefaultStore
(
	defaultStoreId int not null,
    storeId int not null,
    userId int  not null,
    regDate timestamp,
    primary key(defaultStoreId),
    foreign key(userId) references Customers(customerId)
);

create table Store(
	storeId int,
    address varchar(130),
    productId int,
    primary key(storeId)
);

CREATE TABLE Orders (
    orderNum INT,
    userId INT,
    total DOUBLE,
    orderDate TIMESTAMP,
    PRIMARY KEY (orderNum),
    FOREIGN KEY (userId)
        REFERENCES customers (customerId)
);
