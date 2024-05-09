import Text from '../components/Text'

const Footer = () => {
  return (
    <div className="p-5 bg-sky-800 text-white text-center">
      <h3 className="font-bold text-lg mb-3">
        <Text TextKey="FooterH3" />
      </h3>
      <p>© 2024</p>
    </div>
  )
}

export default Footer
