import React, { FunctionComponent, PropsWithChildren, createContext, useEffect, useRef, useState } from 'react'

interface LayoutCtxProps {
  navBarRef: React.MutableRefObject<HTMLDivElement | null>
  navHeight: number
  isfullwidth: boolean
  setfullwidth: React.Dispatch<React.SetStateAction<boolean>>
  isNavOpen: boolean
  setNavOpen: React.Dispatch<React.SetStateAction<boolean>>
  drawerTop: number
}

const LayoutContext = createContext<Partial<LayoutCtxProps>>({})

export const CtxForLayoutProvider: FunctionComponent<PropsWithChildren> = ({ children }) => {
  const [drawerTop, setDrawerTop] = useState<number>(0)

  const headRef = useRef<HTMLDivElement | null>(null)
  const [isfullwidth, setfullwidth] = useState(false)
  const [isNavOpen, setNavOpen] = useState(false)

  useEffect(() => {
    console.log(`rerender happens`)
    if (headRef.current) {
      const { height } = headRef.current.getBoundingClientRect()
      console.log(`the height is ${height}`)
      if (height) {
        setDrawerTop(height + 40)
      }
    }
  }, [])
  return (
    <LayoutContext.Provider
      value={{
        navBarRef: headRef,
        navHeight: drawerTop,
        isfullwidth,
        setfullwidth,
        isNavOpen,
        setNavOpen,
        drawerTop,
      }}
    >
      {children}
    </LayoutContext.Provider>
  )
}

export default LayoutContext
