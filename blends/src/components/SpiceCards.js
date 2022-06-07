import React from "react";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

export default function SpiceCard({ spice }) {
  const navigate = useNavigate();
  const handleInfo = () => {
    navigate(`/Spice/${spice.id}`);
  };
  return (
    <>
      <div className="spiceCard" style={{ width: "18rem" }}>
        <img
          src={spice.imageUrl}
          className="card-img-top"
          alt={spice.name}
        ></img>
        <div className="card-body">
          <h5 className="card-title">{spice.name}</h5>
          <p className="card-text">Peight{spice.weight}</p>
          <p className="card-text">Price:{spice.price}</p>
          <button type="button" className="btn btn-info" onClick={handleInfo}>
            {" "}
            Info
          </button>
        </div>
      </div>
    </>
  );
}

SpiceCard.propTypes = {
    spice: PropTypes.shape({
    id: PropTypes.number,
    name:PropTypes.string,
    weight: PropTypes.number,
    price: PropTypes.number,
    imageUrl: PropTypes.string,
  }),
};
