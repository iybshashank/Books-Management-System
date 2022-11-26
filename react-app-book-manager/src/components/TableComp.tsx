import React,{useEffect} from "react";
import { useDispatch,useSelector } from "react-redux";
import {ListBooks} from '../redux/Action/booksAction'
import axios from 'axios';
import {TList} from './TList';
import {Table} from 'react-bootstrap';
import { IBook } from "../Models/IBook";



function ApiData(){
    
    const dispatch=useDispatch();
    const fetch = async ()=>{
        
        const response:any = await axios.get(process.env.REACT_APP_API_URL+"Book")
        .catch((err)=>{
            console.log("Some err occured");
        })
        //dispatch(response.data);
        //console.log(response.data);
        dispatch(ListBooks(response.data));
        
        
    }

    useEffect(()=>{
        fetch();
      });
    
      return (
          <>
            <CreateList />
          </>
      )
    
}

function CreateList(){
        
    const books=useSelector((state:any)=>state.allBooks.books);
    //console.log(books)
    const renderList=books.map((book:IBook)=>{
        const {id,bName,bAuthor,bYear,bDescription,bISBN} = book
        return (
            <TList 
            key={id}
            id={id}
            bName={bName}
            bAuthor={bAuthor}
            bYear={bYear}
            bISBN={bISBN}
            bDescription={bDescription}
            />
        )
    });

    return(<>{renderList}</>)
}


   
    
  
   



function TableComp(){
    

    return (
        <>
           <Table striped bordered hover size="sm">
            <thead>
                <tr>
                <th>Book</th>
                <th>Author</th>
                <th>Year</th>  
                <th></th>              
                </tr>
            </thead>
            <tbody>
              
                  <ApiData />
                
                

            </tbody>
            </Table> 
            
        </>
    )
}

export default TableComp;