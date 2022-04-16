<template>

<div>
  <form @submit.prevent="">
    <input type="text" v-model="listaDesordenada">
    <input type="button" value="Enviar" @click="enviarListaDesordenada()">
  </form>
  <vue-tree
    style="
      width: 800px;
      min-height: 1000px;
      border: 1px solid gray;
      margin: 0 auto;
    "
    :dataset="sampleData"
    :config="treeConfig"
  >
    <template v-slot:node="{ node, collapsed }">
      <span
        class="tree-node"
        :style="{ border: collapsed ? '2px solid grey' : '' }"
        >{{ node.value }}</span
      >
    </template>
  </vue-tree>

  </div>
</template>

<script>

import VueTree from "@ssthouse/vue-tree-chart";
import axios from "axios";
import Vue from "vue";

Vue.component("vue-tree", VueTree);

export default {
  data() {
    return {
      listaDesordenada: "5,3,4,2,1,6",
      sampleData: {
        value: "5",
        children: [
          {
            value: "3",
            children: [
              {
                value: "2",
                children: [{ value: "1", children: null }]
              },
              { value: "4"},
            ],
          },
          {
            value: "6"
          },
        ],
      },
      treeConfig: { nodeWidth: 120, nodeHeight: 80, levelHeight: 200 },
    };
  },
  components: {
    VueTree,
  },

  methods: {
    enviarListaDesordenada: function (){

      const headers = {
        "Content-Type": "application/json",
        "accept": "text/plain"
      }

      axios
      .post(' http://localhost:7077/Tree',
      {
        "listaDesordenada":this.listaDesordenada
      },
      {
        headers: headers
      }
      )
      .then(response => {
        let resultadoConsulta =  response.data;

        const convert= JSON.parse(JSON.stringify(resultadoConsulta),
        (key, value) => value === null || value === '' ? undefined : value);

        console.log(convert)
        this.sampleData =resultadoConsulta
      })
    }
  }
};
</script>

<style></style>
