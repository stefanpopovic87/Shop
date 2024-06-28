import { Outlet } from 'react-router-dom';
import { Container } from '@material-ui/core';
import Header from './app/layout/Header';

const App = () => {
    return (
        <>
            <Header />
            <Container>
                <Outlet />
            </Container>
        </>
    );
};

export default App;
