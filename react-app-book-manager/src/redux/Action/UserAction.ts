import { IUser } from '../../Models/IUser';
import {actionTypes} from '../constants/action-types'

export const LoginUser=(user:IUser)=>{
return {
    type: actionTypes.LOGIN_USER,
    payload: user,
};
};

export const LogoutUser=()=>{
return {
    type: actionTypes.LOGOUT_USER,
    // payload: user,
};
};