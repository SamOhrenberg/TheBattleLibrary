<template>
  <div>
    <v-btn
      @click="newListClick"
    >
      New List
    </v-btn>
    <v-list>
      <v-list-item
        v-for="item in lists"
        :key="item.id"
        @click="navigateToList(item.id)"
      >
        <v-list-item-title>{{ item.name }}</v-list-item-title>
      </v-list-item>
    </v-list>
  </div>
</template>

<script setup>

import { useRouter } from "vue-router";
import { useListStore } from "@/stores/list";
import { storeToRefs } from 'pinia';

const router = useRouter();
const listStore = useListStore();
const { lists } = storeToRefs(listStore);

const newListClick = () => {
  router.push('/list');
}

const navigateToList = (id) => {
  router.push(`/list?id=${id}`);
}

</script>

<style scoped>

</style>
