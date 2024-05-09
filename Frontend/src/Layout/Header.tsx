import { Link } from 'react-router-dom'
import Text from '../components/Text'
import LanguageSwitcher from '../components/LanguageSwitcher'

const Header = () => {
  return (
    <div className="p-5 flex justify-between items-center bg-sky-50 text-sky-700">
      <Link to={'/'}>
        <h1 className="text-3xl tracking-widest font-bold">MLW</h1>
      </Link>
      <nav className="flex items-center justify-center gap-10">
        <LanguageSwitcher />
        <ul className="flex gap-5">
          <Link to={'about'}>
            <li>
              <Text TextKey="HeaderLi-1" />
            </li>
          </Link>
          <Link to={'hello'}>
            <li>
              <Text TextKey="HeaderLi-2" />
            </li>
          </Link>
        </ul>
      </nav>
    </div>
  )
}

export default Header
