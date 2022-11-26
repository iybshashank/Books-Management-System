import { IUser } from '../../Models/IUser';
import {actionTypes} from '../constants/action-types'

const initialState={
    user:[]
};

export const userReducer=(state=initialState,{type,payload}:{type:string,payload:IUser})=>{
    switch(type){
        case actionTypes.LOGIN_USER:
            return {
                ...state,user:payload
            }
        case actionTypes.LOGOUT_USER:
            return {
                state:(state = {})=> state
            }
        default:
            return state;
    }
};
