import './App.css';

import Home from './Home';
import Department from './Department';
import Employee from './Employee';

import {BrowserRouter} from 'react-router-dom'
import {NavLink} from 'react-router-dom'
import {Routes} from 'react-router-dom'
import {Route} from 'react-router-dom'

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <h3 className="App Container">
          ReactJS Frontend
        </h3>

        

        <nav className='navbar navbar-expand-sm bg-light navbar-dark'>
          <ul className='navbar-nav'>
            <li className='nav-item- m-1'>
              <NavLink className='btn btn-light btn-outline-primary' to="/Home">
                Home
              </NavLink>
            </li>

            <li className='nav-item- m-1'>
              <NavLink className='btn btn-light btn-outline-primary' to="/department">
                Department
              </NavLink>
            </li>

            <li className='nav-item- m-1'>
              <NavLink className='btn btn-light btn-outline-primary' to="/employee">
                Employee
              </NavLink>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path='/Home' element ={<Home />}></Route>
          <Route path='/department' element={<Department />}></Route>
          <Route path='/employee' element={<Employee />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
