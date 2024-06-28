import React from 'react';
import { Outlet } from 'react-router-dom';
import { Container } from '@mui/material';
import Header from './app/layout/Header';

const App = () => {
    return (
        <>
            <Header />
            <Container>
                <Outlet />
            </Container>
        </>
    );
};

export default App;
