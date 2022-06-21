import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";
import { createOrder, updateOrder} from "../api/orderData";
import "bootstrap/js/src/collapse";
//import getCurrentUsersUid from "../helpers/helpers";

const initialState = {
  userId: "",
  total: 0,
  cardNum: "",
  nameOnCard: "",
  expiration: "",
  billingZip: "",
  address: "",
  phone: "",
  date: "",
  weight: 0
};

export default function OrderForm({ obj = {} }) {
  const [formInput, setFormInput] = useState(initialState);
  const navigate = useNavigate();
 // const UID = getCurrentUsersUid();

  useEffect(() => {
    if (obj.id) {
      setFormInput({
        id: obj.id,
        userId: obj.userId,
        total: obj.total,
        cardNum: obj.cardNum,
        expiration: obj.expiration,
        nameOnCard: obj.nameOnCard,
        billingZip: obj.billingZip,
        address: obj.address,
        phone: obj.phone,
        date: obj.date,
        weight: obj.weight,
      });
    }
  }, [obj]);

  const resetForm = () => {
    setFormInput(initialState);
  };

  const handleChange = (e) => {
    setFormInput((prevState) => ({
      ...prevState,

      [e.target.name]: e.target.value,
    }));
  };
  const handleClick = (e) => {
    e.preventDefault();
    if (obj.id) {
      updateOrder(formInput).then(() => {
        navigate(`/`);
      });
    } else {
      console.log(formInput);
//console.log(UID);
        createOrder(
          formInput
        ).then(() => {
          resetForm();
          navigate(`/Order`);
        });
      };
    };
  return (
    <form onSubmit={handleClick}>
      <div className="form-group">
        <label htmlFor="cardNum">Credit Card Number</label>

        <input
          type="text"
          className="form-control"
          value={formInput.cardNum || ""}
          aria-describedby="card number"
          placeholder="xxxxxxxxxx"
          onChange={(e) => handleChange(e)}
          name="cardNum"
        />
      </div>

      <div className="form-group">
        <label htmlFor="expiration">Expiration Date</label>

        <input
          type="text"
          className="form-control"
          value={formInput.expiration || ""}
          placeholder="00/00"
          onChange={(e) => handleChange(e)}
          name="expiration"
        />
      </div>

      <div className="form-group">
        <label htmlFor="nameOnCard">Name</label>

        <input
          type="text"
          className="form-control"
          value={formInput.nameOnCard || ""}
          placeholder="Enter Name"
          onChange={(e) => handleChange(e)}
          name="nameOnCard"
        />
      </div>

      <div className="form-group">
        <label htmlFor="billingZip">Billing Zipcode</label>

        <input
          type="text"
          className="form-control"
          value={formInput.billingZip || ""}
          placeholder="Enter Zip Code"
          onChange={(e) => handleChange(e)}
          name="billingZip"
        />
      </div>

      <div className="form-group">
        <label htmlFor="address">Address</label>

        <input
          type="text"
          className="form-control"
          value={formInput.address || ""}
          placeholder="Enter Address"
          onChange={(e) => handleChange(e)}
          name="address"
        />
      </div>

      <div className="form-group">
        <label htmlFor="phone">Phone Number</label>

        <input
          type="text"
          className="form-control"
          value={formInput.phone || ""}
          placeholder="0000000000"
          onChange={(e) => handleChange(e)}
          name="phone"
        />
      </div>

      <button type="submit" className="btn btn-primary">
        {obj.id ? "Update Order" : "Checkout"}
      </button>
    </form>
  );
}

OrderForm.propTypes = {
  obj: PropTypes.shape({}),
};
OrderForm.defaultProps = { obj: {} };