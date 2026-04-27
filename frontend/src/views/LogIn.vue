<template>
  <div class="register-container">
    <h2>Log In</h2>

    <form @submit.prevent="submitForm" class="login-form">
      <input
        v-model="email"
        type="email"
        placeholder="Email"
        required
        class="form-input"
      />

      <input
        v-model="password"
        type="password"
        placeholder="Password"
        required
        class="form-input"
      />

      <button type="submit" class="submit-btn">Log In</button>
    </form>

    <p v-if="error" class="message error">{{ error }}</p>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { logIn } from '../services/UserService';
import type { UserLoginDTO } from '../models';
import { useRouter } from 'vue-router'

const email = ref('');
const password = ref('');

const error = ref('');

const router = useRouter()

async function submitForm() {
  const userData: UserLoginDTO = {
    email: email.value,
    password: password.value
  };

  try {
    await logIn(userData);
    router.push('/')
  } catch (err: any) {
    error.value = 'Failed to log in user: ' + (err.response?.data || err.message);
  }
}
</script>
<style scoped>
.register-container {
  max-width: 380px;
  margin: 60px auto;
  padding: 2rem;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 14px rgba(0, 0, 0, 0.08);
  font-family: system-ui, sans-serif;
}

h2 {
  text-align: center;
  color: #333;
  margin-bottom: 1.8rem;
}

.login-form {
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
}

.form-input {
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 6px;
  font-size: 1rem;
  transition: all 0.2s ease;
}

.form-input:focus {
  border-color: #007bff;
  box-shadow: 0 0 0 3px rgba(0, 123, 255, 0.1);
  outline: none;
}

.submit-btn {
  background: #007bff;
  color: #fff;
  padding: 0.8rem;
  font-size: 1rem;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: background 0.3s ease;
}

.submit-btn:hover {
  background: #0056b3;
}

.message {
  text-align: center;
  margin-top: 1rem;
  font-weight: 500;
}

.error {
  color: #d9534f;
}
</style>