import React from "react";
import {useNavigate} from 'react-router-dom';

function Restricted(){
    const navigate = useNavigate();
    const nLogin = ()=>{
        navigate('/');
    }

    return (
        <>
        <div style={{textAlign:'center',marginTop:"20vh"}}>
            <h2>Restricted page</h2>
            <p>Either you have been logged out or this page is restricted for you<br></br>Please log in to continue using.</p>
            <button onClick={nLogin} style={{marginTop:"20px"}}>Login</button>
        </div> 
        </>
    )
}

export default Restricted;