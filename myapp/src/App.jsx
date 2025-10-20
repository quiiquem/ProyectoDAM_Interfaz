









//no entiendo porque si borro todo en .jsx va igual, osea esto se supone que debe funcionar solo con este archivo escrito pero aun asi funciona con el de .js???
//osea si es el mismo proposito, mostrar la web en si pero no entiendo porque debemos hacer un .jsx si luego funciona aunque esto estuviera vacio
//por eso lo he dejado como todo en comentario porque la verdad no entiendo el porque
























/*
import { useState } from "react";

function App() {
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

  const [nuevatarea, ponerTareaNueva] = useState("");
  const [columnaActiva, ponerColumnaActiva] = useState("pendiente");

  const crearTarea = () => {
    if (!nuevatarea.trim()) return;

    const columnasActualizadas = { ...columnas };

    columnasActualizadas[columnaActiva].items.push({
      id: Date.now().toString(),
      title: nuevatarea,
      priority: "Media",
      dueDate: new Date().toISOString().slice(0, 10),
    });

    setColumnas(columnasActualizadas);
    ponerTareaNueva("");
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>Mi Kanban</h1>

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

*/