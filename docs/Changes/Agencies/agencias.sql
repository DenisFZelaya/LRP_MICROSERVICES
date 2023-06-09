/*
   dies Sabbati, die 1 Aprilis 2023 p.C.n.12:47:23
   User: 
   Server: DESKTOP-CSF7EUN\SQLEXPRESS
   Database: LRP_AGENCIES_MS_DEV
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_agencias
	(
	id int NOT NULL IDENTITY (1, 1),
	idHash varchar(255) NULL,
	nombre varchar(255) NULL,
	direccion varchar(255) NULL,
	idCiudad int NULL,
	idDepartamento int NULL,
	idPais int NULL,
	longitud varchar(255) NULL,
	latitud varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_agencias SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_agencias ON
GO
IF EXISTS(SELECT * FROM dbo.agencias)
	 EXEC('INSERT INTO dbo.Tmp_agencias (id, idHash, nombre, direccion, idCiudad, idDepartamento, idPais, longitud, latitud)
		SELECT id, idHash, nombre, direccion, idCiudad, idDepartamento, idPais, longitud, latitud FROM dbo.agencias WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_agencias OFF
GO
DROP TABLE dbo.agencias
GO
EXECUTE sp_rename N'dbo.Tmp_agencias', N'agencias', 'OBJECT' 
GO
ALTER TABLE dbo.agencias ADD CONSTRAINT
	PK__agencias__3213E83FDD586364 PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.agencias ADD CONSTRAINT
	UQ__agencias__03D9DF17BD1FE8BA UNIQUE NONCLUSTERED 
	(
	idHash
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.agencias', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.agencias', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.agencias', 'Object', 'CONTROL') as Contr_Per 