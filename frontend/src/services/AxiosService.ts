import axios from 'axios';

export const api = axios.create({
  baseURL: 'https://localhost:7179'
});

export async function get(url: string){
  const response = await api.get(url);
  return response.data;
}

export async function put(url: string, data: any){
  const response = await api.put(url, data);
  return response.data;
}

export async function post(url: string, data: any){
  const response = await api.post(url, data);
  return response.data;
}

export async function secureGet(url: string){
  const response = await api.get(url, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`
    }
  });
  return response.data;
}

export async function securePut(url: string, data: any){
  const response = await api.put(url, data, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`
    }
  });
  return response.data;
}

export async function securePost(url: string, data: any){
  const response = await api.post(url, data, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`
    }
  });
  return response.data;
}
