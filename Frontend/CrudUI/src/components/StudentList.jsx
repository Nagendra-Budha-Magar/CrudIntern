const StudentList = ({ Students = [], deleteStudent, fetchStudents, setEditingStudent }) => {

  const handleDelete = async (id) => {
    await deleteStudent(id);
    fetchStudents();
  }
  
  console.log("STUDENTS:", Students);
  
  return (
    <div className="flex flex-wrap justify-center gap-5">
      {
        Students.map((student) => (
          <div 
            key={student.id || student.Id} 
            className="flex flex-col w-[350px] min-h-[200px] border border-gray-300 p-2.5 m-2.5"
          >
            <h3 className="m-2.5">Student Name: {student.studentName}</h3>
            <h3 className="m-2.5">Phone No: {student.phoneNo}</h3>
            <h3 className="m-2.5">Roll No: {student.rollNo}</h3>
            <h3 className="m-2.5">Semester : {student.semester?.semesterName}</h3>
            
            <div className="mt-2.5">
              <strong>Subjects:</strong>
              {student.semester?.subjectsDto?.map((sub) => (
                <p key={sub.subjectCode} className="my-0.5 mx-0">
                  {sub.subjectName} ({sub.subjectCode})
                </p>
              ))}
            </div>          
            
            <div className="flex gap-2 mt-auto">
              <button 
                onClick={() => setEditingStudent(student)} 
                className="flex-1 py-1.25 bg-[#8635dc] text-white border-none rounded cursor-pointer"
              >
                Edit
              </button>
              <button 
                onClick={() => handleDelete(student.id || student.Id)} 
                className="flex-1 py-1.25 bg-[#8635dc] text-white border-none rounded cursor-pointer"
              >
                Delete
              </button>
            </div>
          </div>
        ))
      }
    </div>
  )
}

export default StudentList;