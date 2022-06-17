import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { getAllSpices } from '../api/spiceData';
import SpiceCard from '../components/SpiceCards';

export default function Products() {
    const [spices, setSpices] = useState([]);
    const navigate = useNavigate();
    useEffect(() => {
        getAllSpices().then((array) => {
            setSpices(array);
        });
    }, []);

    const goToForm =() => {
        navigate(`/OrderForm`)
    }
    return (
        <>
            <div>
               <h1>SPICES!</h1>
               <button type="button" className="btn-sucess" onClick={goToForm}> Create Order</button>
                <div>
                    {spices.map((spice) => (
                        <SpiceCard
                            key={spice.id}
                            spice={spice}
                        />
                    ))}
                </div>
           </div>
        </>
    );
}