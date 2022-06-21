import axios from "axios";

const baseURL = "https://localhost:7060/api";

const getAllUsers = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/User`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });
const getUserById = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/User/${id}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });
const createUser = (newUser) =>
  new Promise((resolve, reject) => {
    axios
      .post(`${baseURL}/User`, newUser)
      .then((response) => {
        resolve(response.data);
      })
      .catch(reject);
  });

export { createUser, getAllUsers, getUserById };
