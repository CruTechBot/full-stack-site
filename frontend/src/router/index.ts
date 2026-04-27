import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import LogIn from '../views/LogIn.vue';
import SignUp from '../views/SignUp.vue';
import ChangeDetails from '../views/ChangeDetails.vue';
import AddComment from '../views/AddComment.vue';
import ViewComments from '../views/ViewComments.vue';
import { auth } from '../services/AuthService';

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/LogIn', name: 'LogIn', component: LogIn },
  { path: '/SignUp', name: 'SignUp', component: SignUp },
  { path: '/ChangeDetails', name: 'ChangeDetails', component: ChangeDetails, meta: { requiresAuth: true } },
  { path: '/AddComment', name: 'AddComment', component: AddComment, meta: { requiresAuth: true } },
  { path: '/ViewComments', name: 'ViewComments', component: ViewComments },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, _from) => {
  if (to.meta.requiresAuth && !auth.isLoggedIn) {
    return '/LogIn';
  }
});

export default router;