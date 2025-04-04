--STORED PROCEDURES PARA TABLA CLIENTES

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta Cliente
-- =============================================
CREATE PROCEDURE SP_ConsCliente
AS
BEGIN 
	SELECT id_Cliente,
		Nombre,
		Apellidos,
		Telefono,
		Correo_Electronico
	FROM Clientes; 
END; 



-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta ClienteXID
-- =============================================
CREATE PROCEDURE SP_ConsClienteXID
	@id_Cliente INT
AS
BEGIN
		SELECT id_Cliente,
		Nombre,
		Apellidos,
		Telefono,
		Correo_Electronico
	FROM Clientes
	WHERE id_Cliente = @id_Cliente;
	
END;

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Insertar Cliente
-- =============================================

CREATE PROCEDURE sp_InsertarCliente
    @Nombre NVARCHAR(60),
    @Apellidos NVARCHAR(90),
    @Telefono NVARCHAR(15),
    @Correo_Electronico NVARCHAR(40)
AS
BEGIN
    INSERT INTO Clientes (Nombre, Apellidos, Telefono, Correo_Electronico)
    VALUES (@Nombre, @Apellidos, @Telefono, @Correo_Electronico);
END;


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Actualizar Cliente
-- =============================================

CREATE PROCEDURE SP_ActualizarCliente
	@id_cliente int,
    @Nombre NVARCHAR(60),
    @Apellidos NVARCHAR(90),
    @Telefono NVARCHAR(15),
    @Correo_Electronico NVARCHAR(40)
AS
BEGIN
	UPDATE Clientes
	SET Nombre = @Nombre,
		Apellidos = @Apellidos,
		Telefono = @Telefono,
		Correo_Electronico = @Correo_Electronico
	WHERE id_cliente = @id_cliente;
END;

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Eliminar Cliente
-- =============================================

CREATE PROCEDURE SP_EliminarCliente
	@id_cliente INT
AS
BEGIN
	DELETE FROM Clientes 
	WHERE id_cliente = @id_cliente;
END; 



--STARED PROCEDURES PARA MENU


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta MENU
-- =============================================
CREATE PROCEDURE SP_ConsMenu
AS
BEGIN 
	SELECT id_menu,
		Precio,
		Descripcion
	FROM Menu; 
END;
-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta MENUXID
-- =============================================

CREATE PROCEDURE SP_ConsMenuXID
	@id_menu INT
AS
BEGIN 
	SELECT id_menu,
		Precio,
		Descripcion
	FROM Menu
	WHERE id_menu = @id_menu;
END;


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Insertar Menu 
-- =============================================

CREATE PROCEDURE SP_InsertarMenu
	@Precio DECIMAL(10, 2),
	@Descripcion NVARCHAR(100)
AS
BEGIN
	INSERT INTO Menu(Precio, Descripcion)
	VALUES(@Precio, @Descripcion);
END; 


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Actualizar Menu 
-- =============================================

CREATE PROCEDURE SP_ActualizarMenu
	@id_menu INT,
	@Precio DECIMAL(10, 2),
	@Descripcion NVARCHAR(100)
AS
BEGIN
	UPDATE Menu
	SET Precio = @Precio,
		Descripcion = @Descripcion
	WHERE id_menu = @id_menu;
END; 

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Eliminar Menu 
-- =============================================

CREATE PROCEDURE SP_EliminarMenu
	@id_menu INT
AS
BEGIN
	DELETE  FROM Menu 
	WHERE id_menu = @id_menu;
END;



--STORED PROCEDURES PARA MESAS

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta Mesa 
-- =============================================
CREATE PROCEDURE SP_ConsMesa
AS
BEGIN
	SELECT id_mesa,
		Numero_Mesa,
		Descripcion
	FROM Mesa;
END;

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta MesaXID 
-- =============================================
CREATE PROCEDURE SP_ConsMesaXID
	@id_mesa INT 
