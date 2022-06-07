import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from '../views/Home';
import Login from '../views/Login';
import Menu from '../views/Menu';

export default function Routing() {
    return (
        <div>
            <Routes>
                <Route exact path="/" element={<Home />}></Route>
                <Route exact path="/Login" element={<Login />}></Route>
                <Route exact path="/Menu" element={<Menu/>}></Route>
            </Routes>
        </div>
    )
}