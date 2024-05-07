import { Outlet } from 'react-router-dom'
import Footer from '../Layout/Footer'
import Header from '../Layout/Header'

const Root = () => {
  return (
    <>
      {' '}
      <Header />
      <Outlet />
      <Footer />
    </>
  )
}

export default Root
