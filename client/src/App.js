import './App.css';

import Home from './pages/Home';
import Menu from './components/Menu';
import EmailConfirmation from './pages/EmailConfirmation';
import Login from './pages/Login';
import Register from './pages/Register';

import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";

function App() {
  return (
    <div className="App">
      <main className='bg-white px-10'>
        <BrowserRouter>
          <Menu></Menu>
          <Routes>
            <Route exact path='/' element={<Home></Home>} />
            <Route path='/register' element={<Register></Register>} />
            <Route path='/login' element={<Login></Login>} />
            <Route path='/activated' element={<Login></Login>} />
            <Route exact path='/confirmemail' element={<EmailConfirmation></EmailConfirmation>} />
          </Routes>
        </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
