import React, { useEffect } from 'react';
import { Grid } from '@mui/material';
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore';
import { fetchProducts } from './productSlice';
import ProductCard from './ProductCard';
import './ProductList.scss';

export default function ProductList() {
    const dispatch = useAppDispatch();
    const { products, status, productsLoaded } = useAppSelector(state => state.products);

    useEffect(() => {
        if (status === 'idle') {
            dispatch(fetchProducts());
        }
    }, [status, dispatch]);

    return (
        <Grid container spacing={4}>
            {products.map(product => (
                <Grid item xs={4} key={product.id}>
                    {!productsLoaded ? (
                        <div className="skeleton-card">
                            <div className="skeleton-image"></div>
                            <div className="skeleton-content">
                                <div className="skeleton-title"></div>
                                <div className="skeleton-subtitle"></div>
                            </div>
                        </div>
                    ) : (
                        <ProductCard product={product} />
                    )}
                </Grid>
            ))}
        </Grid>
    );
}
