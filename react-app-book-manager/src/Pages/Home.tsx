import React from "react";
import TableComp from '../components/TableComp'
import {IsLogin} from '../redux/Action/loginAction'
import {LogoutUser} from '../redux/Action/UserAction';
import {Navbar,Container} from 'react-bootstrap';
import {useSelector, useDispatch} from 'react-redux';
import {useNavigate } from "react-router-dom";
import Restricted from '../Pages/Restricted';

function Home(): JSX.Element{
    const dispatch=useDispatch();
    const userNameFetch=useSelector((state:any)=>state.allUser.user[0]);
    const userIsAdminFetch = useSelector((state:any)=>state.allUser.user[1]);
    const isLogin = useSelector((state:any)=>state.loginUser.isLogin);
    //console.log(isLogin);
    const navigate=useNavigate ();
  const nCreate = () => {
    navigate("/create");
  }
  const nLogout = () => {
    navigate("/");
  }

  function logoutController(){
    

    dispatch(IsLogin(false));
    dispatch(LogoutUser());
    nLogout();
  }

  return (isLogin ?
    <>     
        <Navbar>
        <Container>
            <Navbar.Brand>Book Manager</Navbar.Brand>
            <Navbar.Toggle />
            <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>
                Signed in as: <strong>{userNameFetch} </strong>{userIsAdminFetch? <span style={{color:'#3FE457'}}>(Full access)</span> : <span style={{color:'##5B0911'}}></span>} |
                <a onClick={logoutController} className="link-warning" style={{marginLeft:"5px", cursor:"pointer"}}>Logout</a>
            </Navbar.Text>
            </Navbar.Collapse>
        </Container>
        </Navbar>
        <div>
            {userIsAdminFetch ?
            <button style={{font:"5px",marginLeft:"250px",marginBottom:"2vh", color:"white", marginTop: "30px", width: "40px", height: "40px", backgroundColor: "black", border: "none", boxShadow: "none", fontWeight: "bold"}} onClick={nCreate}>+</button> :
            <div style={{height:'10vh'}}></div>}
        </div>
        <div style={{marginRight:'250px',marginLeft:'250px'}}>
        
        <TableComp />
        
        </div>

        </> :
        <Restricted />
    )
    
    
    
}

export default Home;