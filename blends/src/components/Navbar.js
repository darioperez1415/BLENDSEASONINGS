import React from "react";
import { signOutUser } from "../api/auth/auth";
import '../styles/navBar.css'
function Navbar() {
    return (
        <div className="Navbar">
            <div className="leftSide">
                <div className="leftSidelinks">
                <a href="/">BLEND SEASONINGS </a>
                </div>
            </div>
                <div className="rightSide">
                    <div className="rightSideLinks">
                       <a className="nav-link active" href="/Home">Home</a>
                        <a className="nav-link active" href="/Menu">Menu</a>
                        <a className="Order" href="/Orders">Orders</a>
                    </div>
                </div>
                        <button type="button" className="btn btn-danger" onClick={signOutUser}>
                            Log Out
                        </button>
        </div>
    );
};

export default Navbar;