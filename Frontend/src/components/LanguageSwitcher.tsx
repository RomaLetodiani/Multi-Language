import { twMerge } from 'tailwind-merge'
import { LanguageSVG } from './Icons/Language'
import Popover from './Popover'
import useLanguageStore from './Stores/Languages'
import Button from './UI/Button'

const LanguageSwitcher = () => {
  const { languages, languageCode, setLanguageCode } = useLanguageStore()
  if (!languages.length) return null
  return (
    <Popover
      position="bottom-right"
      content={
        <div>
          {languages.map((language) => (
            <Button
              key={language.id}
              onClick={() => setLanguageCode(language.code)}
              className={twMerge(
                'w-full',
                `${language.code === languageCode ? 'bg-sky-500' : 'bg-slate-500'}`,
              )}
            >
              {language.code}
            </Button>
          ))}
        </div>
      }
    >
      <span className="cursor-pointer">{LanguageSVG}</span>
    </Popover>
  )
}

export default LanguageSwitcher
