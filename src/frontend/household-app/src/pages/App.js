import {omponent } from 'react';
import React, { useState, useEffect } from 'react';
import TestRoute from './TestRoute';
import Home from './Home';
import { 
    BrowserRouter as Browser,
    Routes,
    Route,
} from 'react-router-dom';

export default function App() {
    return (
        <TestRoute/>
    );
}
