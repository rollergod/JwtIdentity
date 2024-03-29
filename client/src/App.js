import './App.css';

import Home from './pages/Home';
import Menu from './components/Menu';
import Login from './pages/Login';
import Profile from './pages/Profile';
import Register from './pages/Register';
import ChangePassword from './pages/ChangePassword';
import EmailConfirmation from './pages/EmailConfirmation';

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
            <Route path='/profile' element={<Profile></Profile>} />
            <Route exact path='/confirmemail' element={<EmailConfirmation></EmailConfirmation>} />
            <Route exact path='/resetpassword' element={<ChangePassword></ChangePassword>} />
          </Routes>
        </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
