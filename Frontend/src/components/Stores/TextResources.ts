import { create } from 'zustand'

type TextResourcesStore = {
  resources: {
    [key: string]: string
  }
  setResources: (resources: { [key: string]: string }) => void
}

const useTextResourcesStore = create<TextResourcesStore>((set) => ({
  resources: {
    'HeaderLi-1': 'About',
    'HeaderLi-2': 'Hello',
    FooterH3: 'Multi Language Website',
  },
  setResources: (resources) =>
    set((state) => ({
      resources: { ...state.resources, ...resources },
    })),
}))

export default useTextResourcesStore
