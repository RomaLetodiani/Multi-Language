import { createBrowserRouter } from 'react-router-dom'
import ErrorPage from '../pages/Error/ErrorPage'
import Home from '../pages/Home/Home'

const Router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
    errorElement: <ErrorPage />,
    children: [],
  },
])

export default Router
