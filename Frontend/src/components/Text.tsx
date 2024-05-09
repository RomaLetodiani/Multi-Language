import useTextResourcesStore from './Stores/TextResources'

type Props = {
  TextKey: string
}

const Text = ({ TextKey }: Props) => {
  const resources = useTextResourcesStore((state) => state.resources)
  return <>{resources[TextKey]}</>
}

export default Text
