<template>
  <v-form v-model="valid">
    <v-container>
      <h1>Battle List</h1>
      <p>Fill out the following form with your faction information and selections.</p>
      <hr class="my-5"/>
      <v-row>
        <v-col
          cols="12"
          lg="8"
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
          lg="8"
        >
          <v-text-field
            v-model="listItem.faction"
            label="What faction is the list for?"
          />
        </v-col>
      </v-row>


      <!-- Display the list of selections -->
      <v-row>
        <v-col cols="12" lg="8">
          <v-row>
            <v-col cols="6" >
              <h2>Selections</h2>
            </v-col>
            <v-col>
              <SelectionEdit @selection-created="handleSelectionCreated" />
            </v-col>
          </v-row>
          <div v-for="(selections, type) in groupedSelections" :key="type">
            <h3>{{ type }}s</h3>
            <ListSelection
              v-for="selection in selections"
              :key="selection.id"
              :selection="selection"
            />
          </div>
        </v-col>
      </v-row>


      <v-row>
        <v-col
          cols="12"
          lg="8"
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
import {newGuid} from "@/utilities/guid";
import ListSelection from "@/components/ListSelection.vue";
import SelectionEdit from "@/components/SelectionEdit.vue";

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

const newSelection = reactive({
  id: '',
  name: '',
  type: '',
  quantity: 1,
  selections: []
});

const handleSelectionCreated = (newSelection) => {

  const existingSelection = listItem.selections.find(selection =>
    selection.name === newSelection.name &&
    selection.type === newSelection.type
  );

  if (existingSelection) {
    existingSelection.quantity = Number(existingSelection.quantity) + Number(newSelection.quantity);
  } else {
    listItem.selections.push(newSelection);
  }

};

const addSelection = () => {
  newSelection.id = newGuid();
  listItem.selections.push({ ...newSelection });
  newSelection.name = '';
  newSelection.type = '';
  newSelection.quantity = 1;
};

const saveButtonClick = () => {
  if (valid.value) {
    listStore.saveList(listItem);
    router.push('/lists');
  }
}

const cancelButtonClick = () => {
  router.push('/lists');
}

// Group selections by type
const groupedSelections = computed(() => {
  return listItem.selections.reduce((groups, selection) => {
    if (!groups[selection.type]) {
      groups[selection.type] = [];
    }
    groups[selection.type].push(selection);
    return groups;
  }, {});
});

</script>

<style scoped>

</style>
