import React from 'react';
import { AppBar, Button, Toolbar, Typography } from '@mui/material';
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <AppBar position="static" sx={{ marginBottom: '2rem' }}>
            <Toolbar>
                <Typography variant="h6" component={Link} to="/" style={{ textDecoration: 'none', color: 'inherit' }}>
                    Shop
                </Typography>
                <div style={{ flexGrow: 1 }}></div>
                <Button color="inherit" component={Link} to="/products">
                    Products
                </Button>
            </Toolbar>
        </AppBar>
    );
};

export default Header;
