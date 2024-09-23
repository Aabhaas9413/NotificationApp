<template>
    <tr>
      <td>
        <input v-model="editableProduct.name" />
      </td>
      <td>
        <input v-model="editableProduct.price" type="number" />
      </td>
      <td>
        <button @click="updateProduct">Update</button>
        <button @click="deleteProduct">Delete</button>
      </td>
    </tr>
  </template>
  
  <script setup>
  import { ref, toRefs } from 'vue';
  
  // Props to accept product data and actions from parent
  const props = defineProps({
    product: Object,
    onUpdate: Function,
    onDelete: Function,
    index: Number
  });
  
  // Create a local copy of the product for editing
  const editableProduct = ref({ ...props.product });
  
  // Emit the update when the user clicks "Update"
  const updateProduct = () => {
    props.onUpdate(props.index, editableProduct.value);
  };
  
  // Emit the delete when the user clicks "Delete"
  const deleteProduct = () => {
    props.onDelete(props.index);
  };
  </script>
  
  <style scoped>
    td {
      padding: 10px;
    }
  
    input {
      width: 100px;
    }
  </style>
  