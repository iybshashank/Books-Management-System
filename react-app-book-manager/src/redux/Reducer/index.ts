import {combineReducers} from 'redux';
import { booksReducer } from './booksReducer';
import { loginReducer } from './loginReducer';
import { userReducer } from './userReducer';

const reducers= combineReducers({
    allBooks:booksReducer,
    allUser:userReducer,
    loginUser:loginReducer,
});
export default reducers;