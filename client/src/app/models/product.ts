export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    pictureUrl?: string | null;
}

export interface ProductState {
    products: Product[];
    product: Product | null;
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | null;
    productsLoaded: boolean;
}