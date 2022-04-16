<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
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
