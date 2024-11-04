<template>
  <div
    class="d-flex flex-column"
  >
    <div
      class="mb-2"
    >
      <v-btn
        @click="newListClick"
      >
        New List
      </v-btn>
    </div>
    <div
      class="flex-fill"
    >
      <h1>Your Lists</h1>
      <p
        v-if="hasLists"
      >
        Below you will find your saved lists.
      </p>
      <p
        v-else
      >
        Looks like you don't have any lists yet. Go ahead and create one!
      </p>
      <v-list
        v-if="hasLists"
      >
        <v-list-item
          v-for="item in lists"
          :key="item.id"
        >
          <v-list-item-title>
            <v-btn
              variant="text"
              @click="navigateToList(item.id)"
            >
              {{ item.name }}
            </v-btn>
            <v-btn
              icon="mdi-delete"
              variant="text"
              @click="beginDeleteList(item.id)"
            />
          </v-list-item-title>
        </v-list-item>
      </v-list>
    </div>
  </div>
</template>

<script setup>

import {useRouter} from "vue-router";
import {useListStore} from "@/stores/list";
import {storeToRefs} from 'pinia';
import {computed} from "vue";

const router = useRouter();
const listStore = useListStore();
const {lists} = storeToRefs(listStore);

const hasLists = computed(() => {
  console.log(lists);
  return lists.value && lists.value.length > 0;
});

const newListClick = () => {
  router.push('/list');
}

const navigateToList = (id) => {
  router.push(`/list?id=${id}`);
}

const beginDeleteList = (id) => {
  const listToDelete = listStore.getList(id);
  const message = `Are you sure you want to delete ${ listToDelete.name }? This action is permanent.`;
  if(confirm(message)) {
    listStore.deleteList(id);
  }
}

</script>

<style scoped>

</style>
