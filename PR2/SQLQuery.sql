CREATE TABLE products (
id INT PRIMARY KEY IDENTITY(1,1),
name NVARCHAR(100),
stillage INT,
cell INT,
quantity INT
);
INSERT INTO products (name, stillage, cell, quantity) VALUES ('Хлеб', 2, 3, 20);
INSERT INTO products (name, stillage, cell, quantity) VALUES ('Вода', 1, 2, 15);
INSERT INTO products (name, stillage, cell, quantity) VALUES ('Сладости', 2, 1, 100);
INSERT INTO products (name, stillage, cell, quantity) VALUES ('Газировка', 20, 100, 15);

select * from products