
<template>
  <div>
    <h1>List Item</h1>
  </div>
</template>

<script setup>
import { useRoute } from 'vue-router';
import { useListStore } from '@/stores/listStore';
import { storeToRefs } from 'pinia';

const route = useRoute();
const listStore = useListStore();
const { lists } = storeToRefs(listStore);

const listId = route.params.id;
let listItem = lists.value.find(item => item.id === listId);

if (!listItem) {
  listItem = listStore.newList();
}
</script>

<style scoped>

</style>
