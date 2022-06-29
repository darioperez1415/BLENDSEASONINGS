import React, { useEffect, useState } from "react";
//import PropTypes from "prop-types";
import { useNavigate, useParams } from "react-router-dom";
import { getAllBlends, getBlendById } from "../api/blendData";
import "bootstrap/dist/css/bootstrap.min.css";
import {
    createBlendOrder,
    getBlendOrderByOrderId,
} from "../api/blendOrderData";
import { getSingleOrder, updateOrder } from "../api/orderData";
import BOCard from "./BOCard";
import getCurrentUsersUid from "../helpers/helpers";

export default function CartForm() {
    const [blendOrders, setBlendOrders] = useState([]);
    const [newBO, setBO] = useState({});
    const [blends, setBlends] = useState([]);
    const [order, setOrder] = useState({});
    const { id } = useParams();
    const navigate = useNavigate();
    const UID = getCurrentUsersUid();

    useEffect(() => {
        getSingleOrder(id).then((order) => setOrder(order));
        getAllBlends().then((blends) => {
            setBlends(blends);
        });
        getBlendOrderByOrderId(id).then((setBlendOrders) => {
            setBlendOrders(blendOrders);
        });

    }, [newBO]);
    const handleAddDog = () => {
        console.log("sending");
        console.log(newBO);
        console.log(newBO.orderId);
        createBlendOrder(newBO).then(
            getBlendOrderByOrderId(order.id).then(setBlendOrders)
        );
    };

    const changeBlend = (newBlendId) => {
        getBlendById(newBlendId).then((res) => {
            console.log("changing");
            console.log(res);
            setBO({
                id: 6,
                orderId: order.id,
                blendId: res.id,
                blendName: res.name,
            });
        });
    };
    const handleSubmit = (order) => {
        setOrder({
            ...order,
            status: false
        })
        console.log(order)
        updateOrder({
            id: order.id,
            userId: UID,
            cardNum: order.cardNum,
            expiration: order.expiration,
            nameOnCard: order.nameOnCard,
            billingZip: order.billingZip,
            address: order.address,
            phone: order.phone,
            date: order.date,
            total: order.total,
            status: false,
        }).then((res) => {
            console.log(res);
            navigate("/Orders");
        })


    };

    return (
        <>
            <div>
                <h2>Your Order # {order.id}</h2>
                {blendOrders?.map((bo) => (
                    <BOCard key={bo.id} bo={bo} setBO={setBlendOrders} />
                ))}
            </div>
            <div></div>
            <div>
                <select
                    style={{ width: "18rem" }}
                    onChange={(event) => changeBlend(event.target.value)}
                    value={newBO}
                >
                    <option></option>
                    {blends?.map((blend) => (
                        <option key={blend.id} value={blend.id}>
                            {blend.name}
                        </option>
                    ))}
                </select>
                <button
                    type="button"
                    className="btn btn-success"
                    onClick={handleAddDog}
                >
                    Add to Order
                </button>
            </div>
            <div>
                <button
                    type="button"
                    className="btn btn-success"
                    onClick={() => handleSubmit(order)}
                >
                    Submit Order
                </button>
            </div>
        </>
    );
}
// CartForm.propTypes = {
//   obj: PropTypes.shape({}),
// };
// CartForm.defaultProps = { obj: {} };

// add a submit order button that closes the order and hides the update and delete options and writes
//closed on the order card.
//add buttons for delete
