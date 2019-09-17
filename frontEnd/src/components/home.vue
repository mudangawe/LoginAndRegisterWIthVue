<template>
  <div>
      <slot>
          {{userData.Name}}
      </slot>
  </div>
</template>

<script>
export default {
    name:"home",

    props:{
        userData:{}
    },
    data(){
        return{
            userData: userData,
        }
    }
}
</script>

<style>

</style>7