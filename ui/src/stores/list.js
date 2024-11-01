import { defineStore } from 'pinia';
import { ref } from 'vue';
import {newGuid} from "@/utilities/guid";

export const useListStore = defineStore('list', () => {

  const lists = ref([]);
  const newList = () => {
    console.log('creating a new list');
    const newListItem = {
      id: newGuid(),
      name: '',
      faction: '',
      selections: []
    };
    lists.value.push(newListItem);
    return newListItem;
  };

  const saveList = (list) => {
    console.log('saving list');
    const listIndex = lists.value.findIndex(l => l.id === list.id);
    lists.value[listIndex] = list;
  };

  return {
    lists,
    newList,
    saveList
  };
});
