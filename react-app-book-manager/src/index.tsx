import React from 'react';
import ReactDOM from 'react-dom/client';
import  store  from './store';
import { Provider } from 'react-redux';
import './index.css';
import "bootstrap/dist/css/bootstrap.min.css";
import Home from './Pages/Home';
import Login from './Pages/Login';
import Create from './Pages/Create';

import { BrowserRouter, Route, Routes } from "react-router-dom";
import Edit from './Pages/Edit';
import View from './Pages/View';
//import {Test}  from './components/Test';

const root = ReactDOM.createRoot(document.getElementById('root')  as HTMLElement);
root.render(
    <Provider store={store}>    
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />}></Route>
                <Route path="/Home" element={<Home />}></Route>
                <Route path="/create" element={<Create />}></Route>
                <Route path="/edit" element={<Edit />}></Route>
                <Route path="/view" element={<View />}></Route>
                {/* <Route path="/Test" element={<Test />}></Route> */}
                
                
            </Routes>
        </BrowserRouter>
    </Provider>
);


