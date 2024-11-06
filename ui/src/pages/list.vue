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

      <!-- Form to add a new selection -->
      <hr class="my-5"/>
      <h2>Add Selections</h2>
      <v-row>
        <v-col
          cols="12"
          lg="8"
        >
          <v-row>
            <v-col
              cols="4"
            >
              <v-text-field v-model="newSelection.name" label="Selection Name"/>
            </v-col>
            <v-col
              cols="4"
            >
              <v-autocomplete
                v-model="newSelection.type"
                label="Selection Type"
                :items="['Unit', 'Operative']"
              />
            </v-col>
            <v-col
              cols="2"
            >
              <v-text-field
                v-model="newSelection.quantity"
                label="Quantity"
                type="number"
              />
            </v-col>
            <v-col
              cols="2">
              <v-btn
                icon="mdi-plus"
                variant="tonal"
                :disabled="newSelection.name === '' || newSelection.type === ''"
                @click="addSelection"
              />
            </v-col>
          </v-row>
        </v-col>
      </v-row>

      <!-- Display the list of selections -->
      <v-row v-if="listItem.selections.length > 0">
        <v-col cols="12" lg="8">
          <h3>Selections</h3>
          <div v-for="(selections, type) in groupedSelections" :key="type">
            <h4>{{ type }}s</h4>
            <ListSelection
              v-for="selection in selections"
              :key="selection.id"
              :selection="selection"
            />
          </div>
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
