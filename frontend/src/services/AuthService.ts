import { reactive } from 'vue'
import type { userTokenDTO } from '../models';

export const auth = reactive({
  token: localStorage.getItem('token'),
  userId: localStorage.getItem('userId'),
  get isLoggedIn() {
    return !!this.token
  },
  logIn(token: userTokenDTO) {
    this.token = token.token
    this.userId = token.userId.toString()
    localStorage.setItem('token', token.token)
    localStorage.setItem('userId', token.userId.toString())
  },
  logOut() {
    this.token = null
    localStorage.removeItem('token')
    localStorage.removeItem('userId')
  }
})