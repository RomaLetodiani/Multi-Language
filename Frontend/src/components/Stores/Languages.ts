import { create } from 'zustand'

type LanguagesStore = {
  languages: language[]
  setLanguages: (languages: language[]) => void
  languageCode: string
  setLanguageCode: (languageCode: string) => void
}

const useLanguageStore = create<LanguagesStore>((set) => ({
  languages: [],
  setLanguages: (languages) => set({ languages }),
  languageCode: localStorage.getItem('languageCode') || 'EN',
  setLanguageCode: (languageCode) => {
    localStorage.setItem('languageCode', languageCode) // Save languageCode to localStorage
    set({ languageCode })
  },
}))

export default useLanguageStore
