<template>
  <footer class="app-footer">
    <p>Current Users: {{ userCount }}</p>
  </footer>
</template>

<script lang="ts" setup>
import { ref, onMounted } from 'vue';
import { getUserCount } from '../services/UserService';

const userCount = ref<number>();

onMounted(async () => {
  userCount.value = await getUserCount();
});
</script>

<style scoped>
.app-footer {
  background-color: #333;
  color: white;
  text-align: right;
  padding: .5rem;
  padding-right: 1rem;
  margin-top: auto;
}
</style>