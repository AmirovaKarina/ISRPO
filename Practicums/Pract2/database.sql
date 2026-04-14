CREATE TABLE Questions (
    Id INT IDENTITY PRIMARY KEY,
    QuestionText NVARCHAR(500) NOT NULL,
    Option1 NVARCHAR(255) NOT NULL,
    Option2 NVARCHAR(255) NOT NULL,
    Option3 NVARCHAR(255) NOT NULL,
    Option4 NVARCHAR(255) NOT NULL,
    CorrectOption INT NOT NULL CHECK (CorrectOption BETWEEN 1 AND 4)
);

CREATE TABLE Users (
    Id INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    TestDate DATETIME NOT NULL,
    Score INT NOT NULL,
    TimeSpentSeconds INT NOT NULL
);

CREATE TABLE UserAnswers (
    Id INT IDENTITY PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE,
    QuestionId INT NOT NULL FOREIGN KEY REFERENCES Questions(Id),
    SelectedAnswer INT NOT NULL,
    IsCorrect BIT NOT NULL
);

INSERT INTO Questions (QuestionText, Option1, Option2, Option3, Option4, CorrectOption) VALUES
('Что такое переменная в программировании?', 'Константа', 'Область памяти для хранения данных', 'Функция', 'Цикл', 2),
('Какой оператор используется для ветвления?', 'for', 'if', 'while', 'switch', 2),
('Что такое SQL?', 'Язык программирования', 'Язык запросов к базам данных', 'Операционная система', 'Текстовый редактор', 2),
('Какой тип данных целое число в C#?', 'string', 'int', 'double', 'bool', 2),
('Что такое OOP?', 'Объектно-ориентированное программирование', 'Операционная система', 'База данных', 'Алгоритм', 1),
('Какой цикл выполняется хотя бы один раз?', 'for', 'while', 'do-while', 'foreach', 3),
('Что такое класс в C#?', 'Шаблон для создания объектов', 'Функция', 'Переменная', 'Пространство имен', 1),
('Какой модификатор доступа делает член доступным только внутри класса?', 'public', 'private', 'protected', 'internal', 2),
('Что такое массив?', 'Набор переменных одного типа', 'Функция', 'Цикл', 'Условный оператор', 1),
('Какой метод является точкой входа в консольное приложение C#?', 'Main', 'Start', 'Run', 'Init', 1),
('Что такое база данных?', 'Хранилище данных', 'Язык программирования', 'Программа для рисования', 'Текстовый процессор', 1),
('Какой оператор используется для сравнения?', '=', '==', '!=', '<>', 2),
('Что такое наследование в ООП?', 'Возможность создавать новые классы на основе существующих', 'Скрытие данных', 'Перегрузка методов', 'Полиморфизм', 1),
('Что такое исключение?', 'Ошибка времени выполнения', 'Ошибка компиляции', 'Предупреждение', 'Логическая ошибка', 1),
('Какой тип данных используется для хранения текста?', 'int', 'string', 'char', 'bool', 2);