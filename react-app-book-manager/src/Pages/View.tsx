import React from "react";
import { useLocation, useNavigate } from "react-router-dom";

function View(){
    const {state}:any = useLocation();
    
    
    const navigate = useNavigate();
    const rHome=()=>{
        navigate("/home")
    }

    return (<>
        <div style={{marginLeft:'250px', marginRight:'250px',marginTop:'20vh'}}>

        <div style={{minHeight:'60vh'}}>
            <h1>{state.props.bName} <span style={{color:'gray', fontSize:'20px'}}>{state.props.bYear}</span></h1>
            <h1 style={{color:'gray', fontSize:'15px', }}><span>By</span> : {state.props.bAuthor} <span style={{marginLeft:'20px'}}>ISBN</span> : {state.props.bISBN}</h1>
            <p style={{marginTop:'20px',width:'80%',wordBreak:'break-word'}}>{state.props.bDescription}</p>

        </div>
        <div style={{height:'20vh'}}>
            <button style={{background:'black', border:'none',color:'white', width:'80px',height:'40px'}} onClick={rHome}>Cancel</button>
        </div>

        </div>
        
    </>)
}

export default View;