import axios from 'axios';  // Import Axios normally
import type { AxiosInstance } from 'axios';  // Use AxiosInstance as a type

// Use import.meta.env for Vite to read environment variables
const apiClient: AxiosInstance = axios.create({
  baseURL: import.meta.env.VITE_APP_API_BASE_URL || 'https://localhost:5001/api', // Use import.meta.env for Vite
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;
