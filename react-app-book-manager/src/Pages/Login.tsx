import React, { useState } from "react";
import {  useDispatch } from "react-redux";
import axios from 'axios';
import {LoginUser } from '../redux/Action/UserAction'
import {IsLogin} from '../redux/Action/loginAction'
import {useNavigate } from "react-router-dom";
import {IUser} from '../Models/IUser';






function Login(){
    const dispatch=useDispatch();
     const navigate=useNavigate ();
    const rLogin = () => {
        navigate("/Home");
      }
      
    const [formData,setData] = React.useState<IUser>({username:'',password:''});
    const [errorData,setErrorData] = useState({show:false,message:""});
      

    const usernameC = (event:any) => {
        setData({...formData,username: event.target.value});       
      };

      const passwordC = (event:any) => {
        setData({...formData,
                password:event.target.value});
      };

      async function loginSubmit(){
        setErrorData({show:false,message:""});
          var uname= formData.username;
          var pswd = formData.password;
        if(uname == "" || pswd == ""){
            setErrorData({show:true,message:"Please enter username and password."});
            return;
        }

        
        const fetch=async ()=>{
            await axios.get(process.env.REACT_APP_API_URL+"login/"+uname+"/"+pswd)
            .catch((err)=>{
                console.log("someerror occured");
                setErrorData({show:true,message:"some error occured"});
            })
            .then((res:any)=>{
                
                if(res.data==="User Not Found"){
                setErrorData({show:true,message:"Please enter correct username and password"});
                    navigate("/")
                }
                else{
                    console.log(res.data);
                    dispatch(LoginUser(res.data))
                    dispatch(IsLogin(true))
                    rLogin();
                }
            })
            
            
        }
        return await fetch();

        
      }
       
      
      

    return (
        <>
            {/* onSubmit={loginSubmit} */}
            <div style={{marginLeft:'250px',marginRight:'250px',marginTop:'20vh'}}>
            <div>
              <h1>Login</h1>
            </div>
            <div style={{marginTop:'50px'}}>
                <input style={{border:'none',background:'#E0E0E0',width:'300px', height:'35px',paddingLeft:'10px',paddingRight:'10px'}} type="text" onChange={usernameC} id="username" placeholder="Enter Username" />
            </div>
            <div style={{marginTop:'20px'}}>
                <input style={{border:'none',background:'#E0E0E0',width:'300px', height:'35px',paddingLeft:'10px',paddingRight:'10px'}} type="password" onChange={passwordC} id="password" placeholder="Enter Password" />
            </div>
            <div style={{marginTop:'20px'}}>
                <button type="submit" onClick={loginSubmit} style={{background:'black',border:'none',color:'white', height:'35px', width:'70px'}}>Login</button>
                {errorData.show ? 
                <span style={{color:'#F73131', width:'70px', paddingLeft:'20px', fontWeight:'650', fontSize:'10px'}}>{errorData.message}</span> : null }
           
            </div>

            

            </div>
            
            
        
        </>
    
    )

}

export default Login;