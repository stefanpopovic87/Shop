import React, { useState, useEffect } from 'react';
import { TextField, Button, Container } from '@mui/material';
import { useDispatch, useSelector } from 'react-redux';
import { useParams, useNavigate } from 'react-router-dom';
import { createProduct, updateProduct, fetchProductById } from './productSlice';
import { RootState, AppDispatch } from '../../app/store/configureStore';
import { Product } from '../../app/models/product';

interface ProductFormProps {
    isEdit: boolean;
}

const ProductForm: React.FC<ProductFormProps> = ({ isEdit }) => {
    const { id } = useParams<{ id: string }>();
    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();
    const { product } = useSelector((state: RootState) => state.products);

    const [formData, setFormData] = useState<Omit<Product, 'id'>>({
        name: '',
        description: '',
        price: 0,
        pictureUrl: '',
    });

    useEffect(() => {
        if (isEdit && id) {
            dispatch(fetchProductById(Number(id)));
        }
    }, [dispatch, id, isEdit]);

    useEffect(() => {
        if (isEdit && product) {
            setFormData({
                name: product.name,
                description: product.description,
                price: product.price,
                pictureUrl: product.pictureUrl || '',
            });
        }
    }, [product, isEdit]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({ ...prevData, [name]: value }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (isEdit) {
            await dispatch(updateProduct({ ...formData, id: Number(id) }));
        } else {
            await dispatch(createProduct(formData));
        }
        navigate('/products');
    };

    return (
        <Container maxWidth="sm">
            <form onSubmit={handleSubmit}>
                <TextField
                    fullWidth
                    label="Name"
                    name="name"
                    value={formData.name}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Description"
                    name="description"
                    value={formData.description}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Price"
                    name="price"
                    type="number"
                    value={formData.price}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Picture URL"
                    name="pictureUrl"
                    value={formData.pictureUrl}
                    onChange={handleChange}
                    margin="normal"
                />
                <Button type="submit" variant="contained" color="primary" fullWidth>
                    {isEdit ? 'Update' : 'Create'} Product
                </Button>
            </form>
        </Container>
    );
};

export default ProductForm;
