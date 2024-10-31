import { defineStore } from 'pinia';
import { ref } from 'vue';
import {newGuid} from "@/utilities/guid";

export const useListStore = defineStore('list', () => {

  const lists = ref([]);
  const newList = () => {
    lists.value.push({
      id: newGuid(),
      name: ''
    })
  };

  return {
    lists,
    newList
  };
});
