<template>
  <div class="home">
    <br>
    <img alt="Vue logo" class="treeLogo" src="../assets/binaryTree2.png">
    <h1>Ordenamiento de Árboles Binarios</h1>
    <Tree/>
  </div>
</template>

<script>
// @ is an alias to /src
import Tree from '@/components/Tree.vue'

export default {
  name: 'HomeView',
  components: {
    Tree
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Ms+Madi&display=swap');
  .treeLogo {
    max-width: 450px;
  }
  h1{
    font-family: 'Ms Madi', cursive;
    font-size: 55px;
  }
</style>
