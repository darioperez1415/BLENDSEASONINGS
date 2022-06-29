import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";

function BlendDetailsCard({ blend }) {
    return (
        <div className="card mb-3">
            <img src={blend.imageUrl} className="card-img-top" alt={blend.name} />
            <div className="card-body">
                <h5 className="card-title">{blend.name}</h5>
                <p className="card-text">{blend.ingredients}</p>
            </div>
        </div>
    )
}

export default BlendDetailsCard;