import { useCallback, useEffect, type FunctionComponent } from 'react'
import reactLogo from '@/assets/img/react.svg'
import { FormattedMessage } from 'react-intl'
// import { useAppDispatch, useAppSelector } from '@/hooks'
// import { HubInit, HubState, REFRESH_URL, TokenProps } from '@/constants/types'
// import { post } from '@/utils/http'

const Dashboard: FunctionComponent = () => {
  // const dispatch = useAppDispatch()
  // const { token, refreshToken } = useAppSelector<HubState>((state) => state.dmHub ?? HubInit)
  // const effectHandler = useCallback(async () => {
  //   if (refreshToken) {
  //     const repsonse = await post<TokenProps>(REFRESH_URL, { refreshToken })
  //     console.log(`try to refresh the token:`, repsonse)
  //   }
  // }, [refreshToken])
  // useEffect(() => {
  //   effectHandler()
  // }, [refreshToken])

  return (
    <div className="dashboard-wrapper">
      <section className="hero is-dark">
        <div className="hero-body">
          <div className="is-flex is-horizontal-center">
            <a href="https://vitejs.dev" target="_blank" rel="noreferrer">
              <img src="/vite.svg" className="logo" alt="Vite logo" />
            </a>
            <a href="https://reactjs.org" target="_blank" rel="noreferrer">
              <img src={reactLogo} className="motion-safe:animate-logo-turn logo react" alt="React logo" />
            </a>
          </div>
        </div>
      </section>
      <section>
        <div className="card">
          <div className="card-content">
            <div className="column">
              <p className="title has-text-centered">Technology Stack</p>
              <hr />
              <div className="columns is-multiline">
                <div className="column dashboard-info is-half">
                  <div className="content">
                    <ul>
                      <li>
                        <FormattedMessage id="pages.home.demotext" values={{ technology: 'React' }} />
                      </li>
                      <li>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href="https://redux.js.org/"
                          className="dashboard-link redux"
                        >
                          Redux
                        </a>
                        {`"centralizes your application's state and logic and helps
                        you write applications that behave consistently and are
                        easy to test."
                      `}
                      </li>
                      <li>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href="https://bulma.io/"
                          className="dashboard-link bulma"
                        >
                          Bulma
                        </a>
                        is open source CSS framework based on Flexbox (with no JQuery dependency).
                      </li>
                    </ul>
                  </div>
                </div>
                <div className="column dashboard-info is-half">
                  <div className="content">
                    <ul>
                      <li>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href="https://www.asp.net/"
                          className="dashboard-link aspcore"
                        >
                          ASP.NET Core
                        </a>
                        is an open source web framework for building modern web apps and services with .NET. Creates
                        websites based on HTML5, CSS, and JavaScript that are simple, fast, and can scale to millions of
                        users.
                      </li>
                      <li>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href="https://sass-lang.com/"
                          className="dashboard-link sass"
                        >
                          SASS
                        </a>
                        is a CSS pre-processor extension to help provide more flexibility &amp; maintainability to your
                        style-sheets.
                      </li>
                      <li>
                        <a
                          target="_blank"
                          rel="noopener noreferrer"
                          href="https://www.typescriptlang.org/"
                          className="dashboard-link typescript"
                        >
                          TypeScript
                        </a>
                        is a typed superset of JavaScript that compiles to plain JavaScript
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  )
}

export default Dashboard
