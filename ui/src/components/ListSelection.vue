<script setup>
import {computed, defineProps} from 'vue';
import {newGuid} from "@/utilities/guid";

const newSubSelection = reactive({
  id: '',
  name: '',
  type: '',
  quantity: 1
});

const props = defineProps({
  selection: {
    type: {
      id: String,
      name: String,
      type: String,
      quantity: Number,
      selections: Array
    },
    required: true
  }
});


const groupedSelections = computed(() => {
  return selection.selections.reduce((groups, selection) => {
    if (!groups[selection.type]) {
      groups[selection.type] = [];
    }
    groups[selection.type].push(selection);
    return groups;
  }, {});
});

const createNewSubSelection= () => {
  newSubSelection.id = newGuid();
}
</script>

<template>
  <div>
    <p>{{ selection.quantity }}x {{ selection.name }}</p>
    <v-row v-if="selection.selections.length > 0">
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
    <v-row>
      <v-col
        cols="12"
        v-if="newSubSelection.id === ''"
      >
        <v-btn
          icon="mdi-plus"
          variant="tonal"
          size="small"
          @click="createNewSubSelection"
        />
      </v-col>
      <v-col
        cols="11"
        v-if="newSubSelection.id !== ''"
      >
        Hello World
      </v-col>
    </v-row>

  </div>
</template>

<style scoped>

</style>