AS
BEGIN
	SELECT id_mesa,
		Numero_Mesa,
		Descripcion
	FROM Mesa
	WHERE id_mesa = @id_mesa;
END;



-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Insertar Mesa 
-- =============================================

CREATE PROCEDURE SP_InsertarMesa
	@Numero_Mesa INT, 
	@Descripcion NVARCHAR(100)
AS
BEGIN 
	INSERT INTO Mesa(Numero_Mesa, Descripcion)
	VALUES(@Numero_Mesa, @Descripcion);
END;


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Actualizar Mesa
-- =============================================

CREATE PROCEDURE SP_ActualizarMesa
	@id_mesa INT,
	@Numero_Mesa INT,
	@Descripcion NVARCHAR(100)
AS
BEGIN
	UPDATE Mesa
	SET Numero_Mesa = @Numero_Mesa,
		Descripcion = @Descripcion
	WHERE id_mesa = @id_mesa
END;


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Eliminar Mesa 
-- =============================================

CREATE PROCEDURE SP_EliminarMesa
	@id_mesa INT
AS
BEGIN 
	DELETE FROM Mesa
	WHERE id_mesa = @id_mesa;
END;


--STORED PROCEDURES PARA Reservaciones

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta Reservacion
-- =============================================

CREATE PROCEDURE SP_ConsReservacion
AS
BEGIN
	SELECT id_reservacion,
		ID_cliente,
		ID_mesa,
		ID_menu,
		Cantidad,
		Fecha_reservacion
	FROM Reservaciones; 

END;
-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Consulta ReservacionXID
-- =============================================
CREATE PROCEDURE SP_ConsReservacionXID
    @id_reservacion INT
AS
BEGIN
    SELECT r.id_reservacion, --r = reservaciones, c = clientes, me = menu
           r.ID_cliente,
           c.Nombre AS NombreCliente,
           r.ID_mesa,
           m.Descripcion AS DescripcionMesa,
           r.ID_menu,
           me.Descripcion AS DescripcionMenu,
           r.Cantidad,
           r.Fecha_reservacion
    FROM Reservaciones r
    INNER JOIN Clientes c ON r.ID_cliente = c.id_cliente
    INNER JOIN Mesa m ON r.ID_mesa = m.id_mesa
    INNER JOIN Menu me ON r.ID_menu = me.id_menu
    WHERE r.id_reservacion = @id_reservacion;
END;



-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Insertar Reservacion
-- =============================================
CREATE PROCEDURE SP_InsertarReservacion
	@ID_cliente INT,
    @ID_mesa INT,
    @ID_menu INT,
    @Cantidad INT,
    @Fecha_reservacion DATETIME
AS
BEGIN
	INSERT INTO Reservaciones(ID_cliente, ID_mesa, ID_menu, Cantidad, Fecha_reservacion)
	VALUES (@ID_cliente, @ID_mesa, @ID_menu,@Cantidad, @Fecha_reservacion);
END;

-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Actualizar Reservacion
-- =============================================
CREATE PROCEDURE SP_ActualizarReservacion
	@id_reservacion INT,
	@ID_cliente INT,
    @ID_mesa INT,
    @ID_menu INT,
    @Cantidad INT,
    @Fecha_reservacion DATETIME
AS
BEGIN	
	UPDATE Reservaciones
	SET ID_Cliente = @ID_cliente,
		ID_mesa = @ID_mesa,
		ID_menu = @ID_menu,
		Cantidad = @Cantidad,
		Fecha_reservacion = @Fecha_reservacion
	WHERE id_reservacion = @id_reservacion;
END;


-- =============================================
-- Author:		Felix ALvarado
-- Create date: 23/3/2025
-- Description:	Eliminar Reservacion
-- =============================================

CREATE PROCEDURE SP_EliminarReservacion
	@id_reservacion INT
AS
BEGIN
	DELETE FROM Reservacion 
	WHERE id_reservacion = @id_reservacion;
END; 