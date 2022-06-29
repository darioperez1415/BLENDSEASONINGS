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
              <img
                  src={blend.imageUrl}
                  className="card-img-top"
                  alt={blend.name}
              ></img>
        <div className="card-body">
                  <h5 className="card-title">{blend.name}</h5>
                  <p className="card-text">{blend.ingredients}</p>
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
  blend: PropTypes.shape({
    id: PropTypes.number,
    name: PropTypes.string,
    ingredients: PropTypes.string,
    imageUrl: PropTypes.string,
}),
};
