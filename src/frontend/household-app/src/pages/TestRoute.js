import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const TestRoute = () => 
{
    useEffect(() => {
        async function getDataAsync() => {
            const results = await axios.get("");
        }
    }, []);

};
