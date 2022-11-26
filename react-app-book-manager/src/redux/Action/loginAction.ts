import { IUser } from '../../Models/IUser';
import {actionTypes} from '../constants/action-types'

export const IsLogin=(users:boolean)=>{
    return {
        type: actionTypes.IS_LOGIN,
        payload: users,
    };
    };