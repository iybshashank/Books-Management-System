import { IBook } from '../../Models/IBook';
import {actionTypes} from '../constants/action-types'

export const ListBooks=(books:IBook)=>{
return {
    type: actionTypes.LIST_BOOKS,
    payload: books,
};
};

export const RemoveBooks=(books:IBook)=>{
    return {
        type: actionTypes.REMOVE_BOOK,
        payload: books,
    };
    };