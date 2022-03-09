CREATE DATABASE BCP
GO

USE BCP
GO

CREATE TABLE MONEDA (
   ID int identity,
   COD_MONEDA CHAR(3),
   TXT_SIMBOLO CHAR(5),
)

GO

INSERT INTO MONEDA (COD_MONEDA, TXT_SIMBOLO) VALUES ('PEN', 'S/');
INSERT INTO MONEDA (COD_MONEDA, TXT_SIMBOLO) VALUES ('USD', '$');
INSERT INTO MONEDA (COD_MONEDA, TXT_SIMBOLO) VALUES ('EUR', '€');
GO

CREATE TABLE TIPOCAMBIO (
   ID INT IDENTITY,
   ID_MONEDA_ORIGEN INT,
   ID_MONEDA_DESTINO INT,
   IMP_COMPRA DECIMAL(3,2),
   IMP_VENTA DECIMAL(3,2)
)
GO

INSERT INTO TIPOCAMBIO (ID_MONEDA_ORIGEN, ID_MONEDA_DESTINO, IMP_COMPRA, IMP_VENTA) VALUES (1, 2, 3.726, 3.788 );
GO

INSERT INTO TIPOCAMBIO (ID_MONEDA_ORIGEN, ID_MONEDA_DESTINO, IMP_COMPRA, IMP_VENTA) VALUES (1, 3 , 4.14, 4.38 );
GO

CREATE TABLE PERSONA (
             ID                   INT PRIMARY KEY IDENTITY, 
             PRIMER_NOMBRE        VARCHAR(20) NOT NULL , 
             SEGUNDO_NOMBRE       VARCHAR(20) , 
             PRIMER_APELLIDO      VARCHAR(20) NOT NULL , 
             SEGUNDO_APELLIDO     VARCHAR(20) NOT NULL , 
             GENERO               CHAR(1) , 
             DOCUMENTO_IDENTIDAD  VARCHAR(20) NOT NULL UNIQUE,
                           );
GO

CREATE TABLE SEGURIDAD_WEB (
			 ID                     INT PRIMARY KEY IDENTITY, 
			 ID_PERSONA             INT CONSTRAINT fk_persona_id FOREIGN KEY REFERENCES  PERSONA(id),
			 CUENTA_LOGUEO          VARCHAR(100) UNIQUE,
			 CONTRASENIA            VARBINARY(100), 
			 REINICIAR_CONTRASENIA  VARBINARY(100), 
			 ESTADO                 VARCHAR(20)
			 );
GO

CREATE TABLE [dbo].PARAMETROS(
	 id  INT NOT NULL PRIMARY KEY IDENTITY,
	 id_compania INT NULL,
	 descripcion VARCHAR(500),
	 estado BIT NULL,
	 usuario_creacion VARCHAR(20) NULL,
	 fec_creacion DATETIME NULL,
	 fec_modificacion DATETIME NULL,
	 usuario_modificacion VARCHAR(20) NULL,
)


CREATE TABLE PARAMETROS_DETALLE(
    ID           INT PRIMARY KEY IDENTITY, 
	ID_PARAMETRO INT NOT NULL CONSTRAINT fk_parametro_id   FOREIGN KEY REFERENCES  PARAMETROS(id),
	DESCRIPCION   VARCHAR(255) NULL,
	PARAMETRO     VARCHAR(10)  NULL,
	VALOR_TEXTO1  VARCHAR(100) NULL,
	EXPLICACION1  VARCHAR(500) NULL,
	VALOR_TEXTO2  VARCHAR(100) NULL,
	EXPLICACION2  VARCHAR(500) NULL,
	VALOR_TEXTO3  VARCHAR(100) NULL,
	EXPLICACION3  VARCHAR(500) NULL,
	VALOR_TEXTO4  VARCHAR(100) NULL,
	EXPLICACION4  VARCHAR(500) NULL
)

