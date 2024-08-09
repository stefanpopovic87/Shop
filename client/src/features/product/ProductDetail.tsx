import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams, Link, useNavigate } from 'react-router-dom';
import { Container, Typography, CircularProgress, Box, IconButton } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { fetchProductById, deleteProduct } from './productSlice';
import { RootState, AppDispatch } from '../../app/store/configureStore';

const ProductDetail = () => {
    const { id } = useParams<{ id: string }>();
    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();
    const { product, status, error } = useSelector((state: RootState) => state.products);

    useEffect(() => {
        dispatch(fetchProductById(Number(id)));
    }, [dispatch, id]);

    const handleDelete = async () => {
        await dispatch(deleteProduct(Number(id)));
        navigate('/products');
    };

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
                    <Box display="flex" justifyContent="space-between" alignItems="center">
                        <Typography variant="h4" component="h1" gutterBottom>
                            {product.name}
                        </Typography>
                        <Box>
                            <IconButton component={Link} to={`/products/edit/${id}`} aria-label="edit">
                                <EditIcon />
                            </IconButton>
                            <IconButton onClick={handleDelete} aria-label="delete">
                                <DeleteIcon />
                            </IconButton>
                        </Box>
                    </Box>
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
