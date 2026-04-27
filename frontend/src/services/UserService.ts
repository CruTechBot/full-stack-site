import {get, put, post, securePut, secureGet} from './AxiosService'
import type { NewUserDTO, UserLoginDTO } from '../models';
import { auth } from "../services/AuthService"

const base = "/Users";

export function getUserCount() {
    return get(base + '/UserCount')
}

export async function newUser(userData: NewUserDTO){
    const responce = await post(base + '/NewUser', userData);
    auth.logIn(responce);
    return responce;
}

export async function logIn(userData: UserLoginDTO){
    const responce = await put(base + "/Login", userData);
    auth.logIn(responce);
    return responce;
}

export function changeDetails(userData: NewUserDTO){
    return securePut(base + '/ChangeDetails', userData);
}

export function getDetails(){
    return secureGet(base + '/GetDetails');
}

export function logOut(){
    auth.logOut();
}