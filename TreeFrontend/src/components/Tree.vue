<template>
  <div>
    <form @submit.prevent="">
      <input type="text" class="ingresoListaDesordenada" v-model="listaDesordenada" />
      <input type="button" class="submitListaDesordenada" value="Enviar" @click="enviarListaDesordenada()" />
    </form>

    Array ordenado: {{arrayOrdenado}}
    <vue-tree class="vue-tree1" :dataset="sampleData" :config="treeConfig">
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
      sampleData: {},
      treeConfig: { nodeWidth: 120, nodeHeight: 80, levelHeight: 200 },
      arrayOrdenado: "Nada"
    };
  },
  components: {
    VueTree,
  },

  methods: {
    enviarListaDesordenada: function () {
      const headers = {
        "Content-Type": "application/json",
        accept: "text/plain",
      };

      axios
        .post(
          " http://localhost:7077/Tree",
          {
            listaDesordenada: this.listaDesordenada,
          },
          {
            headers: headers,
          }
        )
        .then((response) => {
          let resultadoConsulta = response.data;
          this.arrayOrdenado = resultadoConsulta.arrayOrdenado;
          delete resultadoConsulta["arrayOrdenado"]
          // const convert= JSON.parse(JSON.stringify(resultadoConsulta),
          // (key, value) => value === null || value === '' ? delete : value);

          let jsonToString = JSON.stringify(resultadoConsulta);
          // let regex = /,null/g;
          // jsonToString = jsonToString.replace(regex, "");
          // regex = /null,/g;
          // jsonToString = jsonToString.replace(regex, "");
          // regex = /null/g;
          // jsonToString = jsonToString.replace(regex, "");

          let StringToJson = JSON.parse(jsonToString);

          console.log(StringToJson);
          this.sampleData = StringToJson;
        });
    },
  },
};
</script>

<style>
.vue-tree1 {
  width: 100%;
  min-height: 1000px;
  border: 1px solid gray;
  border-radius: 20px;
  top: 30px;
  margin: 0 auto;
}

.container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.tree-node {
  display: inline-block;
  width: 40px;
  height: 40px;
  border-radius: 50%;
  background-color: #E63888;
  color: white;
  text-align: center;
  line-height: 40px;
}

.ingresoListaDesordenada{
  width: 400px;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

.submitListaDesordenada{

  width: 100px;
  font-size: 15px;
  background-color: #E63888;
  color: white;
  padding: 12px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
</style>
