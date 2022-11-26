import axios from "axios";
import React, { useState } from "react";
import {useNavigate } from "react-router-dom";
import {useSelector} from 'react-redux';
import Restricted from "./Restricted";
import { IBook } from "../Models/IBook";

function Create(){
    const options = [];
    for (let i=2022; i >=2000; i--) options.push(i);
    const isLogin = useSelector((state:any)=>state.loginUser.isLogin);
    const userIsAdminFetch = useSelector((state:any)=>state.allUser.user[1]);
    const navigate=useNavigate();
    const rSubmit = () => {
        navigate("/Home");
      }

    const [formData,setData] = React.useState<IBook>({
        id:0,
        bName:'',
        bAuthor:'',
        bYear:2022,
        bDescription:'',
        bISBN:0,
    });

    const [errorData, setErrorData] = useState({show:false,message:""});

    const nameC = (event:any) => {
        setData({...formData,
                bName: event.target.value});
      };


      const authC = (event:any) => {
        setData({...formData,
                bAuthor:event.target.value});
      };

      const yearC = (event:any) => {
         setData({...formData,
                 bYear: event.target.value});
       };

      const isbnC = (event:any) => {
         setData({...formData,
                 bISBN:event.target.value});
       };

       const descC = (event:any) => {
         setData({...formData,
                 bDescription:event.target.value});
       };


       function createSubmit(event:any){

        setErrorData({show:false,message:""})
        if(/^\s+$/.test(formData.bName) || formData.bName == ""){
            setErrorData({show:true,message:"Enter book name"})
            return;
        }

        event.preventDefault();
        axios.post(process.env.REACT_APP_API_URL+"Book/create",{
            bName:formData.bName,
            bAuthor:formData.bAuthor,
            bYear:Number(formData.bYear),
            bDescription:formData.bDescription,
            bISBN:Number(formData.bISBN)
            }, {
                headers: {
                  'Content-Type': 'application/json'
                }})
            .then(rSubmit)
            

       }


    return ( isLogin && userIsAdminFetch ?
    
        
        <>
        {/* <div style={{marginLeft:"150px",marginTop:"10vh"}}>
            <h2>Create</h2>
    
            <input type="text"></input>
            
        </div> */}
        <div className='container' style={{paddingTop:'70px'}}>
                <div className="row" style={{}}>
     <div className='col-sm'>
        <h2 style={{paddingTop:'25px',fontSize:'40px'}}>Create Book</h2>
        </div>
      </div>
      <div style={{width:'300px', paddingTop:'50px'}}>
      
        <div className="form-group" >
                <label htmlFor="Name" style={{fontWeight:'bold'}}>Name</label><span style={{color:'red', paddingLeft:'5px', fontWeight:'650'}}>*</span>
                <input  type="text" onChange={nameC} value={formData.bName} style={{backgroundColor:"#E0E0E0", border:'none',boxShadow:"none", color:"black",fontWeight:'bold'}} className="form-control" id="name"  placeholder="Enter name of the book"></input>
                {errorData.show ? 
                <span style={{color:'#F73131', width:'70px', paddingLeft:'13px', fontWeight:'550',fontSize:'10px'}}>{errorData.message}</span> : null }
            </div>
            <div className="form-group" style={{paddingTop:'20px'}}>
                <label htmlFor="Author" style={{fontWeight:'bold'}} >Author</label>
                <input type="text" onChange={authC} value={formData.bAuthor} style={{backgroundColor:"#E0E0E0", border:'none',boxShadow:"none", color:"black",fontWeight:'bold'}} className="form-control" id="author"  placeholder="Author of the book"></input>
            </div>

            <div className="form-group" style={{paddingTop:'20px'}}>
                <label htmlFor="ISBN" style={{fontWeight:'bold'}}>Year</label>
                <select onChange={yearC} value={formData.bYear} style={{backgroundColor:"#E0E0E0", border:'none',boxShadow:"none", color:"black",fontWeight:'bold'}} className="form-control" id="year" >
                {options.map(option => (
                <option value={option}>
                    {option}
                </option>
                ))}
                </select>
            </div>
            <div className="form-group" style={{paddingTop:'20px'}}>
                <label htmlFor="ISBN" style={{fontWeight:'bold'}}>ISBN</label>
                <input onChange={isbnC} value={formData.bISBN} type="number"  style={{backgroundColor:"#E0E0E0", border:'none',boxShadow:"none", color:"black",fontWeight:'bold'}} className="form-control" id="isbn"  placeholder="ISBN"></input>
            </div>

            <div className="form-group" style={{paddingTop:'20px'}}>
                <label htmlFor="Description" style={{fontWeight:'bold'}}>Description</label>
                <textarea onChange={descC} value={formData.bDescription} maxLength={999} rows={4} cols={40} style={{backgroundColor:"#E0E0E0", border:'none',boxShadow:"none", color:"black",fontWeight:'bold'}} className="form-control" id="description"  placeholder="Describe the book"></textarea>
            </div>


            
            <button onClick={createSubmit} style={{marginTop:'30px',width:'100px',height:'40px', backgroundColor:"black",border:'none',boxShadow:"none", fontWeight:'bold'}}  type="submit" className="btn btn-primary">Add</button>
            
      </div>
      
      </div>
    </> : 
    <>
        <Restricted />
    </>
    )
}

export default Create;