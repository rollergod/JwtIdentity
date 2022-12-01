import './App.css';

import Home from './pages/Home';
import Menu from './components/Menu';
import Test from './pages/Test';
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
            <Route exact path='/test' element={<Test></Test>} />
            {/* <Route path='/api/Account/confirmemail?' element={<ConfirmEmail></ConfirmEmail>} /> */}
          </Routes>
        </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
