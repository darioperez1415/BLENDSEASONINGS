import React from "react";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

export default function BlendCard({ blend }) {
  const navigate = useNavigate();
  const handleInfo = () => {
    navigate(`/Blend/${blend.id}`);
  };
  return (
    <>
      <div className="spiceCard" style={{ width: "18rem" }}>
        <div className="card-body">
          <h5 className="card-title">{blend.name}</h5>
          <button type="button" className="btn btn-info" onClick={handleInfo}>
            {" "}
            Info
          </button>

        </div>
      </div>
    </>
  );
}

BlendCard.propTypes = {
    blend: PropTypes.shape({})
};
