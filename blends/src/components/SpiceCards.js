import React from "react";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

export default function SpiceCard({ spice }) {
    console.warn(spice);
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
    spice: PropTypes.shape({})
};
