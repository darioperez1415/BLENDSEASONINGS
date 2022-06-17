import React, { useEffect, useState } from "react";
import { getAllOrders } from "../api/orderData";
import OrderCard from "../components/OrderCard";
//import getCurrentUsersUid from "../helpers/helpers";

export default function Orders() {
  const [orders, setOrders] = useState([]);
  //const UID = getCurrentUsersUid();

  useEffect(() => {
    getAllOrders().then((array) => {
      setOrders(array);
    });
  }, []);

  return (
    <>
      <div>
        <h1>All Orders </h1>
        {orders ? (
          <>
            <div>
              {orders?.map((order) => (
                <OrderCard key={order.id} order={order} setOrders={setOrders} />
              ))}
            </div>
          </>
        ) : (
          <h2>You don't have any orders! Go to the Products to get some Blends!</h2>
        )}
      </div>
    </>
  );
}