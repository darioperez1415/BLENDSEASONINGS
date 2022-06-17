import axios from "axios";

const baseURL = "https://localhost:7060/api";

const getAllBlends = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Blend`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getSingleBlend = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Blend/${id}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const createNewBlend = (newBlend) =>
  new Promise((resolve, reject) => {
    axios
      .post(`${baseURL}/CreateNewBlend`, newBlend)
      .then((response) => {
        resolve(response.data.id);
      })
      .catch(reject);
  });

export {
  getAllBlends,
  getSingleBlend,
  createNewBlend,
};
