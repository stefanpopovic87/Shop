import React from 'react';
import { Card, CardActions, CardContent, CardMedia, Button, Typography } from '@mui/material';
import { Product } from '../../app/models/product';
import { Link } from 'react-router-dom';

interface Props {
    product: Product;
}

export default function ProductCard({ product }: Props) {
    return (
        <Card>
            <CardMedia
                component="img"
                height="140"
                alt={product.name}
            />
            <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                    {product.name}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {product.description}
                </Typography>
            </CardContent>
            <CardActions>
                <Button size="small" component={Link} to={`/products/${product.id}`}>
                    View
                </Button>
            </CardActions>
        </Card>
    );
}
