use MitRao

create table Product(
	product_id int identity(1,1) not null,
	product_name varchar(50) not null,
	product_price int not null
	constraint pk_productId primary key(product_id)
); 

use MitRao

alter table Cart_Products add quantity int not null

create table Cart(
	cart_id int identity(1,1),
	customer_id int references Customer(id) on delete cascade,
	constraint pk_cartId primary key(cart_id)
);

create table Cart_Products(
	id int identity(1,1) not null,
	cart_id int references Cart(cart_id) on delete cascade,
	product_id int references Product(product_id) on delete set null
	constraint pk_cartProductsId primary key(id)
);

create table Customer(
	id int identity(1,1) not null,
	fname varchar(40) not null,
	lname varchar(40) not null,
	email varchar(100) not null,
	password varchar(100) not null,
	constraint pk_id primary key(id)
);

drop table Customer