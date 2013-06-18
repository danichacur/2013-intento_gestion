select * from 
--transportados.viajes
transportados.micros

/*
1) ver si tenia viajes asignados
2) si tenia, buscar los micros activos que tengan las mismas caracteristicas
3) filtrar los que tengan el/los mismo recorridos asignados
4) devolver el primero 

5) preguntar si se quiere cancelar los pasajes o si se quiere reemplazar el micro
o dar de alta uno nuevo en caso de no haberlo encontrado
6) si decide cancelar.. invocar el codigo de cancelacion de pasajes
7) si decide reemplazar:
	- dar de alta el micro en caso de no encontrar uno y asignarle los viajes
	- al micro asignado encajarle los viajes del otro en la tabla
8) marcar el micro dado de baja en la tabla de micros
*/