import { create } from 'zustand'

type LanguagesStore = {
  languages: language[]
  languageCode: string
  setLanguageCode: (languageCode: string) => void
}

const useLanguageStore = create<LanguagesStore>((set) => ({
  languages: [
    {
      id: 1,
      title: 'English',
      code: 'EN',
    },
    {
      id: 2,
      title: 'Spanish',
      code: 'ES',
    },
    {
      id: 3,
      title: 'French',
      code: 'FR',
    },
  ],
  languageCode: 'EN',
  setLanguageCode: (languageCode) => set({ languageCode }),
}))

export default useLanguageStore
