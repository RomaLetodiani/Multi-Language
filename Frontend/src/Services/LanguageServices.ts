import api from '../utils/Api'

export const LanguageServices = {
  getLanguages: () => api.get('/language'),
}
