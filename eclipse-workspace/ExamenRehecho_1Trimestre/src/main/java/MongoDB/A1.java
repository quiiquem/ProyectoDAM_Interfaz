package MongoDB;
import org.bson.Document;
import java.util.List;
import org.bson.conversions.Bson;

import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Filters;
import com.mongodb.client.model.Projections;
import com.mongodb.client.model.Sorts;
import com.mongodb.client.model.Updates;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import java.util.ArrayList;
import java.util.Scanner;


public class A1 {

	public static void main(String[] args) {
		
//1.1)Crea una base de datos Aquiler en tu servidor MongoDb
		
		// Conectar a Mongo
		MongoClient conectarmongo = MongoClients.create();
		System.out.println("Conectado al mongoclient");
		// Conectar a BD
		MongoDatabase database = conectarmongo.getDatabase("Aquiler");
		System.out.println("Conectado a la base de datos del exámen");
		
		
//1.2)Crea una colección Motos y Clientes, e importa los ficheros .json de aules correspondientes a
// dichas las colecciones que encontrarás en Aules, usa la opción import de MongoDb
		
		
		// Conectar colecciones
		MongoCollection<Document> clientes = database.getCollection("Clientes");
		System.out.println("Coleccion clientes conectado");
		MongoCollection<Document> motos = database.getCollection("Motos");
		System.out.println("Coleccion motos conectado");
		
/*1.3) Crea una proyección en formato json que muestre la matrícula y propiedad tipo 
		de las motos que los clientes han devuelto en el aquiler en una ciudad que te introduzca
		el usuario por consola, ademas tambien debes mostrar cuantas motos se han devuelto en
		dicha ciudad*/
		
		MongoCursor<Document> cursorclientes = null; //cursor para poder recorrer lista cliente
		MongoCursor<Document> cursormotos = null; //cursor para poder recorrer lista motos
		
		int id_cliente=(Integer) cursorclientes.next().get("id"); //para enlazar despues las 2 tablas
		
		Scanner datos = new Scanner(System.in);
		
		System.out.println("Inserta la ciudad en la que has devuelto el producto");
		String ciudad = datos.nextLine();
		
		
		Bson filtrodevolucion  = Filters.eq("aquileres.devol_aquiler",ciudad);
		Bson proyeccionmatricula = Projections.include("matricula","propiedades.tipo");
		
		MongoCursor<Document> cursor_ej = clientes.find(filtrodevolucion).iterator();
		
		while(cursor_ej.hasNext()) {
			System.out.println(cursor_ej);
		}
		
		int motos_devueltas = 0;
		
}
}