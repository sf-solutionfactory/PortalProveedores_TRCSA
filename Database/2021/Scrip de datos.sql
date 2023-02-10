--ZAdministradorportalZ

use proveedores
GO
delete from GrupoNoticia_proveedor
GO
delete from GrupoNoticia_Noticia
GO
delete from grupoNoticia
GO
delete from configuracion
GO
delete from email
GO
 insert into email(sufijo,SMTPAdd,puerto,SSLOpt) values('@hotmail.com','smtp.live.com',587,1);
 insert into email(sufijo,SMTPAdd,puerto,SSLOpt) values('@gmail.com','smtp.gmail.com',587,1);
 insert into email(sufijo,SMTPAdd,puerto,SSLOpt) values('@outlook.com','smtp.live.com',587,1);
 insert into email(sufijo,SMTPAdd,puerto,SSLOpt) values('@yahoo.com','smtp.mail.yahoo.com',587,1);
 insert into email(sufijo,SMTPAdd,puerto,SSLOpt) values('configurado','',0,0);
 insert into email(sufijo,SMTPAdd,puerto,SSLOpt) values('configuradoAnterior','',0,0);
GO
 insert into configuracion(idConfig,esActivPortal,correoAsunto,correoCuerpo,email,emailPass,esCreacionUsuarios,
maxUsuarios,esBloqSociedad,numPassRecordar,intervalTiempo,maxIntentosFail,configPor, fechaConfiguracion, caducidadPass,tiempoBloqAdmin, maxXML)
values('default',1,'Bienvenido!!',
'Bienvenido al portal de carga de facturas, este será el correo que estará vinculado con nosotros para temas de facturas, estamos en contacto, te invitamos a explorar este servicio ahora.','','',1,10,0,5,30,3,0,GETDATE(),0,0,10);
GO
insert into configuracion(idConfig,esActivPortal,correoAsunto,correoCuerpo,email,emailPass,esCreacionUsuarios,
maxUsuarios,esBloqSociedad,numPassRecordar,intervalTiempo,maxIntentosFail,configPor, fechaConfiguracion,caducidadPass,tiempoBloqAdmin, maxXML)
values('activo',1,'Bienvenido!!',
'Bienvenido al portal de carga de facturas, este será el correo que estará vinculado con nosotros para temas de facturas, estamos en contacto, te invitamos a explorar este servicio ahora.','','',1,10,0,5,30,3,0,GETDATE(),0,0,10);
GO
insert into configuracion(idConfig,esActivPortal,correoAsunto,correoCuerpo,email,emailPass,esCreacionUsuarios,
maxUsuarios,esBloqSociedad,numPassRecordar,intervalTiempo,maxIntentosFail,configPor, fechaConfiguracion,caducidadPass,tiempoBloqAdmin, maxXML)
values('anterior',1,'Bienvenido!!',
'Bienvenido al portal de carga de facturas, este será el correo que estará vinculado con nosotros para temas de facturas, estamos en contacto, te invitamos a explorar este servicio ahora.','','',1,10,0,5,30,3,0,GETDATE(),0,0,10);
GO
delete from credencialesInaceptables
GO
delete from credencialesUsadas
GO
delete from controlSeguridad
GO
delete from credencialFallida
GO
delete from usuario -- primero borrar usuario para poder borrar rol 
GO
delete from DetRol
GO
delete from Pantalla;
GO
delete from rol
   insert into rol(idRol, nombre, esActivo) values(0,'UAdministradorPortal',0);
   insert into rol(idRol, nombre, esActivo) values(1,'Facturas Pendientes',1);
   insert into rol(idRol, nombre, esActivo) values(2,'Facturas Liberadas',1);
   insert into rol(idRol, nombre, esActivo) values(4,'Pagos',1);
   insert into rol(idRol, nombre, esActivo) values(8,'Mis datos',1);
   insert into rol(idRol, nombre, esActivo) values(16,'Usuarios',1);
   insert into rol(idRol, nombre, esActivo, esCreacion) values(7,'Rol Default',1, 1);

