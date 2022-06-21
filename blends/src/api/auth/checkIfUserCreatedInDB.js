import axios from 'axios';

const baseURL = 'https://localhost:7060/api'
 
const checkUserCreatedInDB = async () => {
		//get the token from sessionStorage like this
    const token= sessionStorage.getItem("token");
		
		//or get the token from the user in state
		// const tokenFromState = user.token;

		//send the request with an Authorization header containing the token
    await axios.get(`${baseURL}/User/Auth`, {
        headers: { Authorization: 'Bearer ' + token },
    });
};

export default checkUserCreatedInDB;