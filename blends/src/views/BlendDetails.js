import React, { useEffect, useState } from 'react';
import { getBlendById } from '../api/blendData';
import { useParams } from 'react-router-dom';
import BlendDetailsCard from '../components/DetailsCard';

export default function BlendDetails() {
    const [singleBlend, setSingleBlend] = useState({});
    const { key } = useParams();

    useEffect(() => {
        getBlendById(key).then(setSingleBlend)
    }, []);

    return (
        <div>
            <BlendDetailsCard blend={singleBlend} />
        </div>
    )
}