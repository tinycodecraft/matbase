import { createTheme, CssBaseline, StyledEngineProvider, ThemeProvider } from "@mui/material";
import { Fragment, FunctionComponent, PropsWithChildren } from "react";

interface MtLayoutProps extends PropsWithChildren {
    
}
 
const MtLayout: FunctionComponent<MtLayoutProps> = ({children}) => {
    const theme = createTheme({
        cssVariables:true,

    })
    return (
        <Fragment>
            <StyledEngineProvider injectFirst>
                <ThemeProvider theme={theme}>
                    <CssBaseline />
                    {children}
                </ThemeProvider>                
            </StyledEngineProvider>
        </Fragment>
      );
}
 
export default MtLayout;