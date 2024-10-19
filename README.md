# Net-Bank-Test

Partiremos de que tenemos todo instalado y configurado para correr/ejecutar un proyecto con .Net Core 6 Entity Framework, 
además de crear o hacer la recuperación de la DB en SQL Server desde un .bak


- Instalación y/o recuperación de la DB
  
  Desde SQL Server Management Studio (o desde el gestor de DB 
	de su preferencia) hacer la recuperación en la opción de 
	Restore Database y seleccionar el archivo bank_db.bak este
  archivo se encuentra dentro del proyecto en el directorio "DB"

- Abrir la solución
  
  Abrir la solución (.sln) del proyecto desde Visual Studio
  
- Modificar credenciales de conexión
  
  Cambiar las credenciales de conexión a la BD desde el código del proyecto
	Desde appsettings.json abrir el de la configuración de Desarrollo
	y buscar la cadena de conexión llamada AppDBBank y colocar las credenciales 
	necesarias, siempre y cuando se respete el nombre de la DB

- Correr y/o ejecutar la Solución
  
  Ejecutar la solución para levantar el servidor (virtual local)
	Desde el menú de opciones del Visual Studio, seleccionar la opción
	de Depurar y seleccionar la opción de Iniciar sin depurar o presionar la siguiente
	combinación de teclas Ctrl + F5 esto para un ambiende local

- Navegador Web
  
  Una vez ejecutado el proyecto, se abrirá el Sistema Web desde el
	navegador (revisar el puerto donde se esta ejecutando)
	Para poder entrar a la opción de Retiros deberas iniciar sesión
	colocando los datos de un Usuario previamente registrado en la opción de
	Cuentas (ver Metodo Login en HomeController y ver PrivateBaseController 
	que es heredado en la opción del menu ya comentada) 
	Nota: Solo se esta validando el campo de Cuenta de Usuario y no la 
	Contraseña(decision mía por ser prueba)
