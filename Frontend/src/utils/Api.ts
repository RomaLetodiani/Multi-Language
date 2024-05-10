import axios from 'axios'
import qs from 'qs'
const api = axios.create({
  baseURL: 'https://localhost:7108/api/',
})

api.interceptors.request.use((config: any) => {
  config.paramsSerializer = (p: any) => qs.stringify(p, { arrayFormat: 'repeat' })
  return config
})

export default api
