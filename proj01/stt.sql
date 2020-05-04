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
    #FOREIGN KEY (defaultStoreId) REFERENCES Store(storeId),
    regDate timestamp
);
 select* from Customers;
 
create table Store(
	storeId int(8),
    address varchar(130),
    productId int(8),
    primary key(storeId)
    #foreign key(productId) references Inventory(productId)
);
INSERT INTO `revaturedb`.`customers`
(`customerId`,`firstName`,`lastName`,`streetAddress`,`cityAddress`,`stateAddress`,`countryAddress`,`userName`,`pass_word`,`regDate`)
VALUES
('1','Maria','Anders',‘123 John Ave’,‘Berlin’,'Berlin','Germany','Anders1','030-0074321',"2017-07-23");

INSERT INTO `revaturedb`.`customers`
(`lastName`)
VALUES
('John');
