import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from '../views/Home';
import Login from '../views/Login';
import Products from '../views/Menu';
import AllBlends from '../views/Blend'; 
import Orders from '../views/Order';
import OrderForm from '../components/OrderForm';
import EditOrder from '../views/EditOrder';

export default function Routing() {
    return (
        <div>
            <Routes>
                <Route exact path="/" element={<Home />}></Route>
                <Route exact path="/Login" element={<Login />}></Route>
                <Route exact path="/Products" element={<Products/>}></Route>
                <Route exact path="/Blend" element={<AllBlends/>}></Route>
                <Route exact path="/Order" element={<Orders />}></Route>
                <Route exact path="/OrderForm" element={<OrderForm />}></Route>
                <Route exact path="/editOrder/:key" element={<EditOrder/>} />
            </Routes>
        </div>
    )
}