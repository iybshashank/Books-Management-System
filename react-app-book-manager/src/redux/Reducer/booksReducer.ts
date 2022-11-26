import { IBook } from '../../Models/IBook';
import {actionTypes} from '../constants/action-types'

const initialState={
    books:[]
};

export const booksReducer=(state=initialState,{type,payload}:{type:string,payload:number})=>{
    switch(type){
        case actionTypes.LIST_BOOKS:
            return {
                ...state, books:payload
            }
        case actionTypes.REMOVE_BOOK:
            return {
                ...state,
                books: state.books.filter((item:IBook) => item.id != payload)
            }
        default:
            return state;
    }
};
