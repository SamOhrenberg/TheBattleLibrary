import {defineStore} from 'pinia';
import {ref} from 'vue';
import {newGuid} from "@/utilities/guid";

export const useListStore = defineStore('list', () => {

  const lists = ref([]);
  const newList = () => {
    console.log('creating a new list');
    return {
      id: undefined,
      name: '',
      faction: '',
      selections: []
    };
  };

  const getList = (id) => {
    const listIndex = lists.value.findIndex(l => l.id === id);
    if (listIndex > -1) {
      return lists.value[listIndex]
    }
    else {
      return null;
    }
  };

  const saveList = (list) => {
    console.log('saving list');
    const listIndex = lists.value.findIndex(l => l.id === list.id);

    if (listIndex > -1) {
      lists.value[listIndex] = list;
    }
    else {
      list.id = newGuid();
      lists.value.push(list);
    }
  };

  const deleteList = (id) => {
    console.log('deleting list ', id);
    const listIndex = lists.value.findIndex(l => l.id === id);
    if (listIndex > -1) {
      lists.value.splice(listIndex,1);
    }
  }

  return {
    lists,
    newList,
    saveList,
    deleteList,
    getList
  };
});
