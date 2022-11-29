import './App.css';

import Home from './pages/Home';
import Menu from './components/Menu';
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
            <Route exact path='/register' element={<Register></Register>} />
            <Route exact path='/login' element={<Login></Login>} />
          </Routes>
        </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
