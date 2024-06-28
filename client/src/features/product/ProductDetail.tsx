import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router-dom';
import { Container, Typography, CircularProgress, Box } from '@mui/material';
import { fetchProductById } from './productSlice';
import { RootState, AppDispatch } from '../../app/store/configureStore';

const ProductDetail = () => {
    const { id } = useParams<{ id: string }>();
    const dispatch = useDispatch<AppDispatch>();
    const { product, status, error } = useSelector((state: RootState) => state.products);

    useEffect(() => {
        dispatch(fetchProductById(Number(id)));
    }, [dispatch, id]);

    if (status === 'loading') {
        return (
            <Box display="flex" justifyContent="center" alignItems="center" height="100vh">
                <CircularProgress />
            </Box>
        );
    }

    if (status === 'failed') {
        return <div>Error: {error}</div>;
    }

    return (
        <Container maxWidth="sm">
            {product && (
                <>
                    <Typography variant="h4" component="h1" gutterBottom>
                        {product.name}
                    </Typography>
                    {/* <img src={product.pictureUrl} alt={product.name} style={{ width: '100%' }} /> */}
                    <Typography variant="body1" paragraph>
                        {product.description}
                    </Typography>
                    <Typography variant="h6" component="h2">
                        ${product.price}
                    </Typography>
                </>
            )}
        </Container>
    );
};

export default ProductDetail;
