import { createBrowserRouter } from 'react-router-dom'
import Root from './Root'
import { About, ErrorPage, Hello, Home } from '../pages'

const Router = createBrowserRouter([
  {
    path: '/',
    element: <Root />,
    errorElement: <ErrorPage />,
    children: [
      { path: '/', element: <Home /> },
      { path: '/about', element: <About /> },
      { path: '/hello', element: <Hello /> },
    ],
  },
])

export default Router
