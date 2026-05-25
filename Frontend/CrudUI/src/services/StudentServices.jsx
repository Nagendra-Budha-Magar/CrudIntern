import axios from "axios";

const API_URL = "https://localhost:7284/api/Student"

// For Get Student
export const getStudent = async () => {
    const {data} = await axios.get(API_URL);
    return data;
}

// For Get Student by Id
export const getStudentById = async (id) => {
    const {data} = await axios.get(`${API_URL}/${id}`);
    return data;
}

// For post Student
export const createStudent = async (student) => {
    const {data} = await axios.post(API_URL, student);
    return data;
}

// For put Student
export const updateStudent = async (id, updateStudent) => {
    const {data} = await axios.put(`${API_URL}/${id}`, updateStudent);
    return data;
}

// For delete Student
export const deleteStudent = async (id) => {
  await axios.delete(`${API_URL}/${id}`);
};