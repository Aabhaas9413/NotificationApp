import { defineStore } from 'pinia';
import { ref } from 'vue';
import apiClient from '../axios'; // Import the Axios instance

interface Product {
  id: number;
  name: string;
  price: number;
}

export const useProductStore = defineStore('productStore', () => {
  const products = ref<Product[]>([]);

  // Fetch products from the backend API
  const fetchProducts = async () => {
    try {
      const response = await apiClient.get('/Products');
      products.value = response.data;
    } catch (error) {
      console.error('Failed to fetch products:', error);
    }
  };

  // Add a new product to the backend API
  const addProduct = async (product: Omit<Product, 'id'>) => {
    try {
      const response = await apiClient.post('/products', product);
      products.value.push(response.data);
    } catch (error) {
      console.error('Failed to add product:', error);
    }
  };

  return { products, fetchProducts, addProduct };
});
