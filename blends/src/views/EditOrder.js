import React, { useState, useEffect } from 'react';
import { getSingleOrder } from '../api/orderData';
import OrderForm from '../components/OrderForm';
import { useParams } from 'react-router-dom';

function EditOrder() {
    const [editOrder, setEditOrder] = useState({});
    const { ekey } = useParams();

useEffect(() => {
    getSingleOrder(ekey).then(setEditOrder);
    console.log(ekey)
}, []);

  return (
    <div>
        <h2>Edit Order</h2>
        <OrderForm obj={editOrder} />
    </div>
  )
}

export default EditOrder;