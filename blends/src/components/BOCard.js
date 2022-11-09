import React from 'react';
import PropTypes from 'prop-types';
import "bootstrap/dist/css/bootstrap.min.css";
import { deleteBlendOrder } from '../api/blendOrderData';

export default function BOCard({ bo, setbos }) {
    const handleDel = () => {
        deleteBlendOrder(bo.id, bo.orderId).then(setbos);
    }
    return (
        <>
            <div className="card" style={{ width: '18rem' }}>
                <div className="card-body">
                    <h5 className="card-title">{bo.blendName}</h5>
                    <button type="button" className="btn btn-danger" onClick={handleDel}> Delete</button>
                </div>
            </div>
        </>
    )
}

BOCard.propTypes = {
    hdo: PropTypes.shape({
        id: PropTypes.number,
        blendName: PropTypes.string,
        orderId: PropTypes.string,
    }),
    setbos: PropTypes.func.isRequired,
};

BOCard.defaultProps = {
    bo: {},
}