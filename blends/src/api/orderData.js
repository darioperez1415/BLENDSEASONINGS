import axios from "axios";

const baseURL = "https://localhost:7060/api";

const getAllOrders = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Orders`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getSingleOrder = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Orders/${id}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const getOrdersByUserId = (userId) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Orders/user/${userId}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createOrder = (newOrder) =>
  new Promise((resolve,reject) => {
    axios
      .post(`${baseURL}/Orders`,newOrder)
      .then((response) => {
        resolve(response.data.id);
      })
      .catch(reject);
  });

const updateOrder = (orderObj) =>
  new Promise((resolve, reject) => {
    axios
      .put(`${baseURL}/Orders/${orderObj.id}`, orderObj)
      .then(() => getOrdersByUserId(orderObj.userId).then(resolve))

          .catch(reject);
  });

const deleteOrder = (id, userId) =>
  new Promise((resolve, reject) => {
    axios
      .delete(`${baseURL}/Orders/${id}`)
      .then(() => getOrdersByUserId(userId).then(resolve))
      .catch(reject);
  });

export {
  getAllOrders,
  getOrdersByUserId,
  getSingleOrder,
  createOrder,
  updateOrder,
  deleteOrder,
};