GO
   	insert into Pantalla(idPantalla,nombre,descripcion,esBloq) values(0,'Noticia','Pantalla de noticia',1);
	insert into Pantalla(idPantalla,nombre,descripcion,esBloq) values(1,'Facturas','Facturas por cargar',1);
	insert into Pantalla(idPantalla,nombre,descripcion,esBloq) values(2,'Facturas Liberadas','Facturas Liberadas',1);
	insert into Pantalla(idPantalla,nombre,descripcion,esBloq) values(4,'Pagos','Pagos realizados',1);
	insert into Pantalla(idPantalla,nombre,descripcion,esBloq) values(8,'Datos maestros','Datos del proveedor',1);
	insert into Pantalla(idPantalla,nombre,descripcion,esBloq) values(16,'Usuarios','Control de usuarios',1);
 GO  
    	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(0,0);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(1,1);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(2,2);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(4,4);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(8,8);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(16,16);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(7,1);
	insert into DetRol(rol_id_rol,pantalla_idPantalla) values(7,8);
GO
DELETE from usuario
GO
delete from detProveedor
GO
delete from proveedor
GO
insert into proveedor(nombre, esBloq, esCabeceraGrupo) values('ZAdministradorportalZ', 1, 0);
GO
declare @idNuevo int;
select @idNuevo =  @@IDENTITY;

--insert into usuario(proveedor_idProveedor,rol_idRol ,usuarioLog,usuarioPass,email,fechaCreacion,_creadoPor,_autorizadoPor, esBloq)
--	values(@idNuevo,0,'Admin','jOaG1iLn4oyxF6ukf0kOjg==','email',GETDATE(),0,0,1);  -- pass = Admin

UPDATE usuario SET usuarioPass =  'ru/C0FRoFMkiMP9zFnCdinyNLnBN5XcNWJ6wOil4biyYXVI26Jg/cA==' WHERE usuarioLog = 'ZAdministradorportalZ'

	insert into usuario(proveedor_idProveedor,rol_idRol ,usuarioLog,usuarioPass,email,fechaCreacion,_creadoPor,_autorizadoPor, esBloq)
	values(@idNuevo,0,'ZAdministradorportalZ','ru/C0FRoFMkiMP9zFnCdinyNLnBN5XcNWJ6wOil4biyYXVI26Jg/cA==','email',GETDATE(),0,0,1);  -- pass = AdministradorPortal1


--delete from detProveedor
GO
delete from credencialesUsadas
GO
--select * from usuario
--select * from credencialesusadas
--insert into credencialesUsadas(usuario_idusuario, fecha, credencial, tipo) values('Admin',getdate(),'jOaG1iLn4oyxF6ukf0kOjg==',''); -- pass Admin
insert into credencialesUsadas(usuario_idUsuario, fecha, credencial, tipo) values('ZAdministradorportalZ',getdate(),'ru/C0FRoFMkiMP9zFnCdinyNLnBN5XcNWJ6wOil4biyYXVI26Jg/cA==',''); -- pass AdministradorPortal1


GO
delete from instancia
GO
delete from noticia
GO
delete from sociedad
GO
delete from controlSeguridad
GO
insert into controlSeguridad(usuario_idUsuario,esCambiarPassNext,fechaUltimoCambio)  values('ZAdministradorportalZ',1,GETDATE());
GO
delete from UsuarioSociedad
GO
delete from [ValidacionFactura]
GO
delete from [GrupoValidacion]
GO
delete from [Proveedor_GrupoValidacion]
GO
delete from [Grupo_Validacion_Factura]
GO
INSERT INTO ValidacionFactura (descripcion) VALUES ('Moneda');
INSERT INTO ValidacionFactura (descripcion) VALUES ('RFC Emisor');
insert into ValidacionFactura (descripcion) values ('Importe Total');
insert into ValidacionFactura (descripcion) values ('Importe IVA');
insert into ValidacionFactura (descripcion) values ('Sub Total');
GO
