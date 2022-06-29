import axios from "axios";

const baseURL = "https://localhost:7060/api/Orders/blendOrder";

const getBlendOrderByOrderId = (orderId) =>
    new Promise((resolve, reject) => {
        axios
            .get(`${baseURL}/${orderId}`)
            .then((response) => resolve(Object.values(response.data)))
            .catch(reject);
    });

const createBlendOrder = (obj) =>
    new Promise((resolve, reject) => {
        axios
            .post(`${baseURL}`, obj)
            .then((response) => {
                console.log(obj);
                resolve(response.data.id);
            })
            .catch(reject);
    });;

const deleteBlendOrder = (id, orderId) => new Promise((resolve, reject) => {
    axios
        .delete(`${baseURL}/${id}`)
        .then(() => getBlendOrderByOrderId(orderId).then(resolve))
        .catch(reject);
});
export {
    getBlendOrderByOrderId,
    createBlendOrder,
    deleteBlendOrder,
};
  