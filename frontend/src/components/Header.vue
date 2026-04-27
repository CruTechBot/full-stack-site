<template>
  <header class="app-header">
    <h1>My Website</h1>
    <nav>
      <router-link to="/" class="nav-link"><img src="/home.svg"/></router-link>
        <span v-if="auth.isLoggedIn">
        <router-link to="/ChangeDetails" class="nav-link">Change Details</router-link>
        <router-link to="/AddComment" class="nav-link">Add Comment</router-link>
      </span>
      <span v-else>
        <router-link to="/LogIn" class="nav-link">Log In</router-link>
        <router-link to="/SignUp" class="nav-link">Sign Up</router-link>
      </span>
      <router-link to="/ViewComments" class="nav-link">View Comments</router-link>   
        <span v-if="auth.isLoggedIn">
        <button @click="logout">Logout</button>
      </span>
    </nav>
  </header>
</template>

<script lang="ts" setup>
import { logOut } from "../services/UserService";
import { auth } from "../services/AuthService"

function logout(){
    logOut();
}

</script>

<style scoped>
.app-header {
  background-color: #333;
  color: white;
  padding: 1rem;
}
nav a {
  color: white;
  margin-right: 1rem;
  text-decoration: none;
}
.nav-link {
  color: white;
  margin-right: 1rem;
  text-decoration: none;
}
h1 {
  text-align: center;
}
a img{
  height: 2rem;
}
</style>