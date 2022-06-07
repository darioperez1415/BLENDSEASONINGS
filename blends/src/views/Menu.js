import React, { useEffect, useState } from 'react';
import { getAllSpices } from '../api/spiceData';
import SpiceCard from '../components/SpiceCards';

export default function Menu() {
    const [spices, setSpices] = useState([]);
    
    useEffect(() => {
        getAllSpices().then((array) => {
            setSpices(array);
        });
    }, []);
    return (
        <>
            <div>
               <h1>SPICES!</h1>
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