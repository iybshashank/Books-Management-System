import {actionTypes} from '../constants/action-types';

const initialState={
    isLogin:false
};

export const loginReducer=(state=initialState,{type,payload}:{type:string,payload:boolean})=>{
    switch(type){
        case actionTypes.IS_LOGIN:
            return {
                ...state,isLogin:payload
            }
        
        default:
            return state;
    }
};