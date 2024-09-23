<template>
    <div>
      <h2>Modify Products</h2>
  
      <!-- Add new product form -->
      <form @submit.prevent="addProductToStore">
        <input v-model="newProduct.name" placeholder="Product Name" required />
        <input v-model="newProduct.price" placeholder="Product Price" type="number" required />
        <button type="submit">Add Product</button>
      </form>
  
      <!-- Products table -->
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          <Product
            v-for="(product, index) in productStore.products"
            :key="product.id"
            :product="product"
            :index="index"
            @onUpdate="updateProductInStore"
            @onDelete="deleteProductFromStore"
          />
        </tbody>
      </table>
  
      <router-link to="/">Back to Welcome Page</router-link>
    </div>
  </template>
  
  <script setup lang="ts">
  import { onMounted, ref } from 'vue';
  import { useProductStore } from '../stores/productStore'; // Import the store
  import Product from '../components/Product.vue'; // Import the Product component
  
  // Define a reactive object for a new product
  const newProduct = ref({
    name: '',
    price: 0
  });
  
  // Access the Pinia store
  const productStore = useProductStore();
  
  // Fetch products when the component is mounted
  onMounted(() => {
    productStore.fetchProducts();
  });
  
  // Function to add a new product to the store and backend
  const addProductToStore = async () => {
    if (newProduct.value.name && newProduct.value.price > 0) {
      await productStore.addProduct({ ...newProduct.value });
      newProduct.value.name = '';
      newProduct.value.price = 0;
    }
  };
  
  // Function to update a product in the store and backend
  const updateProductInStore = async (index: number, updatedProduct: { name: string; price: number }) => {
    const product = productStore.products[index];
    await productStore.updateProduct(product.id, updatedProduct);
  };
  
  // Function to delete a product from the store and backend
  const deleteProductFromStore = async (index: number) => {
    const product = productStore.products[index];
    await productStore.deleteProduct(product.id);
  };
  </script>
  
  <style>
    table {
      width: 100%;
      border-collapse: collapse;
    }
  
    table, th, td {
      border: 1px solid black;
    }
  
    th, td {
      padding: 8px;
      text-align: left;
    }
  
    form {
      margin-bottom: 20px;
    }
  </style>
  