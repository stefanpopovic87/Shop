import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../app/store/configureStore';
import { Product, ProductState } from '../../app/models/product';
import agent from '../../app/api/agent';

const initialState: ProductState = {
    products: [],
    product: null,
    status: 'idle',
    error: null,
    productsLoaded: false
};

export const fetchProducts = createAsyncThunk<Product[], void, { state: RootState; rejectValue: string }>(
    'products/fetchProducts',
    async (_, { rejectWithValue }) => {
        try {
            const response = await agent.Products.list();
            return response;
        } catch (err) {
            return rejectWithValue((err as Error).message);
        }
    }
);

export const fetchProductById = createAsyncThunk<Product, number, { state: RootState; rejectValue: string }>(
    'products/fetchProductById',
    async (id, { rejectWithValue }) => {
        try {
            const response = await agent.Products.details(id);
            return response;
        } catch (err) {
            return rejectWithValue((err as Error).message);
        }
    }
);

export const createProduct = createAsyncThunk<Product, Omit<Product, 'id'>, { state: RootState; rejectValue: string }>(
    'products/createProduct',
    async (product, { rejectWithValue }) => {
        try {
            const response = await agent.Products.create(product);
            return response;
        } catch (err) {
            return rejectWithValue((err as Error).message);
        }
    }
);

export const updateProduct = createAsyncThunk<Product, Product, { state: RootState; rejectValue: string }>(
    'products/updateProduct',
    async (product, { rejectWithValue }) => {
        try {
            const response = await agent.Products.update(product);
            return response;
        } catch (err) {
            return rejectWithValue((err as Error).message);
        }
    }
);

export const deleteProduct = createAsyncThunk<number, number, { state: RootState; rejectValue: string }>(
    'products/deleteProduct',
    async (id, { rejectWithValue }) => {
        try {
            await agent.Products.delete(id);
            return id;
        } catch (err) {
            return rejectWithValue((err as Error).message);
        }
    }
);

const productSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchProducts.pending, (state) => {
                state.status = 'loading';
            })
            .addCase(fetchProducts.fulfilled, (state, action: PayloadAction<Product[]>) => {
                state.status = 'succeeded';
                state.products = action.payload;
                state.productsLoaded = true; // Dodajte ovo
            })
            .addCase(fetchProducts.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.payload as string;
            })
            .addCase(fetchProductById.pending, (state) => {
                state.status = 'loading';
            })
            .addCase(fetchProductById.fulfilled, (state, action: PayloadAction<Product>) => {
                state.status = 'succeeded';
                state.product = action.payload;
            })
            .addCase(fetchProductById.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.payload as string;
            })
            .addCase(createProduct.fulfilled, (state, action: PayloadAction<Product>) => {
                state.products.push(action.payload);
            })
            .addCase(updateProduct.fulfilled, (state, action: PayloadAction<Product>) => {
                const index = state.products.findIndex((product) => product.id === action.payload.id);
                if (index !== -1) {
                    state.products[index] = action.payload;
                }
            })
            .addCase(deleteProduct.fulfilled, (state, action: PayloadAction<number>) => {
                state.products = state.products.filter((product) => product.id !== action.payload);
            });
    },
});

export default productSlice.reducer;
