import React from 'react';
import { Navigate, createBrowserRouter } from 'react-router-dom';
import App from '../../App';
import ProductList from '../../features/product/ProductList';
import ProductForm from '../../features/product/ProductForm';
import ProductDetail from '../../features/product/ProductDetail';

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'products', element: <ProductList /> },
            { path: 'products/create', element: <ProductForm isEdit={false} /> },
            { path: 'products/edit/:id', element: <ProductForm isEdit={true} /> },
            { path: 'products/:id', element: <ProductDetail /> },
            { path: '*', element: <Navigate replace to='/not-found' /> },
        ],
    },
]);
