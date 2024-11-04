<template>
  <v-form v-model="valid">
    <v-container>
      <v-row>
        <v-col
          cols="12"
          md="4"
        >
          <v-text-field
            v-model="listItem.name"
            label="Name your list"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col
          cols="12"
          md="4"
        >
          <v-text-field
            v-model="listItem.faction"
            label="What faction is the list for?"
          />
        </v-col>
      </v-row>


      <v-row>
        <v-col
          cols="12"
          md="4"
        >
          <v-btn
            :disabled="!valid"
            @click="saveButtonClick"
          >
            Save
          </v-btn>
          <v-btn
            class="ml-1"
            @click="cancelButtonClick"
          >
            Cancel
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>

<script setup>
import { useRoute, useRouter } from 'vue-router';
import { useListStore } from '@/stores/list';
import { reactive, computed } from 'vue';
import { storeToRefs } from 'pinia';

const router = useRouter();
const route = useRoute();
const listStore = useListStore();
const {lists} = storeToRefs(listStore);

const listId = route.query.id;
console.log(route);
console.log('listId', listId);
let listItem = reactive(lists.value.find(item => item.id === listId) || listStore.newList());
console.log(listItem);

const valid = computed(() => {
  return listItem.name !== ''
    && listItem.faction !== '';
});

const saveButtonClick = () => {
  if (valid.value) {
    listStore.saveList(listItem);
    router.push('/lists');
  }
}

const cancelButtonClick = () => {
  router.push('/lists');
}

</script>

<style scoped>

</style>
