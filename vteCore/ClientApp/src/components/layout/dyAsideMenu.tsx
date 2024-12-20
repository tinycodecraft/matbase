import { RouteDepth, RouteInput } from '@/constants/types'
import { getRouteByDepth, recordKeys } from '@/utils/methods'
import { IconCloudCog, IconHome, IconList, IconLock, IconLogout, IconSwitch2 } from '@tabler/icons-react'
import clsx from 'clsx'
import React, { useContext } from 'react'
import { generatePath } from 'react-router'
import { NavLink } from 'react-router-dom'
import LayoutContext from '@/components/context/CtxForLayout'

interface DyAsideProps {
  asideList: RouteInput[]
  routeDepth?: RouteDepth
  depth?: number
  maxDepth?: number
}
const icons = [IconHome, IconLock, IconCloudCog, IconLogout, IconSwitch2, IconList]

export const DyAsideMenu = ({ asideList, routeDepth, depth = 1, maxDepth = 0 }: DyAsideProps) => {
  const cloneDepth = routeDepth ? routeDepth : getRouteByDepth(asideList)
  const { setNavOpen } = useContext(LayoutContext)
  const hasDepth = cloneDepth && cloneDepth[depth]

  if (maxDepth === 0) {
    maxDepth = recordKeys(cloneDepth).length
  }
  const parentnames = routeDepth && depth && depth < maxDepth && routeDepth[depth].map((e) => e.parentName)
  
  const parents = asideList    
    .map((e) => ({ menu: e, submenu: hasDepth && cloneDepth[depth].filter((f) => f.parentName === e.name) , hasChildren: parentnames && parentnames.includes(e.name) }))

  return (
    <ul className={clsx(depth <= 1 ? 'menu bg-base-200 w-full rounded-box pt-0' : '')}>

      {parents.length > 0 &&
        parents.map((p) =>
          p.hasChildren && p.submenu && p.submenu.length > 0 ? (
            <li data-depth={`${depth}`} key={`${p.menu.name}-${depth}`}>
              <details>
                <summary>{p.menu.name}</summary>
                <DyAsideMenu asideList={[...p.submenu]} depth={depth + 1} routeDepth={cloneDepth} />{' '}
              </details>
            </li>
          ) : (
            <li data-depth={`${depth}`} key={`${p.menu.name}-${depth}`}>
              <NavLink
                key={p.menu.name}
                to={generatePath(p.menu.path, p.menu.params)}
                onClick={() => setNavOpen && setNavOpen(false)}
              >
                {React.createElement(icons[p.menu.iconIndex ?? 0], { className: 'h-[18px] w-[18px] inline' })}
                {p.menu.name}
              </NavLink>{' '}
            </li>
          ),
        )}
    </ul>
  )
}
