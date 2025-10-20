import TaskItem from "./TaskItem";

function TaskColumn({ title, tasks }) {
  return ( //Los bloques blancos donde se mostrara cada tarea
    <div
      style={{
        width: "250px",
        padding: "10px",
        background: "#f4f4f4",
        borderRadius: "8px",
      }}
    >
      <h2>{title}</h2>  
      {tasks.length === 0 ? ( //si no hay tareas muestra este mensaje (se ve en completado por defecto)
        <p>Sin tareas</p>
      ) : (
        tasks.map((task) => <TaskItem key={task.id} {...task} />)
      )}
    </div>
  );
}

export default TaskColumn;
