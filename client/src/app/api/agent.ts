import axios, { AxiosResponse } from 'axios';
import { Product } from '../models/product';

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

const responseBody = (response: AxiosResponse) => {
    if (response.data.isSuccess) {
        return response.data.value;
    } else {
        throw new Error(response.data.error);
    }
};

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    del: (url: string) => axios.delete(url).then(responseBody),
};

const Products = {
    list: () => requests.get('products'),
    details: (id: number) => requests.get(`products/${id}`),
    create: (product: Omit<Product, 'id'>) => requests.post('products', product),
    update: (product: Product) => requests.put(`products/${product.id}`, product),
    delete: (id: number) => requests.del(`products/${id}`)
};

const agent = {
    Products
};

export default agent;
