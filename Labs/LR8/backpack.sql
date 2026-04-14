CREATE TABLE objects (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	Weight INT NOT NULL,
	Cost INT NOT NULL
);
GO

INSERT INTO objects (Name, Weight, Cost) VALUES
('Книга', 1, 600),
('Бинокль', 2, 5000),
('Аптечка', 4, 1500),
('Ноутбук', 2, 40000),
('Котелок', 1, 500);
GO