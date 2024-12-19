import { type RouteInput, TRANSITION_DEFAULT, MenuPositionEnum, LinkNameEnum } from '@/constants/types'
import HomeComponent from '@/pages/landing'


const routes: RouteInput[] = [
  {
    path: '/home',
    name: LinkNameEnum.home,
    Component: HomeComponent,
    transition: TRANSITION_DEFAULT,
    iconIndex: 0,
    popUpOnly: false,
    position: MenuPositionEnum.center,
    locked: false,
  },


]

export default routes
