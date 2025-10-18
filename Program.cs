using Microsoft.Data.Sqlite;
string connectionString = "Data Source=nueva.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un porgrama real
    // la aplicamos para poder crear nuestra base de datos desde cero
    string createTableQuery = "CREATE TABLE IF NOT EXISTS productos (id INTEGER PRIMARY KEY, nombre TEXT, precio REAL)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }
    
    // Insertar datos 
    /*
    string insertQuery = "INSERT INTO presupuestos (nombreDestinatario, fechaCreacion) VALUES ('Tomas', '2025-10-25'), ('Facundo', '2025-10-26')";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'presupuestos'.");
            }*/
    // Leer datos
            string selectQuery = "SELECT * FROM productos";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'productos':");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id_prod"]}, Nombre: {reader["descripcion"]}, Precio: {reader["precio"]}");
                }
            }
    //leer presupuestos
    string selectQuery2 = "SELECT * FROM presupuestos";
    using (SqliteCommand selectCmd = new SqliteCommand(selectQuery2, connection))
    using (SqliteDataReader reader = selectCmd.ExecuteReader())
    {
        Console.WriteLine("Datos de tabla presupuestos");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["idPresupuesto"]}, Destinatario: {reader["nombreDestinatario"]}, fecha: {reader["fechaCreacion"]}");
        }
    }

        connection.Close();
}