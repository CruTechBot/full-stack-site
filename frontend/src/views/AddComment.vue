<template>
  <div class="comment-container">
    <h2>Add a Comment</h2>

    <form @submit.prevent="submitForm" class="comment-form">
      <textarea
        v-model="comment"
        placeholder="Write your comment here..."
        required
        class="comment-input"
        rows="4"
      ></textarea>

      <button type="submit" class="submit-btn">Add Comment</button>
    </form>

    <p v-if="error" class="message error">{{ error }}</p>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { addComment } from '../services/CommentService';
import { useRouter } from 'vue-router'

const router = useRouter()

const comment = ref('');

const error = ref('');

async function submitForm() {
 
  try {
    await addComment(comment.value);
    router.push('/')
  } catch (err: any) {
    error.value = 'Failed to create user: ' + (err.response?.data || err.message);
  }
}
</script>
<style scoped>
.comment-container {
  max-width: 500px;
  margin: 60px auto;
  padding: 2.5rem;
  background: #fff;
  border-radius: 14px;
  box-shadow: 0 6px 18px rgba(0, 0, 0, 0.08);
  font-family: "Inter", system-ui, sans-serif;
  transition: all 0.3s ease;
}

.comment-container:hover {
  box-shadow: 0 8px 22px rgba(0, 0, 0, 0.1);
}

h2 {
  text-align: center;
  color: #222;
  margin-bottom: 1.5rem;
  font-size: 1.6rem;
}

.comment-form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.comment-input {
  padding: 0.8rem 0.9rem;
  border: 1px solid #ccc;
  border-radius: 6px;
  font-size: 1rem;
  resize: vertical;
  min-height: 100px;
  transition: all 0.2s ease;
}

.comment-input:focus {
  border-color: #007bff;
  box-shadow: 0 0 0 3px rgba(0, 123, 255, 0.1);
  outline: none;
}

.submit-btn {
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

.comment-container {
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