import { Outlet, useLocation } from 'react-router-dom'
import Header from '../Layout/Header'
import Footer from '../Layout/Footer'
import useLanguageStore from '../components/Stores/Languages'
import { useEffect } from 'react'
import { LanguageServices } from '../Services/LanguageServices'

const Root = () => {
  const { pathname } = useLocation()
  const { setLanguages, languageCode } = useLanguageStore()
  console.log('🚀 ~ Root ~ languageCode:', languageCode)
  useEffect(() => {
    LanguageServices.getLanguages().then(({ data }) => setLanguages(data))
  }, [])
  return (
    <div className="w-full min-h-screen min-w-[375px] flex flex-col">
      <Header />
      <div className="flex-1 flex justify-center items-center bg-sky-100">
        <Outlet />
      </div>
      <Footer />
    </div>
  )
}

export default Root
