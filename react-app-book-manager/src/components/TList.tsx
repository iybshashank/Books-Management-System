import React from "react";
import {RemoveBooks} from "../redux/Action/booksAction";
import axios from 'axios';
import { Button } from "react-bootstrap";
import { useDispatch, useSelector } from 'react-redux';  
import {useNavigate} from 'react-router-dom';
import { IBook } from "../Models/IBook";

export function TList(props:IBook){

    const dispatch=useDispatch();
    const navigate=useNavigate ();
    
    const userIsAdminFetch = useSelector((state:any)=>state.allUser.user[1]);
      const rEdit = (event:any) => {
         navigate("/edit",{ state: { props } })
      }

      const rView = (event:any) => {
        navigate("/view",{ state: { props } })
     }
      

    

    

     

    const deleteBook= async (event:any) => {


            var id =event.target.getAttribute("value");
            console.log("id in delb")
            console.log(id);
            await axios.delete(process.env.REACT_APP_API_URL+"Book/delete/"+id)
            .then(()=>dispatch(RemoveBooks(id)))
        
            
            
            //.then(window.location.reload(false))
            //.then(true?console.log("success"):console.log("failed"));


            

    };

    
    

       function Modifiers(){

        return (userIsAdminFetch ?
            <> |
                <Button variant="link" value={props.id} onClick={rEdit}>Edit</Button>|
                <Button variant="link" style={{color:'red'}} value={props.id} onClick={deleteBook}>Delete</Button>

            {/* <a  className='link-primary' value={props.id} onClick={rEdit}>Edit</a> | 
            <a  className='link-danger' value={props.id} onClick={deleteBook}>Delete</a> */}
            </> :
            <></>);
       }
    
    
    return(
        <>
        <tr>
            <input type="hidden" id="id" value={props.id}></input>
            <td>{props.bName}</td>
            <td>{props.bAuthor}</td>
            <td>{props.bYear}</td>
            <input type='hidden' value={props.bDescription}></input>
            <input type='hidden' value={props.bISBN}></input>
            <td>
                <Button variant="link" style={{color:'#10741F'}} value={props.id} onClick={rView}>View</Button>
                {/* <a className="link-success" value={props.id} onClick={rView}>View</a> */}
                <Modifiers />
            </td>
        </tr>
                
        </>
    )



}






// export default TList;






