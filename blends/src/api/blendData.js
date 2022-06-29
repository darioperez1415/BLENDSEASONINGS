import axios from "axios";

const baseURL = "https://localhost:7060/api";

const getAllBlends = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Blend`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getBlendById = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Blend/${id}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

export {
  getAllBlends,
    getBlendById
};
