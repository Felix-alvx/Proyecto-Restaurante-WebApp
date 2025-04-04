USE Gestion_Resaturante


CREATE TABLE Clientes
(	id_Cliente INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(60) NOT NULL,
	Apellidos NVARCHAR(90) NOT NULL,
	Telefono  NVARCHAR(15) NOT NULL, 
	Correo_Electronico NVARCHAR(40) UNIQUE
);

CREATE TABLE Menu
(
	id_menu INT PRIMARY KEY IDENTITY(1,1),
	Precio DECIMAL(10, 2),
	Descripcion NVARCHAR(100)
);


CREATE TABLE Mesa
(
	id_mesa INT PRIMARY KEY IDENTITY(1,1), 
	Numero_Mesa INT NOT NULL,
	Descripcion NVARCHAR(100)
);

CREATE TABLE Reservaciones
(
	id_reservacion INT PRIMARY KEY IDENTITY(1,1),
	ID_cliente INT, 
	ID_mesa INT,
	ID_menu INT, 
	Cantidad INT,
	Fecha_reservacion DATETIME,
	FOREIGN KEY(ID_cliente) REFERENCES Clientes(id_cliente),
	FOREIGN KEY(ID_mesa) REFERENCES Mesa(id_mesa),
	FOREIGN KEY(ID_menu) REFERENCES Menu(id_menu)
);


--INSERT DATOS

--INSERT CLIENTES
INSERT INTO Clientes (Nombre, Apellidos, Telefono, Correo_Electronico) 
VALUES 
('Juan', 'Gutierres López', '62587892', 'juan.lopez@email.com'),
('María', 'Alfaro Ruiz', '84522611', 'maria.alfaro@email.com'),
('Carlos', 'Ramírez Jimenez', '62598810', 'carlos.ramirez@email.com');

--INSERT MENU
INSERT INTO Menu (Precio, Descripcion) 
VALUES 
(150.00, 'Pizza Napolitana'),
(200.00, 'Pasta Alfredo'),
(120.50, 'Ensalada César'),
(180.75, 'Hamburguesa con papas');

--INSERT MESA
INSERT INTO Mesa (Numero_Mesa, Descripcion) 
VALUES 
(1, 'Mesa junto a la ventana'),
(2, 'Mesa en la terraza'),
(3, 'Mesa privada'),
(4, 'Mesa cerca de la barra');

--INSERT RESERVACIONES
INSERT INTO Reservaciones (ID_cliente, ID_mesa, ID_menu, Cantidad, Fecha_reservacion) 
VALUES 
(1, 1, 2, 2, '2025-03-25 19:30:00'), -- Juan reservó 2 Pastas Alfredo en la mesa 1
(2, 3, 1, 1, '2025-03-26 20:00:00'), -- María reservó 1 Pizza en la mesa 3
(3, 4, 4, 3, '2025-03-27 18:45:00'); -- Carlos reservó 3 Hamburguesas en la mesa 4

Select * from Reservaciones


