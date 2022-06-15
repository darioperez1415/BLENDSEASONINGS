import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";
import { deleteOrder, getOrdersByUserId } from "../api/orderData";

export default function OrderCard({ order, setOrders }) {
  const [blends, setBlends] = useState([]);

  const navigate = useNavigate();

  const handleClick = (method) => {
    if (method === "delete") {
      deleteOrder(order.id).then(setOrders)
    } else if (method === "edit") {
      navigate(`/editOrder/${order.id}`);
    }
  };

  useEffect(() => {
    getOrdersByUserId(order.id).then((array) => {
        setBlends(array);
    });
  }, []);
  return (
    <>
      <div className="card">
        <div className="card-header">
          <h4 className="card-title">Order Number: {order.id}</h4>
          <p className="card-text">Order Name: {order.nameOnCard}</p>
          <p className="card-text">Date: {order.date}</p>
          {
            <>
            <ul>{
                blends?.map((blend) => (
                  <li key={blend.id} >{blend.blendName}</li>
                  ))}
            </ul>
            </>
          }
          <div>
            <button
              type="button"
              onClick={() => handleClick("edit")}
              className="btn btn-warning"
            >
              Update Order
            </button>
            <button
              type="button"
              onClick={() => handleClick("delete")}
              className="btn btn-danger"
            >
              Delete Order
            </button>
          </div>
        </div>
      </div>
    </>
  );
}

OrderCard.propTypes = {
  order: PropTypes.shape(PropTypes.obj).isRequired,
  setOrders: PropTypes.func.isRequired,
};
