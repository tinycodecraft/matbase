import { FunctionComponent } from 'react'
import AppProvider from './components/provider'
import RouterComponent from '@/constants/routes'
import IntlProvider from '@/hooks/context/intl'
import { LangProvider } from '@/hooks/context/lang'
import { CtxForLayoutProvider } from '@/components/context/CtxForLayout'
import '@/assets/scss/site.scss'
import MtLayout from './components/layout/mtLayout'

const App: FunctionComponent = () => {
  return (
    <AppProvider>
      <LangProvider>
        <IntlProvider>
          <CtxForLayoutProvider>
            <MtLayout>
              <RouterComponent />
            </MtLayout>
          </CtxForLayoutProvider>
        </IntlProvider>
      </LangProvider>
    </AppProvider>
  )
}

export default App
