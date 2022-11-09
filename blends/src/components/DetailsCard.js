import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";

function BlendDetailsCard({ blend }) {
    return (
        <div className="spiceCard" style={{ width: "18rem" }}>
            <img src={blend.imageUrl} className="card-img-top" alt={blend.name} />
            <div className="card-body">
                <h3 className="card-title">{blend.name}</h3>
                <h5 className="card-title">Ingredients</h5>
                <p className="card-text">{blend.ingredients}</p>
                <h5 className="card-title">Price</h5>
                <p className="card-text">${blend.price}</p>
            </div>
        </div>
    )
}

export default BlendDetailsCard;