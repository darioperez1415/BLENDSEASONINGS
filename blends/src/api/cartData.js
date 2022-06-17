import axios from "axios";

const baseURL = "https://localhost:7060/api";

const getBlendOrderId = (orderId) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/${orderId}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const addToCart = (newOrder) =>
  new Promise((resolve, reject) => {
    axios
      .post(`${baseURL}/AddToCart`, newOrder)
      .then((response) => {
        resolve(response.data.id);
      })
      .catch(reject);
  });

const removeFromCart = (id, orderId) =>
  new Promise((resolve,reject) => {
    axios
      .delete(`${baseURL}/Remove/${id}`)
      .then(() => getBlendOrderId(orderId).then(resolve))
      .catch(reject)
  });

export {
    addToCart,
    removeFromCart,
    getBlendOrderId,
};
  