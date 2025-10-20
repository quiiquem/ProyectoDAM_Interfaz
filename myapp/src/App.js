import { useState } from "react";
import KanbanBoard from "./components/KanbanBoard";

function App() {
  // Columnas que nos has puesto en el documento de aules (básicamente las que aparecera por defecto)
  const [columnas, setColumnas] = useState({
    pendiente: {
      id: "c1",
      name: "Pendiente",
      items: [
        { id: "t1", title: "Diseñar logo", priority: "Alta", dueDate: "2025-10-10" },
        { id: "t2", title: "Escribir contenido web", priority: "Media", dueDate: "2025-10-15" },
      ],
    },
    enProceso: {
      id: "c2",
      name: "En Proceso",
      items: [
        { id: "t3", title: "Configurar servidor", priority: "Alta", dueDate: "2025-10-08" },
      ],
    },
    terminado: {
      id: "c3",
      name: "Completado",
      items: [],
    },
  });
 
  const [nuevatarea, ponerTareaNueva] = useState(""); // texto del input, osea el texto que va a tener dicha tarea
  const [columnaActiva, ponerColumnaActiva] = useState("pendiente"); // columna por defecto donde va a crearse (Pendiente)

  // Función para crear nueva tarea
  const crearTarea = () => {
    if (nuevatarea.trim() === "") return; //si no tiene texto nada

    const columnasActualizadas = { ...columnas };

    columnasActualizadas[columnaActiva].items.push({ //subir la nueva tarea con la fecha de hoy
      id: Date.now().toString(),
      title: nuevatarea,
      priority: "Media", //prioridad puesta por defecto
      dueDate: new Date().toISOString().slice(0, 10),
    });

    setColumnas(columnasActualizadas);
    ponerTareaNueva(""); // limpiar input cada que se añade una tarea nueva
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>Mi Kanban</h1>

      {}
      <div style={{ marginBottom: "20px" }}>
        <input
          type="text"
          placeholder="Nueva tarea..."
          value={nuevatarea}
          onChange={(e) => ponerTareaNueva(e.target.value)}
          style={{ padding: "8px", width: "200px" }}
        />
        <select
          value={columnaActiva}
          onChange={(e) => ponerColumnaActiva(e.target.value)}
          style={{ marginLeft: "10px", padding: "8px" }}
        >
          {Object.keys(columnas).map((key) => (
            <option key={columnas[key].id} value={key}>
              {columnas[key].name}
            </option>
          ))}
        </select>
        <button onClick={crearTarea} style={{ marginLeft: "10px", padding: "8px" }}>
          Añadir
        </button>
      </div>

      <KanbanBoard columnas={columnas} />
    </div>
  );
}

export default App;
