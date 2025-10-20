import TaskColumn from "./TaskColumn";

function KanbanBoard({ columnas }) {
  if (!columnas) return <p>Cargando...</p>;

  return ( //devuelve todos los objetos (tareas) de las diferentes tablas
    <div style={{ display: "flex", gap: "20px" }}>
      {Object.keys(columnas).map((key) => (
        <TaskColumn
          key={columnas[key].id}
          title={columnas[key].name}
          tasks={columnas[key].items}
        />
      ))}
    </div>
  );
}

export default KanbanBoard;
