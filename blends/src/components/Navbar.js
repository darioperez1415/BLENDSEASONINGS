import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { signOutUser } from "../api/auth/auth";

function Navbar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">
                    BLEND SEASONINGS
                </a>
                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNavAltMarkup"
                    aria-controls="navbarNavAltMarkup"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <div className="navbar-nav">
                        <a className="nav-link active" aria-current="page" href="/">
                            Home
                        </a>
                        <a className="nav-link" href="/Menu">
                            Menu
                        </a>

                        <a className="nav-link" href="/Orders">
                            Orders
                        </a>
                        <button className="btn btn-danger" onClick={signOutUser}>
                            Log Out
                        </button>
                    </div>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;