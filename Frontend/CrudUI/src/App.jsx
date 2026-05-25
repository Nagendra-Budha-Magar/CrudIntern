import StudentForm from "./components/StudentForm";
import StudentList from "./components/StudentList";
import { deleteStudent, getStudent } from "./services/StudentServices";
import { useEffect, useState } from "react";

const App = () => {
  const [Students, setStudents] = useState([]);
  const [editingStudent, setEditingStudent] = useState(null);

  const fetchStudents = async () => {
    const data = await getStudent();
    console.log("API DATA:", data);
    setStudents(data);
  }

  useEffect(() => {
    fetchStudents();
  }, [])

  return(
    <div className="Container flex flex-col items-center gap-5"> 
      <h1 className="text-2xl font-bold mt-5">Student Management</h1>

      <StudentForm fetchStudents={fetchStudents} editingStudent={editingStudent} setEditingStudent={setEditingStudent} />
      <StudentList Students={Students} deleteStudent={deleteStudent} fetchStudents={fetchStudents} editingStudent={editingStudent} setEditingStudent={setEditingStudent} />
    </div>
  )
}

export default App;