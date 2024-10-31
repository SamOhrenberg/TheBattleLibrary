
<script setup>

import { useListStore } from "@/stores/list";
import { storeToRefs } from 'pinia';

const listStore = useListStore();
const { lists } = storeToRefs(listStore);


</script>

<template>
  <div>
    <ul>
      <li
        v-for="(list, index) in lists"
        :key="index"
      >
        {{ list }}
      </li>
    </ul>
  </div>
</template>

<style scoped>

</style>
