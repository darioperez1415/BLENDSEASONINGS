import React, { useState, useEffect } from "react";
import auth from "./api/auth/apiKeys";
import { useNavigate } from "react-router-dom";
import checkUserCreatedInDB from "./api/auth/checkIfUserCreatedInDB";
import Routing from "./routes";
import Navbar from "./components/Navbar";
//import "./App.css";
import Login from "./views/Login";

function App() {
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        auth.onAuthStateChanged(async (response) => {
      if (response) {
        const userObj = {
          uid: response.uid,
          fullName: response.displayName,
          profilePic: response.photoURL,
          username: response.email.split("@")[0],
          token: response.accessToken, //you can save the token in an object if you want
        };setUser(userObj);

        console.log(userObj);

        sessionStorage.setItem("token", response.accessToken);
        console.log(userObj.uid);
        checkUserCreatedInDB(response.accessToken);
      } else {
        setUser(false);

        //don't forget to clear the token if using sessionStorage!
        sessionStorage.removeItem("token");

        navigate('/');
      }
    });
  }, []);
    return (
        <div>
            {user ? (
                <>
                    <Navbar />
                    <Routing />
                </>
            ) : (
                <Login user={user} />
            )}
        </div>
    );
}

export default App;
