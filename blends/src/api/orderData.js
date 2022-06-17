import axios from "axios";

const baseURL = "https://localhost:7060/api";

const getAllOrders = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Order`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const getSingleOrder = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Order/${id}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const getOrdersByUserId = (userId) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Order/user/${userId}`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

const createOrder = (newOrder) =>
  new Promise((resolve, reject) => {
    axios
      .post(`${baseURL}/Order`, newOrder)
      .then((response) => {
        resolve(response.data.id);
      })
      .catch(reject);
  });

const updateOrder = (orderObj) =>
  new Promise((resolve, reject) => {
    axios
      .put(`${baseURL}/Order/${orderObj.id}`, orderObj)
      .then(() =>getAllOrders(orderObj.id).then(resolve))
    
      .catch(reject);
  });

const deleteOrder = (id) =>
  new Promise((resolve, reject) => {
    axios
      .delete(`${baseURL}/Order/${id}`)
      .then(() => getAllOrders(id).then(resolve))
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
