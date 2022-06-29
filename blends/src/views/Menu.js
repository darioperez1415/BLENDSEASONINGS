import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { getAllBlends } from '../api/blendData';
import BlendCard from '../components/BlendCards';

export default function Menu() {
    const [blends, setBlends] = useState([]);
    const navigate = useNavigate();
    useEffect(() => {
        getAllBlends().then((array) => {
            setBlends(array);
        });
    }, []);

    const goToForm =() => {
        navigate(`/OrderForm`)
    }
    return (
        <>
            <div>
               <h1>Blends!</h1>
               <button type="button" className="btn-sucess" onClick={goToForm}> Create Order</button>
                <div>
                    {blends.map((blend) => (
                        <BlendCard
                            key={blend.id}
                            blend={blend}
                        />
                    ))}
                </div>
           </div>
        </>
    );
}