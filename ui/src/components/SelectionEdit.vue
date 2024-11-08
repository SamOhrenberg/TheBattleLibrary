<script setup>
import { newGuid } from "@/utilities/guid";
import { ref } from 'vue';

const props = defineProps({
  selection: {
    type: Object,
    default: () => ({
      id: '',
      name: '',
      type: '',
      quantity: 1,
      selections: []
    })
  }
});


const dialog = ref(false);
const newSelection = ref({ ...props.selection });

const emit = defineEmits(['selection-created']);

watch(() => props.selection, (newVal) => {
  newSelection.value = { ...newVal };
}, { deep: true });

const saveAndCloseDialog = () => {
  if (!newSelection.value.id) {
    newSelection.value.id = newGuid();
  }
  // Emit the new selection object
  emit('selection-created', {...newSelection.value});
  closeDialog();
};

const closeDialog = () => {
  // Reset the form data when a new selection is presented - otherwise keep the data
  if (props.selection.id === '') {
    newSelection.value = {
      id: '',
      name: '',
      type: '',
      quantity: 1,
      selections: []
    };
  }
  dialog.value = false;
};

console.log('newSelection', newSelection)

</script>

<template>

  <v-dialog max-width="500" v-model="dialog">
    <template
      v-slot:activator="{ props: activatorProps }"
      v-if="newSelection.id === ''"
    >
      <v-btn
        v-bind="activatorProps"
        color="surface-variant"
        icon="mdi-plus"
        variant="flat"
      ></v-btn>
    </template>

    <template
      v-slot:activator="{ props: activatorProps }"
      v-if="newSelection.id !== ''"
    >
      <v-btn
        v-bind="activatorProps"
        color="surface-variant"
        icon="mdi-wrench"
        variant="text"
      ></v-btn>
    </template>

    <template v-slot:default="{ isActive }">
      <v-card>
        <v-card-title>
          <span class="text-h5" v-if="newSelection.id !== ''">Edit Selection</span>
          <span class="text-h5" v-if="newSelection.id === ''">New Selection</span>
        </v-card-title>

        <v-card-text>
          <v-form>
            <v-text-field v-model="newSelection.name" label="Selection Name"/>
            <v-autocomplete v-model="newSelection.type" label="Selection Type" :items="['Unit', 'Operative']"/>
            <v-text-field v-model="newSelection.quantity" label="Quantity" type="number"/>
          </v-form>
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn
            text="Save"
            @click="saveAndCloseDialog"
          ></v-btn>

          <v-btn
            text="Close Dialog"
            @click="closeDialog"
          ></v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>
