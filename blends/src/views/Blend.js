import React, { useEffect, useState } from 'react';
import { getAllBlends } from '../api/blendData';
import BlendCard from '../components/BlendCards';

export default function AllBlends() {
    const [blends, setBlends] = useState([]);
    
    useEffect(() => {
        getAllBlends().then((array) => {
            setBlends(array);
        });
    }, []);
    return (
        <>
            <div>
               <h1>Blends!</h1>
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