INSERT INTO [dbo].PARAMETROS(id_compania,descripcion, estado, usuario_creacion, fec_creacion, fec_modificacion,usuario_modificacion )
					  VALUES(1,'ESTADOS',1,NULL,NULL,NULL,NULL),
					        (1,'MOTIVO CAMBIO ESTADO',1,NULL,NULL,NULL,NULL)
GO

INSERT INTO PARAMETROS_DETALLE(ID_PARAMETRO,DESCRIPCION,PARAMETRO,VALOR_TEXTO1)
                      VALUES(1,'Estado Pendiente','PEN','PENDIENTE'),
					  (1,'Estado Registrado','REG','REGISTRADO'),
					  (1,'Estado Habilitado','HAB','HABILITADO'),
					  (1,'Estado Deshabilitado','DES','DESHABILITADO'),	
					  (2,'Registro Nuevo',NULL,'NUEVO REGISTRO'),	
					  (2,'Otro Motivo de cambio de estado',NULL,'OTROS')
GO

CREATE PROCEDURE USP_REGISTRAR_PERSONA_WEB

@P_PRIMER_NOMBRE        VARCHAR(20), 
@P_SEGUNDO_NOMBRE       VARCHAR(20), 
@P_PRIMER_APELLIDO      VARCHAR(20), 
@P_SEGUNDO_APELLIDO     VARCHAR(20), 
@P_GENERO               CHAR(1), 
@P_DOCUMENTO_IDENTIDAD  VARCHAR(8)
AS
    BEGIN
        DECLARE @CODIGO CHAR(9);
        SET @CODIGO = 'C' + TRIM(ISNULL(@P_DOCUMENTO_IDENTIDAD, '00000000'));
                    BEGIN
                        INSERT INTO dbo.PERSONA
                        ( 
                         PRIMER_NOMBRE, 
                         SEGUNDO_NOMBRE, 
                         PRIMER_APELLIDO, 
                         SEGUNDO_APELLIDO,
                         GENERO, 
                         DOCUMENTO_IDENTIDAD
                        )
                        VALUES
                        (
                         @P_PRIMER_NOMBRE, 
                         @P_SEGUNDO_NOMBRE, 
                         @P_PRIMER_APELLIDO, 
                         @P_SEGUNDO_APELLIDO, 
						 @P_GENERO,
                         @P_DOCUMENTO_IDENTIDAD
                        );

                        BEGIN
                            INSERT INTO dbo.SEGURIDAD_WEB
                            (ID_PERSONA	, 
							 CUENTA_LOGUEO,
							 CONTRASENIA, 
							 ESTADO
                            )
                            VALUES
                            (SCOPE_IDENTITY(),
							 @CODIGO, 
                             CAST(@P_DOCUMENTO_IDENTIDAD AS VARBINARY(MAX)),
							 (select VALOR_TEXTO1 from PARAMETROS_DETALLE where ID = 3 and ID_PARAMETRO = 1)
                            );
                END;
            END;
    END;
GO

 CREATE PROCEDURE USP_ACCESO_WEB

@P_IDINGRESO   VARCHAR(50), 
@P_CONTRASENIA VARCHAR(50)
AS
        BEGIN
            SELECT P.ID AS IDCLIENTE, 
                   L.CUENTA_LOGUEO AS IDINGRESO, 
                   P.PRIMER_NOMBRE AS PRIMERNOMBRE, 
                   P.PRIMER_APELLIDO AS PRIMERAPELLIDO
            FROM SEGURIDAD_WEB AS L
                 INNER JOIN PERSONA P  ON P.ID = L.ID
            WHERE L.CUENTA_LOGUEO = @P_IDINGRESO
                  AND L.CONTRASENIA = @P_CONTRASENIA;
        END;
GO

CREATE PROCEDURE USP_GETMONEDAS 
AS	
  BEGIN
  SELECT ID AS IDMONEDA,
         COD_MONEDA AS COD_MONEDA,
	     TXT_SIMBOLO AS TXT_SIMBOLO  FROM MONEDA
  END




