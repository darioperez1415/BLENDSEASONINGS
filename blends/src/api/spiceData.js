import axios from 'axios';

const baseURL = "https://localhost:7060/api";

const getAllSpices = () => new Promise((resolve, reject) => {
    axios
        .get(`${baseURL}/Spice`)
        .then((response) => resolve(Object.values(response.data)))
        .catch(reject);
});

const getSpiceById = (spiceId) => new Promise((resolve, reject) => {
    axios.get(`${baseURL}/Spice/${spiceId}`)
    .then((response) => {
        resolve(response.data);
    })
    .catch(reject)
})

export { getAllSpices, getSpiceById };