import { createStudent, updateStudent } from "../services/StudentServices";
import { useState, useEffect } from "react";

const StudentForm = ({fetchStudents, editingStudent, setEditingStudent}) => {
  const [formData, setFormData] = useState({
      StudentName: "",
      PhoneNo: "",
      RollNo: "",
      SemesterId: ""
    });

    useEffect(() => {
    if (editingStudent) {
      setFormData({
        StudentName: editingStudent.studentName || "",
        PhoneNo: editingStudent.phoneNo || "",
        RollNo: editingStudent.rollNo || "",
        SemesterId: editingStudent.semester?.id || editingStudent.semesterId || "" 
      });
    }
  }, [editingStudent]);

    const handleChange = (e) => {
      setFormData({
        ...formData,
        [e.target.name]: e.target.value
      })
    }


const handleSubmit = async (e) => {
  e.preventDefault();

  if (!formData.SemesterId) {
  alert("Please select semester");
  return;
}

  const newStudent = {
    StudentName: formData.StudentName === "" ? null : formData.StudentName,
    PhoneNo: formData.PhoneNo === "" ? null : formData.PhoneNo,
    RollNo: Number(formData.RollNo),
    SemesterId: formData.SemesterId ? Number(formData.SemesterId) : null
  }

  if (editingStudent) {
      const studentId = editingStudent.id || editingStudent.Id;
      await updateStudent(studentId, newStudent);
      setEditingStudent(null);
    } else {
      await createStudent(newStudent);
    }
  fetchStudents();

  setFormData({
    StudentName: "",
    PhoneNo: "",
    RollNo: "",
    SemesterId: ""
  })
};

return(
  <div className="flex flex-col items-center gap-5 border border-gray-300 py-20 px-5 w-[700px]">
  <form onSubmit = {handleSubmit} className="flex flex-col gap-5 w-[500px]" >
    <input type="text" name="StudentName" value={formData.StudentName} onChange={handleChange} placeholder=" Enter the Student Name" className="border border-gray-400 p-2 rounded bg-white text-black" />
    <input type="text" name="PhoneNo" value={formData.PhoneNo} onChange={handleChange} placeholder="Enter the Phone No" className="border border-gray-400 p-2 rounded bg-white text-black" /> 
    <input type="number" name="RollNo" value={formData.RollNo} onChange={handleChange} placeholder="Enter the Roll No" className="border border-gray-400 p-2 rounded bg-white text-black" />
    <input type="number" name="SemesterId" value={formData.SemesterId} onChange={handleChange} placeholder="Enter the Semester " className="border border-gray-400 p-2 rounded bg-white text-black" />
    <button 
          type="submit" 
          className={`py-2 px-5 text-white border-none rounded cursor-pointer ${editingStudent ? 'bg-green-600' : 'bg-[#5586ba]'}`}
        >
          {editingStudent ? "Update Student" : "Add Student"}
        </button>

        {editingStudent && (
          <button 
            type="button" 
            onClick={() => {
              setEditingStudent(null);
              setFormData({ StudentName: "", PhoneNo: "", RollNo: "", SemesterId: "" });
            }}
            className="py-1 px-5 bg-gray-500 text-white rounded cursor-pointer"
          >
            Cancel Edit
          </button>
        )}
  </form>
  </div>
)
};

export default StudentForm;