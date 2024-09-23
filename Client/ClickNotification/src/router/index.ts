import { createRouter, createWebHistory } from 'vue-router';
import Welcome from '../views/Welcome.vue'
import ModifyProducts from '../views/ModifyProducts.vue';

const routes = [
  {
    path: '/',
    name: 'Welcome',
    component: Welcome
  },
  {
    path: '/modify-products',
    name: 'ModifyProducts',
    component: ModifyProducts
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;