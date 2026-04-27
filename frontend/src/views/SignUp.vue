<template>
  <div class="register-container">
    <h2>Create Your Account</h2>

    <form @submit.prevent="submitForm" class="register-form">
      <div class="form-group">
        <input
          v-model="name"
          placeholder="Full Name"
          required
          class="form-input"
        />
      </div>

      <div class="form-group">
        <input
          v-model="email"
          type="email"
          placeholder="Email Address"
          required
          class="form-input"
        />
      </div>

      <div class="form-group">
        <input
          v-model="password"
          type="password"
          placeholder="Password"
          required
          class="form-input"
        />
      </div>

      <div class="form-group">
        <input
          v-model="passwordVerification"
          type="password"
          placeholder="Confirm Password"
          required
          class="form-input"
        />
      </div>

      <button type="submit" class="submit-btn">Register</button>
    </form>

    <p v-if="error" class="message error">{{ error }}</p>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { newUser } from '../services/UserService';
import type { NewUserDTO } from '../models';
import { useRouter } from 'vue-router'

const router = useRouter()

const name = ref('');
const email = ref('');
const password = ref('');
const passwordVerification = ref('');

const error = ref('');

async function submitForm() {
  if (password.value != passwordVerification.value){
    error.value = 'Passwords do not match'
    return;
  }

  const userData: NewUserDTO = {
    name: name.value,
    email: email.value,
    password: password.value
  };

  try {
    await newUser(userData);
    router.push('/')
  } catch (err: any) {
    error.value = 'Failed to create user: ' + (err.response?.data || err.message);
  }
}
</script>
<style scoped>
.register-container {
  max-width: 400px;
  margin: 60px auto;
  padding: 2.5rem;
  background: #fff;
  border-radius: 14px;
  box-shadow: 0 6px 18px rgba(0, 0, 0, 0.08);
  font-family: "Inter", system-ui, sans-serif;
  transition: all 0.3s ease;
}

.register-container:hover {
  box-shadow: 0 8px 22px rgba(0, 0, 0, 0.1);
}

h2 {
  text-align: center;
  color: #222;
  margin-bottom: 1.8rem;
  font-size: 1.6rem;
}

.register-form {
  display: flex;
  flex-direction: column;
  gap: 1.1rem;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-input {
  padding: 0.8rem 0.9rem;
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
  margin-top: 0.5rem;
  background: linear-gradient(90deg, #007bff, #0056b3);
  color: #fff;
  padding: 0.9rem;
  font-size: 1rem;
  font-weight: 600;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: all 0.3s ease;
}

.submit-btn:hover {
  background: linear-gradient(90deg, #0056b3, #004494);
  transform: translateY(-1px);
}

.message {
  text-align: center;
  margin-top: 1rem;
  font-weight: 500;
}

.error {
  color: #d9534f;
}

/* Optional: Small animation for mount */
.register-container {
  animation: fadeIn 0.4s ease-out;
}

@keyframes fadeIn {
  from {
    opacity: 0;
    transform: translateY(10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}
</style>