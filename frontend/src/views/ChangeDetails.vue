<template>
  <div class="change-details-container">
    <h2>Change Your Details</h2>

    <form @submit.prevent="submitForm" class="change-details-form">
      <div class="form-group">
        <label>Name</label>
        <input v-model="name" :placeholder="currentDetails.name" />
      </div>

      <div class="form-group">
        <label>Email</label>
        <input v-model="email" type="email" :placeholder="currentDetails.email" />
      </div>

      <div class="form-group">
        <label>Password</label>
        <input v-model="password" type="password" placeholder="New Password" />
      </div>

      <button type="submit" class="submit-btn">Change</button>
    </form>

    <p v-if="error" class="message error">{{ error }}</p>
    <p v-if="success" class="message success">{{ success }}</p>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted } from 'vue';
import { changeDetails, getDetails } from '../services/UserService';
import type { NewUserDTO } from '../models';

const name = ref('');
const email = ref('');
const password = ref('');

const error = ref('');
const success = ref('');

const currentDetails = ref<NewUserDTO>({
  name: '',
  email: '',
  password: ''
});

onMounted( async () => {
    currentDetails.value = await getDetails();
})  

async function submitForm() {
  const userData: NewUserDTO = {
    name: name.value,
    email: email.value,
    password: password.value
  };

  try {
    await changeDetails(userData);
    success.value = 'User details changed in!';
    error.value = '';
  } catch (err: any) {
    error.value = 'Failed to edit user details: ' + (err.response?.data || err.message);
    success.value = '';
  }
}
</script>
<style scoped>
.change-details-container {
  max-width: 400px;
  margin: 50px auto;
  padding: 2rem;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.1);
  font-family: system-ui, sans-serif;
}

h2 {
  text-align: center;
  color: #333;
  margin-bottom: 1.5rem;
}

.change-details-form {
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
}

.form-group {
  display: flex;
  flex-direction: column;
}

label {
  font-weight: 600;
  color: #555;
  margin-bottom: 0.3rem;
}

.current {
  font-size: 0.9rem;
  color: #888;
  margin-bottom: 0.3rem;
}

input {
  padding: 0.6rem;
  border: 1px solid #ccc;
  border-radius: 6px;
  font-size: 1rem;
  transition: border-color 0.2s ease;
}

input:focus {
  outline: none;
  border-color: #007bff;
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

.success {
  color: #28a745;
}
</style>