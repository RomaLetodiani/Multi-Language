import { InputHTMLAttributes } from 'react'
import { twMerge } from 'tailwind-merge'

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  // Additional props specific to Input component can be defined here
  label?: string
  inputClass?: string
  hasError?: boolean
  errorMessage?: string
  focus?: boolean
}

const Input = ({ label, hasError, errorMessage, focus, inputClass, ...rest }: InputProps) => {
  return (
    <div className="relative w-full">
      <div className="flex justify-between mb-1">
        {label && (
          <label className={` font-bold`} htmlFor={label}>
            {label}
          </label>
        )}
        {hasError && <p className="text-danger font-bold text-xs mt-2 mr-2">{errorMessage}</p>}
      </div>
      {
        <span className="relative">
          <input
            autoComplete="off"
            id={label}
            className={twMerge(
              'smooth w-full px-3 py-2 rounded-lg border border-gray-300 outline-none',
              inputClass,
              hasError && 'border-danger text-danger',
            )}
            {...rest}
          />
        </span>
      }
    </div>
  )
}

export default Input
