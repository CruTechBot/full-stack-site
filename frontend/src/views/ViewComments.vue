<template>
    <div v-for="comment in data" class="comment-card">
        <div class="comment-header">
        <div class="comment-meta">
            <strong>{{ comment.name }}</strong>
            <span class="comment-date">{{ new Date(comment.created).toLocaleString() }}</span>
        </div>
        <button v-if="auth.userId == comment.userId.toString()" class="delete-btn" @click="deleteSelected(comment.id)">✖</button>
        </div>
        <p class="comment-text">{{ comment.comment }}</p>
    </div>
</template>

<script lang="ts" setup>
import { ref, onMounted } from 'vue';
import { getAllComments, deleteComment } from '../services/CommentService';
import type { CommentDTO } from '../models';
import { auth } from "../services/AuthService"

const data = ref([] as CommentDTO[])

onMounted( async () => {
    data.value = await getAllComments();
})

async function deleteSelected(id: number)
{
  try{
    await deleteComment(id);
    data.value = data.value.filter(c => c.id != id);
  } catch (error) {
    console.error('Error deleting comment:', error);
  }
}
</script>

<style scoped>
.comment-card {
  background: #f9f9f9;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 0.75rem 1rem;
  margin-bottom: 1rem;
  transition: box-shadow 0.2s ease-in-out;
}

.comment-card:hover {
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.15);
}

.comment-header {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  margin-bottom: 0.25rem;
}

.comment-meta {
  display: flex;
  flex-direction: column;
}

.comment-date {
  font-size: 0.8rem;
  color: #888;
}

.comment-text {
  margin: 0;
  font-size: 1rem;
  color: #333;
  line-height: 1.4;
}

.delete-btn {
  background: transparent;
  border: none;
  color: #c00;
  font-size: 1.1rem;
  cursor: pointer;
  margin-left: 1rem;
  line-height: 1;
  padding: 0;
  transition: color 0.2s;
}

.delete-btn:hover {
  color: #900;
}
</style>