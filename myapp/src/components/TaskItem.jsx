function TaskItem({ title, priority, dueDate }) {
  return (
    <div
      style={{
        background: "white",
        margin: "5px 0",
        padding: "8px",
        borderRadius: "5px",
      }}
      //muestra el titulo de la tarea, su prioridad y la fecha limite
    > 
      <h4>{title}</h4>
      <p>Prioridad: {priority}</p>
      <p>Fecha límite: {dueDate}</p>
    </div>
  );
}

export default TaskItem;
