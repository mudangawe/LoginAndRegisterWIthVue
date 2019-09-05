<template>
  <div>
      <h1> {{headingtitle}}</h1>
  </div>    
</template>

<script>
import { watch } from 'fs';
export default {
  props:{
     title: String
  },
name:"heading",
  
data(){ return{headingtitle: this.title}},

watch:{
title(){
    this.headingtitle = this.title
}
}
}
</script>

<style>
   h1{
     text-align: center;
     text-decoration: aliceblue;
   }
</style>