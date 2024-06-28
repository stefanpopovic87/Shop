import React from 'react';
import { AppBar, Button, Toolbar, Typography } from '@mui/material';
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" style={{ flexGrow: 1 }}>
                    Shop
                </Typography>
                <Button color="inherit" component={Link} to="/products">
                    Products
                </Button>
            </Toolbar>
        </AppBar>
    );
};

export default Header;
