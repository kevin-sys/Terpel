CREATE TABLE cliente (
Cedula VARCHAR2(11) PRIMARY KEY,
PrimerNombre VARCHAR2(25),
SegundoNombre VARCHAR2(25),
PrimerApellido VARCHAR2(25),
SegundoApellido VARCHAR2(25),
Telefono VARCHAR2(10),
Email VARCHAR2(50),
Marca VARCHAR2(50),
Modelo VARCHAR2(10),
TipoAceite VARCHAR2(25),
ReferenciaAceite VARCHAR2(50),
TipoFiltro VARCHAR2(50),
ReferenciaFiltro VARCHAR2(50)
);
    





       
create or replace PACKAGE PKG_INSERTAR AS 
PROCEDURE INSERTAR_CLIENTE(
ACedula IN VARCHAR2, 
APrimerNombre IN VARCHAR2, 
ASegundoNombre IN VARCHAR2,
APrimerApellido IN VARCHAR2,
ASegundoApellido IN VARCHAR2,
ATelefono IN VARCHAR2,
AEmail IN VARCHAR2,
AMarca IN VARCHAR2,
AModelo IN VARCHAR2,
ATipoAceite IN VARCHAR2,
AReferenciaAceite IN VARCHAR2,
ATipoFiltro IN VARCHAR2,
AReferenciaFiltro IN VARCHAR2
);
END PKG_INSERTAR;

CREATE OR REPLACE PACKAGE BODY PKG_INSERTAR AS
PROCEDURE INSERTAR_CLIENTE(
ACedula IN VARCHAR2, 
APrimerNombre IN VARCHAR2, 
ASegundoNombre IN VARCHAR2,
APrimerApellido IN VARCHAR2,
ASegundoApellido IN VARCHAR2,
ATelefono IN VARCHAR2,
AEmail IN VARCHAR2,
AMarca IN VARCHAR2,
AModelo IN VARCHAR2,
ATipoAceite IN VARCHAR2,
AReferenciaAceite IN VARCHAR2,
ATipoFiltro IN VARCHAR2,
AReferenciaFiltro IN VARCHAR2
)
AS
BEGIN
INSERT INTO CLIENTE VALUES(ACedula, APrimerNombre, ASegundoNombre, APrimerApellido,ASegundoApellido, ATelefono, AEmail,
AMarca, AModelo, ATipoAceite, AReferenciaAceite,ATipoFiltro, AReferenciaFiltro);
END INSERTAR_CLIENTE;
END PKG_INSERTAR;



